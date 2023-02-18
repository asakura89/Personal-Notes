---
tags:
- Javascript
- Parser
date: 2023-07-29
---

# Simple Condition Parser

**Code:**

```javascript
function Parse(condition, obj) {
    var parseFunc = new Function("obj", `return ${condition}`);
    var result = parseFunc(obj);

    return result;
}

var example = { x: 6 };
console.log(Parse("obj.x > 5", example));
console.log(Parse("obj.x < 5", example));
console.log(Parse("obj.x === 6", example));
```

**Output:**

```javascript
true
false
true
```