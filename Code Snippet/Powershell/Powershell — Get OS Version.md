---
tags:
- Snippet
- Powershell
- OS Version
date: 2020-05-25
---

# Get OS Version

## OS Version

OS version bisa make command ini
```powershell
Clear-Host
Write-Host $([System.Environment]::OSVersion.Version)
```

atau sesimpel `[System.Environment]::OSVersion.Version.ToString()`



Contoh hasil run
```powershell
10.0.19044.0
```



## OS Full Version

```powershell
Clear-Host
[System.Environment]::OSVersion
```



Contoh hasil run
```powershell
Platform ServicePack Version      VersionString                    
-------- ----------- -------      -------------                    
 Win32NT             10.0.19044.0 Microsoft Windows NT 10.0.19044.0
```



## OS Major Version only

```powershell
Clear-Host
[System.Environment]::OSVersion.Version.Major
```



Contoh hasil run
```powershell
10
```


