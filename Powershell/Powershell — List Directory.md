---
tags:
- Powershell
- Directory
- File
date: 2022-09-04
---

# List Directory

Sebelum masuk ke topik _Directory_ atau _File_, umumnya untuk ngambil list item dari working directory (folder yang lagi dibuka) bisa pake `Get-ChildItem`. Kalo dipanggil tanpa parameter maka bakal nge-list semua item dan menghasilkan output yang sama dengan batch command `dir`.

## First Level

```powershell
Clear-Host

$dirPath = "D:\\Personal-Notes"
Get-ChildItem -Path $dirPath |
    Where-Object {
        $(Get-Item -Path $_.FullName) -Is [System.IO.DirectoryInfo]
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



## List Directory contents excluding some

```powershell
Clear-Host

Get-ChildItem -Path . -Recurse |
    Where-Object { $_.FullName -NotMatch "(^\.|\\\.).+" } |
    Select-Object @{
        Name="FullName";
        Expression={
            If ($_ -Is [System.IO.DirectoryInfo]) { $_.FullName + "\" }
            Else { $_.FullName }
        }
    } |
    Select-Object -ExpandProperty FullName
```

Contoh hasil run

```
D:\Personal-Notes\AI Tools\
D:\Personal-Notes\Coffee\
D:\Personal-Notes\Communication\
D:\Personal-Notes\CSharp\
D:\Personal-Notes\Design\
D:\Personal-Notes\Excel\
D:\Personal-Notes\Git\
D:\Personal-Notes\Go\
D:\Personal-Notes\IIS\
D:\Personal-Notes\Java\
D:\Personal-Notes\Javascript\
D:\Personal-Notes\Life\
D:\Personal-Notes\LINQPad\
D:\Personal-Notes\Markdown\
D:\Personal-Notes\Office 365\
D:\Personal-Notes\Powershell\
D:\Personal-Notes\Productive\
D:\Personal-Notes\Programming Concept\
D:\Personal-Notes\Sitecore\
D:\Personal-Notes\SQL\
D:\Personal-Notes\Tech\
D:\Personal-Notes\Time Management\
D:\Personal-Notes\Work\
D:\Personal-Notes\_templates\
D:\Personal-Notes\LICENSE.md
D:\Personal-Notes\notes.code-workspace
D:\Personal-Notes\README.md
D:\Personal-Notes\AI Tools\AI Index.md
D:\Personal-Notes\AI Tools\AI Tools — Bing Prompt.md
D:\Personal-Notes\AI Tools\AI Tools — chatGPT Prompt.md
D:\Personal-Notes\AI Tools\AI Tools — Use generative-AI for studying.md
D:\Personal-Notes\Coffee\_media\
D:\Personal-Notes\Coffee\Coffee — Simple Recipe.md
D:\Personal-Notes\Coffee\_media\51641b4b-4d11-4453-a4ad-2ccc1ff316ec_jpg_webp.png
D:\Personal-Notes\Coffee\_media\66d8f1a0-dc97-4675-ab74-d95d8e3a896d_jpg_webp.png
D:\Personal-Notes\Coffee\_media\93933c5d-ed2f-4bb2-bbb4-380a1dd89300_jpg_webp.png
D:\Personal-Notes\Coffee\_media\aa063ee9-39e3-4a11-be15-55e27a0534f9_jpg_webp.png
D:\Personal-Notes\Communication\English\
D:\Personal-Notes\Communication\Writing\
D:\Personal-Notes\Communication\_media\
D:\Personal-Notes\Communication\Communication Index.md
D:\Personal-Notes\Communication\Communication — Active Listening 1.md
D:\Personal-Notes\Communication\Communication — Active Listening.md
. . . omitted . . .
D:\Personal-Notes\Work\Team Lead\Team Lead — Terminating Member.md
D:\Personal-Notes\Work\Team Lead\_media\20231126_003131_image.png
D:\Personal-Notes\Work\_media\Why Your Less-Experienced Colleagues Are Promoted Instead of You! - English.srt.md
D:\Personal-Notes\_templates\Default.md
```



## List Directory contents

```powershell
Clear-Host

Get-ChildItem -Path . -Recurse |
    Where-Object { $_.FullName -NotMatch "(^\.|\\\.).+" } |
    Select-Object @{
        L="Type";
        E={
            If ($_ -Is [System.IO.DirectoryInfo]) { "D" }
            ElseIf ($_ -Is [System.IO.FileInfo]) { "F" }
        }
    }, @{
        L="Name";
        E={ $_.Name }
    }, @{
        L="Path";
        E={ [System.IO.Path]::GetDirectoryName($_.FullName) }
    } |
    Select-Object @{
        L="Desc";
        E={ "{0}: {1,-50} : {2}" -F $_.Type,$_.Name,$_.Path }
    } |
    Select-Object -ExpandProperty Desc
```

Contoh hasil run

```powershell
D: AI Tools                                           : D:\Personal-Notes
D: Coffee                                             : D:\Personal-Notes
D: Communication                                      : D:\Personal-Notes
. . . omitted . . .
F: Team Lead — Team Member.md                         : D:\Personal-Notes\Work\Team Lead
F: Team Lead — Terminating Member.md                  : D:\Personal-Notes\Work\Team Lead
F: 20231126_003131_image.png                          : D:\Personal-Notes\Work\Team Lead\_media
F: Default.md                                         : D:\Personal-Notes\_templates
```



## List Directory contents file-only

```powershell
Clear-Host

Get-ChildItem -Path . -Recurse |
    Where-Object { $_.FullName -NotMatch "(^\.|\\\.).+" } |
    Select-Object @{
        L="Type";
        E={
            If ($_ -Is [System.IO.DirectoryInfo]) { "D" }
            ElseIf ($_ -Is [System.IO.FileInfo]) { "F" }
        }
    },
    @{ L="Name"; E={ $_.Name } },
    @{ L="Path"; E={ [System.IO.Path]::GetDirectoryName($_.FullName) } } |
    Where-Object { $_.Type -Eq "F" } |
    Select-Object -ExpandProperty Name
```

Contoh run-nya kaya gini

```powershell
LICENSE.md
notes.code-workspace
README.md
. . . omitted . . .
Team Lead — Team Member.md
Team Lead — Terminating Member.md
20231126_003131_image.png
Default.md
```



## `Get-Item` gotchas

```powershell
Clear-Host

$dirPath = "D:\\Personal-Notes"
Get-ChildItem -Path $dirPath |
    Select-Object @{ L="Name"; E={ $_.Name } },
        @{ L="GetType"; E={ $_.GetType() } },
        @{ L="GetItem"; E={ $(Get-Item $_) } },
        @{ L="Is DirectoryInfo"; E={ $(Get-Item $_) -Is [System.IO.DirectoryInfo] } },
        @{ L="GetItem Name"; E={ $(Get-Item $_).Name } } |
    Format-Table
```

Output

```powershell
Name                 GetType                 GetItem Is DirectoryInfo GetItem Name
----                 -------                 ------- ---------------- ------------
.obsidian            System.IO.DirectoryInfo                    False             
AI Tools             System.IO.DirectoryInfo                    False             
Coffee               System.IO.DirectoryInfo                    False             
Communication        System.IO.DirectoryInfo                    False             
CSharp               System.IO.DirectoryInfo                    False             
Design               System.IO.DirectoryInfo                    False             
Economic             System.IO.DirectoryInfo                    False             
Excel                System.IO.DirectoryInfo                    False             
Git                  System.IO.DirectoryInfo                    False             
Go                   System.IO.DirectoryInfo                    False             
IIS                  System.IO.DirectoryInfo                    False             
Java                 System.IO.DirectoryInfo                    False             
Javascript           System.IO.DirectoryInfo                    False             
Life                 System.IO.DirectoryInfo                    False             
LINQPad              System.IO.DirectoryInfo                    False             
Office 365           System.IO.DirectoryInfo                    False             
Politic              System.IO.DirectoryInfo                    False             
Powershell           System.IO.DirectoryInfo                    False             
Programming Concept  System.IO.DirectoryInfo                    False             
Sitecore             System.IO.DirectoryInfo                    False             
SQL                  System.IO.DirectoryInfo                    False             
Statistics           System.IO.DirectoryInfo                    False             
Tech                 System.IO.DirectoryInfo                    False             
Work                 System.IO.DirectoryInfo                    False             
_templates           System.IO.DirectoryInfo                    False             
.editorconfig        System.IO.FileInfo                         False             
.gitattributes       System.IO.FileInfo                         False             
.gitignore           System.IO.FileInfo                         False             
LICENSE.md           System.IO.FileInfo                         False             
notes.code-workspace System.IO.FileInfo                         False             
README.md            System.IO.FileInfo                         False             
```

Liat kolom GetItem sama GetItem Name, kosong. Kayanya emang gak ada result-nya. Ini bisa dibuktiin pake JSON.

```powershell
Clear-Host

$dirPath = "D:\\Personal-Notes"
Get-ChildItem -Path $dirPath |
    Select-Object @{ L="Name"; E={ $_.Name } },
        @{ L="GetType"; E={ $_.GetType() } },
        @{ L="GetItem"; E={ $(Get-Item $_) } },
        @{ L="Is DirectoryInfo"; E={ $(Get-Item $_) -Is [System.IO.DirectoryInfo] } },
        @{ L="GetItem Name"; E={ $(Get-Item $_).Name } } |
    ConvertTo-Json
```

Output

```json
[
    {
        "Name":  ".obsidian",
        "GetType":  {
                        "BaseType":  "System.IO.FileSystemInfo",
                        "UnderlyingSystemType":  "System.IO.DirectoryInfo",
                        "FullName":  "System.IO.DirectoryInfo",
                        . . . omitted . . .
                    },
        "GetItem":  {

                    },
        "Is DirectoryInfo":  false,
        "GetItem Name":  null
    },
    {
        "Name":  "AI Tools",
        "GetType":  {
                        "BaseType":  "System.IO.FileSystemInfo",
                        "UnderlyingSystemType":  "System.IO.DirectoryInfo",
                        "FullName":  "System.IO.DirectoryInfo",
                        . . . omitted . . .
                    },
        "GetItem":  {

                    },
        "Is DirectoryInfo":  false,
        "GetItem Name":  null
    },
    {
        "Name":  "LICENSE.md",
        "GetType":  {
                        "BaseType":  "System.IO.FileSystemInfo",
                        "UnderlyingSystemType":  "System.IO.FileInfo",
                        "FullName":  "System.IO.FileInfo",
                        . . . omitted . . .
                    },
        "GetItem":  {

                    },
        "Is DirectoryInfo":  false,
        "GetItem Name":  null
    },
    {
        "Name":  "notes.code-workspace",
        "GetType":  {
                        "BaseType":  "System.IO.FileSystemInfo",
                        "UnderlyingSystemType":  "System.IO.FileInfo",
                        "FullName":  "System.IO.FileInfo",
                        . . . omitted . . .
                    },
        "GetItem":  {

                    },
        "Is DirectoryInfo":  false,
        "GetItem Name":  null
    },
    {
        "Name":  "README.md",
        "GetType":  {
                        "BaseType":  "System.IO.FileSystemInfo",
                        "UnderlyingSystemType":  "System.IO.FileInfo",
                        "FullName":  "System.IO.FileInfo",
                        . . . omitted . . .
                    },
        "GetItem":  {

                    },
        "Is DirectoryInfo":  false,
        "GetItem Name":  null
    },
    . . . omitted . . .
]
```

Itu kenapa code ini error

```powershell
Clear-Host

$dirPath = "D:\\Personal-Notes"
Get-ChildItem -Path $dirPath |
    Where-Object {
         $(Get-Item $_) -Is [System.IO.DirectoryInfo]
    } |
    Select-Object -ExpandProperty "Name" |
    Format-List
```

Output

```powershell
Get-Item : Cannot find path 'C:\Users\ASMNetworkLabUsr\.gitattributes' because it does not exist.
At line:6 char:12
+          $(Get-Item $_) -Is [System.IO.DirectoryInfo]
+            ~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (C:\Users\ASMNetworkLabUsr\.gitattributes:String) [Get-Item], ItemNotFoundException
    + FullyQualifiedErrorId : PathNotFound,Microsoft.PowerShell.Commands.GetItemCommand
 
Get-Item : Cannot find path 'C:\Users\ASMNetworkLabUsr\.gitignore' because it does not exist.
At line:6 char:12
+          $(Get-Item $_) -Is [System.IO.DirectoryInfo]
+            ~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (C:\Users\ASMNetworkLabUsr\.gitignore:String) [Get-Item], ItemNotFoundException
    + FullyQualifiedErrorId : PathNotFound,Microsoft.PowerShell.Commands.GetItemCommand
 
Get-Item : Cannot find path 'C:\Users\ASMNetworkLabUsr\LICENSE.md' because it does not exist.
At line:6 char:12
+          $(Get-Item $_) -Is [System.IO.DirectoryInfo]
+            ~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (C:\Users\ASMNetworkLabUsr\LICENSE.md:String) [Get-Item], ItemNotFoundException
    + FullyQualifiedErrorId : PathNotFound,Microsoft.PowerShell.Commands.GetItemCommand
 
Get-Item : Cannot find path 'C:\Users\ASMNetworkLabUsr\notes.code-workspace' because it does not exist.
At line:6 char:12
+          $(Get-Item $_) -Is [System.IO.DirectoryInfo]
+            ~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (C:\Users\dita.s....code-workspace:String) [Get-Item], ItemNotFoundException
    + FullyQualifiedErrorId : PathNotFound,Microsoft.PowerShell.Commands.GetItemCommand
 
Get-Item : Cannot find path 'C:\Users\ASMNetworkLabUsr\README.md' because it does not exist.
At line:6 char:12
+          $(Get-Item $_) -Is [System.IO.DirectoryInfo]
+            ~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (C:\Users\ASMNetworkLabUsr\README.md:String) [Get-Item], ItemNotFoundException
    + FullyQualifiedErrorId : PathNotFound,Microsoft.PowerShell.Commands.GetItemCommand
. . . omitted . . .
```