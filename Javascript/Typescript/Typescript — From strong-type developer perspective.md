---
tags:
- Typesscript
date: 2023-11-20
---

# From strong-type developer perspective

Biasanya kita bakal menganggap type itu kaku dan statik dan strong type kaya gini

```typescript
interface Pointlike {
    x: number;
    y: number;
}

interface Named {
    name: string;
}

function logPoint(point: Pointlike): string {
    return `x = ${point.x}, y = ${point.y}`;
}

function logName(x: Named): string {
    return `Hello, ${x.name}`;
}

let pointObj = {
    x: 0,
    y: 0
};

let namedObj = {
    name: "Origin"
};

console.table({
    point: logPoint(pointObj),
    name: logName(namedObj)
});
```

Outputnya

```markdown
┌─────────┬─────────────────┐
│ (index) │     Values      │
├─────────┼─────────────────┤
│  point  │ 'x = 0, y = 0'  │
│  name   │ 'Hello, Origin' │
└─────────┴─────────────────┘
```

Tapi ternyata di typescript, type itu gak mesti melulu strong type tapi bisa structural type. Jadi bisa ditulis gini

```typescript
let obj = {
    x: 0,
    y: 0,
    name: "Origin"
};

console.table({
    point: logPoint(obj),
    name: logName(obj)
});
```

Tapi kalo diginiin, jadinya tetep strong type dan error.

```typescript
let obj: Pointlike = {
    x: 0,
    y: 0,
    name: "Origin" // error disini
};

console.table({
    point: logPoint(obj),
    name: logName(obj) // error disini
});
```

Begitupun ini

```typescript
let obj: Named = {
    x: 0, // error disini
    y: 0,
    name: "Origin"
};

console.table({
    point: logPoint(obj), // error disini
    name: logName(obj)
});
```

Gara-gara structural type, jadinya bisa gini

```typescript
interface Empty { }

let obj: Empty = {
    x: 0,
    y: 0,
    name: "Origin"
};
```

Tapi diginiin error 🤣🤣

```typescript
console.table({
    point: logPoint(obj), // error disini
    name: logName(obj), // error disini
    empty: ((o) => `x = ${o.x}, y = ${o.y}, name = ${o.name}`)(obj) // error disini
});
```

Di object property yang ketiga juga error karena obj type-nya `Empty`. `Empty` gak punya `x`, gak punya `y`, apalagi `name`.

Kecuali diginiin

```typescript
let obj = {
    x: 0,
    y: 0,
    name: "Origin"
};
```

Outputnya

```markdown
┌─────────┬───────────────────────────────┐
│ (index) │            Values             │
├─────────┼───────────────────────────────┤
│  point  │        'x = 0, y = 0'         │
│  name   │        'Hello, Origin'        │
│  empty  │ 'x = 0, y = 0, name = Origin' │
└─────────┴───────────────────────────────┘
```

Itu tadi kalo secara structural, yang sama adalah property-nya. Gimana kalo yang secara structural yang sama adalah method-nya? Ya sama juga. Maksudnya sama gakkan error secara typing, tapi bakal beda secara output.

```typescript
class Pointlike {
    log(): string {
        let obj = {
            x: 0,
            y: 0,
            name: "Origin"
        };

        return `x = ${obj.x}, y = ${obj.y}`;
    }
}

class Named {
    log(): string {
        let obj = {
            x: 0,
            y: 0,
            name: "Origin"
        };

        return `Hello, ${obj.name}`;
    }
}

let expected2BePointlikeButGotNamedInstead: Pointlike = new Named();

console.log(expected2BePointlikeButGotNamedInstead.log());
```

Outputnya

```markdown
Hello, Origin
```

Sebaliknya

```typescript
let expected2BeNamedButGotPointlikeInstead: Named = new Pointlike();

console.log(expected2BeNamedButGotPointlikeInstead.log());
```

Outputnya

```markdown
x = 0, y = 0
```

Kecuali class-nya punya property, maka secara structural udah gak bisa dibilang sama dan kalo saling di-assign, jadi error.

```typescript
class Pointlike {
    x: number;
    y: number;

    log(): string {
        return `x = ${this.x}, y = ${this.y}`;
    }
}

class Named {
    name: string;

    log(): string {
        return `Hello, ${this.name}`;
    }
}

let expected2BePointlikeMustBeGotPointlike: Pointlike = new Named(); // error disini

console.log(expected2BePointlikeMustBeGotPointlike.log());
```