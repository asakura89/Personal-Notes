---
tags:
- Powershell
- File
date: 2023-12-03
---

# Filename by Extensions

## Get File list

```powershell
Clear-Host

function GetFiles($rootDir, $fileExt) {
    If (-Not $fileExt.StartsWith(".")) {
        $fileExt = ".$($fileExt)"
    }

    $fileExt = "*$($fileExt)"

    $files = Get-ChildItem -Path $rootDir -Include $fileExt -Recurse |
        Select-Object -ExpandProperty VersionInfo |
        Select-Object -ExpandProperty FileName

    Return $files
}

$dir = "C:\\Users\\<Username>\\.nuget\\packages"
$ext = ".nupkg"

GetFiles $dir $ext |
    Sort-Object -Descending
```

Output-nya

```powershell
C:sers\<Username>\.nuget\packages\Zlib.Portable.Signed.1.11.0.nupkg
C:sers\<Username>\.nuget\packages\Z.EntityFramework.Plus.EF5.1.7.7.nupkg
C:sers\<Username>\.nuget\packages\yuicompressor.net.2.7.0.nupkg
C:sers\<Username>\.nuget\packages\YUICompressor.NET.2.7.0.0.nupkg
. . . omitted . . .
C:sers\<Username>\.nuget\packages\ActionMailer.0.7.4.nupkg
C:sers\<Username>\.nuget\packages\7zip.commandline.16.02.nupkg
C:sers\<Username>\.nuget\packages\51Degrees.mobi-core.3.2.17.2.nupkg
```



## Copy File list by extension

```powershell
Clear-Host

$dir = "C:\\Users\\<username>\\.nuget\\packages"
$ext = ".nupkg"

$destDir = "D:\nuget"

$files = @()
Get-ChildItem -Path $dir -Include "*$($ext)" -Recurse |
    Select-Object -ExpandProperty VersionInfo  |
    Select-Object -ExpandProperty FileName |
    ForEach-Object { $files += $_ }

If ((Test-Path -Path $destDir) -Eq $False) {
    [System.IO.Directory]::CreateDirectory($destDir)
}

ForEach ($file In $files) {
    Copy-Item -Path $file -Destination $destDir
}
```