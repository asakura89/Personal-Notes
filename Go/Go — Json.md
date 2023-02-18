---
tags:
- Golang
- Json
date: 2023-12-24
---

# Json

> ❗ Note
> 
> go version = 1.21.0

```go
package main

import (
    "bytes"
    "encoding/json"
    "fmt"
    "log"
)

type EmailStruct struct {
    Email string
    Name string
}

type MailConfig struct {
    From EmailStruct
    Recipients []EmailStruct
    Ccs []EmailStruct
    Subject string
    Body string
}

type Configuration struct {
    MailConfig MailConfig
}

func main() {
    config := Configuration{
        MailConfig: MailConfig{
            From: EmailStruct{
                Email: "dontreply_notif@orenosaito.co.jp",
                Name:  "DO_NOT_Reply Notification Script",
            },
            Recipients: []EmailStruct{
                {
                    Email: "menolakreply@orenosaito.co.jp",
                    Name:  "",
                },
            },
            Ccs: []EmailStruct{
                {
                    Email: "menolakreply@orenosaito.co.jp",
                    Name:  "",
                },
            },
            Subject: "Notification Script",
            Body: `<strong><ins>Reminder</ins></strong>
            <br/>
            <br/>
            ${ReminderItem1}
            ${ReminderItem2}`,
        },
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

    jsonString := buffer.String()

    fmt.Println(jsonString)
}
```

Output-nya

```json
{
  "MailConfig": {
    "From": {
      "Email": "dontreply_notif@orenosaito.co.jp",
      "Name": "DO_NOT_Reply Notification Script"
    },
    "Recipients": [
      {
        "Email": "menolakreply@orenosaito.co.jp",
        "Name": ""
      }
    ],
    "Ccs": [
      {
        "Email": "menolakreply@orenosaito.co.jp",
        "Name": ""
      }
    ],
    "Subject": "Notification Script",
    "Body": "\u003cstrong\u003e\u003cins\u003eReminder\u003c/ins\u003e\u003c/strong\u003e\n            \u003cbr/\u003e\n            \u003cbr/\u003e\n            ${ReminderItem1}\n            ${ReminderItem2}"
  }
}
```
