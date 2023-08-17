---
tags:
- Javascript
- Typescript
date: 2023-08-17
---

# Typescript types

**Code:**

```typescript
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
