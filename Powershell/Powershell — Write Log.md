---
tags:
- Powershell
- Log
date: 2021-08-17
---

# Write Log

## Write Log

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

Log "``:: Start Script ::'" $true

Log "Doing something ..."

Log "Doing another thing ..."

Log ".:: Finish Script ::."
```

Contoh hasil run

```powershell
[2023.05.26.20:45:35] `:: Start Script ::'
[2023.05.26.20:45:35] Doing something ...
[2023.05.26.20:45:35] Doing another thing ...
[2023.05.26.20:45:35] .:: Finish Script ::.
```



## Cleanup Log

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

function CleanupLog($startDateString, $endDateString) {
    $scriptInfo = GetScriptInfo
    $searchedPath = "$($scriptInfo.Directory.FullName)\"
    $format = "yyyyMMdd"
    $start = [System.DateTime]::ParseExact($startDateString, $format, [System.Globalization.CultureInfo]::CurrentCulture)
    $end = [System.DateTime]::ParseExact($endDateString, $format, [System.Globalization.CultureInfo]::CurrentCulture)
    $patterns = @()
    For ([System.DateTime]$current = $start; $current -Le $end; $current = $current.AddDays(1)) {
        $patterns += "*_$($current.ToString($format))*.log"
    }

    $files = Get-ChildItem -Path $searchedPath -Include $patterns -Recurse -File
    ForEach ($file in $files) {
        Log "$($file.FullName) will be deleted"
        # Be careful, uncomment this if you are sure
        # Remove-Item -Path $file.FullName
        Log "$($file.FullName) deleted"
    }
}

#:< --------------------------------------------- >:#

Log ":: Start Script ::" $true

CleanupLog "20200504" "20200507"

Log ":: Finish Script ::"
```

Contoh hasil run

```powershell
[2023.06.24.01:30:46] :: Start Script ::
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050742.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050742.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050743.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050743.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050744.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050744.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050747.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050747.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050748.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050748.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050752.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050752.log deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050807.log will be deleted
[2023.06.24.01:30:46] D:\project\release\PSScratchpad\Script\cleanup-solr_202005050807.log deleted
[2023.06.24.01:30:46] :: Finish Script ::
```