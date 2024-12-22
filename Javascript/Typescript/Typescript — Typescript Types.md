---
tags:
- Typescript
date: 2023-08-17
---

# Typescript types

- [Various types](#various-types)
- [From strong-type developer perspective](#from-strong-type-developer-perspective)



## Various types

**Code:**

```javascript
let threshold: number = 80; // Number
let message: string = "Yahharo Typescript and Javascript"; // String
let isSuperhero: boolean = true; // Booelan
let numbers: number[] = [1, 2, 3, 4, 5]; // Number Array
let messages: string[] = ["It is what it is", "Smile everyday", "You're the one who has control over your happiness"]; // String Array
let resultAndErr: [number, string] = [40, "succeed"]; // Tuple
let user: { name: string, age: number } = { name: "Clark Kent", age = 32 }; // Object
let dynamicObj: any = { message: "this can be object", limit: 35, output: "or can be anything" }; // Dynamic object or primitive type
let nullValue: null = null; // Null
let undefinedOrUnassigned: undefined = undefined; // Undefined

// Void
function SetThreshold(updatedValue: number): void {
    threshold = updatedValue;
}

// With return value
function GetThreshold(): number {
    return threshold;
}
```



## From strong-type developer perspective

Biasanya kita bakal menganggap type itu kaku dan statik dan strong type kaya gini

```javascript
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

Output-nya

```javascript
┌─────────┬─────────────────┐
│ (index) │     Values      │
├─────────┼─────────────────┤
│  point  │ 'x = 0, y = 0'  │
│  name   │ 'Hello, Origin' │
└─────────┴─────────────────┘
```

Tapi ternyata di typescript, type itu gak mesti melulu strong type tapi bisa structural type. Jadi bisa ditulis gini

```javascript
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

```javascript
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

```javascript
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

```javascript
interface Empty { }

let obj: Empty = {
    x: 0,
    y: 0,
    name: "Origin"
};
```

Tapi diginiin error 🤣🤣

```javascript
console.table({
    point: logPoint(obj), // error disini
    name: logName(obj), // error disini
    empty: ((o) => `x = ${o.x}, y = ${o.y}, name = ${o.name}`)(obj) // error disini
});
```

Di object property yang ketiga juga error karena obj type-nya `Empty`. `Empty` gak punya `x`, gak punya `y`, apalagi `name`.

Kecuali diginiin

```javascript
let obj = {
    x: 0,
    y: 0,
    name: "Origin"
};
```

Output-nya

```javascript
┌─────────┬───────────────────────────────┐
│ (index) │            Values             │
├─────────┼───────────────────────────────┤
│  point  │        'x = 0, y = 0'         │
│  name   │        'Hello, Origin'        │
│  empty  │ 'x = 0, y = 0, name = Origin' │
└─────────┴───────────────────────────────┘
```

Itu tadi kalo secara structural, yang sama adalah property-nya. Gimana kalo yang secara structural yang sama adalah method-nya? Ya sama juga. Maksudnya sama gakkan error secara typing, tapi bakal beda secara output.

```javascript
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

Output-nya

```javascript
Hello, Origin
```

Sebaliknya

```javascript
let expected2BeNamedButGotPointlikeInstead: Named = new Pointlike();

console.log(expected2BeNamedButGotPointlikeInstead.log());
```

Output-nya

```javascript
x = 0, y = 0
```

Kecuali class-nya punya property, maka secara structural udah gak bisa dibilang sama dan kalo saling di-assign, jadi error.

```javascript
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