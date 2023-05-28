---
tags:
- Powershell
- Log
date: 2021-08-17
---

# Write Log

```powershell
Clear-Host

function Log($message, $starting = $false, $writeToScreen = $true) {
    $scriptfile = (Get-Item $PSCommandPath)
    $logdir = $scriptfile.Directory
    $logname = "$($scriptfile.BaseName)_$([System.DateTime]::Now.ToString("yyyyMMddHHmm")).log"
    $logfile = [System.IO.Path]::Combine($logdir, $logname)

    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    If ($writeToScreen) {
        Write-Host $logmsg
    }

    If ($starting) {
        $logmsg | Out-File -Encoding "UTF8" -FilePath $logfile
    }
    Else {
        $logmsg | Add-Content -Encoding "UTF8" -Path $logfile
    }
}


Log "``:: Start Script ::'" $true

Log "Doing something ..."

Log "Doing another thing ..."

Log ".:: Finish Script ::."
```



Contoh hasil run
```powershell
[2023.05.26.20:45:35] `:: Start Script ::'
[2023.05.26.20:45:35] Doing something ...
[2023.05.26.20:45:35] Doing another thing ...
[2023.05.26.20:45:35] .:: Finish Script ::.
```