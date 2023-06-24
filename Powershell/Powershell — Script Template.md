---
tags:
- Powershell
- Template
date: 2021-12-22
---

# Script Template

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
#:< Script Info >:#

#:< Log >:#
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
#:< Log >:#

#:< Get Exception >:#
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
#:< Get Exception >:#

#:< Load Xml >:#
function LoadXml([System.String]$xmlContent) {
    $content = $xmlContent.Trim()
    If ([System.String]::IsNullOrEmpty($content)) {
        Return $null
    }

    $xmlDoc = New-Object System.Xml.XmlDocument
    $xmlDoc.LoadXml($content)

    Return $xmlDoc
}

function LoadXmlFromPath([System.String]$xmlPath) {
    If (-Not (Test-Path $xmlPath)) {
        Throw New-Object System.IO.FileNotFoundException($xmlPath)
    }

    $content = [System.IO.File]::ReadAllText($xmlPath)
    [System.Xml.XmlDocument]$xmlDoc = LoadXml $content
    
    Return $xmlDoc
}

function GetAttribute([System.Xml.XmlNode]$node, $name) {
    If ($node -Ne $null -And $node.Attributes -Ne $null) {
        [System.Xml.XmlAttribute]$attr = $node.Attributes[$name]
        If ($attr -Ne $null) {
            Return $attr -As [System.Xml.XmlNode]
        }
    }

    Return $null
}

function AssignAttributeTo([System.Xml.XmlDocument]$xmlDoc, [System.Xml.XmlNode]$node, $name, $value) {
    If ($xmlDoc -Ne $null -And $node -Ne $null) {
        $attr = GetAttribute $node $name
        If ($attr -Eq $null) {
            $attr = $xmlDoc.CreateAttribute($name)
            $node.Attributes.Append($attr)
        }

        $attr.Value = $value
    }
}

function GetAttributeValue([System.Xml.XmlNode]$node, $name) {
    $attr = GetAttribute $node $name
    If ($attr -Ne $null) {
        Return $attr.Value
    }

    Return "";
}

function GetNodeValue([System.Xml.XmlDocument]$xmlDoc, $selector) {
    $node = $xmlDoc.SelectSingleNode($selector) -As [System.Xml.XmlNode]
    Return $node.InnerText
}

function GetMultipleNodeValue([System.Xml.XmlDocument]$xmlDoc, $selector) {
    $values = New-Object System.Collections.Generic.List[System.String]
    $docs = $xmlDoc.SelectNodes($selector)
    ForEach ($doc In $docs) {
        $values.Add($doc.InnerText)
    }

    Return $values
}
#:< Load Xml >:#

function GetConfig() {
    $scriptInfo = GetScriptInfo
    $configFileName = [System.IO.Path]::Combine($scriptInfo.Directory, "$($scriptInfo.Name).config.xml")

    Return LoadXmlFromPath $configFileName
}

Log ":: Start Script ::" $true

Log "Doing something ..."

Log "Doing another thing ..."

Log ":: Finish Script ::"
```



