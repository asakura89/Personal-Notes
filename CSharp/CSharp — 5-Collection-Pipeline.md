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



# Collection Pipeline

- [1. Select](#1-select)
- [2. Where](#2-where)
- [3. Sort](#3-sort)
- [4. Aggregate](#4-aggregate)



`Collection` secara general me-refer ke `Array`, `List`, `Dictionary` atau object yang memiliki anak yang lebih dari 1 dan bisa diiterasi / loop. 
Sedangkan `Pipeline` me-refer ke fungsi dari suatu code / app yang bisa menerima input dari fungsi / app lain lalu memprosesnya kemudian menghasilkan output yang masih bisa diproses oleh fungsi lain. 
Kalau digabungkan, `Collection Pipeline` adalah `Pipeline` yang menerima input dan menghasilkan output dalam bentuk `Collection`.  

`Collection Pipeline` sendiri dalam tiap-tiap teknologi atau bahasa bisa punya istilah yang beda. Misal di .NET ada istilah `Linq` atau `Lambda method`, di javascript ada istilah `Array Method`, di Powershell, Bash-shell, ataupun Windows cmd ada istilah `Pipe`. 
Semuanya me-refer ke `Collection Pipeline`. Buat bahasan di .NET kita akan pake istilah `Linq`. AndBud Watie nge-pronounce-nya `lingki` biar gak ketuker sama pronounce `link` yang sama-sama di-pronounce `ling` juga.  

`Linq` yang paling sering dipake adalah `Select`, `Where`, `Sort`, `Aggregate`.  



## 1. Select

Secara konsep fungsi `Select` ini disebut juga `Map`. `Select` / `Map` ini tugasnya adalah menerima `Collection`, mentransformasi si input tadi menjadi `Collection` dalam bentuk yang berbeda.  

Flow-nya adalah kaya di bawah ini.  

![Select flow](_media/BungaMatahari-CollectionPipeline-Select.drawio.svg)

Misal, kita punya data kaya gini.  

```C#
var data = new[] {
    "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
    "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
    "charles", "danny", "stephen", "gabriel", "susan", "donald",
    "isabella", "patrick"
};
```

Dari data di atas kita mau bikin semua datanya yang isinya nama orang, huruf pertamanya jadi huruf kapital. 
Nah, disini kita mentransformasi yang tadinya input-nya bisa aja huruf pertamanya udah kapital menjadi nama yang huruf pertamanya kapital (tidak ada perubahan sama sekali). 
Atau kita bisa mentransformasi input-nya yang tadinya huruf pertamanya belum kapital menjadi kapital.  

Mari kita coba.  

```C#
var data = new[] {
    "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
    "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
    "charles", "danny", "stephen", "gabriel", "susan", "donald",
    "isabella", "patrick"
};

var result = data.Select(name => name[0].ToString().ToUpper() + name.Substring(1, name.Length -1));
```

atau, kalo terlalu mager buat misahin variable data dan result, kita bisa pake cara simplify Budie (oneliner code).  

```C#
var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name => name[0].ToString().ToUpper() + name.Substring(1, name.Length -1));
```

atau, kalo masih terlalu panjang ke kanan, kita bisa pake cara Budie sewaktu dia lagi sebel (oneliner code alternative version).  

```C#
var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name =>
        name[0].ToString().ToUpper() +
        name.Substring(1, name.Length -1));
```

Tujuannya adalah tidak lain dan tidak bukan untuk men-simplify code biar gampang dibaca.  

Nah, hasil dari code di atas harusnya adalah ini.

```
Clifford
Lewis
Ollie
Leah
Kathryn
Carolyn
Genevieve
Adam
Milton
Eleanor
Maurice
Ethel
Charles
Danny
Stephen
Gabriel
Susan
Donald
Isabella
Patrick
```

Kasus kedua adalah, nama-nama di atas mau dikasi nomor urut agar keliatan jumlah dari data nama. Maka code-nya bisa ditambahin 1 `Pipeline` lagi di bawahnya.  

```C#
var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name =>
        name[0].ToString().ToUpper() +
        name.Substring(1, name.Length -1))
    .Select((name, index) => {
        var number = index +1;
        var stringified = number.ToString().PadLeft(2, '0');

        return stringified + ". " + name;
    });
```

Keliatan bedanya `Pipeline` pertama dan yang kedua?  

Yang pertama cuma menerima 1 parameter, jadi gak perlu ada `()` kurung yang nge-wrap. Sedangkan yang kedua lebih dari 1, makanya butuh kurung untuk nge-wrap. 
Dan yang kedua logic-nya multiline. Jadi butuh kurung kurawal `{}` untuk nge-wrap scope dari logic.  

Dan hasil run dari code di atas adalah, tattaraaa  

```
01. Clifford
02. Lewis
03. Ollie
04. Leah
05. Kathryn
06. Carolyn
07. Genevieve
08. Adam
09. Milton
10. Eleanor
11. Maurice
12. Ethel
13. Charles
14. Danny
15. Stephen
16. Gabriel
17. Susan
18. Donald
19. Isabella
20. Patrick
```

Dari code di atas, ternyata Andie kena code review sama Budie, dia disuruh `refactor` buat `Pipeline` yang kedua karena terlalu panjang untuk dijadikan parameter. 
Maka akhirnya Andie `refactor` jadi kaya di bawah ini.  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name =>
        name[0].ToString().ToUpper() +
        name.Substring(1, name.Length -1))
    .Select((name, index) => NumberifiedName(name, index));
}

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return stringified + ". " + name;
}
```

Budie masih gak puas dan nyuruh lagi buat `refactor` sekali lagi.  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name => TitleCasedName(name))
    .Select((name, index) => NumberifiedName(name, index));
}

public String TitleCasedName(String name) {
    return name[0].ToString().ToUpper() +
        name.Substring(1, name.Length -1);
}

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return stringified + ". " + name;
}
```

Lagi-lagi Budie masih tidak puas.  

"Baiklah!" kata Andie mendengus.  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(TitleCasedName)
    .Select(NumberifiedName);
}

