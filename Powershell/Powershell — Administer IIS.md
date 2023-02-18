---
tags:
- Powershell
- Windows
date: 2023-12-03
---

# Administer IIS

## Get IIS Sites name

```powershell
Clear-Host

Get-IISSite |
    Select-Object -ExpandProperty "Name"

Get-IISSite |
    Select-Object Id, Applications, Bindings, Name, State


Import-Module WebAdministration
Get-ChildItem IIS:\Sites


Import-Module WebAdministration
Get-ChildItem IIS:\Sites |
    Select-Object Id, Bindings, Name, State
```

Output-nya

```powershell
Default Web Site
jenkins-ss.dev.localmachine.com
riku.dev.localmachine.com
sc92xm.dev.localmachine.com
sc101xp.dev.localmachine.com

Id           : 1
Applications : {Default Web Site/}
Bindings     : {http *:80:, net.tcp 808:*, net.msmq localhost, msmq.formatname localhost...}
Name         : Default Web Site
State        : Stopped

Id           : 2
Applications : {jenkins-ss.dev.localmachine.com/}
Bindings     : {https *:443:jenkins-ss.dev.localmachine.com sslFlags=None}
Name         : jenkins-ss.dev.localmachine.com
State        : Stopped

Id           : 3
Applications : {riku.dev.localmachine.com/}
Bindings     : {http *:80:riku.dev.localmachine.com}
Name         : riku.dev.localmachine.com
State        : Stopped

Id           : 93
Applications : {sc92xm.dev.localmachine.com/}
Bindings     : {https *:443:sc92xm.dev.localmachine.com sslFlags=None}
Name         : sc92xm.dev.localmachine.com
State        : Started

Id           : 94
Applications : {sc101xp.dev.localmachine.com/}
Bindings     : {https *:443:sc101xp.dev.localmachine.com sslFlags=None}
Name         : sc101xp.dev.localmachine.com
State        : Started

Name         : Default Web Site
ID           : 1
State        : Stopped
PhysicalPath : %SystemDrive%\inetpub\wwwroot
Bindings     : Microsoft.IIs.PowerShell.Framework.ConfigurationElement

Name         : jenkins-ss.dev.localmachine.com
ID           : 2
State        : Stopped
PhysicalPath : D:\Projects\jenkins\wwwroot
Bindings     : Microsoft.IIs.PowerShell.Framework.ConfigurationElement

Name         : riku.dev.localmachine.com
ID           : 3
State        : Stopped
PhysicalPath : D:\Projects\riku-wwwroot
Bindings     : Microsoft.IIs.PowerShell.Framework.ConfigurationElement

Name         : sc101xp.dev.localmachine.com
ID           : 94
State        : Started
PhysicalPath : D:\Projects\sc101xp\wwwroot
Bindings     : Microsoft.IIs.PowerShell.Framework.ConfigurationElement

Name         : sc92xm.dev.localmachine.com
ID           : 93
State        : Started
PhysicalPath : D:\Projects\sc92xm\wwwroot
Bindings     : Microsoft.IIs.PowerShell.Framework.ConfigurationElement

id       : 1
bindings : Microsoft.IIs.PowerShell.Framework.ConfigurationElement
name     : Default Web Site
state    : Stopped

id       : 2
bindings : Microsoft.IIs.PowerShell.Framework.ConfigurationElement
name     : jenkins-ss.dev.localmachine.com
state    : Stopped

id       : 3
bindings : Microsoft.IIs.PowerShell.Framework.ConfigurationElement
name     : riku.dev.localmachine.com
state    : Stopped

id       : 94
bindings : Microsoft.IIs.PowerShell.Framework.ConfigurationElement
name     : sc101xp.dev.localmachine.com
state    : Started

id       : 93
bindings : Microsoft.IIs.PowerShell.Framework.ConfigurationElement
name     : sc92xm.dev.localmachine.com
state    : Started

```



## Get IIS Sites Urls

