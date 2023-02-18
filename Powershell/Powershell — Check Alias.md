---
tags:
- Powershell
date: 2023-12-03
---

# Check Alias

```powershell
Clear-Host

@(
    "gci",
    "ni",
    "echo"
) |
Select-Object @{L="Alias"; E={ $(Get-Alias $_).DisplayName }}
```

Output-nya

```powershell
Alias               
-----               
gci -> Get-ChildItem
ni -> New-Item      
echo -> Write-Output
```