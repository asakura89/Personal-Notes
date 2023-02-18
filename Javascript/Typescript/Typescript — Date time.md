---
tags:
- Typescript
date: 2024-12-23
---

# Date time

```javascript
const dateISO = new Date().toISOString();
const readable = dateISO
    .replace(/[\.Z]/gm, "")
    .replace(/\-/gm, ".")
    .replace(/T/gm, ".")
    .slice(0, 19);
const idFromDate = dateISO.replace(/[\.\-:TZ]/gm, "").slice(0, 14);

console.table({
    dateISO,
    readable,
    idFromDate
});
```

Output-nya

```javascript
┌────────────┬────────────────────────────┐
│ (idx)      │ Values                     │
├────────────┼────────────────────────────┤
│ dateISO    │ "2024-12-22T21:21:36.329Z" │
│ readable   │ "2024.12.22.21:21:36"      │
│ idFromDate │ "20241222212136"           │
└────────────┴────────────────────────────┘
```