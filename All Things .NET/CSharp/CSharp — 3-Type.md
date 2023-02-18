---
tags:
- CSharp
- C#
date: 2021-08-14
---

<p>
  <h1 style="text-align:center;font-size:1.25em;margin-top:24px;margin-bottom:16px;font-weight:600;line-height:1.25">Kelompok Belajar Bunga Matahari</h1>
  <h3 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">Coding sudah seharusnya menyenangkan!</h3>
  <h5 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">
    <a href="https://github.com/asakura89">asakura89</a> /
    <a href="https://opensource.org/licenses/0BSD">BSD Zero Clause</a>
  </h5>
</p>



# Type

## 1. `var`

Keyword `var` biasanya rame di bahasa-bahasa pemrograman yang dynamic. Dynamic disini maksudnya adalah bahasa yang weakly-typed atau loosely-typed. Apa bahasa weakly-typed? Bahasa weakly-typed adalah bahasa pemrograman yang gak harus nulis type dari variable sewaktu deklarasi dan inisialisasi. Sedangkan C# .Net adalah bahasa yang harus ditulis type-nya sewaktu deklarasi dan inisialisasi. Maka dari itu, C# .Net ini strong-typed.

```c#
// C#
Boolean apakahPandemiAkanBerakhirSuatuHariNanti = true;

// javascript
var apakahPandemiAkanBerakhirSuatuHariNanti = true;

// php
var $apakahPandemiAkanBerakhirSuatuHariNanti = true;

// dart, mirip javascript
var apakahPandemiAkanBerakhirSuatuHariNanti = true;
```

Semenjak dari C# 3, C# udah bisa pake keyword `var`. YEEEEEEEEEEE!!!

Terus apa kelebihannya? toh dari bertaun-taun lalu mulai dari C# 1, 1.1 sama 2 pake strong-typed kok, dan gak ribet karena udah kebiasa. Karena memang bahasanya strong-typed.

Kelebihannya ya gak perlu ngetik panjang-panjang. Karena Preman sama Bos Preman termasuk pemalas.

Coba seandainya Bos Preman disuruh ngetik code di bawah ini.

```c#
IDictionary<String, IDictionary<String, String>> pengaturanPerSitus = new Dictionary<String, IDictionary<String, String>>();
```

Pasti Bos Preman bakal ngetiknya jadi kaya gini.

```C#
var pengaturanPerSitus = new Dictionary<String, IDictionary<String, String>>();
```

Tapi, kalo Bos Preman ditanya apakah dia akan ganti semua type jadi `var` atau enggak. Jawabnya adalah enggak. Kenapa? Karena walaupun malas, Bos Preman lebih malas kalo harus ngebaca code yang readability-nya gak bagus.

Contohnya gini.

```C#
var maksRentangPembatalanPesanan = PengaturanGlobal["MaksRentangPembatalanPesanan"];
```

Ada yang tau type dari `maksRentangPembatalanPesanan` apa? Kalo secara nalar kita mungkin akan nebak kalo type-nya integer dan dalam bentuk jumlah hari. Tapi kita bakal ngira gak kalau ternyata type-nya TimeSpan dan sewaktu diambil dari `Pengaturan Global` type-nya `String`?

Nah makanya penggunaan `var` disini malah bikin developer lain yang baca code ini nantinya jadi bingung. Jadi akan lebih baik nulis pake `var` kalo si type-nya udah ketauan. Contohnya gini.

```C#
class Configuration {
	String Get(String name);
	Object GetFromSessions(String name);
	T Get<T>(String name);
}

// tidak baik
var situs = Configuration.Get("Sites");

// lebih baik
String situs = Configuration.Get("Sites");

// gray area
var situs = new[] {
    "microsoft.com",
    "google.com",
    "amazon.com"
};

// lebih baik
String[] situs = new[] {
    "microsoft.com",
    "google.com",
    "amazon.com"
};

// baik
var situs = Configuration.GetFromSessions("Sites") as String;

// baik
var situs = (String) Configuration.GetFromSessions("Sites");

// baik
var situs = Configuration.Get<String>("Sites");
```

Baiklah. Setelah kita berusaha untuk gak membuat marah Bos Preman, karena menggunakan `var` dengan baik. Ada yang gak bisa dilakukan dengan `var`. Apa itu? Berikut ini.

```C#
// bisa
var situs = "microsoft.com";

// isi null, gak bisa, error
var situs = null;

// deklarasi tanpa inisialisasi, gak bisa, error
var situs;
```

Yang terakhir, `var` ini digunakan oleh tim .Net untuk menampung anonymous type. Contohnya gini.

```C#
var situs = new[] {
    new {
        Site = "microsoft.com",
        Rank = 1
    },
    new {
        Site = "google.com",
        Rank = 2
    }
};
```



## 2. `dynamic`

`dynamic` adalah keyword yang dikenalin di C# 4. Ini untuk mengakomodasi semua fitur bahasa dynamic ke C#. YEEEEEEEYYY!!

`dynamic` ini juga dibawa tandem dengan DLR (Dynamic Language Runtime) yang dibangun di atas CLR (Common Language Runtime)-nya .Net.

Secara simpelnya, `dynamic` ini bisa ganti type dan bisa ganti value.

```C#
dynamic apaIni = 123;          // integer
apaIni = 456.5;                // float
apaIni = "Ini adalah dynamic"; // string
```

Bedanya sama `var` apa? Ini pertanyaan yang paling sering ditanya dimana-mana. Beda sangat. Simpelnya, `var` gak bisa ganti type tapi bisa ganti value.

```C#
var apaIni = 123;          // integer
apaIni = 456.5;            // float, error
apaIni = "Ini adalah var"; // string, error
```

Kenapa error? Karena type aktual dari `var` akan ditentukan ketika value-nya diisi. Jadi dalam kasus di atas, type dari `var apaIni` adalah integer.



## 3. Anonymous

Anonymous type, juga dikelanin semenjak C# 3, adalah type yang enggak ada actual class-nya sebagain template.

Ini contoh normal type.

```C#
class Orang {
    Single Tinggi;
    Single Berat;
    String Mata;
    String Rambut;
}

var orangDiPulaiSeberang = new Orang {
    Tinggi = 172.0,
    Berat = 65.0,
    Mata = "Kehijau-hijauan emeral",
    Rambut = "Keperak-perakan"
};
```

Dan ini contoh anonymous type.

```C#
var orangDiPulaiSeberang = new {
    Tinggi = 172.0,
    Berat = 65.0,
    Mata = "Kehijau-hijauan emeral",
    Rambut = "Keperak-perakan"
};
```

