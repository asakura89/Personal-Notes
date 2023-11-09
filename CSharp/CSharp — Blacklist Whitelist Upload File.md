---
tags:
- CSharp
- C#
date: 2023-11-09
---

# Blacklist Whitelist Upload File

## 1. Blacklist

**Code:**

```c#
Func<String, Boolean> IsOneOfBlackListed = filename => {
    var blacklist = new[] { ".exe", ".com", ".dll", ".bin", ".cmd" };
    return filename
        .Split('.')
        .Select(segment => blacklist.Contains("."+segment))
        .Aggregate(false, (acc, blacklisted) => acc || blacklisted);
};

var result = new StringBuilder()
    .AppendLine(IsOneOfBlackListed("Campaign.20231101.exe.pdf").ToString())
    .AppendLine(IsOneOfBlackListed(@"D:\CODE_PART_1 - Copy.IBB.docx.com").ToString())
    .AppendLine(IsOneOfBlackListed(@"D:\CODE_PART_1.IBB").ToString())
    .ToString();
    
Console.Write(result);
```

**Output:**

```xml
True
True
False
```



## 2. Whitelist

**Code:**

```c#
Func<String, Boolean> IsOneOfWhiteListed = filename => {
    var whitelist = new[] { ".pdf", ".png", ".jpg", ".jpeg", ".doc", ".docx", ".ppt", ".pptx", ".txt", ".xls", ".xlsx", ".csv" };
    return whitelist.Contains(
        Path.GetExtension(filename));
};

var result2 = new StringBuilder()
    .AppendLine(IsOneOfWhiteListed("Report.20231101.exe.pdf").ToString())
    .AppendLine(IsOneOfWhiteListed(@"D:\CODE_PART_1 - Copy.IBB.docx.com").ToString())
    .AppendLine(IsOneOfWhiteListed(@"D:\CODE_PART_1.IBB").ToString())
    .ToString();
    
Console.Write(result2);
```

**Output:**

```xml
True
False
False
```

