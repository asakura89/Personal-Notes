---
tags:
- Typescript
- Regex
date: 2023-12-02
---

# Filter file extension

Regex:
- `([^\\]+)?\.map$`
- `([^\\]+)?\.min.js$`
- `([^\\]+)?\.css$`
- `(.+)\\([^\\]+).+\.[^\\]{2,}$` → file with extension

Code:

```javascript
import fs from "node:fs"

try {
    let content: string = fs.readFileSync("D:\\Personal-Notes\\Powershell\\_media\\file-list.txt", "utf8");
    let lines: string[] = content.split(/\r?\n/);
    let mapMatches: (string | null)[] = lines
        .map(item => item.trim())
        .filter(item => {
            let matching = item.match(/([^\\]+)?\.map$/g);
            return matching !== null;
        });

    console.log(mapMatches.length);

    let minJsMatches: (string | null)[] = lines
        .map(item => item.trim())
        .filter(item => {
            let matching = item.match(/([^\\]+)?\.min.js$/g);
            return matching !== null;
        });

    console.log(minJsMatches.length);

    let cssMatches: (string | null)[] = lines
        .map(item => item.trim())
        .filter(item => {
            let matching = item.match(/([^\\]+)?\.css$/g);
            return matching !== null;
        });

    console.log(cssMatches.length);

    let fileWithExtMatches: (string | null)[] = lines
        .map(item => item.trim())
        .filter(item => {
            let matching = item.match(/(.+)\\([^\\]+).+\.[^\\]{2,}$/g);
            return matching !== null;
        });

    console.log(fileWithExtMatches.length);
}
catch (err) {
    console.log(err);
}
```

Output-nya

```javascript
137
17
81
3370
```