public String TitleCasedName(String name) {
    return name[0].ToString().ToUpper() +
        name.Substring(1, name.Length -1);
}

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return stringified + ". " + name;
}
```

Di atas, Andie menggunakan `MethodGroup`. `MethodGroup` adalah istilah yang digunakan untuk mendefinisikan kondisi sewaktu method dipanggil hanya dengan nama, tanpa menggunakan signature (parameter). 
Dari code di atas (`.Select(TitleCasedName)`), `TitleCasedName` dipanggil tanpa menyebutkan signature. 
Karena parameter yang diterima di `Select` dan parameter yang diterima di `TitleCasedName` sama-sama berjumlah 1 dan sama-sama memiliki `Type` `String`. 
Begitupun dengan method `NumberifiedName`.  

Untung tak dapet di raih, malang tak dapat ditolak, Budie lagi-lagi tidak puas. Akhirnya Budie turun tangan sendiri untuk me-`refactor` code Andie.  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(TitleCasedName)
    .Select(NumberifiedName);
}

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Di `TitleCasedName`, karena isi method tersebut cuma oneliner, Budie mulai menggunakan teknik C# 6 yaitu `Expression Body`. 
`Expression Body` ini bisa digunakan untuk men-simplify code dengan membuang kurung kurawal scope-wrapper dan menggantikannya dengan lambda `=>`. 
Karena ada `return` juga, `return` ini juga dibuang karena tidak ada scope.  

Di `NumberifiedName`, karena Budie terlalu mager buat melakukan `String Concatenation` menggunakan operator plus `+`, `return`-nya diganti menggunakan `String Interpolation`. 
Yaitu menggunakan dollar-sign `$` di depan `string`-nya terus menggunakan kurung kurawal untuk nge-wrap variable yang digunakan didalam `string`.  



## 2. Where

`Where` juga disebut `Filter`. `Where` / `Filter` ini tugasnya adalah menerima `Collection`, memilih si input tadi berdasarkan kriteria / predikat, lalu menghasilkan output `Collection` yang sesuai dengan kriteria / predikat yang disebutkan.  
Flow-nya adalah kaya di bawah ini.  

![Where flow](_media/BungaMatahari-CollectionPipeline-Where.drawio.svg)

Misal lagi nih, dari data nama-nama tersebut mau diambil yang memiliki kata-kata 'el'.

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Where(ContainsEl)
    .Select(TitleCasedName)
    .Select(NumberifiedName);
}

public Boolean ContainsEl(String name) => name.Contains("el");

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Hasilnya jadi kaya di bawah ini  

```
01. Eleanor
02. Ethel
03. Gabriel
04. Isabella
```

Hmm... gimana kalo posisi `Pipeline`-nya kita pindah ke posisi kedua?  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(TitleCasedName)
    .Where(ContainsEl)
    .Select(NumberifiedName);
}

public Boolean ContainsEl(String name) => name.Contains("el");

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Hasilnya berbeda  

```
01. Ethel
02. Gabriel
03. Isabella
```

Coba kita taro di posisi ketiga  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(TitleCasedName)
    .Select(NumberifiedName)
    .Where(ContainsEl);
}

public Boolean ContainsEl(String name) => name.Contains("el");

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Hasilnya juga berbeda  

```
12. Ethel
16. Gabriel
19. Isabella
```

Kenapa?  

Karena, sewaktu kriteria ditaro di posisi pertama, data nama-nama tersebut masih dalam bentuk lowercase. 
Lalu kita filter dengan menggunakan `Where`, semua nama yang memiliki 'el', maka hasilya jadi kaya gini.  

```
eleanor   // => 'el' eanor
ethel     // => eth 'el'
gabriel   // => gabri 'el'
isabella  // => isab 'el' la
```

Sewaktu `Where` ada di posisi kedua, data sudah tertransformasi menjadi titlecase. 
Dan kriteria yang kita lakukan adalah yang mengandung 'el' lowercase. Inget, C# adalah language case-sensitive. 
Jadi hasil data yang ke-filter adalah kaya gini tanpa mengikutsertakan 'Eleanor'. 
Karena 'el' eanor sudah bertransformasi menjadi 'El' eanor, yang mana gak sesuai dengan apa yang kita filter.  

```
Ethel     // => Eth 'el'
Gabriel   // => Gabri 'el'
Isabella  // => Isab 'el' la
```

Terus-terus, kalo ditaro di posisi yang ketiga berbeda dimana? 
Di numbering-nya, karena di posisi ketiga kita nge-filter nama yang udah tertransformasi menjadi bentuk yang bernomor.  



## 3. Sort

Sort di .NET menggunakan method `OrderBy`, `ThenBy`, `OrderByDescending`, dan `ThenByDescending`. Tugasnya? udah pasti buat ngurutin data berdasarkan `key`. 
Flow-nya kaya di bawah ini.

![Sort flow](_media/BungaMatahari-CollectionPipeline-Sort.drawio.svg)

Nah, `key` ini apa? `Key` ini adalah object yang digunakan sebagain acuan urutan. Misal, sewaktu AndBud baru mau mulai pelajaran. Mereka diabsen secara berurutan berdasarkan abjad pertama dari nama mereka. 
Atau misalkan, sewaktu AndBud lagi ikut pelajaran Pendidikan Kesehatan dan Jasmani terus semua murid dibagi jadi 2 kelompok berdasarkan ganjil genap nomor absen

Kasus urut berdasarkan abjad name, bisa kita ambil dari data yang udah disiapin di atas. 

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .OrderBy(name => name[0]);
}
```

