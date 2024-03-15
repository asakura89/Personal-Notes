---
tags:
- CSharp
date: 2024-03-10
---

# Timestamp

Bisa dipake buat banyak hal. Contoh yang paling sering adalah buat bikin unique id. Kalo cuma sekedar unique id yang dalem 1 hari di-generate beberapa kali, dalem artian bukan butuh unique id yang jarak generate-nya per detik atau per milidetik. Code ini udah cukup sih. Ini cukup sampe yang generate per detik.

```c#
Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
// 20240310235224
```

Tapi kalo butuh sampe milidetik, butuh nambahin milidetiknya.


```c#
Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
// 20240310235224287
```

Ada juga format lain yang suka dipake buat rename file. Contohnya gini.

```c#
Console.WriteLine("Name file - " + DateTime.Now.ToString("yyyyMMddTHHmmss.fff") + ".txt");
// Name file - 20240310T235224.287.txt
```

Yang ini mungkin lebih ke datestamp kali ya. Karena format ini biasanya dipake buat blogging.

```c#
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
// 2024-03-10
```