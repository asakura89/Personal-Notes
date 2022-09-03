---
tags:
- Snippet
- Powershell
- Random
date: 2020-05-25
---

# Get Random

## Random Seeds

Generate random seeds dengan trik random _Guid_ dan Feigenbaum (46692016)
```powershell
Clear-Host

$range = 1..10

[System.Collections.Generic.List[System.Int32]]$firstSeeds = $range |
    Select-Object @{L="50001"; E={((New-Guid).GetHashCode() % 50001)}} |
    Select-Object -ExpandProperty "50001"

[System.Collections.Generic.List[System.Int32]]$secondSeeds = $range |
    Select-Object @{L="46692016"; E={((New-Guid).GetHashCode() % 46692016)}} |
    Select-Object -ExpandProperty "46692016"

$firstSeeds |
    Sort-Object { $_ }

Write-Host ""
Write-Host "---"
Write-Host ""

$secondSeeds |
    Sort-Object { $_ }
```



Contoh hasil run
```powershell
-34908
-27215
6696
9795
11021
15191
29103
39524
40496
44261

---

-34491041
-28318835
-23416429
-23032612
-17446219
-8954845
-7306253
9144988
18589909
29547686
```



## Random Number

```powershell
Clear-Host

$range = 1..10

[System.Collections.Generic.List[System.Int32]]$firstSeeds = $range |
    Select-Object @{L="50001"; E={((New-Guid).GetHashCode() % 50001)}} |
    Select-Object -ExpandProperty "50001"

[System.Collections.Generic.List[System.Int32]]$secondSeeds = $range |
    Select-Object @{L="46692016"; E={((New-Guid).GetHashCode() % 46692016)}} |
    Select-Object -ExpandProperty "46692016"

[System.Collections.Generic.List[System.Int32]]$firstRands = @()
ForEach ($seed In $firstSeeds) {
    $rand = New-Object System.Random($seed)
    $firstRands.Add($rand.Next(0, 10))
}

$firstRands

Write-Host ""
Write-Host "---"
Write-Host ""

[System.Collections.Generic.List[System.Int32]]$secondRands = @()
ForEach ($seed In $secondSeeds) {
    $rand = New-Object System.Random($seed)
    $secondRands.Add($rand.Next(0, 10))
}

$secondRands
```



Contoh hasil run
```powershell
1
6
3
4
5
5
0
4
1
3

---

5
2
6
6
5
2
7
4
1
8
```