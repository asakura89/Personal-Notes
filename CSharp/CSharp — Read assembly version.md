---
tags:
- CSharp
date: 2017-03-18
---

# Read assembly version

```c#
using System;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: AssemblyTitle("CSScratchpad")]
[assembly: AssemblyDescription("CSharp Scratchpad")]
[assembly: AssemblyCompany("asakura89 own's company")]
[assembly: AssemblyProduct("AssemblyVersion_CSScratchpad")]
[assembly: AssemblyVersion("1.0.2017.0111")]
[assembly: AssemblyFileVersion("1.0.2017.0111")]
[assembly: AssemblyInformationalVersion("1.0.2017.0111")]
[assembly: AssemblyCopyright("Copyright © asakura89 own's company 2017")]
[assembly: AssemblyTrademark("No TM yet")]
[assembly: AssemblyConfiguration("Release")]
//[assembly: Guid("a9340416-c17b-4bc1-a623-2ad601db2050")]
//[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]

void Main() {
    DateTime date = DateTime.Now;
    DateTime buildYearMo = new DateTime(date.Year, date.Month, 1);
    DateTime projectYear = new DateTime(2017, 7, 1);

    Console.WriteLine($"Actual Build Date (fist day of the month): {buildYearMo}");
    Console.WriteLine($"Project Started Date (fist day of the month): {projectYear}");

    Int32 major = 5;
    Int32 minor = 0;
    Int32 build = buildYearMo.Year;
    String revisionFirstCombination = (Convert.ToInt32(buildYearMo.Subtract(projectYear).TotalDays / 30) + 1).ToString().PadLeft(2, '0');
    String revisionSecondCombination = date.Day.ToString().PadLeft(2, '0');

    String generatedVersion = new StringBuilder()
        .Append(major).Append(".")
        .Append(minor).Append(".")
        .Append(build).Append(".")
        .Append(revisionFirstCombination).Append(revisionSecondCombination)
        .ToString();

    Console.WriteLine($"Generated Version: {generatedVersion}");
    Console.WriteLine($"Build Date constructed from version number: {projectYear.AddMonths(Convert.ToInt32(revisionFirstCombination))}");
    Console.WriteLine($"Current App Version: {AppVersion}");
}

static AssemblyVersionAttribute AsmVersion => Assembly
    .GetExecutingAssembly()
    .GetCustomAttributes(typeof(AssemblyVersionAttribute), false)
    .Cast<AssemblyVersionAttribute>()
    .SingleOrDefault();

static AssemblyFileVersionAttribute AsmFileVersion => Assembly
    .GetExecutingAssembly()
    .GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)
    .Cast<AssemblyFileVersionAttribute>()
    .SingleOrDefault();


public static String AppVersion =>
    AsmVersion != null ?
        AsmVersion.Version : AsmFileVersion != null ?
            AsmFileVersion.Version : "1.0.0.0";
```



Output

```markdown
Actual Build Date (fist day of the month): 01/12/2022 12:00:00 AM
Project Started Date (fist day of the month): 01/07/2017 12:00:00 AM
Generated Version: 5.0.2022.6724
Build Date constructed from version number: 01/02/2023 12:00:00 AM
Current App Version: 1.0.2017.0111
```