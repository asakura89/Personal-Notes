---
tags:
- Powershell
- Json
- Read-Json
date: 2020-04-25
---

# Read Json

```powershell
Clear-Host

$json = @{
    CurrentDirGetLocation = @{
        GetLocation = (Get-Location)
        GetLocationToString = (Get-Location).ToString()
        GetLocationPath = (Get-Location).Path
    }
    CurrentDirGetItem = @{
        GetItemDotToString = (Get-Item -Path .).ToString()
        GetItemDotFullName = (Get-Item -Path .).FullName
    }
} |
ConvertTo-Json |
ConvertFrom-Json

Write-Host $json.CurrentDirGetLocation.GetLocation.Path
Write-Host $json.CurrentDirGetLocation.GetLocation.Provider

<#:<
    $json = Get-Content "$(Split-Path -parent $PSCommandPath)\pull-code.json" | ConvertFrom-Json
    $json.cards.header.title
>:#>
```



Contoh hasil run
```powershell
C:\WINDOWS\system32
Microsoft.PowerShell.Core\FileSystem
```