Hasil run-nya  

```
adam
clifford
carolyn
charles
danny
donald
eleanor
ethel
genevieve
gabriel
isabella
kathryn
lewis
leah
milton
maurice
ollie
patrick
stephen
susan
```

Atau biar rapih bisa dikasi nomor urut absen juga sama ditransformasi ke `TitleCase`  

```C#
public void Run() {
    var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(TitleCasedName)
    .OrderBy(ByFirstChar)
    .Select(NumberifiedName);
}

public Char ByFirstChar(String name) => name[0];

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Buat kasus pembagian 2 kelompok tadi, Budie inisiatif buat ngebagi kelompoknya. Pembagiannya bisa dengan gampangnya dibikinin program-nya segampang membalikkan telapak tangan.  

```C#
public void Run() {
    var names = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    };

    var oddGroup = names
        .Select(TitleCasedName)
        .OrderBy(ByFirstChar)
        .Select(NumberifiedName)
        .Where(HasOddAbsenceNo);

    var evenGroup = names
        .Select(TitleCasedName)
        .OrderBy(ByFirstChar)
        .Select(NumberifiedName)
        .Where(HasEvenAbsenceNo);
}

public Boolean HasOddAbsenceNo(String name, Int32 index) {
    var absenceNo = index +1;  
    var odd = absenceNo %2 != 0;

    return odd;
}

