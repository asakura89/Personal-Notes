<p>
  <h1 align="center">Kelompok Belajar Bunga Matahari</h1>
  <h3 align="center" style="margin-top: -2em;">Coding sudah seharusnya menyenangkan!</h3>
  <h5 align="center" style="margin-top: -0.5em;">
    <a href="https://github.com/asakura89">asakura89</a> /
    <a href="https://choosealicense.com/licenses/unlicense/">UNLICENSE</a> /
    20210605
  </h5>
  <!-- use MistyLightWindows theme -->
</p>



[TOC]



## [.Net] Perkenalan
### 1. Entry Point
Semua apps yang dibuat pake C# .Net, atau .Net tanpa memandang bahasa lebih tepatnya, memiliki entry point. Terkecuali web, atau yang dibuat dengan ASP.Net. 
Karena web apps memiliki life cycle (urutan seuatu web app dieksekusi). Apps yang berjenis desktop, kaya WinForm, WPF, dan Console, entry point-nya dimulai dari method `Main`.  

```c#
class Program {
    static void Main(string[] args) {
        // ^ Method ini adalah Entry Point.
    }
}
```



### 2. Constructor
Sewaktu class dipanggil, baris code yang pertama kali dijalanin adalah baris code yang ada di `constructor`. `constructor` adalah method dengan nama yang sama dengan nama class, tapi gak punya return value. 
Atau gak ada nilai yang balikin dari method itu. Biasanya method ini punya keyword `void` (method yang gak balikin nilai). Tapi `constructor` ini method khusus, jadi gak punya keyword `void` juga.  

```c#
class Program {
    public Program() {
        // ^ Method ini adalah constructor,
        // namanya sama dengan nama class dan gak punya return value
    }

    static void Main(string[] args) {
        var program = new Program();
        // sewaktu class Program dipanggil, constructor dari class itu akan dieksekusi duluan
    }
}
```



### 3. Deklarasi
Tahap deklarasi adalah tahapan sewaktu variabel dibuat. Apakah diberi nilai atau enggak.

```c#
class Program {
    static void Main(string[] args) {
        // Deklarasi variabel
        int permenDiTanganKiri;
        int permenDiTanganKanan = 3;
    }
}
```



### 4. Inisialisasi
Tahap inisialisasi adalah tahapan sewaktu variabel diberi nilai.

```c#
class Program {
    // Deklarasi variabel
    int jariKakiKiri;
    int jariKakiKanan;

    public Program() {
        // Inisialisasi variabel
        jariKakiKiri = 5;
        jariKakiKanan = 5;
    }

    static void Main(string[] args) {
        int permenDiTanganKiri; // → hanya deklarasi
        int permenDiTanganKanan = 3; // → deklarasi dan inisialisasi
    }
}
```

#### 4.1. Array Initializers
```c#
class Program {
    static void Main(string[] args) {
        var arrayPertama = new string[3];
        var arrayKedua = new string[3] { "Ini", "array", "kedua" };
        var arrayKetiga = new string[] { "Ini", "aray", "ketiga" };
        var arrayKeempat = new[] { "Ini", "array", "keempat" };
        var arrayKelima = { "Ini", "array", "kelima" }; // → tidak akan ter-compile karena tidak ada informasi type. walaupun C# udah mulai merambah ke dynamic typing, sejatinya C# tetap bahasa strong-typed.
        string[] arrayKeenam = { "Ini", "array", "keenam" };
    }
}
```

Mudah kan?
Bandingin sama yang ini coba

```c#
class Program {
    static void Main(string[] args) {
        string[] arrayPertama = new string[3];
        arrayPertama[0] = "Ini";
        arrayPertama[1] = "array";
        arrayPertama[2] = "pertama";
    }
}
```



#### 4.2. Object Initializers
```c#
public class Koordinat {
    public Double Lintang { get; set; }
    public Double Bujur { get; set; }
}

public class TitikTempat : Koordinat {
    public String NamaTempat;
}

class Program {
    static void Main(string[] args) {
        var tujuan = new TitikTempat {
            Lintang = -6.1753924,
            Bujur = 106.8249641,
            NamaTempat = "Monumen Nasional"
        };
    }
}
```

Sebagai perbandingan

```c#
public class Koordinat {
    public Double Lintang { get; set; }
    public Double Bujur { get; set; }
}

public class TitikTempat : Koordinat {
    public String NamaTempat;
}

class Program {
    static void Main(string[] args) {
        TitikTempat tujuan = new TitikTempat();
        tujuan.Lintang = -6.1753924;
        tujuan.Bujur = 106.8249641;
        tujuan.NamaTempat = "Monumen Nasional";
    }
}
```



#### 4.3. Property Initializers



#### 4.4. Index Initializers



### 5. Print to Console
Apa itu `Console`? `Console` adalah program yang beroperasi di lingkungan text hitam putih. Biasanya program-program yang dibuat bekerja di lingkungan ini adalah program yang kecil, simpel, dan melakukan operasi yang gak kompleks. 
Atau bisa juga untuk program yang gak perlu banyak input dari pengguna.  

Nah lalu yang dimaksud dengan Print to Console disini, gak ada hubungannya dengan nge-print ke kertas. Tapi maksudnya adalah, menampilkan ke `console`. Atau menampilkan ke text hitam putih.  

```c#
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Ini adalah Print to Console.");
        Console.ReadLine();
    }
}
```

![Print to Console](img\2020-03-27_22-20-53.png)



### 6. Membuat Library
Library disini adalah file `.dll`. Atau file yang bisa digunakan program yang lain. 
Misalkan ada program A mau nampilin kalimat "Budi pergi ke Sekolah". Terus ada program B mau nampilin kalimat yang mirip, yaitu "Sakha pergi ke Sekolah".
Karena secara pola, kedua program itu sama-sama ngelakuin hal yang sama, cuma beda di nama orangnya aja. 
Maka bagian yang ngoperasiin buat nampilin kalimat "pergi ke Sekolah" bisa diekstrak dari kedua program tadi ke satu file yang lain yang nantinya bisa dipanggil dan jalanin operasi yang dipanggil tadi.

