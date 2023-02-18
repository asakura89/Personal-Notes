---
tags:
- Powershell
- Email
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

#:< String Replace >:#
function Replace([System.String]$template, [System.Collections.Hashtable]$replacements) {
    If ($replacements -Ne $null -And $replacements.Count -Gt 0) {
        $matches = [System.Text.RegularExpressions.Regex]::Matches($template, "\$\{(\w*)\}")
        ForEach ($match In $matches) {
            If ($match.Success) {
                $replace = $match.Groups[0].Value
                $key = $match.Groups[1].Value
                $replacement = $replacements[$key]
                $template = $template.Replace($replace, $replacement)
            }
        }
    }

    Return $template
}
#:< String Replace End >:#

#:< Email >:#
function SendEmail($smtpConfig, $mailConfig) {
    $mailClient = New-Object System.Net.Mail.SmtpClient($smtpConfig.Server)
    $mailClient.Port = $($smtpConfig.Port -As [System.Int32])
    $mailClient.EnableSsl = $($smtpConfig.UseSsl -As [System.Boolean])
    $mailClient.Credentials = New-Object System.Net.NetworkCredential($smtpConfig.Username, $smtpConfig.Password)

    $message = New-Object System.Net.Mail.MailMessage
    $message.From = New-Object System.Net.Mail.MailAddress($mailConfig.FromEmail, $mailConfig.FromName)
    ForEach ($to in $mailConfig.Recipients) {
        $message.To.Add($to)
    }
    $message.Subject = $mailConfig.Subject
    $message.Body = $mailConfig.Body
    $message.IsBodyHtml = $true

    $mailClient.Send($message)
}
#:< Email End >:#

#:< Map Config >:#
function GetConfig() {
    $scriptInfo = GetScriptInfo
    #$configFileName = [System.IO.Path]::Combine($scriptInfo.Directory, "$($scriptInfo.Name).config.xml")
    $configFileName = "D:\\Personal-Notes\\Powershell\\_media\\Load-Xml.config.xml"

    $xmlDoc = LoadXmlFromPath $configFileName
    $fromNode = $xmlDoc.SelectSingleNode("configuration/mailConfig/from") -As [System.Xml.XmlNode]
    $config = @{
        SmtpConfig = @{
            Server = (GetNodeValue $xmlDoc "configuration/smtpConfig/server")
            Port = (GetNodeValue $xmlDoc "configuration/smtpConfig/port") -As [System.Int32]
            Username = (GetNodeValue $xmlDoc "configuration/smtpConfig/userName")
            Password = (GetNodeValue $xmlDoc "configuration/smtpConfig/password")
            UseSsl = (GetNodeValue $xmlDoc "configuration/smtpConfig/useSsl") -As [System.Boolean]
            UseTls = (GetNodeValue $xmlDoc "configuration/smtpConfig/useTls") -As [System.Boolean]
        }
        MailConfig = @{
            FromEmail = (GetAttributeValue $fromNode "email") 
            FromName = (GetAttributeValue $fromNode "name")
            Recipients = (GetNodesValue $xmlDoc "configuration/mailConfig/recipients/email")
            Ccs = (GetNodesValue $xmlDoc "configuration/mailConfig/ccs/email")
            SubjectTemplate = (GetNodeValue $xmlDoc "configuration/mailConfig/subject")
            Subject = ""
            BodyTemplate = (GetNodeValue $xmlDoc "configuration/mailConfig/body")
            Body = ""
        }
    }

    $rep = @{
        "Title" = "Reminding you of Task"
        "Body" = "<ins><strong>Reminder: $([System.DateTime]::Now.ToString(`"HH:mm:ss`"))</strong></ins>
        <br/>
        <em>Approve my PR ASAP sir!</em>"
    }
    $config.MailConfig.Subject = $config.MailConfig.SubjectTemplate
    $config.MailConfig.Body = Replace $config.MailConfig.BodyTemplate $rep

    Return $config
}
#:< Map Config End >:#

Try {
    Log ":: Start Script ::" $true

    Log "Preparing config ..."

    $config = GetConfig

    Log "Preparing config done ..."

    Log "Sending email ..."

    SendEmail $config.SmtpConfig $config.MailConfig

    Log "Sending email done ..."

    Log ":: Finish Script ::"
}
Catch {
    Log $(GetExceptionMessage $_.Exception)
}
```
