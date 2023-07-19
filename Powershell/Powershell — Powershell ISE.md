---
tags:
- Powershell
- ISE
date: 2023-06-22
---

# Powershell ISE

Code ini buat ngecek apakah lagi di-run pake Powershell ISE atau enggak.

```powershell
Write-Host $($psISE -Eq $null)
```

Contoh hasil run (tergantung dari mana nge-run-nya). Bisa jadi `True`, bisa jadi `False`.

```powershell
True
```