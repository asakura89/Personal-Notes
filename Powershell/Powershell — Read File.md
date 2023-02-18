---
tags:
- Powershell
- File
date: 2023-12-02
---

# Read File

```powershell
Clear-Host

$filepath = (Get-Item -Path ".\Powershell\_media\file-list.txt").FullName

$content = Get-Content $filepath
Write-Host "Get-Content → `$content.GetType().FullName → " $content.GetType().FullName
Write-Host "Get-Content → `$content[0].GetType().FullName → " $content[0].GetType().FullName

$content = Get-Content $filepath -Raw
Write-Host "Get-Content -Raw → `$content.GetType().FullName → " $content.GetType().FullName

$content = [System.IO.File]::ReadAllText($filepath)
Write-Host "[System.IO.File]::ReadAllText() → `$content.GetType().FullName → " $content.GetType().FullName
```

Output-nya

```powershell
Get-Content → $content.GetType().FullName →  System.Object[]
Get-Content → $content[0].GetType().FullName →  System.String
Get-Content -Raw → $content.GetType().FullName →  System.String
[System.IO.File]::ReadAllText() → $content.GetType().FullName →  System.String
```