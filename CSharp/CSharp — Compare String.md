---
tags:
- C#
- CSharp
- Benchmark
date: 2022-12-24
---

# Compare String

Barusan gak sengaja baca soal compare string. Katanya, pake `"<some string>".ToLower() == "<SoME STrinG>".ToLower()` atau `"<some string>".ToUpper() == "<SoME STrinG>".ToUpper()`lebih lelet dari `"<some string>".Equals("<SoME STrinG>", StringComparison.OrdinalIgnoreCase)`.

Apakah betul? Let's see.

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="BenchmarkDotNet" version="0.13.1" targetFramework="net472" />
  <package id="BenchmarkDotNet.Annotations" version="0.13.1" targetFramework="net472" />
</packages>
```

```c#
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

void Main() {
    BenchmarkRunner.Run<StringCompare>();
}

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
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
```

Menghasilkan inih

```markdown
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.2364 (21H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]               : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT  [AttachedDebugger]
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT

Job=.NET Framework 4.6.1  Runtime=.NET Framework 4.6.1
```

|              Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|-------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|  CompareUsingEquals |  33.10 ns |  5.715 ns |  16.85 ns |  26.37 ns |      - |         - |
| CompareUsingToUpper | 465.80 ns | 69.630 ns | 205.31 ns | 414.40 ns | 0.0229 |      48 B |
| CompareUsingToLower | 509.97 ns | 69.854 ns | 205.96 ns | 507.15 ns | 0.0229 |      48 B |

Wah bener dong. `Equals` cuma 33 nanoseconds (kolom Mean), sedangkan yang lain 400, 500-an. Terus juga kalo ngeliat kolom Allocated, ada alokasi memory sekitar 48 Bytes. Kecil sih, tapi kalo ditaro di dalem looping data yang sekian ribu bisa jadi makan banyak memory juga.