---
tags:
- CSharp
- LINQPad
date: 2022-12-24
---

# Benchmarkdotnet in LINQPad

```c#
void Main() {
    Environment.CurrentDirectory = Directory.CreateDirectory(GetPathBasedOnExeOrQuery()).FullName;
    BenchmarkRunner.Run<StringCompare>();
}

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[SimpleJob(RuntimeMoniker.Net461)]
public class StringCompare {
    [Benchmark]
    public void CompareUsingToLower() {
        Boolean same = "Hello".ToLower() == "hELLO".ToLower();
    }

    [Benchmark]
    public void CompareUsingToUpper() {
        Boolean same = "Hello".ToUpper() == "hELLO".ToUpper();
    }

    [Benchmark]
    public void CompareUsingEquals() {
        Boolean same = "Hello".Equals("hELLO", StringComparison.OrdinalIgnoreCase);
    }
}

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

