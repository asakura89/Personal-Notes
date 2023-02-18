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



# CSharp String

Tipe data `string` memang paling populer dan paling gampang untuk dipake. Apapun data yang mau dipake di app, paling gampang make tipe data `string` buat nampung nilainya. 



## 1. Dasar

`String` paling dasar adalah variabel yang diisi dengan value yang diapit oleh kutip dua. Kalo di dalem suatu `string` ada karakter `\` (backslash) maka akan diperlakukan sebagai `character escapes`. Jadi kalo mau meng-include karakter backslash sebagai bagian dari `string`, harus di-escape pake backslash lagi. Kalo enggak nanti karakter setelah backslash-nya akan di-escape. 
`Characted escapes` yang paling sering dipake adalah:

| Character Escapes          | Artinya dalam `string` |
| -------------------------- | ---------------------- |
| `\t`                       | Tab                    |
| `\r`                       | Carriage retun         |
| `\n`                       | Newline \ Line feed    |
| `\\`                       | Backslash              |
| `\'`                       | Single quote           |
| `\"`                       | Double quote           |


```c#
var kalimat = "\"Apa yang kita ketahui tentang dia?\"\r\nWakil direktur segera mengeluarkan file yang berisi semua informasi terkait yang terkait.\r\nDirektur memindai file dan membentuk senyum puas.";
```

Kalo variabel di atas di-print bakal ngeluarin hasil kaya gini  

```
"Apa yang kita ketahui tentang dia?"
Wakil direktur segera mengeluarkan file yang berisi semua informasi terkait yang terkait.
Direktur memindai file dan membentuk senyum puas.
```

Karena kombinasi `\r\n` adalah Enter kalo di Windows. Sedangkan di Linux atau yang Unix-based Enter hanya butuh `\n`.  



## 2. Multi-line String

Multi-line string sebenernya bisa didapet dengan banyak cara. Salah satunya contoh `string` di atas. Pake `\r\n`. Atau bisa juga pake `verbatim string`. 

Apa itu `verbatim string`? `Verbatim string` adalah `string` yang gak perlu di-escape. Kecualiiiii, kecuali nih double quote `"`. Karena walaupun gak perlu di-escape, pada dasarnya kan `string` sendiri diapit double-quote.  

Contoh di atas kalo di-convert pake `verbatim string` jadi gini code-nya  

```c#
var kalimat = @"
""Apa yang kita ketahui tentang dia?""
Wakil direktur segera mengeluarkan file yang berisi semua informasi terkait yang terkait.
Direktur memindai file dan membentuk senyum puas.";
```

Liat gak? ada `@` di depan `string`-nya. Itu yang nandain kalo dia itu `verbatim string`.  

Mau pake cara lain lagi buat multi-line?  

Bisa!  

Pake `StringBuilder`  

```C#
using System.Text;

var kalimat = new StringBuilder()
    .AppendLine("\"Apa yang kita ketahui tentang dia?\"")
    .AppendLine("Wakil direktur segera mengeluarkan file yang berisi semua informasi terkait yang terkait.")
    .Append("Direktur memindai file dan membentuk senyum puas.")
    .ToString();
```

Jangan lupa tambahin `using System.Text;` karena `StringBuilder` ini ada di dalem `namespace` `System.Text`.  

Kunci multi-line-nya ada di method `AppendLine()`. Dan buat menghasilkan `string` yang utuh, method `ToString()` harus dipanggil di akhir method-chain.  



## 3. Interpolation / penyisipan kata

Sebelum ada `String Interpolation` dari C# 6, kita kalo mau nyisipin variabel ke dalem `string` tertentu, seringnya `String.Format` yang dipake.

```C#
public void Run() {
    var namaNamaIkan = new List<String>();

    var lele = SebutNamaIkan("Lele");
    namaNamaIkan.Add(lele);

    var paus = SebutNamaIkan("Paus");
    namaNamaIkan.Add(paus);
    
    var teri = SebutNamaIkan("Teri");
    namaNamaIkan.Add(teri);

    var tongkol = SebutNamaIkan("Tongkol");
    namaNamaIkan.Add(tongkol);

    foreach (var nama in namaNamaIkan)
        Console.WriteLine(nama);
}

public String SebutNamaIkan(String nama) =>
    String.Format("Ikan {0}", nama);
```

"Sebentar", preman dibegal boss preman dengan tatapan sinis

"Code macam apa?", preman cuma bisa nunduk dan melakukan `refactor`

