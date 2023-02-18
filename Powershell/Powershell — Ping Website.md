---
tags:
- Powershell
- Ping
- Website
date: 2020-10-25
---

# Throw and handle errors

```powershell
Clear-Host

function Log($message) {
    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    Write-Host $logmsg
}

function Ping([System.String]$url) {
    Log "Clearing `$Error variable."
    $Error.Clear()

    Log "Ping-ing $($url)."
    $req = [System.Net.WebRequest]::Create($url)
    $res = $req.GetResponse()
    $status = [int]$res.StatusCode
    $res.Dispose()

    Log "Done."

    Return $status
}

Log ":: Start Script ::"
$result = Ping "https://google.com"
Log $result
Log ":: Finish Script ::"
```

Contoh hasil run

```powershell
[2023.06.15.20:15:42] :: Start Script ::
[2023.06.15.20:15:42] Clearing $Error variable.
[2023.06.15.20:15:42] Ping-ing https://google.com.
[2023.06.15.20:15:42] Done.
[2023.06.15.20:15:42] 200
[2023.06.15.20:15:42] :: Finish Script ::
```