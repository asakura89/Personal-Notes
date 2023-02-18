---
tags:
- Powershell
- Chain-Method
date: 2023-05-28
---

# Multiline chain-method

## Normal Powershell way

```powershell
Clear-Host

(New-Object System.Text.StringBuilder).
    AppendLine("Start of script").
    AppendLine("Second Line").
    AppendLine("Finish of script").
    ToString() |
Write-Host
```

Contoh hasil run

```powershell
Start of script
Second Line
Finish of script
```



## Use ForEach-Object alias

```powershell
Clear-Host

$msgBuilder = (New-Object System.Text.StringBuilder) |
    % AppendLine "Start of script" |
    % AppendLine "Second Line" |
    % AppendLine "Finish of script"

Write-Host $msgBuilder.ToString()
```

Contoh hasil run

```powershell
Start of script
Second Line
Finish of script
```