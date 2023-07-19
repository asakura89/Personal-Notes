---
tags:
- Powershell
- WorkingDir
- Directory
date: 2023-05-26
---

# Current Working Dir

## Live script

Maksudnya gak di-save dulu ke file sebagai .ps1 script file gitu

```powershell
Clear-Host

@{
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
    ConvertTo-Json

```

Contoh hasil run

```json
{
    "CurrentDirGetLocation": {
        "GetLocation": {
            "Drive": "D",
            "Provider": "Microsoft.PowerShell.Core\\FileSystem",
            "ProviderPath": "D:\\temp",
            "Path": "D:\\temp"
        },
        "GetLocationPath": "D:\\temp",
        "GetLocationToString": "D:\\temp"
    },
    "CurrentDirGetItem": {
        "GetItemDotToString": "D:\\temp",
        "GetItemDotFullName": "D:\\temp"
    }
}
```



## .ps1 script file

```powershell
Clear-Host

Write-Host (Get-Item $PSCommandPath).Directory
```



Contoh hasil run

```powershell
D:\temp
```