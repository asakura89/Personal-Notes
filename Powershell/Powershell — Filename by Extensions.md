---
tags:
- Powershell
- File
date: 2023-12-03
---

# Filename by Extensions

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

$dir = "C:\Users\<Username>\.nuget\packages"
$ext = ".nupkg"

GetFiles $dir $ext |
    Sort-Object -Descending
```

Output-nya

```powershell
D:\Microsoft\Workspace\NugetCache\Zlib.Portable.Signed.1.11.0.nupkg
D:\Microsoft\Workspace\NugetCache\Z.EntityFramework.Plus.EF5.1.7.7.nupkg
D:\Microsoft\Workspace\NugetCache\yuicompressor.net.2.7.0.nupkg
D:\Microsoft\Workspace\NugetCache\YUICompressor.NET.2.7.0.0.nupkg
. . . omitted . . .
D:\Microsoft\Workspace\NugetCache\ActionMailer.0.7.4.nupkg
D:\Microsoft\Workspace\NugetCache\7zip.commandline.16.02.nupkg
D:\Microsoft\Workspace\NugetCache\51Degrees.mobi-core.3.2.17.2.nupkg
```