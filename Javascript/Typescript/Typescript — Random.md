---
tags:
- Typescript
- Deno
date: 2025-04-08
---

# Random

```javascript
let lowerBound: number = 0;
let upperBound: number = 5;

let randArray: Int8Array<ArrayBuffer>;
let random: number;
let finalValue: number;

let i: number = 23;
let table: {}[] = [];
while (i > 0) {
    randArray = crypto.getRandomValues(new Int8Array(1));
    random = lowerBound + (randArray[0] % (upperBound - lowerBound + 1));
    finalValue = Math.abs(Math.floor(random));
    table.push({
        randArray,
        random,
        finalValue
    });

    i--;
}

console.table(table);
```

Output

```markdown
┌───────┬───────────────────────┬────────┬────────────┐
│ (idx) │ randArray             │ random │ finalValue │
├───────┼───────────────────────┼────────┼────────────┤
│     0 │ Int8Array(1) [ 16 ]   │      4 │          4 │
│     1 │ Int8Array(1) [ -70 ]  │     -4 │          4 │
│     2 │ Int8Array(1) [ -88 ]  │     -4 │          4 │
│     3 │ Int8Array(1) [ 33 ]   │      3 │          3 │
│     4 │ Int8Array(1) [ 55 ]   │      1 │          1 │
│     5 │ Int8Array(1) [ -67 ]  │     -1 │          1 │
│     6 │ Int8Array(1) [ -101 ] │     -5 │          5 │
│     7 │ Int8Array(1) [ -48 ]  │      0 │          0 │
│     8 │ Int8Array(1) [ -49 ]  │     -1 │          1 │
│     9 │ Int8Array(1) [ -18 ]  │      0 │          0 │
│    10 │ Int8Array(1) [ 67 ]   │      1 │          1 │
│    11 │ Int8Array(1) [ 71 ]   │      5 │          5 │
│    12 │ Int8Array(1) [ 127 ]  │      1 │          1 │
│    13 │ Int8Array(1) [ -44 ]  │     -2 │          2 │
│    14 │ Int8Array(1) [ -41 ]  │     -5 │          5 │
│    15 │ Int8Array(1) [ -110 ] │     -2 │          2 │
│    16 │ Int8Array(1) [ -69 ]  │     -3 │          3 │
│    17 │ Int8Array(1) [ 0 ]    │      0 │          0 │
│    18 │ Int8Array(1) [ 84 ]   │      0 │          0 │
│    19 │ Int8Array(1) [ 49 ]   │      1 │          1 │
│    20 │ Int8Array(1) [ 34 ]   │      4 │          4 │
│    21 │ Int8Array(1) [ -40 ]  │     -4 │          4 │
│    22 │ Int8Array(1) [ 92 ]   │      2 │          2 │
└───────┴───────────────────────┴────────┴────────────┘
```

kalo mau nyamain sama `int` yang ada di c#, which 32 bit, berarti ganti `Int8Array` ajadi `Int32Array`


```javascript
let lowerBound: number = 0;
let upperBound: number = 5;

let randArray: Int32Array<ArrayBuffer>;
let random: number;
let finalValue: number;

let i: number = 23;
let table: {}[] = [];
while (i > 0) {
    randArray = crypto.getRandomValues(new Int32Array(1));
    random = lowerBound + (randArray[0] % (upperBound - lowerBound + 1));
    finalValue = Math.abs(Math.floor(random));
    table.push({
        randArray,
        random,
        finalValue
    });

    i--;
}

console.table(table);
```

Output

```markdown
┌───────┬───────────────────────────────┬────────┬────────────┐
│ (idx) │ randArray                     │ random │ finalValue │
├───────┼───────────────────────────────┼────────┼────────────┤
│     0 │ Int32Array(1) [ -32284672 ]   │     -4 │          4 │
│     1 │ Int32Array(1) [ -1958653030 ] │     -4 │          4 │
│     2 │ Int32Array(1) [ 1654187747 ]  │      5 │          5 │
│     3 │ Int32Array(1) [ -255553167 ]  │     -3 │          3 │
│     4 │ Int32Array(1) [ -865047151 ]  │     -1 │          1 │
│     5 │ Int32Array(1) [ -1543528775 ] │     -5 │          5 │
│     6 │ Int32Array(1) [ -2095871272 ] │     -4 │          4 │
│     7 │ Int32Array(1) [ 59756168 ]    │      2 │          2 │
│     8 │ Int32Array(1) [ -1653453605 ] │     -5 │          5 │
│     9 │ Int32Array(1) [ -700612706 ]  │     -2 │          2 │
│    10 │ Int32Array(1) [ -548068525 ]  │     -1 │          1 │
│    11 │ Int32Array(1) [ -798623950 ]  │     -4 │          4 │
│    12 │ Int32Array(1) [ -568606627 ]  │     -1 │          1 │
│    13 │ Int32Array(1) [ -1961448963 ] │     -3 │          3 │
│    14 │ Int32Array(1) [ -1496071874 ] │     -2 │          2 │
│    15 │ Int32Array(1) [ 1606283087 ]  │      5 │          5 │
│    16 │ Int32Array(1) [ 869108669 ]   │      5 │          5 │
│    17 │ Int32Array(1) [ 729123340 ]   │      4 │          4 │
│    18 │ Int32Array(1) [ 687853468 ]   │      4 │          4 │
│    19 │ Int32Array(1) [ 155162545 ]   │      1 │          1 │
│    20 │ Int32Array(1) [ -898076286 ]  │      0 │          0 │
│    21 │ Int32Array(1) [ 2007400837 ]  │      1 │          1 │
│    22 │ Int32Array(1) [ 1863098876 ]  │      2 │          2 │
└───────┴───────────────────────────────┴────────┴────────────┘
```