```C#
public void Run() {
    var namaNamaIkan = new List<String>();
    namaNamaIkan.Add(SebutNamaIkan("Lele"));
    namaNamaIkan.Add(SebutNamaIkan("Paus"));
    namaNamaIkan.Add(SebutNamaIkan("Teri"));
    namaNamaIkan.Add(SebutNamaIkan("Tongkol"));

    foreach (var nama in namaNamaIkan)
        Console.WriteLine(nama);
}

public String SebutNamaIkan(String nama) => $"Ikan {nama}";
```

"Gak, gak. Gak gitu"

"Oooookkeeeyy", preman kembali menunduk

```C#
public void Run() {
    var namaNamaIkan = new List<String> {
        SebutNamaIkan("Lele"),
        SebutNamaIkan("Paus"),
        SebutNamaIkan("Teri"),
        SebutNamaIkan("Tongkol")
    };

    foreach (var nama in namaNamaIkan)
        Console.WriteLine(nama);
}

public String SebutNamaIkan(String nama) => $"Ikan {nama}";
```

Hasil run-nya sebagai berikut.  

```
Ikan Lele
Ikan Paus
Ikan Teri
Ikan Tongkol
```



## 4. Concatenation / rentetan kata

Rentetan kata atau penggabungan kata paling simpel udah pasti pake operator plus (`+`).  

```C#
var hamlet =
    "Menjadi atau tidak sama sekali. " +
    "Itulah pertanyaannya.";
```

Cara yang lainnya adalah antara pake `String.Concat`,  

```C#
var hamlet = String.Concat(
    "Menjadi atau tidak sama sekali. ",
    "Itulah pertanyaannya."
);
```

atau pake `StringBuilder`.  

```C#
var builder = new StringBuiler();
var hamlet = builder
    .Append("Menjadi atau tidak sama sekali. ")
    .Append("Itulah pertanyaannya.")
    .ToString();
```

ehmm dari balik `StringBuilder` ada yang mengintai. Dan tiba-tiba, BAMM!

```C#
var hamlet = new StringBuiler()
    .Append("Menjadi atau tidak sama sekali. ")
    .Append("Itulah pertanyaannya.")
    .ToString();
```

`inline code`, begitulah cara preman.  



## 5. Split

Suatu hari Bang Preman disuruh sama boss-nya buat nyairin duit dari invoice yang ditemuin di tengah jalan depan warung Mpok Romlah. Jadi invoice ini adalah tagihan buat dagangan yang dititipin penjual aslinya ke warung Mpok Romlah. Boss-nya pesen kalo buat bisa nyairin nota tagihan ini, Mpok Romlah bakal nanya informasi seputar dagangannya.  

Boss Preman yang cerdik langsung ngeuh kalo informasi dagangan untuk nota tagihan yang dipegang oleh Bang Preman itu berbentuk `String` unik. `String` unik yang dimaksud tidak lain dan tidak bukan 2 baris pertama dari nota. Karena baris ketiganya adalah total yang ditagih.  

2 baris pertama tadi berbunyi kaya gini.  

```
BL10-OD15-KL15
TK10-YG05-AL10
```

Boss Preman bilang gini, "Di tiap-tiap strip / dash (`-`), itu ada 2 digit nama barang dagangan. Dan 2 digit lagi ada jumlah barangnya. Nanti kalo Mpok Romlah nanya, jawabannya ada disitu."  

"Siap boss!" kata Bang Preman.  

Bang Preman pulang ke rumah, nyalain laptop terus langsung bikin program buat mecah-mecah `String` unik buat persiapan menghadapi si Mpok. Berbekal pesan si Boss, Bang Preman bikin code kaya di bawah ini.  

```C#
var stringUnik = String.Concat("BL10-OD15-KL15", "-", "TK10-YG05-AL10");
var terpotong = stringUnik.Split('-');
```

Kenapa parameter `.Split()` pake petik satu? Karena umumnya tanda pemotong `String` berbentuk karakter dan bukan `String`. Dalam kasus Bang Preman, adalah strip (`-`). Dan karakter disimbolkan dengan karakter yang diapit oleh petik satu. Sedangkan `String` disimbolkan dengan satu atau lebih karakter yang diapit oleh petik dua.  

Output-nya jadi gini

```
BL10
OD15
KL15
TK10
YG05
AL10
```

Seandainya, `String` unik yang ada di kertas nota tadi tulisannya kaya di bawah ini,  

