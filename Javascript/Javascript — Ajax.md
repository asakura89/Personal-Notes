---
tags:
- Javascript
- Ajax
date: 2023-07-01
---

# Ajax

Ajax itu sesimple ini

```javascript
var xhr = new XMLHttpRequest();
xhr.open("GET", "https://localhost:7091/ajax");
xhr.responseType = "application/xml";

xhr.onload = function() {
    if (xhr.status === 200) {
        var data = xhr.response;
        console.log(data);
    }
    else {
        console.error("Request failed: " + xhr.status);
    }
};

xhr.onerror = function() {
    console.error("Network error");
};

xhr.send();
```

Kalo mau setup API ala-alanya bisa pake ini [CSharp — Minimal API returns Xml](/CSharp/CSharp%20%E2%80%94%20Minimal%20API%20returns%20Xml.md)