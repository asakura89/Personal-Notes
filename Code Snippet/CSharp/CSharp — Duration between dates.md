---
tags:
- Snippet
- CSharp
date: 2016-08-19
---

# Duration between dates

```c#
using System.Globalization;

void Main() {
    var (year, month) = GetDuration(new DateTime(2021, 2, 1), new DateTime(2022, 3, 1));
    String durString = GetDurationString(year, month);
    Console.WriteLine(durString);
}

(Int32 Year, Int32 Month) GetDuration(DateTime start, DateTime end) {
    TimeSpan span = end.Subtract(start);
    Int32 year = (span.Days / 365);
    Int32 month = ((span.Days % 365) / 30);

    return (Year: year, Month: month);
}

String GetDurationString(Int32 year, Int32 month) {
    var syear = (year == 0 ? String.Empty : $"{year.ToString(CultureInfo.InvariantCulture)} year{(year > 1 ? "s" : String.Empty)} ");
    var smonth = (month == 0 ? String.Empty : $"{month.ToString(CultureInfo.InvariantCulture)} month{(month > 1 ? "s" : String.Empty)}");

    return (syear + smonth).Trim();
}
```



Menghasilkan inih

```markdown
1 year
```



# Total duration

```c#
void Main() {
    var list = new List<(Int32, Int32)> {
        GetDuration(new DateTime(2006, 6, 1), new DateTime(2008, 6, 1)),
        GetDuration(new DateTime(2008, 6, 1), new DateTime(2011, 5, 1)),
        GetDuration(new DateTime(2010, 4, 19), new DateTime(2011, 8, 21)),
        GetDuration(new DateTime(2012, 6, 19), new DateTime(2014, 2, 15)),
        GetDuration(new DateTime(2014, 2, 15), new DateTime(2015, 2, 15)),
        GetDuration(new DateTime(2015, 2, 16), new DateTime(2017, 6, 20)),
        GetDuration(new DateTime(2017, 7, 3), new DateTime(2018, 8, 31)),
        GetDuration(new DateTime(2018, 11, 1), new DateTime(2020, 4, 1)),
        GetDuration(new DateTime(2020, 4, 1), new DateTime(2021, 2, 1)),
        GetDuration(new DateTime(2021, 2, 1), new DateTime(2022, 3, 1)),
        GetDuration(new DateTime(2022, 3, 1), DateTime.Now)
    };

    var (year, month) = GetTotalDuration(list);
    String durString = GetDurationString(year, month);
    Console.WriteLine(durString);
}

(Int32 Year, Int32 Month) GetTotalDuration(IEnumerable<(Int32, Int32)> durationList) {
    Func<(Int32 Year, Int32 Month), (Int32 Year, Int32 Month), (Int32 Year, Int32 Month)> reducer = (acc, curr) =>
        (Year: acc.Year + curr.Year, Month: acc.Month + curr.Month);

    (Int32 Year, Int32 Month) rawDuration = durationList.Aggregate((0, 0), reducer);
    (Int32 Year, Int32 Month) totalDuration = (Year: rawDuration.Year + Convert.ToInt32(Math.Floor(rawDuration.Month / 12M)), Month: (rawDuration.Month % 12));

    return totalDuration;
}

(Int32 Year, Int32 Month) GetDuration(DateTime start, DateTime end) {
    TimeSpan span = end.Subtract(start);
    Int32 year = (span.Days / 365);
    Int32 month = ((span.Days % 365) / 30);

    return (Year: year, Month: month);
}

String GetDurationString(Int32 year, Int32 month) {
    var syear = (year == 0 ? String.Empty : $"{year.ToString(CultureInfo.InvariantCulture)} year{(year > 1 ? "s" : String.Empty)} ");
    var smonth = (month == 0 ? String.Empty : $"{month.ToString(CultureInfo.InvariantCulture)} month{(month > 1 ? "s" : String.Empty)}");

    return (syear + smonth).Trim();
}
```



Output

```markdown
16 years 4 months
```



## Duration parser

```c#
void Main() {
    var years = GetYears("16 years 4 months");
    var months = GetMonths("16 years 4 months");

    Console.WriteLine($"{years} tahun, {months} bulan");
}

Int32 GetYears(String duration) {
    var rgx = new Regex(@"(?:\d{1,}\s(?!month[Ss]?))", RegexOptions.Compiled);
    Match m = rgx.Match(duration);
    return m.Captures.Count > 0 ? Convert.ToInt32(m.Captures[0].Value) : 0;
}

Int32 GetMonths(String duration) {
    var rgx = new Regex(@"(?:\d{1,}\s(?!year[Ss]?))", RegexOptions.Compiled);
    Match m = rgx.Match(duration);
    return m.Captures.Count > 0 ? Convert.ToInt32(m.Captures[0].Value) : 0;
}
```



Output

```markdown
16 tahun, 4 bulan
```