```
BL10-OD15-KL15
TK10-YG05--AL10
```

hasilnya bakal beda. Jadi kaya gini.

```
BL10
OD15
KL15
TK10
YG05

AL10
```

Nyadar gak kalo diantara `YG05` sama `AL10` ada gap? Item kosong lebih tepatnya. Itu karena di `String` uniknya, diantara `YG05` sama `AL10` dipisah oleh 2 strip. 2 strip ini akan dianggap 2 separator atau pemisah yang memiliki item yang kosong.  

Terus gimana biar gak kejadian?  

Nah, `.Split()` sendiri ada parameter kedua yang bentuknya pilihan apakah si item kosong ini mau dibuang aja dari hasil akhirnya atau enggak. 
Normalnya, `.Split()` bakal pake pilihan `StringSplitOptions.None`. Jadi kalo ada item-item kosong, bakalan ikut ke hasil akhir. Sedangkan pilihan yang kedua (yang mau dipake buat ngebuang item kosongnya) adalah `StringSplitOptions.RemoveEmptyEntries`.  

Jadi code-nya jadi gini.  

```C#
var stringUnik = String.Concat("BL10-OD15-KL15", "-", "TK10-YG05--AL10");
var terpotong = stringUnik.Split('-', StringSplitOptions.RemoveEmptyEntries);
```



## 6. Substring

Setelah `String` uniknya dipotong-potong pake `.Split()`, Bang Preman pun ngelanjutin dengan nyomot-nyomot `String`-nya pake `Subtring`. 2 Digit di depan dan 2 digit setelahnya.  

```C#
var stringUnik = String.Concat("BL10-OD15-KL15", "-", "TK10-YG05-AL10");
var terpotong = stringUnik.Split('-');

foreach (var potongan in terpotong) {
    var dagangan = potongan.Substring(0, 2);
    var jumlah = potongan.Substring(2, 2);

    var keterangan = String.Concat(
        "Dagangan \"", dagangan, "\" ",
        "jumlahnya ", jumlah, " buah."
    );
    
    Console.WriteLine(keterangan);
}
```

Bang Preman berhasil mengekstrak informasi rahasia dari di penjual dagangan yang nitipin dagangannya ke Mpok Romlah. Dia tersenyum licik. Tapi kemudian senyumannya pudar setelah ngeliat output program-nya.  

```
Dagangan "BL" jumlahnya 10 buah.
Dagangan "OD" jumlahnya 15 buah.
Dagangan "KL" jumlahnya 15 buah.
Dagangan "TK" jumlahnya 10 buah.
Dagangan "YG" jumlahnya 05 buah.
Dagangan "AL" jumlahnya 10 buah.
```

Apa itu BL? apa itu TK? pikirnya.  

Sebelum Bang Prem melakukan penagihan dia nyuruh temen seprofesinya untuk mengintai jualan Mpok Romlah. Dan akhirnya semua berbuah manis. Bang Prem dapet seua informasinya lengkap dari temennya dan mulai nge-update program-nya.  

```C#
var daftar = new Dictionary<String, String> {
    ["BL"] = "Bala-bala",
    ["OD"] = "Onde-onde",
    ["KL"] = "Klepon",
    ["TK"] = "Teh Koci",
    ["YG"] = "Yogurt",
    ["AL"] = "Air Lemon"
};

var stringUnik = String.Concat("BL10-OD15-KL15", "-", "TK10-YG05-AL10");
var terpotong = stringUnik.Split('-');

foreach (var potongan in terpotong) {
    var dagangan = potongan.Substring(0, 2);
    var jumlah = potongan.Substring(2, 2);
    
    var keterangan = String.Concat(
        "Dagangan \"", daftar[dagangan], "\" ",
        "jumlahnya ", jumlah, " buah."
    );
    
    Console.WriteLine(keterangan);
}
```

Hasilnya adalah berikut ini.  

```
Dagangan "Bala-bala" jumlahnya 10 buah.
Dagangan "Onde-onde" jumlahnya 15 buah.
Dagangan "Klepon" jumlahnya 15 buah.
Dagangan "Teh Koci" jumlahnya 10 buah.
Dagangan "Yogurt" jumlahnya 05 buah.
Dagangan "Air Lemon" jumlahnya 10 buah.
```

Setelah itu, Bang Prem dan Boss Prem meraup keuntungan dan bisa ongkang-ongkang kaki untuk sebulan kedepan.  



## 7. Awalan dan akhiran

