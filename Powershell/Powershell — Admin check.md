---
tags:
- Powershell
date: 2023-12-03
---

# Admin check

```powershell
Clear-Host

$user = [System.Security.Principal.WindowsIdentity]::GetCurrent()
$principal = New-Object System.Security.Principal.WindowsPrincipal($user)
$adminRole = [System.Security.Principal.WindowsBuiltInRole]::Administrator
$role = "Not Admin"
If ($principal.IsInRole($adminRole)) {
    $role = "Admin"
}

Write-Host "'$($user.Name)' is $($role)"
```

Output-nya kalo admin

```powershell
'ASMNetworkLab\ask89' is Admin
```

Output-nya kalo bukan admin

```powershell
'ASMNetworkLab\ASMNetworkLabUsr' is Not Admin
```
