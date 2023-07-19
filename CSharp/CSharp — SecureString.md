---
tags:
- C#
- CSharp
- Security
date: 2022-11-29
---

# SecureString

Seringkali developer retrieve password atau hal yang tergolong sensitive information dari text file kah, config file kah, atau dari network kah semisal key-value storage dan nyimpen ke String. Umum malah dan bukan cuma seringkali.

Masalahnya dimana?

Sewaktu ada security source code scan menggunakan HP Fortify, variable atau config yang mengandung kata-kata password pasti akan ke-detect sebagai security finding dengan kategori _Privacy Violation: Heap Inspection_.

Terus kenapa?

Fortify akan nge-points out kalo nyimpen atau naro sensitive information tadi di variable ber-type String adalah hal yang gak aman. Ada skenario ketika attacker bisa akses memory dump dari program yang sedang berjalan dan bisa membca sensitive information tadi dari memory dump. Karena memang String adalah tipe data seprimitif itu.

Sebenernya, menurut komen-komen dari [pertanyaan Stackoverflow ini](https://stackoverflow.com/questions/40789379/how-to-solve-heap-inspection-vulnerability-for-mvc-viewmodel). Kalo memory server bisa diakses sama hacker, itu udah masalah yang lebih kritis dari sekedar memory dump dibaca. Dan komen lain yang nyaranin pake `SecureString` adalah jalan terbaik tapi juga waste time dan effort karena di environtment yang bagus kecil banget kemungkinan buat issue ini bisa muncul. Tapi yang namanya security finding, tetep hal yang kritikal mau seberapa persen pun kemungkinan kejadiannya.

Ok, nah, cara benerinnya gimana?

Dari link Stackoverflow yang sama, `SecureString` jadi pilihan utama buat nge-solve issue-nya. Cara paling gampang buat make `SecureString` ini adalah dengan nge-create `NetworkCredential` instance, terus akses property `SecurePassword`-nya. Property ini bakal balikin `SecureString` dari String yang kita set sebagai password.

```c#
var creds = new NetworkCredential("", "ini adalah password");
SecureString secure = creds.SecurePassword;
```

Untuk ngebalikin lagi ke String, apakah karena ada keperluan untuk di-pass ke method lain, bisa pake property `Password` dari `NetworkCredential`-nya. Dengan catetan, jangan ditampung lagi ke variable String lain. Karena jadinya malah menyalahi tujuannya. Yang seharusnya menghindari untuk nyimpen sensitive information ke variable bertipe String. Jadi ketika mau dipake bsia langsung di-pass aja.

```c#
var creds = new NetworkCredential("", "ini adalah password");
SecureString secure = creds.SecurePassword;

var credsValid = CredentialValidator.ValidatePassword(secure.Password);
```



**References:**

- [Software Security | Privacy Violation: Heap Inspection C#](https://vulncat.fortify.com/en/detail?id=desc.dataflow.dotnet.privacy_violation_heap_inspection.master#C%23%2FVB.NET%2FASP.NET)
- [Software Security | Privacy Violation: Heap Inspection Java](https://vulncat.fortify.com/en/detail?id=desc.dataflow.dotnet.privacy_violation_heap_inspection.master#Java%2FJSP)
- [c# - How to solve Heap inspection vulnerability for MVC viewmodel? - Stack Overflow](https://stackoverflow.com/questions/40789379/how-to-solve-heap-inspection-vulnerability-for-mvc-viewmodel)
- [java - Heap Inspection Security Vulnerability - Stack Overflow](https://stackoverflow.com/questions/30341327/heap-inspection-security-vulnerability)
- [security - Is SecureString ever practical in a C# application? - Stack Overflow](https://stackoverflow.com/questions/26190938/is-securestring-ever-practical-in-a-c-sharp-application)
- [securestring.cs](https://referencesource.microsoft.com/#mscorlib/system/security/securestring.cs,77d68ea938f47705,references)
- [c# - Safe use of SecureString for login form - Stack Overflow](https://stackoverflow.com/questions/14449579/safe-use-of-securestring-for-login-form)
- [security - When would I need a SecureString in .NET? - Stack Overflow](https://stackoverflow.com/questions/141203/when-would-i-need-a-securestring-in-net/141393#141393)
- [Glavs Blog - SecurePasswordTextBox update](https://weblogs.asp.net/pglavich/440191)

