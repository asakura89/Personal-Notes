---
tags:
- CSharp
- C#
- Filename
- Extension
date: 2023-09-06
---

# Filename and Extension

```c#
using System.IO;

void Main() {
    Console.WriteLine(
        new StringBuilder()
            .AppendLine(
                Path.GetFileName(@"D:\Temp\MainArtifact.zip"))
            .AppendLine(
                Path.GetFileNameWithoutExtension(@"D:\Temp\upgrade.bundle.js"))
            .AppendLine(
                Path.ChangeExtension(@"D:\Temp\main.css", null))
            .ToString());
}
```

Contoh hasil run

```c#
MainArtifact.zip
upgrade.bundle
D:\Temp\main
```