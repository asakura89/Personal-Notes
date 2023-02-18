---
tags:
- Typescript
- NodeJs
date: 2023-11-20
---

# Buffer experiment

```javascript
class BufferExperiment {
    log() {
        let a: Buffer = Buffer.from("yahharo");
        let b: string = typeof a;
        let c: string = JSON.stringify(a);
        let d: string = `<Buffer ${Array.from(a).map(byte => byte.toString(16)).reduce((acc, item) => acc += item + " ", "").trim()}>`
        let e: string = d
            .match(/\s[0-9a-fA-F]+/g)
            ?.map(match => match.trim())
            .join("")!;
        let f: Buffer = Buffer.from(e, "hex");
        let g: number = Buffer.compare(a, f);

        console.log(a);
        console.table({
            a, b, c, d, e, f, g
        });
    }
}

let exp = new BufferExperiment();
exp.log();
```

Output-nya

```markdown
<Buffer 79 61 68 68 61 72 6f>
┌─────────┬─────┬────┬─────┬─────┬────┬─────┬─────┬────────────────────────────────────────────────────────┐
│ (index) │  0  │ 1  │  2  │  3  │ 4  │  5  │  6  │                         Values                         │
├─────────┼─────┼────┼─────┼─────┼────┼─────┼─────┼────────────────────────────────────────────────────────┤
│    a    │ 121 │ 97 │ 104 │ 104 │ 97 │ 114 │ 111 │                                                        │
│    b    │     │    │     │     │    │     │     │                        'object'                        │
│    c    │     │    │     │     │    │     │     │ '{"type":"Buffer","data":[121,97,104,104,97,114,111]}' │
│    d    │     │    │     │     │    │     │     │            '<Buffer 79 61 68 68 61 72 6f>'             │
│    e    │     │    │     │     │    │     │     │                    '7961686861726f'                    │
│    f    │ 121 │ 97 │ 104 │ 104 │ 97 │ 114 │ 111 │                                                        │
│    g    │     │    │     │     │    │     │     │                           0                            │
└─────────┴─────┴────┴─────┴─────┴────┴─────┴─────┴────────────────────────────────────────────────────────┘
```