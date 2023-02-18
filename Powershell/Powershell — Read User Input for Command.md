---
tags:
- Powershell
date: 2023-12-02
---

# Read User Input for Command

## In a script or REPL

```powershell
[System.String[]]$quitCommand = @("q", "e", "c")
$inp = Read-Host "Enter to continue or [$quitCommand] to quit"
$quit = [System.Linq.Enumerable]::Contains($quitCommand, $inp.ToLowerInvariant())
While(-Not $quit) {
    Write-Host "Hello, your input was [$inp]"

    $inp = Read-Host "Enter to continue or [$quitCommand] to quit"
    $quit = [System.Linq.Enumerable]::Contains($quitCommand, $inp.ToLowerInvariant())
}
```

Output-nya

```powershell
Enter to continue or [q e c] to quit: yahharo
Hello, your input was [yahharo]
Enter to continue or [q e c] to quit: c
```



## In a script

_Note: `param` ini cuma bisa dipake didalem script. artinya harus di-save ke .ps1 dulu_

```powershell
param([System.String]$mode, [System.String]$profile)

Clear-Host

function ListAction($profile) {
    Write-Host "nantokanantoka"
    Write-Host $profile
}

function DeleteAction($profile) {
    Write-Host "nan"
    Write-Host $profile
}

$modeActions = @{
    "l" = "ListAction"
    "d" = "DeleteAction"
}

If ([System.Linq.Enumerable]::Contains([System.String[]]$modeActions.Keys, $mode.ToLowerInvariant())) {
    & $modeActions[$mode.ToLowerInvariant()] $profile
}
```

Contoh run-nya jadi gini

```powershell
D:\temp> D:\Personal-Notes\Powershell\Read-Parameters.ps1 "l" "fakeprofile"

nantokanantoka
fakeprofile
```