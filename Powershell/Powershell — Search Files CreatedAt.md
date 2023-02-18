---
tags:
- Powershell
- File
- Search
date: 2023-05-28
---

# List Directory

Sebelum masuk ke topik _Directory_ atau _File_, umumnya untuk ngambil list item dari working directory (folder yang lagi dibuka) bisa pake `Get-ChildItem`. Kalo dipanggil tanpa parameter maka bakal nge-list semua item dan menghasilkan output yang sama dengan batch command `dir`.



## First Level

```powershell
Clear-Host

$searchedpath = "D:\temp"
$startdate = 20230528 # <-- in a yyyyMMdd format for easy math compare
$enddate = 20230529

#:< Create file to dump content >:#
$workingpath = $null
If ($PSCommandPath -Eq [System.String]::Empty) {
    # Note: $PSCommandPath will be empty string if it is not ran from script file
    $workingpath = (Get-Item -Path .)
}
Else {
    $workingpath = (Get-Item $PSCommandPath)
}

$fullfilepath = $null
If ($workingpath -Ne $null) {
    $filename = "$($workingpath.BaseName)_$([System.DateTime]::Now.ToString("yyyyMMddHHmm")).txt"
    $fullfilepath = [System.IO.Path]::Combine($($workingpath.Directory), $filename)

    (New-Object System.Text.StringBuilder).
        Append("<#:< Script Output >:#>").
        AppendLine().
        ToString() |
    Out-File -Encoding UTF8 -FilePath $fullfilepath
}

#:< Search File >:#
$filelist = Get-ChildItem -Path $searchedpath -Recurse -File |
    Where-Object {
        [System.Convert]::ToInt32($_.CreationTime.ToString("yyyyMMdd")) -Ge $startdate -And `
        [System.Convert]::ToInt32($_.CreationTime.ToString("yyyyMMdd")) -Le $enddate
    } |
    Select-Object @{L="Desc"; E={ "{0}: {1}" -F $_.FullName,$_.CreationTime.ToString() }} |
    Select-Object -ExpandProperty Desc

$filelist | Add-Content -Encoding UTF8 -Path $fullfilepath
```

Contoh hasil file output
```powershell
<#:< Script Output >:#>

D:\temp\temp_202305281148.log: 28/05/2023 11:48:15 AM
D:\temp\temp_202305281149.log: 28/05/2023 11:49:07 AM
D:\temp\temp_202305281247.txt: 28/05/2023 12:47:12 PM
D:\temp\temp_202305281250.txt: 28/05/2023 12:50:55 PM
D:\temp\temp_202305281251.txt: 28/05/2023 12:51:21 PM

```