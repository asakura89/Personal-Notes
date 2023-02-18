---
tags:
- Powershell
date: 2023-12-03
---

# Check Port

```powershell
Clear-Host

[System.Int32[]]$ports = @(
    80,
    443
)

<#:<
$portInfo = Get-NetTCPConnection |
    Select `
        local*, `
        remote*, `
        state, `
        *process, `
        @{Name="ProcessName";Expression={(Get-Process -Id $_.OwningProcess).ProcessName}}, `
        @{Name="UserName";Expression={(Get-Process -Id $_.OwningProcess -IncludeUserName).UserName}} |
    Where { [System.Linq.Enumerable]::Contains(([System.Int32[]]$ports), [System.Int32]$_.LocalPort) -Or [System.Linq.Enumerable]::Contains(([System.Int32[]]$ports), [System.Int32]$_.RemotePort) }
>:#>

$portInfo = Get-NetTCPConnection |
    Select-Object `
        LocalAddress, `
        @{Name="LocalPort";Expression={$_.LocalPort.ToString()}}, `
        RemoteAddress, `
        @{Name="RemotePort";Expression={$_.RemotePort.ToString()}}, `
        State, `
        @{Name="OwningProcess";Expression={$_.OwningProcess.ToString()}}, `
        @{Name="ProcessName";Expression={(Get-Process -Id $_.OwningProcess).ProcessName}}, `
        @{Name="UserName";Expression={(Get-Process -Id $_.OwningProcess -IncludeUserName).UserName}} |
    Where-Object {
        [System.Linq.Enumerable]::Contains(([System.Int32[]]$ports), [System.Int32]$_.LocalPort) -Or `
        [System.Linq.Enumerable]::Contains(([System.Int32[]]$ports), [System.Int32]$_.RemotePort)
    } |
    Sort-Object -Property `
        @{Expression={[System.Int32]$_.LocalPort};Descending=$false}, `
        @{Expression={[System.Int32]$_.RemotePort};Descending=$false}, `
        @{Expression="State";Descending=$false}

If ($portInfo -Eq $null) {
    Write-Host "None"
}

$portInfo | Out-GridView
```

Output-nya bakal nampilin semacam WPF GridView dengan data yang di-pipe.

Kalo `$portInfo` di-pipe ke `Format-Table`, output-nya jadi gini

```powershell
LocalAddress LocalPort RemoteAddress   RemotePort       State OwningProcess ProcessName    UserName                      
------------ --------- -------------   ----------       ----- ------------- -----------    --------                      
::           80        ::              0               Listen 4             System                                       
::           443       ::              0               Listen 4             System                                       
192.168.1.6  14990     36.86.63.182    80         Established 8412          Code           ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  19856     184.25.236.208  443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  22991     20.198.118.190  443        Established 6160          svchost        NT AUTHORITY\SYSTEM           
192.168.1.6  24639     20.198.119.143  443        Established 13720         OneDrive       ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  25271     52.123.160.135  443        Established 27228         ms-teams       ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  28362     20.198.118.190  443        Established 12904         OneDrive       ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  33759     184.25.236.178  443          CloseWait 24000         SearchApp      ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34032     136.143.186.36  443        Established 23628         dcondemand     NT AUTHORITY\SYSTEM           
192.168.1.6  34053     34.107.243.93   443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34065     13.67.9.5       443        Established 8412          Code           ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34126     185.199.108.133 443        Established 8412          Code           ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34160     52.114.44.86    443        Established 16608         msedgewebview2 ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34206     52.111.229.29   443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34208     52.111.239.28   443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34255     34.117.217.74   443        Established 5664          ccSvcHst       NT AUTHORITY\SYSTEM           
192.168.1.6  34262     168.149.132.112 443          CloseWait 5704          ccSvcHst       NT AUTHORITY\SYSTEM           
192.168.1.6  34284     34.117.32.246   443        Established 5664          ccSvcHst       NT AUTHORITY\SYSTEM           
192.168.1.6  34292     52.178.17.233   443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34293     13.107.246.59   443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34296     52.107.252.8    443           TimeWait 0             Idle                                         
192.168.1.6  34322     20.50.80.210    443        Established 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34323     52.168.117.168  443        Established 13720         OneDrive       ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34325     20.189.173.4    443        Established 13072         FileCoAuth     ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34328     20.42.65.88     443        Established 12904         OneDrive       ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34330     20.189.173.3    443        Established 16608         msedgewebview2 ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34336     52.35.150.14    443            SynSent 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
192.168.1.6  34337     52.35.150.14    443            SynSent 7616          firefox        ASMNetworkLab\ASMNetworkLabUsr
```