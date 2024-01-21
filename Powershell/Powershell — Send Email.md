---
tags:
- Powershell
- DotEnv
- .env
- env
- Config
date: 2024-01-20
---

# Send Email

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

#:< Xml >:#
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

function GetNodesValue([System.Xml.XmlDocument]$xmlDoc, $selector) {
    $values = New-Object System.Collections.Generic.List[System.String]
    $docs = $xmlDoc.SelectNodes($selector)
    ForEach ($doc In $docs) {
        $values.Add($doc.InnerText)
    }

    Return $values
}
#:< Xml End >:#

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

Isi dari `Load-Env.config.env` adalah

```env
STRIPE_API_KEY=scr_12345
TWILIO_API_KEY=abcd1234
LISTEN_ADDRESS=0.0.0.0
MONGO_HOST=mongo
MONGO_URL=mongodb://mongo/mainnode?directConnection=true
WEB_API_PASSWORD=mainnode
WEB_API_USER=mongo_main
WEB_HOST=web
email_template="<ins><strong>Reminder: ${Date}</strong></ins>
<em>Approve my PR ASAP sir!</em>"
```

Contoh hasil run

```powershell
Key              Value
---              -----
STRIPE_API_KEY   scr_12345
TWILIO_API_KEY   abcd1234
LISTEN_ADDRESS   0.0.0.0
MONGO_HOST       mongo
MONGO_URL        mongodb://mongo/mainnode?directConnection=true
WEB_API_PASSWORD mainnode
WEB_API_USER     mongo_main
WEB_HOST         web
email_template   "<ins><strong>Reminder: ${Date}</strong></ins>...
```


**References:**

- https://github.com/bkeepers/dotenv/blob/master/lib/dotenv/parser.rb