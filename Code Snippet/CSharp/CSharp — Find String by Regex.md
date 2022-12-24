---
tags:
- Snippet
- CSharp
date: 2019-12-01
---

# Find String by Regex

```c#
var anonResult = new[] {
    "https://app-stg.localweb.net",
    "https://beta-app.devsvr.net",
    "https://beta-app-admin.devsvr.net",
    "https://web.shadowmonarch.io",
    "https://web-admin.shadowmonarch.io",
    "https://web-dev.shadowmonarch.io",
    "https://admin-dev.shadowmonarch.io",
    "https://api-stg.localweb.net",
    "https://web.api.io",
    "https://api.devsvr.net",
    "https://beta-api.devsvr.net",
    "https://hub.devsvr.net",
    "https://hub-admin.devsvr.net",
    "https://beta-hub.devsvr.net"
}
.Select(host => new {
    Host = host,
    Match = Regex.Match(host, ".+(shadow|monarch|devsvr).+")
})
.Select(match => new {
    match.Host,
    match.Match.Success,
    match.Match.Value
});
```



Kalo `anonResult` di dump ke JSON, kira-kira isinya gini.

```json
[
  {
    "Host": "https://app-stg.localweb.net",
    "Success": false,
    "Value": ""
  },
  {
    "Host": "https://beta-app.devsvr.net",
    "Success": true,
    "Value": "https://beta-app.devsvr.net"
  },
  {
    "Host": "https://beta-app-admin.devsvr.net",
    "Success": true,
    "Value": "https://beta-app-admin.devsvr.net"
  },
  {
    "Host": "https://web.shadowmonarch.io",
    "Success": true,
    "Value": "https://web.shadowmonarch.io"
  },
  {
    "Host": "https://web-admin.shadowmonarch.io",
    "Success": true,
    "Value": "https://web-admin.shadowmonarch.io"
  },
  {
    "Host": "https://web-dev.shadowmonarch.io",
    "Success": true,
    "Value": "https://web-dev.shadowmonarch.io"
  },
  {
    "Host": "https://admin-dev.shadowmonarch.io",
    "Success": true,
    "Value": "https://admin-dev.shadowmonarch.io"
  },
  {
    "Host": "https://api-stg.localweb.net",
    "Success": false,
    "Value": ""
  },
  {
    "Host": "https://web.api.io",
    "Success": false,
    "Value": ""
  },
  {
    "Host": "https://api.devsvr.net",
    "Success": true,
    "Value": "https://api.devsvr.net"
  },
  {
    "Host": "https://beta-api.devsvr.net",
    "Success": true,
    "Value": "https://beta-api.devsvr.net"
  },
  {
    "Host": "https://hub.devsvr.net",
    "Success": true,
    "Value": "https://hub.devsvr.net"
  },
  {
    "Host": "https://hub-admin.devsvr.net",
    "Success": true,
    "Value": "https://hub-admin.devsvr.net"
  },
  {
    "Host": "https://beta-hub.devsvr.net",
    "Success": true,
    "Value": "https://beta-hub.devsvr.net"
  }
]
```