Biasanya kalo ada `String` yang terformat dengan pola tertentu, kita akan gampang ngolahnya. Mungkin cuma dengan `Split` sama `Substring` aja kita udah dapet hasil yang kita mau. Selain itu ada juga yang cuma butuh prefix dan postfix dari `String` tersebut untuk dapet hasil yang sesuai.  

Misal ada kasus dimana kita lagi butuh nyusun file-file log yang kita ambil dari server. Contoh name file-nya mungkin kaya di bawah ini.  

```
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201008_x.log
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201008_x.log.bak
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201009_x.log
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201009_x.log.bak
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201010_x.log
D:\temp\analysis\log\prod\EU\personal-blog\u_ex201014_x.log
D:\temp\analysis\log\prod\EU\personal-blog\u_ex201015_x.log
D:\temp\analysis\log\prod\EU\personal-blog\u_ex201016_x.log
D:\temp\analysis\log\prod\EU\personal-blog\u_ex201016_x.log.bak
D:\temp\analysis\log\prod\US\personal-blog\u_ex201004_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201005_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201006_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201006_x.log.bak
D:\temp\analysis\log\prod\US\personal-blog\u_ex201007_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201011_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201012_x.log
D:\temp\analysis\log\prod\US\personal-blog\u_ex201012_x.log.bak
D:\temp\analysis\log\prod\US\personal-blog\u_ex201013_x.log
```

Tanpa menghiraukan file backup kita hanya butuh ambil log dari server Asia Pacific yang berkode APC. Kita bisa coba dengan kombinasiin codenya dengan `Substring` juga. Terus kita bisa pake `.StartsWith()` untuk cari yang berawalan APC terus menghiraukan yang berekstensi `.bak` dengan `.EndsWith()`.

```C#
var logPaths = new[] {
    @"D:\temp\analysis\log\prod\APC\personal-blog\u_ex201008_x.log",
    @"D:\temp\analysis\log\prod\APC\personal-blog\u_ex201008_x.log.bak",
    @"D:\temp\analysis\log\prod\APC\personal-blog\u_ex201009_x.log",
    @"D:\temp\analysis\log\prod\APC\personal-blog\u_ex201009_x.log.bak",
    @"D:\temp\analysis\log\prod\APC\personal-blog\u_ex201010_x.log",
    @"D:\temp\analysis\log\prod\EU\personal-blog\u_ex201014_x.log",
    @"D:\temp\analysis\log\prod\EU\personal-blog\u_ex201015_x.log",
    @"D:\temp\analysis\log\prod\EU\personal-blog\u_ex201016_x.log",
    @"D:\temp\analysis\log\prod\EU\personal-blog\u_ex201016_x.log.bak",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201004_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201005_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201006_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201006_x.log.bak",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201007_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201011_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201012_x.log",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201012_x.log.bak",
    @"D:\temp\analysis\log\prod\US\personal-blog\u_ex201013_x.log"
};

var kumpulan = new List<String>();
foreach (var path in logPaths) {
    var idxAwal = 26;
    var panjang = path.Length -1 -idxAwal;

    var asiaPacific = path
        .Substring(idxAwal, panjang)
        .StartsWith("APC");

    var fileBackup = path
        .EndsWith(".bak");

    var sesuai = asiaPacific && !fileBackup;
    if (sesuai)
        kumpulan.Add(path);
}
```

Dapet deh file-nya.  

```
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201008_x.log
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201009_x.log
D:\temp\analysis\log\prod\APC\personal-blog\u_ex201010_x.log
```



## 8. Replace

Dari file-file log tadi kita mau tau tanggal dari masing-masing log, karena penamaan log file-nya udah sesuai tanggal misalnya.  

Kita bisa manfaatin `.Replace()` buat ganti kata-kata tertentu jadi kata-kata yang kita mau. Dalam kasus log file ini kita mau ganti semua yang bukan tanggal jadi `String` kosong misalnya.  

```C#
foreach (var log in kumpulan) {
    var namaBersih = log
        .Replace(@"D:\temp\analysis\log\prod\APC\personal-blog\u_ex", String.Empty)
        .Replace("_x.log", String.Empty);

    var tanggal = namaBersih.Substring(4, 2);
    var bulan = namaBersih.Substring(2, 2);
    var tahun = "20" + namaBersih.Substring(0, 2);

    Console.WriteLine($"{tanggal}-{bulan}-{tahun}");
}
```

Tadaaa . . .

```
08-10-2020
09-10-2020
10-10-2020
```

