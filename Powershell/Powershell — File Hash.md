---
tags:
- Powershell
- Hash
- FileHash
date: 2023-02-21
---

# File Hash

Ini guna banget buat check file-file deployment. Apakah file-nya udah sesuai atau malah beda branch yang di-deploy.

```powershell
$path = "C:\Users\ASMNetworkLabUsr\Project\656eb24c36a609fe8fb8e41c6a5f276347793717.js"
$(Get-FileHash -Path $path -Algorithm "SHA256").Hash
```



Contoh hasil run
```powershell
D7CF8959B943433BA58C7609BBD758A5912AAAA4E9010B67EA5E0F343600029E
```