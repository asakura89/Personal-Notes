---
tags:
- Powershell
- File
- Dummy
date: 2020-05-04
---

# Create Empty File

Biasanya script ini dipake buat bikin dummy file

```powershell
Clear-Host

$files = "index.js","index.html","style.css"
New-Item -ItemType File $files
$(Get-ChildItem $files).ForEach({ $_.LastWriteTime = Get-Date })

# ^ will output 0 kb file
```

Contoh hasil run

```powershell


    Directory: D:\temp


Mode                 LastWriteTime         Length Name                                                              
----                 -------------         ------ ----                                                              
-a----        28/05/2023  12:07 PM              0 index.js                                                          
-a----        28/05/2023  12:07 PM              0 index.html                                                        
-a----        28/05/2023  12:07 PM              0 style.css                                                         



```

Tapi kalo file dengan nama yang sama udah ada, script-nya bakal nge-output-in error

Terus kan script ini masih nge-output-in list file yang di-create, kalo mau di-silent bisa diginiin

```powershell
Clear-Host

$files = "index.js","index.html","style.css"
New-Item -ItemType File $files | Out-Null  # <-- line yang di-modify
$(Get-ChildItem $files).ForEach({ $_.LastWriteTime = Get-Date })
```

Atau diginiin.

```powershell
$null = New-Item -ItemType File $files
```

Atau juga bisa digiin

```powershell
[void](New-Item -ItemType File $files)
```

Kalo gak terlalu saklek harus 0 kb, bisa pake oneliner gini sebetulnya

```powershell
Clear-Host; Write-Output $null > anotherfile.txt; # <-- will output 1 kb file
```