public Boolean HasEvenAbsenceNo(String name, Int32 index) {
    var absenceNo = index +1;
    var even = absenceNo %2 == 0;

    return even;
}

public Char ByFirstChar(String name) => name[0];

public String TitleCasedName(String name) =>
    name[0].ToString().ToUpper() +
    name.Substring(1, name.Length -1);

public String NumberifiedName(String name, Int32 index) {
    var number = index +1;
    var stringified = number.ToString().PadLeft(2, '0');

    return $"{stringified}. {name}";
}
```

Hasil run-nya adalaaaaahh ... jeng jeng jeng jeng ...

```
01. Adam
03. Carolyn
05. Danny
07. Eleanor
09. Genevieve
11. Isabella
13. Lewis
15. Milton
17. Ollie
19. Stephen

02. Clifford
04. Charles
06. Donald
08. Ethel
10. Gabriel
12. Kathryn
14. Leah
16. Maurice
18. Patrick
20. Susan
```



## 4. Aggregate

Secara konsep `Aggregate` ini sering disebut `Reduce`.  `Reduce` seperti nama panggilannya, tugasnya adalah me-reduce atau mengurangi. Atau lebih tepatnya memperciut. Apa yang diperciut? Adalah jumlah butir (item) dari sebuah`Collection`.

Flow-nya kaya di bawah ini.

![Aggregate flow](_media/BungaMatahari-CollectionPipeline-Aggregate.drawio.svg)

Contoh paling dekat adalah fungsi `SUM` yang ada di bahasa SQL. `SUM` memperciut butir `Collection` yang tadinya ada sekian menjadi hanya sebuah atau satu hasil. Misalkan ada `Collection` yang berisikan 3 butir `integeter`, dengan `SUM` 3 butir tadi dijumlahkan menjadi satu hasil.

```C#
public void Run() {
    var bilangan = new[] { 3, 10, 15 };
    var total = bilangan.Aggregate(0, (acc, item) => acc + item);
}
```

Isi dari variable `total` adalah 28. Kenapa? Karena logika utama dari `Aggregate`/`Reduce` di atas adalah menjumlahkan semua butir.

Oke mari ke contoh yang lain.

"TUNGGUU OEE!" teriak Budie dengan lantang.

"JANGAN SEMBARANGAN NGODING!" masih teriakan Budie yang lantang sambil berlari mendekat.

Dengan cekatan Budie langsung me-refactor code di atas menjadi

```C#
public void Run() {
    var bilangan = new[] { 3, 10, 15 };
    var total = bilangan.Aggregate(0, Sum);
}

