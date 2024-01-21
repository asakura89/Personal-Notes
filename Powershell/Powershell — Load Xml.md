---
tags:
- Powershell
- Xml
- Config
date: 2020-10-25
---

# Load Xml

## Using .NET

```powershell
Clear-Host

#:< global config >:#
$configPath = "D:\\Personal-Notes\\Powershell\\_media\\Load-Xml.config.xml"

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

function MapConfigToSmtpConfig($configPath = $Script:configPath) {
    $config = LoadXmlFromPath $configPath
    Return @{
        Server = (GetNodeValue $config "configuration/smtpConfig/server")
        Port = (GetNodeValue $config "configuration/smtpConfig/port") -As [System.Int32]
        Username = (GetNodeValue $config "configuration/smtpConfig/userName")
        Password = (GetNodeValue $config "configuration/smtpConfig/password")
        UseTls = (GetNodeValue $config "configuration/smtpConfig/useTls") -As [System.Boolean]
    }
}

$smtpConfig = MapConfigToSmtpConfig
$smtpConfig | ConvertTo-Json

$xmlContent = @"
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <events>
        <event>name.of.the.event</event>
        <event>name.of.the.second.event</event>
    </events>
</configuration>
"@

$xml = LoadXml $xmlContent
$values = (GetNodesValue $xml "configuration/events/event")
$values | ConvertTo-Json
```

Isi dari `Load-Xml.config.xml` adalah

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <smtpConfig>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin</password>
        <useTls>false</useTls>
    </smtpConfig>
</configuration>
```

Contoh hasil run

```powershell
{
    "Port":  587,
    "Server":  "smtp.supermailservice.com",
    "Username":  "SmtpUser_Admin",
    "Password":  "100%SmtpPwd4Admin",
    "UseTls":  true
}
[
    "name.of.the.event",
    "name.of.the.second.event"
]
```



## Using Powershell native

```powershell
Clear-Host

#:< global config >:#
$configPath = "D:\\Personal-Notes\\Powershell\\_media\\Load-Xml.config.xml"

function MapConfigToSmtpConfig($configPath = $Script:configPath) {
    [xml]$config = Get-Content $configPath
    Return @{
        Server = $config.configuration.smtpConfig.server
        Port = $config.configuration.smtpConfig.port -As [System.Int32]
        Username = $config.configuration.smtpConfig.userName
        Password = $config.configuration.smtpConfig.password
        UseTls = $config.configuration.smtpConfig.useTls -As [System.Boolean]
    }
}

$smtpConfig = MapConfigToSmtpConfig
$smtpConfig | ConvertTo-Json

[xml]$xmlContent = @"
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <events>
        <event>name.of.the.event</event>
        <event>name.of.the.second.event</event>
    </events>
</configuration>
"@

$values = $xmlContent.configuration.events.event
$values | ConvertTo-Json
```