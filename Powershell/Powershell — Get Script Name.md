---
tags:
- Powershell
date: 2021-08-17
---

# Get Script Name

## Script Info

```powershell
Clear-Host

function GetScriptInfo() {
    $workingpath = $null
    If ($PSCommandPath -Eq [System.String]::Empty) {
        # Note: $PSCommandPath will be empty string if it is not ran from script file
        $workingpath = (Get-Item -Path .)
    }
    Else {
        $workingpath = (Get-Item $PSCommandPath)
    }

    If ($workingpath -Eq $null) {
        Return @{
            Name = $null
            FullName = $null
            Directory = $null
        }
    }

    If ($workingpath -Is [System.IO.DirectoryInfo]) {
        Return @{
            Name = $workingpath.BaseName
            FullName = $workingpath.Name
            Directory = $workingpath
        }
    }

    Return @{
        Name = $workingpath.BaseName
        FullName = $workingpath.Name
        Directory = $workingpath.Directory
    }
}

GetScriptInfo
```

Contoh hasil run kalo script di-save ke file

```powershell
Name            Value                            
----            -----                            
FullName        Test.ps1                         
Name            Test                             
Directory       D:\project\release\PSScratchpad  
```

Contoh hasil run kalo script gak di-save ke file

```powershell
Name            Value                            
----            -----                            
FullName        Untitled                         
Name            Untitled                         
Directory       C:\WINDOWS\system32              
```



## `$PSCommandPath`

Ini script test buat ngeliat isi variable `$PSCommandPath`

```powershell
Clear-Host

@{
    PSCommandPath = $PSCommandPath
    SplitPathResolve = $(Split-Path -Resolve $PSCommandPath)
    SplitPathParent = $(Split-Path -Parent $PSCommandPath)
    SplitPathParentResolve = $(Split-Path -Parent -Resolve $PSCommandPath)
    SplitPathLeaf = $(Split-Path -Leaf $PSCommandPath)
    SplitPathLeafResolve = $(Split-Path -Leaf -Resolve $PSCommandPath)
    DotNetFileBaseName = (Get-Item $PSCommandPath).BaseName
} | 
    Format-List
```

Contoh hasil run. Dan ini cuma bisa di-run tanpa error kalo script di-save ke file. Karena `$PSCommandPath` bakal null kalo script-nya gak di-save

```powershell
Name  : PSCommandPath
Value : D:\project\release\PSScratchpad\Untitled5.ps1

Name  : SplitPathLeaf
Value : Untitled5.ps1

Name  : DotNetFileBaseName
Value : Untitled5

Name  : SplitPathLeafResolve
Value : Untitled5.ps1

Name  : SplitPathResolve
Value : D:\project\release\PSScratchpad

Name  : SplitPathParent
Value : D:\project\release\PSScratchpad

Name  : SplitPathParentResolve
Value : D:\project\release\PSScratchpad
```