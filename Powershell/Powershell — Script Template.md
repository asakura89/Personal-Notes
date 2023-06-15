---
tags:
- Powershell
- Template
date: 2021-12-22
---

# Script Template

```powershell
Clear-Host

function GetScriptInfo() {
    $scriptfile = (Get-Item $PSCommandPath)

    Return @{
        Name = $scriptfile.BaseName
        FullName = $scriptfile.Name
        Directory = $scriptfile.Directory
    }
}

#:< Log >:#
function Log($message, $starting = $false, $writeToScreen = $true) {
    $scriptfile = (Get-Item $PSCommandPath)
    $logdir = $scriptfile.Directory
    $logname = "$($scriptfile.BaseName)_$([System.DateTime]::Now.ToString("yyyyMMddHHmm")).log"
    $logfile = [System.IO.Path]::Combine($logdir, $logname)

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

function CleanupLog() {
    $scriptInfo = GetScriptInfo
    $logdir = $scriptInfo.Directory

    $maxDay = "-"+$logage -As [System.Int32]
    $date = (Get-Date).AddDays($maxDay)

    $logfolderFiles = Get-ChildItem -Path $logdir -Recurse -File
    ForEach ($file in $logfolderFiles) {
        If ($file.Extension -Eq ".log") { 
            If($file.LastWriteTime -lt $date){
                Remove-Item -Path $file.PSPath
            }
        }
    }
}

#:< Log >:#

#:< GetException >:#
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
#:< GetException >:#

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