```c#
class ProgramA {
    static void Main(string[] args) {
        Console.WriteLine("Budi pergi ke Sekolah.");
        Console.ReadLine();
    }
}
```

```c#
class ProgramB {
    static void Main(string[] args) {
        Console.WriteLine("Sakha pergi ke Sekolah.");
        Console.ReadLine();
    }
}
```

Sebelum bagian program buat nampilin kalimat dipisah, kedua program itu code-nya bakal kaya di atas ini. 
Tapi abis dipisah jadi kaya di bawah.  

```c#
namespace LibraryKalimat {
    public class PenampilKalimat {
        public void TampilkanKalimat(string nama) {
            Console.WriteLine($"{nama} pergi ke Sekolah");
        }
    }
}
```

```c#
using LibraryKalimat;

class ProgramA {
    static void Main(string[] args) {
        var penampil = new PenampilKalimat();
        penampil.TampilkanKalimat("Budi");
        Console.ReadLine();
    }
}
```

```c#
using LibraryKalimat;

class ProgramB {
    static void Main(string[] args) {
        var penampil = new PenampilKalimat();
        penampil.TampilkanKalimat("Sakha");
        Console.ReadLine();
    }
}
```

![Library](img\2020-03-27_22-52-45.png)



### 7. Membuat variabel dan memberi nilai
Semua operasi app pasti butuh variabel. Semua nilai yang di dibaca dari file, diambil dari database, atau bisa juga dari internet, disimpan ke memory untuk dipake di dalem app dengan menggunakan variabel. 

```c#
class Program {
    static void Main(string[] args) {
        string nama1 = "Sakha";
        Console.WriteLine($"Namaku adalah {nama1}");

        var nama2 = "Sakha";
        Console.WriteLine($"Namaku adalah {nama2}");

        dynamic nama3 = "Sakha";
        Console.WriteLine($"Namaku adalah {nama3}");

        Console.ReadLine();
    }
}
```



### 8. Nilai standar
Kalo variabel gak diberi nilai, secara otomatis variabel itu akan diberi nilai standar / default value.

```c#
class Program {
    static void Main(string[] args) {
        bool nilaiBoolean;
        char nilaiChar;
        double nilaiDouble;
        float nilaiFloat;
        int nilaiInt;
        short nilaiShort;
        object nilaiObject;
        string nilaiString;

        // Console.WriteLine($"Nilai standar dari boolean: {nilaiBoolean}");
        // ^ compile-time error

        Console.ReadLine();
    }
}
```

Nilai standar dari code di atas adalah:

* `nilaiBoolean` → `false`
* `nilaiChar` → `\0` (Unicode untuk karakter `null`)
* `nilaiDouble` → `0`
* `nilaiFloat` → `0`
* `nilaiInt` → `0`
* `nilaiShort` → `0`
* `nilaiObject` → `null`
* `nilaiString` → `null`

Kalo mau ngeliat nilai standar sebelum diinisialisai, cuma bisa diliat lewat `debug mode`. Di VS Code sendiri ada fitur `variables`. 
Karena kalo variabelnya ditampilin / di-print ke console, bakal ada error message sewaktu di-compile. Jadi gak bisa di-compile terus dijalanin. 
Error ini adalah error dari compiler yang ditampilin sewaktu ada variabel yang mau dipake tapi gak diinisialisasi dulu.

![Nilai standar](img\2020-03-28_19-16-35.png)



### 9. Nilai tetap
Sama kaya namanya, nilai tetap ini gak bisa diubah setelah diberi nilai. Ada 2 nilai tetap di C#. Yang satu `readonly`. Yang satu lagi `const`. 
Bedanya kalo `const`, nilainya sama sekali gak bisa diubah dan gak diambil dari variabel manapun. Jadi nilainya adalah nilai dirinya sendiri. 
Sedangkan `readonly`, nilainya cuma bisa diberi / diisi sebaris / inline sewaktu deklarasi atau di `constructor`.

```c#
class Program {
    const bool bundar = true;

    readonly bool topiSaya = bundar;
    readonly bool bukanTopiSaya;

    public Program() {
        bukanTopiSaya = bundar == false;

        // bundar = false;
        // ^ compile-time error

        Console.WriteLine($"Apakah topi saya bundar? {topiSaya}");
        Console.WriteLine($"Bagaimana dengan bukan topi saya, apakah juga bundar? {bukanTopiSaya}");

        Console.ReadLine();
    }

    static void Main(string[] args) {
        var program = new Program();
    }
}
```

![Nilai tetap](img\2020-05-17_204428.png)



### 10. Field
Misalkan, ada objek nyata bernama Orang memiliki atribut Tinggi, Berat, Mata, Rambut. Semua atribut ini memiliki nilai. Jika dipetakan ke sebuah OOP template atau class di C#, maka disebut juga dengan `Field`. Atribut ini adalah sifat dari OOP. Coba lihat contoh di bawah ini.

```C#
public void Run() {
    var budi = new Orang {
        Tinggi = 168.0f,
        Berat = 64.2f,
        Mata = "Coklat Tua",
        Rambut = "Hitam"
    };

    var clarissa = new Orang {
        Tinggi = 173.3f,
        Berat = 65.7f,
        Mata = "Biru Gelap",
        Rambut = "Keperakan"
    };
}

public class Orang {
    public Single Tinggi;
    public Single Berat;
    public String Mata;
    public String Rambut;
}
```



### 11. Property
Awalnya di programming language Java, ada istilah `getter` dan `setter`. Apa itu? `getter` adalah method yang digunakan sebuah object untuk menyamarkan implementasi dari pemberian nilai atau pengambilan nilai pada sebuah atribut atau `Field`. Kok harus disamarkan? Ini mengacu pada `Encapsulation` dari OOP. Yang berhak tau implementasi dari pemberian dan pengambilan nilai pada `Field`, adalah object itu sendiri. Bukan object lain. 