public Int32 Sum(Int32 accumulated, Int32 item) => accumulated + item;
```

Budie tidak akan tinggal diam kalo ada code yang tidak bisa dimengerti dengan gampang. Itu adalah prinsip hidupnya. Walaupun simpel, harus tetap bisa dimengerti.

Oke, satu masalah terselesaikan, mari kita lanjut.

Suatu hari Budie dipanggil Watie buat ngumpulin temen-temen sekelas buat nerima pembagian Bubul Kacang Hejo dari Bu Guru. Tapi sayangnya bantuan tersebut memiliki syarat. Tidak semua orang bisa mendapatkannya. Syaratnya adalah penerima harus udah donor darah yang diselenggarain di kantor KepSek oleh PMI setempat. Dan yang udah donor lebih dari sekali, dapet tambahan setengah porsi lagi.

Yang jadi masalah adalah Budie gak hapal dan tau berapa jumlah temen-temennya yang udah donor. Akhirnya Budie teringat teknik `Reduce`. Dia akan mencari nilai terbesar dari jumlah berapa kali temen-temennya donor. Temen-temennya cuma perlu nulis nama dan jumlah udah berapa kali donor darah, nanti sisanya urusan Budie.

```C#
public void Run() {
    var bilangan = new[] {
        new Mentemen { Nama = "Jupri", JumlahDonor = 3 },
        new Mentemen { Nama = "Sapri", JumlahDonor = 0 },
        new Mentemen { Nama = "Mukri", JumlahDonor = 2 },
        new Mentemen { Nama = "Rojali", JumlahDonor = 6 },
        new Mentemen { Nama = "Badri", JumlahDonor = 0 }
    };
}

public class Mentemen {
    public String Nama;
    public Int32 JumlahDonor;
}
```

Setelah terkumpul, Budie mulai melancarkan aksinya untuk mencari tau apakah temen-temennya berhak menerima Bubul Kacang Hejo yang disebut Watie.

```C#
public void Run() {
    var semuaMentemen = new[] {
        new Mentemen { Nama = "Jupri", JumlahDonor = 3 },
        new Mentemen { Nama = "Supri", JumlahDonor = 0 },
        new Mentemen { Nama = "Mukri", JumlahDonor = 2 },
        new Mentemen { Nama = "Rojali", JumlahDonor = 6 },
        new Mentemen { Nama = "Badri", JumlahDonor = 0 }
    };
    
    var berhak = semuaMentemen
        .Where(YangBerhak)
        .OrderBy(item => item.Nama)
        .Select((item, index) => new Mentemen {
            Nomor = index +1,
            Nama = item.Nama,
            JumlahDonor = item.JumlahDonor
        })
        .Aggregate(String.Empty, SatukanDaftarNama)
        .TrimEnd(',', ' ');
    
    var tidakBerhak = semuaMentemen
        .Where(YangTakBerhak)
        .OrderBy(item => item.Nama)
        .Select((item, index) => new Mentemen {
            Nomor = index +1,
            Nama = item.Nama,
            JumlahDonor = item.JumlahDonor
        })
        .Aggregate(String.Empty, SatukanDaftarNama)
        .TrimEnd(',', ' ');
}

public String SatukanDaftarNama(String accumulated, Mentemen item) =>
    $"{accumulated}{item.Nomor}: {item.Nama}, ";

public Boolean YangBerhak(Mentemen mentemen) => mentemen.JumlahDonor > 1;

public Boolean YangTakBerhak(Mentemen mentemen) => mentemen.JumlahDonor <= 1;

public class Mentemen {
    public Int32 Nomor;
    public String Nama;
    public Int32 JumlahDonor;
}
```

Hasilnya, ada 3 yang berhak menerima dan ada 2 yang tidak berhak menerima.

```c#
1: Jupri, 2: Mukri, 3: Rojali
1: Badri, 2: Supri
```


Begitulah kehidupan Budie dan temen-temennya berjalan seperti biasa kembali. Tapi Andie kemana ya? Dia gak ngeliat daritadi.



Resources:

- [Draw.io diagram](_media/BungaMatahari-CollectionPipeline.xml)