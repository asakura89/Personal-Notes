---
tags:
- Powershell
- File
date: 2023-12-02
---

# Read User Input for Command

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