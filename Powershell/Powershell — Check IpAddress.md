---
tags:
- Powershell
- Windows
date: 2023-12-03
---

# Check IpAddress

```powershell
Clear-Host

Get-NetIpAddress |
    Where-Object { `
        $_.InterfaceAlias.ToLowerInvariant().Contains("ethernet") -And `
        $_.AddressFamily.ToString().ToLowerInvariant() -Eq "ipv4" `
    } |
    Select-Object -ExpandProperty IpAddress
```

Output-nya

```powershell
172.19.96.145
169.254.3.232
```