Contohnya adalah object clarissa di *section 10. Field* di atas. Mungkin bisa lihat code di bawah biar lebih jelas penggambarannya.

```C#
public void Run() {
    var clarissa = new Clarissa();
    Console.WriteLine(clarissa.GetTinggi());
    Console.WriteLine(clarissa.GetBerat());
    Console.WriteLine(clarissa.GetMata());
    Console.WriteLine(clarissa.GetRambut());

    clarissa.SetRambut("Ungu Cerah");
    Console.WriteLine(clarissa.GetRambut());
}

public abstract class Orang {
    protected Single InternalTinggi;
    protected Single InternalBerat;
    protected String InternalMata;
    protected String InternalRambut;
}

public class Clarissa : Orang {
    public Clarissa() {
        InternalTinggi = 152.0f;
        InternalBerat = 87.8f;
        InternalMata = "Hitam";
        InternalRambut = "Hitam";
        
        catRambut = "Keperakan";
    }
    
    String catRambut = String.Empty;
    
    public Single GetTinggi() {
        var highHeels = 21.3f;
        return InternalTinggi + highHeels;
    }

    public Single GetBerat() {
        var toleransiAkurasiTimbangan = -22.1f;
        return InternalBerat + toleransiAkurasiTimbangan;
    }

    public String GetMata() {
        var contactLensPrincess = "Biru Gelap";
        return contactLensPrincess;
    }

    
    public String GetRambut() {
        if (String.IsNullOrEmpty(catRambut))
            return InternalRambut;

        return catRambut;
    }
    
    public void SetRambut(String warnaBaru) {
        catRambut = warnaBaru;
        InternalRambut = "Hitam";
    }
}
```

Yang berhak tau dari pengambilan dan proses sebelum pengambilan nilai dari atributnya adalah object clarissa sendiri. Bukan object lain. Dengan kata lain, yang object lain cukup tau adalah apa yang di-expose sebagai `public` aja. Kecuali untuk warna rambut. Object clarissa membolehkan object lain untuk memberi nilai warna rambutnya.

Code di atas adalah code primitive sewaktu Java mengenalkan konsep `getter`/`setter`. Di C# sendiri, `getter`/`setter` udah built-in di dalam syntax-nya. Jadi code di atas bisa di-refactor dengan menggunakan code berikut.

```C#
public void Run() {
    var clarissa = new Clarissa();
    Console.WriteLine(clarissa.Tinggi);
    Console.WriteLine(clarissa.Berat);
    Console.WriteLine(clarissa.Mata);
    Console.WriteLine(clarissa.Rambut);

    clarissa.Rambut = "Ungu Cerah";
    Console.WriteLine(clarissa.Rambut);
}

public abstract class Orang {
    protected Single InternalTinggi;
    protected Single InternalBerat;
    protected String InternalMata;
    protected String InternalRambut;
}

public class Clarissa : Orang {
    public Clarissa() {
        InternalTinggi = 152.0f;
        InternalBerat = 87.8f;
        InternalMata = "Hitam";
        InternalRambut = "Hitam";

        catRambut = "Keperakan";
    }

    String catRambut = String.Empty;
    
    public Single Tinggi {
        get {
            var highHeels = 21.3f;
            return InternalTinggi + highHeels;
        }

        private set {
            InternalTinggi = value;
        }
    }

    public Single Berat {
        get {
            var toleransiAkurasiTimbangan = -22.1f;
            return InternalBerat + toleransiAkurasiTimbangan;
        }

        private set {
            InternalBerat = value;
        }
    }

    public String Mata {
        get {
            var contactLensPrincess = "Biru Gelap";
            return contactLensPrincess;
        }

        private set {
            InternalMata = value;
        }
    }

    public String Rambut {
        get {
            if (String.IsNullOrEmpty(catRambut))
                return InternalRambut;

            return catRambut;
        }

         set {
            catRambut = value;
            InternalRambut = "Hitam";
        }
    }
}
```

property di C# 2
backing field
auto property di C# 3
get set di C# 6
get set di C# 7

property butuh untuk binding
contoh control yang punya binding

kalo gak butuh-butuh amat buat binding dan yang lain, mending pake public Field gadak salahnya juga kok

https://softwareengineering.stackexchange.com/questions/109943/combining-getters-and-setters
https://softwareengineering.stackexchange.com/questions/355148/dealing-with-a-lot-of-getters-and-setters
https://stackoverflow.com/questions/57131458/difference-between-using-gettersetter-and-public-properties
https://stackoverflow.com/questions/1568091/why-use-getters-and-setters-accessors


## [.Net] String
Tipe data `string` memang paling populer dan paling gampang untuk dipake. Apapun data yang mau dipake di app, paling gampang make tipe data `string` buat nampung nilainya. 

### 1. Dasar
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



### 2. Multi-line String
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



### 3. Interpolation / penyisipan kata
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



### 4. Concatenation / rentetan kata
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



### 5. Split
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



### 6. Substring
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



### 7. Awalan dan akhiran
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



### 8. Replace
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



## [.Net] Type
### 1. `var`
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



### 2. `dynamic`
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



### 3. Anonymous
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



## [.Net] Collection
### 1. Array / List



### 2. Pasangan Key-Value



### 3. Set (daftar unik)



### 4. Antrian (FIFO / First In First Out)



## [.Net] Alur program



## [.Net] Collection Pipeline
`Collection` secara general me-refer ke `Array`, `List`, `Dictionary` atau object yang memiliki anak yang lebih dari 1 dan bisa diiterasi / loop. 
Sedangkan `Pipeline` me-refer ke fungsi dari suatu code / app yang bisa menerima input dari fungsi / app lain lalu memprosesnya kemudian menghasilkan output yang masih bisa diproses oleh fungsi lain. 
Kalau digabungkan, `Collection Pipeline` adalah `Pipeline` yang menerima input dan menghasilkan output dalam bentuk `Collection`.  

