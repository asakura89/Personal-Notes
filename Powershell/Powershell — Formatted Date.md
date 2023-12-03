---
tags:
- Powershell
date: 2023-12-03
---

# Formatted Date

```powershell
Clear-Host

Write-Host $(Get-Date -f yyyyMMdd)
Write-Host $(Get-Date -Format yyyyMMdd)
```

Output-nya

```powershell
20231203
20231203
```