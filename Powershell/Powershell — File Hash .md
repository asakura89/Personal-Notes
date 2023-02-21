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
$(Get-FileHash -Path $path -Algorithm "MD5").Hash
```



Contoh hasil run
```powershell
429F8B8935CF7A633BE8D282843516BA
```