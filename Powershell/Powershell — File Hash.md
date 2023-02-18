---
tags:
- Powershell
- Hash
- File
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



## Script version

```powershell
Clear-Host

$path = "C:\Users\ASMNetworkLabUsr\Downloads\MicrosoftTeams-image (27).png"

$hashMD5 = Get-FileHash $path -Algorithm MD5
$hash256 = Get-FileHash $path -Algorithm SHA256
$hash512 = Get-FileHash $path -Algorithm SHA512

Write-Host "Hash MD5:" $hashMD5.Hash.ToLowerInvariant()
Write-Host "Hash 256:" $hash256.Hash.ToLowerInvariant()
Write-Host "Hash 512:" $($hash512.Hash.ToLowerInvariant())
```

Contoh hasil run

```powershell
Hash MD5: 4b08d9807c56e415a505a93e8648d431
Hash 256: a32d57b2b2b1aa02dfe55648e3798130632bcb6b0b445937a3452ba164963ce4
Hash 512: 05050302b0e2629a0e9e54107ba5ac9b02179004ada8c4e2b3ff8a3df55fba1526d2100ebf295db88229853bf4aef6750f15414a9f5
213d74e8f80f25563502f
```