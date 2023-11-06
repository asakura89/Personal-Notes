---
tags:
- Javascript
- Datetime
- Epoch
date: 2023-11-06
---

# Unix epoch to Date time

```javascript
var ep = 1696305394.188467;
console.log(
    new Date(ep * 1000)
        .toLocaleString('en-US', {
            timeZone: 'Asia/Bangkok', hour12: false }));
```

Buat nge-validate bisa kesini [Epoch Converter - Unix Timestamp Converter](https://www.epochconverter.com/)