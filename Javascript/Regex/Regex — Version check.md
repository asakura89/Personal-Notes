---
tags:
- Javascript
- Regex
date: 2023-12-02
---

# Version check

Regex: `(?:\d{1,}\.){2}\d{1,}(?:.+)?`

Code:

```javascript
console.log(
    [
        "jquery.js",
        "jquery.min.js",
        " jquery-1.5.6.js",
        "jquery-1.5.6.min.js ",
        "bootstrap-main.css",
        " tailwind.min.css"
    ]
    .map(item => item.trim())
    .filter(item => item.endsWith(".js") || item.endsWith(".min.js"))
    .map(item => {
        let matching = item.match(/(?:\d{1,}\.){2}\d{1,}(?:.+)?/g);
        return matching === null ? null : matching[0];
    })
);
```

Output-nya

```javascript
[ null, null, '1.5.6.js', '1.5.6.min.js' ]
```