`Collection Pipeline` sendiri dalam tipa-tiap teknologi atau bahasa bisa punya istilah yang beda. Misal di .Net ada istilah `Linq` atau `Lambda method`, di javascript ada istilah `Array Method`, di Powershell, Bash-shell, ataupun Windows cmd ada istilah `Pipe`. 
Semuanya me-refer ke `Collection Pipeline`. Buat bahasan di .Net kita akan pake istilah `Linq`.  

`Linq` yang paling sering dipake adalah `Select`, `Where`, `Sort`, `Aggregate`.  



### 1. Select
Secara konsep fungsi `Select` ini disebut juga `Map`. `Select` / `Map` ini tugasnya adalah menerima `Collection`, mentransformasi si input tadi menjadi `Collection` dalam bentuk yang berbeda.  

Flow-nya adalah kaya di bawah ini.  

![Select flow](img\BungaMatahari-CollectionPipeline-Select.png)

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

atau, kalo terlalu mager buat misahin variable data dan result, kita bisa pake cara preman (oneliner code).  

```C#
var result = new[] {
        "clifford", "lewis", "ollie", "leah", "kathryn", "carolyn",
        "genevieve", "adam", "milton", "eleanor", "maurice", "ethel",
        "charles", "danny", "stephen", "gabriel", "susan", "donald",
        "isabella", "patrick"
    }
    .Select(name => name[0].ToString().ToUpper() + name.Substring(1, name.Length -1));
```

atau, kalo masih terlalu panjang ke kanan, kita bisa pake cara preman sewaktu dia lagi sebel (oneliner code alternative version).  

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

Tujuan preman ngelakuin ini adalah tidak lain dan tidak bukan untuk men-simplify code biar gampang dibaca.  

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

Dari code di atas, ternyata preman kena code review sama boss preman, dia disuruh `refactor` buat `Pipeline` yang kedua karena terlalu panjang untuk dijadikan parameter. 
Maka akhirnya preman `refactor` jadi kaya di bawah ini.  

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

Boss preman masih gak puas dan nyuruh preman buat `refactor` sekali lagi.  

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

Lagi-lagi boss preman masih tidak puas.  

"Baiklah!" kata preman.  

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

Di atas, preman menggunakan `MethodGroup`. `MethodGroup` adalah istilah yang digunakan untuk mendefinisikan kondisi sewaktu method dipanggil hanya dengan nama, tanpa menggunakan signature (parameter). 
Dari code di atas (`.Select(TitleCasedName)`), `TitleCasedName` dipanggil tanpa menyebutkan signature. 
Karena parameter yang diterima di `Select` dan parameter yang diterima di `TitleCasedName` sama-sama berjumlah 1 dan sama-sama memiliki `Type` `String`. 
Begitupun dengan method `NumberifiedName`.  

Untung tak dapet di raih, malang tak dapat ditolak, boss preman lagi-lagi tidak puas. Akhirnya boss preman turun tangan sendiri untuk me-`refactor` code preman.  

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

Di `TitleCasedName`, karena isi method tersebut cuma oneliner, boss preman mulai menggunakan teknik C# 6 yaitu `Expression Body`. 
`Expression Body` ini bisa digunakan untuk men-simplify code dengan membuang kurung kurawal scope-wrapper dan menggantikannya dengan lambda `=>`. 
Karena ada `return` juga, `return` ini juga dibuang karena tidak ada scope.  

Di `NumberifiedName`, karena boss preman terlalu mager buat melakukan `String Concatenation` menggunakan operator plus `+`, `return`-nya diganti menggunakan `String Interpolation`. 
Yaitu menggunakan dollar-sign `$` di depan `string`-nya terus menggunakan kurung kurawal untuk nge-wrap variable yang digunakan didalam `string`.  



### 2. Where
`Where` juga disebut `Filter`. `Where` / `Filter` ini tugasnya adalah menerima `Collection`, memilih si input tadi berdasarkan kriteria / predikat, lalu menghasilkan output `Collection` yang sesuai dengan kriteria / predikat yang disebutkan.  
Flow-nya adalah kaya di bawah ini.  

![Where flow](img\BungaMatahari-CollectionPipeline-Where.png)

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



### 3. Sort
Sort di .Net menggunakan method `OrderBy`, `ThenBy`, `OrderByDescending`, dan `ThenByDescending`. Tugasnya? udah pasti buat ngurutin data berdasarkan `key`. 
Flow-nya kaya di bawah ini.

![Sort flow](img\BungaMatahari-CollectionPipeline-Sort.png)

Nah, `key` ini apa? `Key` ini adalah object yang digunakan sebagain acuan urutan. Misal, kalo di kelas dulu sewaktu preman sama boss preman masih sekolah. 
Mereka diabsen secara berurutan berdasarkan abjad pertama dari nama mereka. 
Atau misalkan, preman sama boss preman lagi ikut pelajaran Pendidikan Kesehatan dan Jasmani terus semua murid dibagi jadi 2 kelompok berdasarkan ganjil genap nomor absen

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

Buat kasus pembagian 2 kelompok tadi, boss preman inisiatif buat ngebagi kelompoknya. Kalo diinget-inget lagi sekarang, pembagiannya bisa dengan gampangnya dibikinin program-nya segampang membalikkan telapak tangan.  

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



### 4. Aggregate

Secara konsep `Aggregate` ini sering disebut `Reduce`.  `Reduce` seperti nama panggilannya, tugasnya adalah me-reduce atau mengurangi. Atau lebih tepatnya memperciut. Apa yang diperciut? Adalah jumlah butir (item) dari sebuah`Collection`.

Flow-nya kaya di bawah ini.

