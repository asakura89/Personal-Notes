---
tags:
- CSharp
- C#
date: 2021-05-17
---

<p>
  <h1 style="text-align:center;font-size:1.25em;margin-top:24px;margin-bottom:16px;font-weight:600;line-height:1.25">Kelompok Belajar Bunga Matahari</h1>
  <h3 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">Coding sudah seharusnya menyenangkan!</h3>
  <h5 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">
    <a href="https://github.com/asakura89">asakura89</a> /
    <a href="https://opensource.org/licenses/0BSD">BSD Zero Clause</a>
  </h5>
</p>



# 001-20210517 — Collection Pipeline

## 1.1 Soal

Ekstrak nama-nama user yang diawali dengan karakter `@` seperti pada text berikut:

```C#
@Oreki-kun, @Satoshi-kun, @Mayaka call dikit yuuk. Nanti @Chi-chan nyusul aja.
```

Hasil yang diharapkan adalah berupa list nama-nama user tanpa tanda `@` seperti berikut:

```C#
"Oreki-kun", "Satoshi-kun", "Mayaka", "Chi-chan"
```



## 1.2 Jawaban

Lampirkan jawaban kalian di code berikut dengan mengikuti penjelasan di point 1.1. Dan hanya boleh menulis code di bagian `@CODE-HERE` saja.

```C#
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Quiz0010120210517 {
    class Program {
        static void Main(String[] args) {
            try {
                var text = "@Oreki-kun, @Satoshi-kun, @Mayaka call dikit yuuk. Nanti @Chi-chan nyusul aja.";
                var expectedUserNames = new[] { "Oreki-kun", "Satoshi-kun", "Mayaka", "Chi-chan" };

                var p = new Program();
                var userNames = p.ExtractUserNames(text);
                AssertEqual(userNames.Length, 4);

                Console.WriteLine("User names:");
                for (var i = 0; i < userNames.Length; i++) {
                    AssertEqual(userNames[i], expectedUserNames[i]);
                    Console.WriteLine($"    + {userNames[i]}");
                }

                Console.WriteLine("[DONE]");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public String[] ExtractUserNames(String text) {
            // @CODE-HERE

            return Regex
                .Matches(text, "@\\w+[-\\._]?\\w+")
                .Cast<Match>()
                .Select(u => u.Value.Replace("@", ""))
                .ToArray();
        }

        public static void AssertEqual(Object a, Object b) {
            if (!a.Equals(b))
                throw new InvalidOperationException($"[FAILED] '{a}' != '{b}'");
        }
    }
}
```



## 2.1 Soal

Ekstrak nama-nama user yang diawali dengan karakter `@` seperti pada text berikut:

```C#
@Oreki-kun, @Satoshi-kun, @Mayaka call dikit yuuk. Nanti @Chi-chan nyusul aja.
```

Hasil yang diharapkan adalah berupa list display name dari nama-nama user seperti berikut:

```C#
"Unidentified user", "Fukube Satoshi", "Ibara Mayaka", "Chitanda Eru"
```



## 2.2 Jawaban

Lampirkan jawaban kalian di code berikut dengan mengikuti penjelasan di point 1.1. Dan hanya boleh menulis code di bagian `@CODE-HERE` saja.


```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Quiz0010220210517 {
    class Program {
        static void Main(String[] args) {
            try {
                var text = "@Oreki-kun, @Satoshi-kun, @Mayaka call dikit yuuk. Nanti @Chi-chan nyusul aja.";
                var expectedDisplayNames = new[] { "Unidentified user", "Fukube Satoshi", "Ibara Mayaka", "Chitanda Eru" };

                var p = new Program();
                var userNames = p.ExtractUserNames(text);
                var displayNames = p.ExtractDisplayNames(userNames);

                AssertEqual(displayNames.Length, 4);

                Console.WriteLine("Display names:");
                for (var i = 0; i < displayNames.Length; i++) {
                    AssertEqual(displayNames[i], expectedDisplayNames[i]);
                    Console.WriteLine($"    + {displayNames[i]}");
                }

                Console.WriteLine("[DONE]");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        IDictionary<String, String> usernameMap = new Dictionary<String, String> {
            ["satoshi-kun"] = "Fukube Satoshi",
            ["mayaka"] = "Ibara Mayaka",
            ["chi-chan"] = "Chitanda Eru"
        };

        public String[] ExtractUserNames(String text) {
            // @CODE-HERE

            return Regex
                .Matches(text, "@\\w+[-\\._]?\\w+")
                .Cast<Match>()
                .Select(u => u.Value.Replace("@", ""))
                .ToArray();
        }

        public String[] ExtractDisplayNames(String[] usernames) {
            // @CODE-HERE

            return usernames
                .Select(u => {
                    var username = u.ToLowerInvariant();
                    if (!usernameMap.ContainsKey(username))
                        return "Unidentified user";

                    return usernameMap[username];
                })
                .ToArray();
        }

        public static void AssertEqual(Object a, Object b) {
            if (!a.Equals(b))
                throw new InvalidOperationException($"[FAILED] '{a}' != '{b}'");
        }
    }
}
```