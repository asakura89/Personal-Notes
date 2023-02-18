---
tags:
- Powershell
- Line-of-code
date: 2021-06-14
---

# Count Line of Code


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

function Log($message, $starting = $false, $writeToScreen = $true) {
    $workingpath = GetScriptInfo
    If ($workingpath.Name -Ne $null) {
        $logname = "$($workingpath.Name)_$([System.DateTime]::Now.ToString("yyyyMMddHHmm")).log"
        $logfile = [System.IO.Path]::Combine($($workingpath.Directory), $logname)

        $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
        If ($writeToScreen) {
            Write-Host $logmsg
        }

        If ($starting) {
            $logmsg | Out-File -Encoding "UTF8" -FilePath $logfile
        }
        Else {
            $logmsg | Add-Content -Encoding "UTF8" -Path $logfile
        }
    }
}

#:< --------------------------------------------- >:#

Log "``:: Start Script ::'" $true

$dir = "D:\\New folder"
$exts = @(".cs", ".eqx")

$files = @()
ForEach ($ext In $exts) {
    Get-ChildItem -Path $dir -Include "*$($ext)" -Recurse |
        Select-Object -ExpandProperty VersionInfo  |
        Select-Object -ExpandProperty FileName |
        ForEach-Object { $files += $_ }
}

$total = 0
ForEach ($file In $files) {
    $line = $(Get-Content $file |
        Measure-Object -Line |
        Select-Object -ExpandProperty Lines)
    $total = $total + $line
    Log "$($file) -- $($line)"
}

Log "Total -- $($total)"

Log ".:: Finish Script ::."
```