![Aggregate flow](img\BungaMatahari-CollectionPipeline-Aggregate.png)

Contoh paling dekat adalah fungsi `SUM` yang ada di bahasa SQL. `SUM` memperciut butir `Collection` yang tadinya ada sekian menjadi hanya sebuah atau satu hasil. Misalkan ada `Collection` yang berisikan 3 butir `integeter`, dengan `SUM` 3 butir tadi dijumlahkan menjadi satu hasil.

```C#
public void Run() {
    var bilangan = new[] { 3, 10, 15 };
    var total = bilangan.Aggregate(0, (acc, item) => acc + item);
}
```

Isi dari variable `total` adalah 28. Kenapa? Karena logika utama dari `Aggregate`/`Reduce` di atas adalah menjumlahkan semua butir.

Oke mari ke contoh yang lain.

"TUNGGUU OEE!" teriak Bos Preman dengan lantang.

"JANGAN SEMBARANGAN NGODING!" masih teriakan Bos Preman yang lantang sambil berlari mendekat.

Dengan cekatan Bos Premana langsung me-refactor code di atas menjadi

```C#
public void Run() {
    var bilangan = new[] { 3, 10, 15 };
    var total = bilangan.Aggregate(0, Sum);
}

public Int32 Sum(Int32 accumulated, Int32 item) => accumulated + item;
```

Bos Preman tidak akan tinggal diam kalo ada code yang tidak bisa dimengerti dengan gampang. Itu adalah prinsip hidupnya. Walaupun simpel, harus tetap bisa dimengerti.

Oke, satu masalah terselesaikan, mari kita lanjut.

Suatu hari Bos Preman dipanggil pak RT untuk mengumpulkan anak buahnya untuk menerima pembagian Bantuan Langsung Tunai dari pemerintah. Tapi sayangnya bantuan tersebut memiliki syarat. Tidak semua orang bisa mendapatkannya. Syaratnya adalah penerima harus berkeluarga dan memiliki anak lebih dari 1. Yang jadi masalah adalah Bos Preman tidak hapal berapa jumlah anak masing-masing anak buahnya.

Akhirnya Bos Preman teringat teknik `Reduce`. Dia akan mencari nilai terbesar dari jumlah anak yang dimiliki anak buahnya. Anak buahnya hanya perlu menulis nama dan jumlah anak saja, nanti sisanya urusan Bos Preman.

```C#
public void Run() {
    var bilangan = new[] {
        new AnakBuah { Nama = "Jupri", JumlahAnak = 3 },
        new AnakBuah { Nama = "Sapri", JumlahAnak = 2 },
        new AnakBuah { Nama = "Mukri", JumlahAnak = 2 },
        new AnakBuah { Nama = "Rojali", JumlahAnak = 6 },
        new AnakBuah { Nama = "Badri", JumlahAnak = 0 }
    };
}

public class AnakBuah {
    public String Nama;
    public Int32 JumlahAnak;
}
```

Setelah terkumpul, Bos Preman mulai melancarkan aksinya untuk mencari tau apakah anak buahnya berhak menerima bantuan yang disebutkan pak RT.

```C#
public void Run() {
    var semuaAnakBuah = new[] {
        new AnakBuah { Nama = "Jupri", JumlahAnak = 3 },
        new AnakBuah { Nama = "Supri", JumlahAnak = 1 },
        new AnakBuah { Nama = "Mukri", JumlahAnak = 2 },
        new AnakBuah { Nama = "Rojali", JumlahAnak = 6 },
        new AnakBuah { Nama = "Badri", JumlahAnak = 0 }
    };
    
    var berhak = semuaAnakBuah
        .Where(YangBerhak)
        .OrderBy(item => item.Nama)
        .Select((item, index) => new AnakBuah {
            Nomor = index +1,
            Nama = item.Nama,
            JumlahAnak = item.JumlahAnak
        })
        .Aggregate(String.Empty, SatukanDaftarNama)
        .TrimEnd(',', ' ');
    
    var tidakBerhak = semuaAnakBuah
        .Where(YangTakBerhak)
        .OrderBy(item => item.Nama)
        .Select((item, index) => new AnakBuah {
            Nomor = index +1,
            Nama = item.Nama,
            JumlahAnak = item.JumlahAnak
        })
        .Aggregate(String.Empty, SatukanDaftarNama)
        .TrimEnd(',', ' ');
}

public String SatukanDaftarNama(String accumulated, AnakBuah item) =>
    $"{accumulated}{item.Nomor}: {item.Nama}, ";

public Boolean YangBerhak(AnakBuah anakBuah) => anakBuah.JumlahAnak > 1;

public Boolean YangTakBerhak(AnakBuah anakBuah) => anakBuah.JumlahAnak <= 1;

public class AnakBuah {
    public Int32 Nomor;
    public String Nama;
    public Int32 JumlahAnak;
}
```

Hasilnya, ada 3 yang berhak menerima dan ada 2 yang tidak berhak menerima.

```c#
1: Jupri, 2: Mukri, 3: Rojali
1: Badri, 2: Supri
```

Tapi Bos Preman sudah mengantisipasi ini dengan menyuarakan jikalau seandainya ada anak buahnya yang tidak berhak mendapatkan bantuan, maka harus dibantu.

Dan semuanya setuju, dan pada akhirnya semua anak buah mendapat bantuan dengan menjumlahkan semua bantuan dan membagi rata total bantuan.

Begitulah kehidupan Bos Preman dan anak buahnya berjalan seperti biasa kembali.



