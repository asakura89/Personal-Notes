---
tags:
- Typescript
date: 2023-12-13
---

# Print table

Versi typescript-nya

```javascript
function drawTable(data: (string | number)[][]): void {
    const horizontal: string = '─';
    const vertical: string = '│';
    const topLeft: string = '┌';
    const topRight: string = '┐';
    const bottomLeft: string = '└';
    const bottomRight: string = '┘';
    const tDown: string = '┬';
    const tUp: string = '┴';
    const tRight: string = '├';
    const tLeft: string = '┤';
    const cross: string = '┼';

    let colLengths: number[] = data[0].map((_, i) => Math.max(...data.map(row => String(row[i]).length)));

    let topBorder: string = topLeft + colLengths.map(len => horizontal.repeat(len + 2)).join(tDown) + topRight;
    console.log(topBorder);

    for (let i = 0; i < data.length; i++) {
        let row: (string | number)[] = data[i];
        let line: string = vertical + row.map((cell, j) => ' ' + cell + ' '.repeat(colLengths[j] - String(cell).length + 1)).join(vertical) + vertical;
        console.log(line);
        if (i < data.length - 1) {
            let separator: string = tRight + colLengths.map(len => horizontal.repeat(len + 2)).join(cross) + tLeft;
            console.log(separator);
        }
    }

    let bottomBorder: string = bottomLeft + colLengths.map(len => horizontal.repeat(len + 2)).join(tUp) + bottomRight;
    console.log(bottomBorder);
}

drawTable([
    ['Name', 'Age', 'City'],
    ['Alice', 23, 'New York'],
    ['Bob', 27, 'San Francisco']
]);
```

Versi javascript-nya

```javascript
"use strict";
function drawTable(data) {
    var horizontal = '─';
    var vertical = '│';
    var topLeft = '┌';
    var topRight = '┐';
    var bottomLeft = '└';
    var bottomRight = '┘';
    var tDown = '┬';
    var tUp = '┴';
    var tRight = '├';
    var tLeft = '┤';
    var cross = '┼';
    var colLengths = data[0].map(function (_, i) { return Math.max.apply(Math, data.map(function (row) { return String(row[i]).length; })); });
    var topBorder = topLeft + colLengths.map(function (len) { return horizontal.repeat(len + 2); }).join(tDown) + topRight;
    console.log(topBorder);
    for (var i = 0; i < data.length; i++) {
        var row = data[i];
        var line = vertical + row.map(function (cell, j) { return ' ' + cell + ' '.repeat(colLengths[j] - String(cell).length + 1); }).join(vertical) + vertical;
        console.log(line);
        if (i < data.length - 1) {
            var separator = tRight + colLengths.map(function (len) { return horizontal.repeat(len + 2); }).join(cross) + tLeft;
            console.log(separator);
        }
    }
    var bottomBorder = bottomLeft + colLengths.map(function (len) { return horizontal.repeat(len + 2); }).join(tUp) + bottomRight;
    console.log(bottomBorder);
}
drawTable([
    ['Name', 'Age', 'City'],
    ['Alice', 23, 'New York'],
    ['Bob', 27, 'San Francisco']
]);
```

Output-nya

```javascript
┌───────┬─────┬───────────────┐
│ Name  │ Age │ City          │
├───────┼─────┼───────────────┤
│ Alice │ 23  │ New York      │
├───────┼─────┼───────────────┤
│ Bob   │ 27  │ San Francisco │
└───────┴─────┴───────────────┘
```

Alternatifnya ini

Versi typescript-nya

```javascript
function drawTable(data: (string | number)[][]): void {
    const horizontal: string = '─';
    const vertical: string = '│';
    const topLeft: string = '┌';
    const topRight: string = '┐';
    const bottomLeft: string = '└';
    const bottomRight: string = '┘';
    const tDown: string = '┬';
    const tUp: string = '┴';

    let colLengths: number[] = data[0].map((_, i) => Math.max(...data.map(row => String(row[i]).length)));

    let topBorder: string = topLeft + colLengths.map(len => horizontal.repeat(len + 2)).join(tDown) + topRight;
    console.log(topBorder);

    for (let row of data) {
        let line: string = vertical + row.map((cell, i) => ' ' + cell + ' '.repeat(colLengths[i] - String(cell).length + 1)).join(vertical) + vertical;
        console.log(line);
    }

    let bottomBorder: string = bottomLeft + colLengths.map(len => horizontal.repeat(len + 2)).join(tUp) + bottomRight;
    console.log(bottomBorder);
}

drawTable([
    ['Name', 'Age', 'City'],
    ['Alice', 23, 'New York'],
    ['Bob', 27, 'San Francisco']
]);
```

Versi javascript-nya

```javascript
"use strict";
function drawTable(data) {
    var horizontal = '─';
    var vertical = '│';
    var topLeft = '┌';
    var topRight = '┐';
    var bottomLeft = '└';
    var bottomRight = '┘';
    var tDown = '┬';
    var tUp = '┴';
    var colLengths = data[0].map(function (_, i) { return Math.max.apply(Math, data.map(function (row) { return String(row[i]).length; })); });
    var topBorder = topLeft + colLengths.map(function (len) { return horizontal.repeat(len + 2); }).join(tDown) + topRight;
    console.log(topBorder);
    for (var _i = 0, data_1 = data; _i < data_1.length; _i++) {
        var row = data_1[_i];
        var line = vertical + row.map(function (cell, i) { return ' ' + cell + ' '.repeat(colLengths[i] - String(cell).length + 1); }).join(vertical) + vertical;
        console.log(line);
    }
    var bottomBorder = bottomLeft + colLengths.map(function (len) { return horizontal.repeat(len + 2); }).join(tUp) + bottomRight;
    console.log(bottomBorder);
}
drawTable([
    ['Name', 'Age', 'City'],
    ['Alice', 23, 'New York'],
    ['Bob', 27, 'San Francisco']
]);
```

Output-nya

```typescript
┌───────┬─────┬───────────────┐
│ Name  │ Age │ City          │
│ Alice │ 23  │ New York      │
│ Bob   │ 27  │ San Francisco │
└───────┴─────┴───────────────┘
```

Unicode code buat masing-masing char, ini:
- "─" : U+2500
- "│" : U+2502
- "┌" : U+250C
- "┐" : U+2510
- "└" : U+2514
- "┘" : U+2518
- "┬" : U+252C
- "┴" : U+2534
- "├" : U+251C
- "┤" : U+2524
- "┼" : U+253C