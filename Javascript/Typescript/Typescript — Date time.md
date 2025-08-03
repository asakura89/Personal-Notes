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


```javascript
console.table([
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("12:35"),
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("00:00"),
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("23:59"),
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("12"),
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("03"),
    /^\d{1,2}:\d{2}$|^\d{1,2}$/.test("4")
]);

console.table([
    "12:35".split(":"),
    "00:00".split(":"),
    "23:59".split(":"),
    "12".split(":"),
    "03".split(":"),
    "4".split(":")
]);
```

```javascript
┌─────────┬────────┐
│ (index) │ Values │
├─────────┼────────┤
│ 0       │ true   │
│ 1       │ true   │
│ 2       │ true   │
│ 3       │ true   │
│ 4       │ true   │
│ 5       │ true   │
└─────────┴────────┘
┌─────────┬──────┬──────┐
│ (index) │ 0    │ 1    │
├─────────┼──────┼──────┤
│ 0       │ '12' │ '35' │
│ 1       │ '00' │ '00' │
│ 2       │ '23' │ '59' │
│ 3       │ '12' │      │
│ 4       │ '03' │      │
│ 5       │ '4'  │      │
└─────────┴──────┴──────┘
```