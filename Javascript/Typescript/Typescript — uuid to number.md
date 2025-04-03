---
tags:
- Typescript
- Deno
date: 2025-04-02
---

# uuid to number

```javascript
const uuid = crypto.randomUUID();
const num = BigInt('0x' + uuid.replace(/-/g, ''));
console.table({
    uuid: uuid,
    num: num,
    strnum: num.toString()
});

const Feigenbaum: number = 46692016;
const BigMath = {
    abs(bigN: bigint): bigint {
        return bigN < 0n ? -bigN : bigN;
    }
};

console.table({
    num2: BigMath.abs(num % BigInt(Feigenbaum)),
    strnum2: BigMath.abs(num % BigInt(Feigenbaum)).toString()
});
```

Output pertama

```markdown
┌────────┬──────────────────────────────────────────┐
│ (idx)  │ Values                                   │
├────────┼──────────────────────────────────────────┤
│ uuid   │ "2a031e1e-46ce-4297-82d4-113c7b954fe5"   │
│ num    │ 55843763584588360000296506063532150757n  │
│ strnum │ "55843763584588360000296506063532150757" │
└────────┴──────────────────────────────────────────┘
```

Output kedua

```
┌─────────┬────────────┐
│ (idx)   │ Values     │
├─────────┼────────────┤
│ num2    │ 34558645n  │
│ strnum2 │ "34558645" │
└─────────┴────────────┘
```



**Reference:**

- [Is there a library similar to Math that supports JavaScript BigInt? - Stack Overflow](https://stackoverflow.com/questions/51867270/is-there-a-library-similar-to-math-that-supports-javascript-bigint)
- [What's the Math.abs() Alternative for BigInt Values in JavaScript? - Designcise](https://www.designcise.com/web/tutorial/what-is-the-math-abs-alternative-for-bigint-values-in-javascript)
