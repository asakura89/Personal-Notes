---
tags:
- Powershell
- Windows
date: 2023-12-03
---

# List Process by Memory

## Specific processes

```powershell
Clear-Host

$processes = @(
    "*java*",
    "*zookeeper*",
    "*solr*",
    "*webview*",
    "*code*"
)

Get-Process |
    Group-Object -Property ProcessName | 
    Select-Object `
        @{L="Name"; E={ $_.Name }}, `
        @{L="Memory"; E={ ($_.Group|Measure-Object WorkingSet -Sum).Sum / 1KB }} |
    Where-Object {
        $_.Name -Like $processes[0] -Or `
        $_.Name -Like $processes[1] -Or `
        $_.Name -Like $processes[2] -Or `
        $_.Name -Like $processes[3] -Or `
        $_.Name -Like $processes[4]
    } |
    Sort-Object { $_.Memory } -Descending |
    Format-Table Name, @{N="Mem (KB)"; E={"{0:N0}" -F $_.Memory}; A="Right"} -AutoSize
```

Output-nya

```powershell
Name                                     Mem (KB)
----                                     --------
Code                                    2.324.460
msedgewebview2                            725.416
Microsoft.VisualStudio.Code.ServiceHost   190.096
Microsoft.VisualStudio.Code.Server        128.312
```

Atau ini buat liat memory pake MB

```powershell
Clear-Host

$processes = @(
    "*java*",
    "*zookeeper*",
    "*solr*",
    "*webview*",
    "*code*"
)

Get-Process |
    Group-Object -Property ProcessName | 
    Select-Object `
        @{L="Name"; E={ $_.Name }}, `
        @{L="Memory"; E={ ($_.Group|Measure-Object WorkingSet -Sum).Sum / 1KB / 1024 }} |
    Where-Object {
        $_.Name -Like $processes[0] -Or `
        $_.Name -Like $processes[1] -Or `
        $_.Name -Like $processes[2] -Or `
        $_.Name -Like $processes[3] -Or `
        $_.Name -Like $processes[4]
    } |
    Sort-Object { $_.Memory } -Descending |
    Format-Table Name, @{N="Mem (MB)"; E={"{0:N0}" -F $_.Memory}; A="Right"} -AutoSize
```

Output-nya

```powershell
Name                                    Mem (MB)
----                                    --------
Code                                       2.278
msedgewebview2                               421
Microsoft.VisualStudio.Code.ServiceHost      186
Microsoft.VisualStudio.Code.Server           125
```



## List all

```powershell
Clear-Host

Get-Process |
    Group-Object -Property ProcessName | 
    Select-Object `
        @{L="Name"; E={ $_.Name }}, `
        @{L="Memory"; E={ ($_.Group|Measure-Object WorkingSet -Sum).Sum / 1KB / 1024 }} |
    Sort-Object -Property Memory -Descending |
    Select-Object -Property Name, @{N="Mem (MB)"; E={ "{0:N0}" -F $_.Memory}} |
    Out-GridView
```

Output-nya ada window WPF yang nampilin table.

Atau giniin biar keluar jadi text.

```powershell
Clear-Host

Get-Process |
    Group-Object -Property ProcessName | 
    Select-Object `
        @{L="Name"; E={ $_.Name }}, `
        @{L="Memory"; E={ ($_.Group|Measure-Object WorkingSet -Sum).Sum / 1KB / 1024 }} |
    Sort-Object -Property Memory -Descending |
    Format-Table Name, @{N="Mem (MB)"; E={ "{0:N0}" -F $_.Memory}; A="Right"} -AutoSize
```

Gini nih output-nya

```powershell
Name                                    Mem (MB)
----                                    --------
firefox                                    6.032
Code                                       2.314
msedge                                     1.280
svchost                                    1.229
Memory Compression                           472
msedgewebview2                               420
dotnet                                       403
powershell_ise                               372
. . . omitted . . .
CalculatorApp                                  2
SystemSettings                                 1
smss                                           1
CAudioFilterAgent64                            1
System                                         0
Idle                                           0
```