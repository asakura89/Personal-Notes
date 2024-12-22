---
tags:
- Typescript
- NodeJs
date: 2023-12-03
---

# Read file

```javascript
import fs from "node:fs"

try {
    let content: string = fs.readFileSync("D:\\Personal-Notes\\Powershell\\_media\\file-list.txt", "utf8");
    let lines: string[] = content.split(/\r?\n/);
    console.log(lines.length);
}
catch (err) {
    console.log(err);
}
```

Output-nya

```javascript
4235
```