---
tags:
- Powershell
- Json
date: 2020-04-25
---

# Json

## Read Json

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

Json buat contoh code di atas

```json
{
  "cards": [{
    "header": {
      "title": "Build machine",
      "subtitle": "Processing Build"
    },
    "sections": [{
      "widgets": [{
        "keyValue": {
          "topLabel": "Activity",
          "contentMultiline": "true",
          "content": "Pulling code from source control."
        }
      }]
    }]
  }]
}
```



## Dump Json

```powershell
Clear-Host

$dumppath = "D:\IIS-SiteName.json"
Get-IISSite |
    ConvertTo-Json |
    Out-File -Encoding "UTF8" -FilePath $dumppath
```