```powershell
Clear-Host

Import-Module WebAdministration

function ExtractUrl([System.String]$binding) {
    $splittedBinding = $binding -Split ":"
    $url = $splittedBinding[0] + "://" + $splittedBinding[3] + ":" + $splittedBinding[2]

    Return $url
}

function GetIISSiteInfo() {
    $siteInfos =
        Get-ChildItem IIS:\Sites |
            Select-Object @{L="Urls";E={ `
                ($_.Bindings.Collection | `
                    Select-Object @{L="InnerItem";E={ (ExtractUrl "$($_.protocol):$($_.bindingInformation)") }} | `
                    Select-Object -ExpandProperty InnerItem
                ) `
            }},
            @{L="Name";E={ $_.Name.ToString() }},
            @{L="State";E={ $_.State.ToString() }}

    Return $siteInfos
}

GetIISSiteInfo |
    Format-Table
```

Output-nya

```powershell
Urls                                                                              Name                           
----                                                                              ----                           
{http://:80, net.tcp://:*, net.msmq://:, msmq.formatname://:...}                  Default Web Site               
https://jenkins-ss.dev.localmachine.com:443                                       jenkins-ss.dev.localmachine.com
http://riku.dev.localmachine.com:80                                               riku.dev.localmachine.com      
https://sc101xp.dev.localmachine.com:443                                          sc101xp.dev.localmachine.com   
https://sc92xm.dev.localmachine.com:443                                           sc92xm.dev.localmachine.com    

```



## Get IIS AppPool Users

```powershell
Clear-Host

Get-IISAppPool |
    Select-Object @{E={"IIS APPPOOL\\$($_.Name)"};L="Name"} |
    Select-Object -ExpandProperty Name |
    Sort-Object
```

Output-nya

```powershell
IIS APPPOOL\\.NET v2.0
IIS APPPOOL\\.NET v2.0 Classic
IIS APPPOOL\\.NET v4.5
IIS APPPOOL\\.NET v4.5 Classic
IIS APPPOOL\\Classic .NET AppPool
IIS APPPOOL\\DefaultAppPool
IIS APPPOOL\\jenkins-ss.dev.localmachine.com
IIS APPPOOL\\riku.dev.localmachine.com
IIS APPPOOL\\sc101xp.dev.localmachine.com
IIS APPPOOL\\sc92xm.dev.localmachine.com
```



## Start IIS Sites

```powershell
Clear-Host

function Log($message) {
    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    Write-Host $logmsg
}

[System.String[]]$quitCommand = @("q", "e", "c")
Do {
    Write-Host ""
    Write-Host ".:: Start / Stop IIS Website ::."

    $default = "example-"
    If (!($prefix = Read-Host "Prefix (for multiple sites) [$($default)]")) {
        $prefix = $default
    }

    $default = "Start"
    If (!($action = Read-Host "Action (Start/Stop) [$($default)]")) {
        $action = $default
    }

    Get-IISSite |
        Where-Object { $_.Name.ToLowerInvariant().StartsWith($prefix) } |
        ForEach-Object {
            $name = $_.Name
            $status = $_.State.ToString().ToLowerInvariant()
            $logPrfx = "[$($action)] Site: $($name)"

            Log "$($logPrfx)."

            $appPoolName = $_.Applications[0].ApplicationPoolName
            $appPool = $(Get-IISAppPool -Name $appPoolName)
            $appPoolStatus = $appPool.State.ToString().ToLowerInvariant()

            If ($appPoolStatus.Contains($action.ToLowerInvariant())) {
                Log "$($logPrfx), AppPool: $($appPoolName) is already $($appPoolStatus)."
            }
            Else {
                Log "$($logPrfx), AppPool: $($appPoolName)."
                If ($action.ToLowerInvariant() -Eq "start") {
                    $appPool.Start()
                }
                Else {
                    $appPool.Stop()
                }
                Log "$($logPrfx), AppPool: $($appPoolName). Done."
            }

            If ($status.Contains($action.ToLowerInvariant())) {
                Log "$($logPrfx) is already $($status)."
            }
            Else {
                Log "$($logPrfx)."
                If ($action.ToLowerInvariant() -Eq "start") {
                    Start-IISSite -Name $name
                }
                Else {
                    Stop-IISSite -Name $name -Confirm:$False
                }
                Log "$($logPrfx). Done."
            }
        }

        $inp = Read-Host "Enter to continue, exit with Q, E, C"
}
While ([System.Linq.Enumerable]::Contains($quitCommand, $inp.ToLowerInvariant()) -Eq $False)

Write-Host "Quitting."
```