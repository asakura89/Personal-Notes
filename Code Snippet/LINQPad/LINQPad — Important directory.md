---
tags:
- Snippet
- CSharp
- LINQPad
date: 2022-12-24
---

# Important directory

## LINQPad.exe directory

```c#
void Main() {
    AppDomain.CurrentDomain.BaseDirectory.Dump();
    LINQPad.Util.LINQPadFolder.Dump();
}
```

Output

```markdown
D:\Tools\LINQPad5-AnyCPU\
D:\Tools\LINQPad5-AnyCPU
```



## LINQPad query directory

```c#
void Main() {
    Path.GetDirectoryName(LINQPad.Util.CurrentQueryPath).Dump();
}
```

Output

```markdown
null // akan null kalo query-nya belom di-save ke file
D:\LinqpadCollection\LogicTest // kalo query-nya di-save ke file
```



## Path based on LINQPad.exe or its query

```c#
String GetPathBasedOnExeOrQuery() {
    String
        queryDir = Path.GetDirectoryName(LINQPad.Util.LINQPadFolder),
        queryName = "Untitled";

    if (!String.IsNullOrEmpty(LINQPad.Util.CurrentQueryPath)) {
        queryDir = Path.GetDirectoryName(LINQPad.Util.CurrentQueryPath);
        queryName = Path.GetFileNameWithoutExtension(LINQPad.Util.CurrentQueryPath);
        // queryName = LINQPad.Util.CurrentQuery.Name // or simply this
    }

    String finalPath = Path.Combine(queryDir, queryName);
    finalPath += "_" + DateTime.Now.ToString("yyyyMMddHHmmss");

    return finalPath;
}
```

Output

```markdown
D:\LinqpadCollection\LogicTest\Untitled_20221224141355 // akan null kalo query-nya belom di-save ke file
D:\LinqpadCollection\LogicTest\datedurations_20221224141355 // kalo query-nya di-save ke file
```