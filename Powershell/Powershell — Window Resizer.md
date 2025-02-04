---
tags:
- Powershell
date: 2024-07-04
---

# Window Resizer

```powershell
Clear-Host

#:< Script Info >:#
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
#:< Script Info End >:#

#:< Exception Helper >:#
function GetExceptionMessage([System.Exception]$ex) {
    $errorList = New-Object System.Text.StringBuilder
    [System.Exception]$current = $ex;
    While ($current -Ne $null) {
        [void]$errorList.AppendLine()
        [void]$errorList.AppendLine("Exception: $($current.GetType().FullName)")
        [void]$errorList.AppendLine("Message: $($current.Message)")
        [void]$errorList.AppendLine("Source: $($current.Source)")
        [void]$errorList.AppendLine($current.StackTrace)
        [void]$errorList.AppendLine()

        $current = $current.InnerException
    }

    Return $errorList.ToString()
}
#:< Exception Helper End >:#

#:< Logging >:#
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
#:< Logging End >:#

#:< ActiveWindow Collector >:#
function Get-ActiveWindows {
    $global:shellWindow = [ActiveWindowCollector]::GetShellWindow()
    $windows = New-Object System.Collections.Generic.List[PSCustomObject]

    $enumWindowsCallback = {
        param ($hWnd, $lParam)
        if ($hWnd -eq $global:shellWindow) { return $true }
        if (-not [ActiveWindowCollector]::IsWindowVisible($hWnd)) { return $true }
        $length = [ActiveWindowCollector]::GetWindowTextLength($hWnd)
        if ($length -eq 0) { return $true }
        $builder = New-Object System.Text.StringBuilder $length
        [ActiveWindowCollector]::GetWindowText($hWnd, $builder, $length + 1)
        $windows.Add([PSCustomObject]@{ Id = $hWnd; Name = $builder.ToString() })
        return $true
    }

    [ActiveWindowCollector]::EnumWindows($enumWindowsCallback, 0)
    return $windows
}

Add-Type @"
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class ActiveWindowCollector {
    [DllImport("USER32.DLL")]
    public static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

    [DllImport("USER32.DLL")]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("USER32.DLL")]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("USER32.DLL")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("USER32.DLL")]
    public static extern IntPtr GetShellWindow();

    public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
}
"@
#:< ActiveWindow Collector End >:#

#:< Size Controller >:#
function Set-WindowSize {
    param (
        [System.IntPtr]$hWnd,
        [int]$width,
        [int]$height
    )
    $rect = New-Object SizeController+Rect
    if ([SizeController]::GetWindowRect($hWnd, [ref]$rect)) {
        [SizeController]::MoveWindow($hWnd, $rect.X, $rect.Y, $width, $height, $true)
    }
}

Add-Type @"
using System;
using System.Runtime.InteropServices;

public class SizeController {
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, ref Rect rect);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
}
"@
#:< Size Controller End >:#

function Set-CurrentSize {
    param (
        [System.String]$sizeString
    )
    $splitted = $sizeString -split ','
    $global:currentSize = New-Object Drawing.Size ([int]$splitted[0], [int]$splitted[1])
    Log "Current Size set as: $($global:currentSize.Width) x $($global:currentSize.Height)"
}

[System.String[]]$windowSizeList = @(
    "1581.25, 868.75"  <# 1.25 scaling #>
    "1897.5, 1042.5"   <# 1.5 scaling #>
    "1265, 695"        <# 1 scaling #>
    "500, 340"
    "385, 217"

    "1024, 768"
    "1080, 695"
    "1080, 550"
    "1080, 650"
    "1200, 650"
    "1920, 1080"

    "1440, 765"
    "1580, 870"
    "1120, 645"
    "1080, 575"

    "450, 1040"

    "1000, 536.25"    <# 1.25 scaling #>
    "800, 429"        <# 1 scaling #>
)

function Run() {
    Try {
        $allWindows = Get-ActiveWindows
        $selectedWindows = $allWindows | Where-Object { $_.Name -notin @("start", "My Application") }

        foreach ($window in $selectedWindows) {
            If ($window.Id -Ne $null) {
                Log "Setting Window: $($window.Id), $($window.Name)"
                Set-WindowSize -hWnd $window.Id -width $global:currentSize.Width -height $global:currentSize.Height
            }
        }
    }
    Catch {
        Log "$(GetExceptionMessage $_.Exception)"
    }
}

Log ":: Start Script ::" $true
$first = [System.Linq.Enumerable]::First([System.String[]]$windowSizeList)
Set-CurrentSize $first
Run
Log ":: Finish Script ::"
```
