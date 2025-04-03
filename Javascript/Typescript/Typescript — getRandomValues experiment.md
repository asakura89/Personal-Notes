---
tags:
- Typescript
- Deno
date: 2025-04-02
---

# getRandomValues experiment

```javascript
let length = 12;
let arr = new Uint8Array((length || 12) / 2);
console.table({
    arr: arr,
    hxArr: '',
    join: ''
});
crypto.getRandomValues(arr);
let hxArr = Array.from(arr).map(i => i.toString(16)); // convert to hex
console.table({
    arr: arr,
    hxArr: hxArr,
    join: hxArr.join('')
});
```

Output pertama

```markdown
┌───────┬───┬───┬───┬───┬───┬───┬────────┐
│ (idx) │ 0 │ 1 │ 2 │ 3 │ 4 │ 5 │ Values │
├───────┼───┼───┼───┼───┼───┼───┼────────┤
│ arr   │ 0 │ 0 │ 0 │ 0 │ 0 │ 0 │        │
│ hxArr │   │   │   │   │   │   │ ""     │
│ join  │   │   │   │   │   │   │ ""     │
└───────┴───┴───┴───┴───┴───┴───┴────────┘
```

Output kedua

```markdown
┌───────┬──────┬──────┬──────┬──────┬──────┬──────┬────────────────┐
│ (idx) │ 0    │ 1    │ 2    │ 3    │ 4    │ 5    │ Values         │
├───────┼──────┼──────┼──────┼──────┼──────┼──────┼────────────────┤
│ arr   │ 30   │ 175  │ 201  │ 138  │ 244  │ 44   │                │
│ hxArr │ "1e" │ "af" │ "c9" │ "8a" │ "f4" │ "2c" │                │
│ join  │      │      │      │      │      │      │ "1eafc98af42c" │
└───────┴──────┴──────┴──────┴──────┴──────┴──────┴────────────────┘
```

