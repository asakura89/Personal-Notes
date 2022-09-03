---
tags:
- Snippet
- Powershell
- Directory
date: 2022-09-04
---

# List Directory

Sebelum masuk ke topik _Directory_ atau _File_, umumnya untuk ngambil list item dari working directory (folder yang lagi dibuka) bisa pake `Get-ChildItem`. Kalo dipanggil tanpa parameter maka bakal nge-list semua item dan menghasilkan output yang sama dengan batch command `dir`.

## First Level

```powershell
Clear-Host

Get-ChildItem -Path . |
    Where-Object {
        $((Get-Item $_) -Is [System.IO.DirectoryInfo])
    } |
    Select-Object -ExpandProperty "Name" |
    Format-List
```



Contoh hasil run
```powershell
.obsidian
All Things .NET
Code Snippet   
Communication  
Excel
Git
Java
Office 365
Programming Concept
Time Management
Work
_templates
```