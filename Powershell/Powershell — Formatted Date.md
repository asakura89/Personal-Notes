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

Write-Host $(Get-Date -f yyyy-MM-dd_HHmmss)
```

Output-nya

```powershell
20231203
20231203
2024-05-10_230756
```