## [.Net] Extension Methods
`Extension Methods` merupakan salah satu fitur C# 3 yang paling membantu. Kenapa? karena, `Extension Methods` bisa bikin seakan suatu `class` punya suatu `method` yang kita define tanpa harus ngerubah isi `class` tersebut. 
`Extension Methods` ini biasanya dipake buat memodifikasi `class` yang gak bisa diubah langsung. Atau paling sering dipake buat `util class` / `helper class` (`class`-`class` kecil yang dipake dan dipanggil dari berbagai macam `class` lain yang punya logic yang simple dan digunakan sebagai alat pembantu). 
Syarat `Extension Methods` ini adalah harus ditaro di `static class`, terus harus berupa `static method`, harus menggunakan keyword `this` pada parameter pertama yang mana parameter pertamanya adalah `class` yang mau di-extend.  

Misalkan ada variabel nama dan mau dijadiin `TitleCase`. Biasanya kita bakal bikin `util class` yang bisa dipake bareng-bareng dari manapun. 

```C#
public void Run() {
    var nama = "bretpit kertarajasa";
    var titleCase = StringUtil.TitleCasedName(nama);
}

public static class StringUtil {
    public static String TitleCasedName(String name) {
        var splitted = name.Split(' ');
        for (var idx = 0; idx < splitted.Length; idx++) {
            var part = splitted[idx];
            var firstChar = part[0].ToString().ToUpper();
            var theRest = part.Substring(1, part.Length -1).ToLower();
            splitted[idx] = firstChar + theRest;
        }

        return String.Join(" ", splitted);
    }
}
```

Kalo `util class` di atas (`StringUtil`) di-convert jadi `Extension Methods`, nanti jadi gini  

```C#
public void Run() {
    var nama = "bretpit kertarajasa";
    var titleCase = nama.TitleCasedName();
}

public static class StringUtil {
    public static String TitleCasedName(this String name) {
        var splitted = name.Split(' ');
        for (var idx = 0; idx < splitted.Length; idx++) {
            var part = splitted[idx];
            var firstChar = part[0].ToString().ToUpper();
            var theRest = part.Substring(1, part.Length -1).ToLower();
            splitted[idx] = firstChar + theRest;
        }

        return String.Join(" ", splitted);
    }
}
```

Method `TitleCasedName`-nya dipanggil seakan-akan dia adalah method dari `string` (variable `nama` disini bertipe `string` walaupun kita pake keyword `var` buat nampungnya).  

Semua itu adalah ilusi semata. Kenapa? karena ini fitur dari language C# 3. Artinya sewaktu compiler C# nanti nge-compile code yang pake `Extension Methods` (code yang kedua) dia bakal di-compile jadi code yang pake `static class` (code yang pertama).  

