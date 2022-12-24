---
tags:
- Snippet
- CSharp
- LINQPad
date: 2022-12-24
---

# Query saved checker

```c#
void Main() {
    // 1st way
    Boolean savedFirst = !String.IsNullOrEmpty(LINQPad.Util.CurrentQueryPath);

    // 2nd way
    Boolean savedSecond = !String.IsNullOrEmpty(LINQPad.Util.CurrentQuery.Name);

    new {
        Saved = savedFirst,
        SavedAgain = savedSecond
    }
    .Dump();
}
```

Output

| ø          |      |
|----------- |----- |
| Saved      | True |
| SavedAgain | True |

