---
tags:
- Golang
- Xml
- Config
date: 2023-12-24
---

# Load Xml

> ❗ Note
> 
> go version = 1.21.0

Cara pertama

```go
package main

import (
    "encoding/xml"
    "encoding/json"
    "fmt"
    "log"
    "os"
)

type SmtpConfig struct {
    Server string `xml:"server"`
    Port int `xml:"port"`
    UserName string `xml:"userName"`
    Password string `xml:"password"`
    UseTls bool `xml:"useTls"`
}

type From struct {
    Email string `xml:"email,attr"`
    Name string `xml:"name,attr"`
}

type Recipients struct {
    Emails []string `xml:"email"`
}

type Ccs struct {
    Emails []string `xml:"email"`
}

type MailConfig struct {
    From From `xml:"from"`
    Recipients Recipients `xml:"recipients"`
    Ccs Ccs `xml:"ccs"`
    Subject string `xml:"subject"`
    Body string `xml:"body"`
}

type Configuration struct {
    SmtpConfig SmtpConfig `xml:"smtpConfig"`
    MailConfig MailConfig `xml:"mailConfig"`
}

func readConfig(filename string) (Configuration, error) {
    file, err := os.Open(filename)
    if err != nil {
        return Configuration{}, err
    }

    defer file.Close()

    var config Configuration
    /* cara pertama */
    decoder := xml.NewDecoder(file)
    err = decoder.Decode(&config)
    if err != nil {
        return Configuration{}, err
    }

    /* cara kedua
    data, err := io.ReadAll(file)
    if err != nil {
        return Configuration{}, err
    }

    err = xml.Unmarshal(data, &config)
    */

    return config, nil
}

func main() {
    config, err := readConfig("D:\\Personal-Notes\\Powershell\\_media\\Load-Xml.config.xml")
    if err != nil {
        log.Fatal(err)
    }

    jsonData, err := json.Marshal(config)
    if err != nil {
        log.Fatal(err)
    }

    jsonString := string(jsonData)

    fmt.Println(jsonString)
}
```

Output-nya

```json
{"SmtpConfig":{"Server":"smtp.orenosaito.co.jp","Port":587,"UserName":"SmtpUser_Admin","Password":"100%SmtpPwd4Admin","UseTls":false},"MailConfig":{"From":{"Email":"dontreply_notif@orenosaito.co.jp","Name":"DO_NOT_Reply Notification Script"},"Recipients":{"Emails":["menolakreply@orenosaito.co.jp"]},"Ccs":{"Emails":null},"Subject":"Notification Script","Body":"\n      \n        
\u003cstrong\u003e\u003cins\u003eReminder\u003c/ins\u003e\u003c/strong\u003e\n        \u003cbr/\u003e\n        \u003cbr/\u003e\n        ${ReminderItem1}\n        ${ReminderItem2}\n      \n    "}}
```

Cara kedua

```go
package main

import (
    "encoding/xml"
    "encoding/json"
    "fmt"
    "log"
    "os"
    "io"
)

type SmtpConfig struct {
    Server string `xml:"server"`
    Port int `xml:"port"`
    UserName string `xml:"userName"`
    Password string `xml:"password"`
    UseTls bool `xml:"useTls"`
}

type From struct {
    Email string `xml:"email,attr"`
    Name string `xml:"name,attr"`
}

type Recipients struct {
    Emails []string `xml:"email"`
}

type Ccs struct {
    Emails []string `xml:"email"`
}

type MailConfig struct {
    From From `xml:"from"`
    Recipients Recipients `xml:"recipients"`
    Ccs Ccs `xml:"ccs"`
    Subject string `xml:"subject"`
    Body string `xml:"body"`
}

type Configuration struct {
    SmtpConfig SmtpConfig `xml:"smtpConfig"`
    MailConfig MailConfig `xml:"mailConfig"`
}

func readConfigRaw(xmlConfig string) (Configuration, error) {
    var config Configuration
    err := xml.Unmarshal([]byte(xmlConfig), &config)
    if err != nil {
        return Configuration{}, err
    }

    return config, nil
}

func main() {
    xmlConfig := `<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <smtpConfig>
    <server>smtp.orenosaito.co.jp</server>
    <port>587</port>
    <userName>SmtpUser_Admin</userName>
    <password>100%SmtpPwd4Admin</password>
    <useTls>false</useTls>
  </smtpConfig>
  <mailConfig>
    <from email="dontreply_notif@orenosaito.co.jp" name="DO_NOT_Reply Notification Script" />
    <recipients>
      <email>menolakreply@orenosaito.co.jp</email>
    </recipients>
    <ccs>
      <!--
        <email>menolakreply@orenosaito.co.jp</email>
      -->
    </ccs>
    <subject>Notification Script</subject>
    <body>
      <![CDATA[
        <strong><ins>Reminder</ins></strong>
        <br/>
        <br/>
        ${ReminderItem1}
        ${ReminderItem2}
      ]]>
    </body>
  </mailConfig>
</configuration>`

    config, err := ReadConfigRaw(xmlConfig)
    if err != nil {
        log.Fatal(err)
    }

    jsonBytes, err := json.Marshal(config)
    if err != nil {
        log.Fatal(err)
    }

    var buffer bytes.Buffer
    err = json.Indent(&buffer, jsonBytes, "", "  ")
    if err != nil {
        log.Fatal(err)
    }

    fmt.Println(buffer.String())
}
```

Output-nya

```json
{
  "SmtpConfig": {
    "Server": "smtp.orenosaito.co.jp",
    "Port": 587,
    "UserName": "SmtpUser_Admin",
    "Password": "100%SmtpPwd4Admin",
    "UseTls": false
  },
  "MailConfig": {
    "From": {
      "Email": "dontreply_notif@orenosaito.co.jp",
      "Name": "DO_NOT_Reply Notification Script"
    },
    "Recipients": {
      "Emails": [
        "menolakreply@orenosaito.co.jp"
      ]
    },
    "Ccs": {
      "Emails": null
    },
    "Subject": "Notification Script",
    "Body": "\n      \n        \u003cstrong\u003e\u003cins\u003eReminder\u003c/ins\u003e\u003c/strong\u003e\n        \u003cbr/\u003e\n        \u003cbr/\u003e\n        ${ReminderItem1}\n        ${ReminderItem2}\n      \n    "
  }
}
```