Jadi fitur ini ada di level language-nya (C#). Bukan di level runtime-nya (.Net).



## [.Net] Custom Collection Pipeline



## [.Net] Delegate
`Delegate` ini adalah konsep `function pointer` yang ada di .Net. Dengan adanya `delegate` ini malah ngebawa konsep `functional` ke bahasa yang berkonsep `object oriented` kaya C# ini. 
Apa sebenernya `function pointer`? `function pointer` adalah jenis khusus dari variabel yang digunakan untuk menyimpan reference / memory address dari sebuah method. Jadi method yang biasanya kitab pake dengan cara dipanggil, sekarang bisa juga ditampung jadi sebuah variabel buat dipanggil nanti. 
Atau malah buat dikirim sebagai `parameter` ke method yang lain.  

Di C#, `delegate` ini adalah keyword. Dan bukan cuma sekedar konsep.  

Karena C# ini by default adalah static language, yang artinya semua jenis variabel harus ada type-nya, jadi kita gak bisa bikin `delegate` atau `function pointer` ke `anonymous function`. Apa itu `anonymous function`? Ialah `function` tak bernama dan tak dideklarasi. Karena harus ber-type tadilah setiap `delegate` harus merujuk ke satu jenis `function` / `Method` yang spesifik.  

Contohnya code kaya gini, `var funcPointer = delegate{};`. Kenapa? Karena compiler gak bisa nebak, `delegate{}` ini nge-refer / nge-point ke function dengan type apa. Apa nge-refer ke `void` tanpa parameter? Atau nge-refer ke `function` yang nge-return `int` tanpa parameter? Atau malah nge-refer ke `function` yang return `bool` tanpa parameter. Terlalu banyak kemungkinan.  

Baiklah langsung ke contohnya aja.  

```C#
delegate void CaraBerpindahTempat();

public void Run() {
    CaraBerpindahTempat funcPointer = delegate{};
    funcPointer = ManusiaBerpindahTempat;
    funcPointer();

    funcPointer = SupermanBerpindahTempat;
    funcPointer();
}

public void ManusiaBerpindahTempat() {
    Console.WriteLine("Dengan cara berjalan.");
}

public void SupermanBerpindahTempat() {
    Console.WriteLine("Dengan cara terbang.");
}
```

Selain `void`, ya pastinya `delegate` juga bisa buat jenis `function` yang lain dong. Tapi ya itu tadi, definisiin dulu type-nya.

```C#
delegate String CaraBerpindahTempat();

public void Run() {
    CaraBerpindahTempat funcPointer = delegate{ return String.Empty; };
    funcPointer = ManusiaBerpindahTempat;
    var pindahTempatnyaManusia = funcPointer();

    funcPointer = SupermanBerpindahTempat;
    var pindahTempatnyaSuperman = funcPointer();
}

public String ManusiaBerpindahTempat() {
    return "Dengan cara berjalan.";
}

public String SupermanBerpindahTempat() {
    return "Dengan cara terbang.";
}
```

Kalo pake cara preman, code-nya jadi gini.  

```C#
delegate String CaraBerpindahTempat();

public void Run() {
    CaraBerpindahTempat funcPointer = () => String.Empty;
    funcPointer = ManusiaBerpindahTempat;
    var pindahTempatnyaManusia = funcPointer();

    funcPointer = SupermanBerpindahTempat;
    var pindahTempatnyaSuperman = funcPointer();
}

public String ManusiaBerpindahTempat() => "Dengan cara berjalan.";

public String SupermanBerpindahTempat() => "Dengan cara terbang.";
```

### 1. Action
`function` / `Method` sendiri ada 4 jenis.  
1. Tanpa return value
2. Dengan parameter dan tanpa return value
3. Dengan return value
4. Dengan parameter dan dengan return value

Dari keempat ini, `Action` masuk ke kategori no. 1 dan 2 yaitu tanpa return value. Apakah punya parameter atau enggak.  

`Action` ini termasuk delegate yang bisa langsung pake. Jadi gak perlu di definisiin dulu. Karena udah didefinisiin dari BCL-nya (Base Class Library bukan Bunga Citra Lestari) .Net.  

Yang paling dasar ada `Action` aja. Ini merujuk (points / sebagai pointer) ke `function` kategori no. 1. Tanpa return value dan tanpa parameter. 
Ada juga yang `Action<T>`. `T` disini berarti memiliki parameter dengan type `T` (Generic). Ini merujuk ke `function` kategori no. 2. Untuk kategori no. 2 ini ada banyak `overload` (varian dari `function` / `Method`-nya). 
Mulai dari `Action<T>`, atau yang parameter `T`-nya cuma satu. Sampe ke `Action<T, T2, T3 . . . T16>` yang parameter-nya sampe 16. Tapi begitupun daripada ditabokin Boss Preman, mending `refactor` deh semua `Method`-nya biar maksimal cuma punya 3 parameter. 
Gimana caranya? Jadiin semua parameternya jadi satu `class` sendiri yang khusus.  

Mari langsung praktek. Kalo contoh `delegate` di atas di `refactor` jadi pake `Action`, maka jadinya kaya di bawah ini.  

```C#
public void Run() {
    Action caraBerpindahTempat = delegate {};
    caraBerpindahTempat = ManusiaBerpindahTempat;
    caraBerpindahTempat();

    caraBerpindahTempat = SupermanBerpindahTempat;
    caraBerpindahTempat();
}

public void ManusiaBerpindahTempat() => Console.WriteLine("Dengan cara berjalan.");

public void SupermanBerpindahTempat() => Console.WriteLine("Dengan cara terbang.");
```

Buat yang multiple parameter bisa diliat di bawah ini.  


```C#
public void Run() {
    var aksi = new Dictionary<String, String> {
        ["Budi"] = "Lompat",
        ["Sandi"] = "Jalan tegak lurus",
        ["Preman"] = "Lari",
        ["Boss Preman"] = "Lari 12 m/s",
        ["Superman"] = "Terbang"
    };

    Action<IDictionary<String, String>, String> caraBerpindahTempat = (aksiPindah, nama) => { };
    caraBerpindahTempat = CaraBerpindahTempat;
    caraBerpindahTempat(aksi, "Budi");
    caraBerpindahTempat(aksi, "Preman");
    caraBerpindahTempat(aksi, "Syaiton");
}

public void CaraBerpindahTempat(IDictionary<String, String> aksiPindah, String nama) {
    if (aksiPindah.ContainsKey(nama))
        Console.WriteLine(aksiPindah[nama]);
    else
        Console.WriteLine("Menghilang");
}
```

Hasilnya? syuda pasti dapat ditebak.  

```
Lompat
Lari
Menghilang
```



### 2. Func
Kebalikan dari `Action`, `Func` termasuk kategori no. 3 dan 4. `Func` adalah `delegate` yang merujuk ke `Method` yang punya return value.  

Bedanya sama `Action`, karena `Func` ini punya return value, jadi gak ada `Func` yang tanpa Generic. Jadi pasti seminimal mungkin adanya `Func<T>`. `T` disini adalah type dari return value-nya, dan tanpa parameter. Terus yang pake parameter gimana? Yang pake parameter, jumlah `T`-nya mulai dari 2 atau lebih dengan maksimal `T` sampe 17 atau `Func<T1, T2, . . . T16, TResult>`. Dimana 16 `T` yang pertama adalah parameter maksimal, `T` yang terakhir adalah `T` untuk return value.  

Jadi kalo mau pake `Func` yang pake parameter, minimal harus punya 2 `T`. Karena `T` terakhir selalu `T` return value.  

Kalo mau nge-`refactor` code di atas jadi pake `Func` bisa banget. Contohnya gini ni.  

```C#
public void Run() {
    var aksi = new Dictionary<String, String> {
        ["Budi"] = "Lompat",
        ["Sandi"] = "Jalan tegak lurus",
        ["Preman"] = "Lari",
        ["Boss Preman"] = "Lari 12 m/s",
        ["Superman"] = "Terbang"
    };

    Func<IDictionary<String, String>, String, String> caraBerpindahTempat = (aksiPindah, nama) => String.Empty;
    caraBerpindahTempat = CaraBerpindahTempat;
    var budi = caraBerpindahTempat(aksi, "Budi");
    var preman = caraBerpindahTempat(aksi, "Preman");
    var syaiton = caraBerpindahTempat(aksi, "Syaiton");
}

public String CaraBerpindahTempat(IDictionary<String, String> aksiPindah, String nama) {
    if (aksiPindah.ContainsKey(nama))
        return aksiPindah[nama];
        
    return "Menghilang";
}
```


### 3. Predicate



## [.Net] IIFE
`IIFE` tu apa sik? `IIFE` adalah singkatan dari Immediately Invoked Function Expression.  

Sebenernya `IIFE` ini awal mulanya dari javascript. Javascript sendiri memang menganggap `function` adalah first-class citizen. Artinya `function` yang bisa disimpen di dalem variabel, `function` yang dilempar jadi parameter `function` yang lain itu semua udah biasa banget. Normal. Gadak yang aneh.  

Tapi buat C# di .Net? .Net sendiri punya cara untuk bikin `function` (dalam bahasa .Net disebut `Method`), jadi first-class citizen. Gimana cara .Net? Pake `delegate`.  

```C#
Int32 anggotaPreman = 7;
Int32 palakanPerHari = 30_000;
Int32 totalPalakan = new Func<Int32>(() => anggotaPreman * palakanPerHari).Invoke();
```

Kalo mau pake cara preman, gak perlu pake `.Invoke()`. Cukup pake `()` aja. Dengan gitu bakal jadi lebih mirip `IIFE` yang ada di javascript.  

```C#
Int32 anggotaPreman = 7;
Int32 palakanPerHari = 30_000;
Int32 totalPalakan = new Func<Int32>(() => anggotaPreman * palakanPerHari)();
```

Apa `IIFE` cuma bisa pake `Func`? Enggak kok. Pake `Action` juga bisa. Nih, biasanya boss preman manggilin anggotanya pake ini.  

```C#
new Action(() => Console.WriteLine("Woee... Kumpul klean semua sini!"))();
```



## [.Net] Fitur Bahasa C#
### C# 2.0

### C# 3.0
1. Implicitly typed local variable (baca bagian _[.Net] Type → 1. `var`_)
2. Object initializers (baca bagian _[.Net] Perkenalan → 4. Inisialisasi_)
3. Array initializers (baca bagian _[.Net] Perkenalan → 4. Inisialisasi_)


### C# 4.0

### C# 5.0

### C# 6.0
1. Index initializers (baca bagian _[.Net] Perkenalan → 4. Inisialisasi_)
2. Property initializers (baca bagian _[.Net] Perkenalan → 4. Inisialisasi_)

### C# 7.0

### C# 7.1

### C# 7.2

### C# 7.3

### C# 8.0

### C# 9.0




## [.Net] Event Handler

1. Event keyword

2. Multicast

3. Observer Pattern


## [Software Engineering] [.Net] Event Emitter



## [Sitecore] Sitecore Event



## [Software Engineering] [.Net] Dependency Injection



## [Software Engineering] [.Net] Minimalizing bugs



### 1. Private-First

Teknik ini merupakan versi garis kerasnya encapsulation. Encalsulation itu kan memiliki makna, hanya class atau method tersebut yang boleh tau isi dari implementation-details yang diterapin di 

### 2. Exception must not escape



### 3. Localized member



### 4. Expressive code



### 5. Refactor continuously



### 6. Module-based architecture



### 7. Utilize 100% coverage for unit-test and integration-test




Dengan ngambil huruf pertama dari masing-masing step di atas dan menggabungkannya menjadi sebuah nama programming principle, boss preman ngajarin teknik ini ke preman yang mirip dengan teknik SOLID-principle.   



## [Software Engineering] Developer Resolutions
Jadi seorang Developer ataupun Programmer itu susah. Apalagi menjaga keseimbangan kegiatan sehari-hari dan bekerja sama berat dan susahnya.  

Ini beberapa saran, resolusi, hal yang bisa ngejaga kita tetep sehat, waras, dan enjoy menjadi Developer.  

### Dev
Programming is a solo activity. Try spending a lot of time alone
Collaborate with other programmers to save time and effort
Learn more programming lang / theory / code / software / app
Finish personal project
Keep it simple. (Write a simple code which is easy to read and debug which helps in shipping product faster)

### Work
Have result-oriented goals (products which u can really ship)
Fix a goal and then reverse engineer the timelines and technical effort
Keep back straight while sitting on chair
Have exposure to sunlight during your non-productive hours such mealtime
Drink a lot of fluid to save your eyes

### Self
Good Sleep
Wake up early
Eat healthy food
Exercise
Express feelings with hobby
Stop complaining / squawking / sighing
Automate
Focus on security and privacy and backup your data
Get out of comfort zone

# Human being
Priorities family
Unfollow negative energy around you
Meet new people
Always smiling
Embrace the uncomfortable
Engage arts and humanities
Mimic deaf people, they dont listen (but do listen constructive feedback)



## [Software Engineering] Mengajukan ide
Dengan seiring bertambahnya usia, pengetahuan, dan kebijakan, pastinya kita sadar kalo misalkan kita mau ngajuin satu ide kita butuh juga nyodorin impact analysis. Apa pros and cons, apa keunggulan dan kekurangan.  
Dan pastinya kita juga butuh nyari tau solusi sejenis. Yang mungkin sebenernya cons-nya udah di-handle sama ide sejenis tersebut. Atau malah pros-nya lebih banyak ada di ide sejenis tersebut tapi untuk kasus spesifik yang lagi di-handle sekarang butuh pros yang ada di ide yang sekarang. Atau dengan mengevaluasi tujuan yang mau dicapai, bisa juga sebagai bahan pertimbangan untuk ngajuin ide yang sekarang ketimbang ide sejenis walaupun pros lebih banyak di ide sejenis.  




## [Solr] Perkenalan
Apache Solr adalah `search engine` berskala enterprise yang berbasiskan Apache Lucene. Solr menyimpan datanya dalam bentuk inverted index format ([src](https://www.quora.com/Where-does-the-Apache-Solr-store-the-actual-data-If-it-is-stored-on-a-local-disk-can-it-be-separated-and-be-stored-on-a-NoSQL-data-base)) / Lucene index format. 
Index ini sendiri disimpan berbentuk file di local filesystem by default. Tapi bisa juga di setup untuk disimpandi HDFS (Hadoop Distributed Filesystem) ([src](https://blog.toadworld.com/2017/07/20/storing-apache-solr-5-x-data-in-hdfs), [src](https://stackoverflow.com/questions/7685464/where-solr-store-search-index-in-database-or-in-file)).  

Solr by default beroperasi di standalone mode. Standalone mode ini beroperasi dengan sistem `core`. Dimana `core` disini adalah index yang di-manage di satu Solr server. 
Saat digunakan dalam skala besar, Solr bisa di setup dengan menggunakan distributed mode. Biasa disebut Solr Cloud. Solr Cloud biasanya di-run di beberapa server sebagai HA (High Availibility).



## Sumber

https://dartdoc.takyam.com/docs/synonyms/
