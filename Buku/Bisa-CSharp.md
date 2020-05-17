# Bisa CSharp



[TOC]

## Kebutuhan
### Operating System
Semua code dan kebutuhan menjalankan program, dijalankan di atas Windows 10. Karena menggunakan `.Net Core`, bisa memilih sesuai OS yang digunakan. Dengan catatan, cari installer yang sesuai. Berikut link yang disebut di bawah adalah spesifik Windows.



### .Net Core SDK
Di waktu tulisan ini dibuat, versi yang digunakan untuk semua program adalah `.Net Core 2.1`. Install / gunakan versi yang sama atau di atasnya (`>= 2.1`).

* [.Net Core](https://dotnet.microsoft.com/download/dotnet-core)
* [.Net Core SDK 2.1](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.1.610-windows-x64-installer)



### Visual Studio Code
Versi yang digunakan adalah versi terbaru saat tulisan ini dibuat, yaitu `1.43.2`. Install / gunakan versi yang sama atau di atasnya (`>= 1.43.2`).

* [VS Code](https://code.visualstudio.com/download)
* [VS Code 1.43.2](https://update.code.visualstudio.com/1.43.2/win32-x64/stable)



### C# Extension
Install C# Extension dari VS Code. Caranya klik icon extension (icon kubus rubik). Ketik `C#` untuk mencari. Lalu pilih extension `C#` dari `Microsoft`. Untuk versi akan otomastis ke yang paling baru.

![C# Extensions](2020-03-28_14-25-15.png)



## Persiapan
### Membuat Solution / file `.sln`



### Membuat  Project / file `.proj`



### Meng-compile / Mem-build program



### Menjalankan Program



## Tingkat awal
### Entry Point
Untuk Program C# berjalan ada titik awal yang dijadikan patokan oleh runtime. Yaitu Entry Point. Program yang berjenis desktop, seperti WinForm, WPF, dan Console, Entry Point dimulai dari method Main.

```c#
class Program {
    static void Main(string[] args) {
        // Method Main di atas ini adalah Entry Point.
    }
}
```



### Constructor
Ketika sebuah class dipanggil, maka baris code yang pertama kali dijalankan adalah baris code yang berada di constructor. Constructor adalah method dengan nama yang sama dengan nama class tetapi tidak memiliki return value. Atau tidak ada nilai yang dikembalikan dari method tersebut. Biasanya method semacam ini diberi keyword `void` (method yang tidak mengembalikan nilai). Tapi constructor adalah method khusus sehingga tidak memiliki keyword `void`.

```c#
class Program {
    public Program() {
        // Method di atas ini adalah constructor
    }

    static void Main(string[] args) {
        var program = new Program();
        // ketika class Program dipanggil maka constructor dari class tersebut akan dijalankan duluan
    }
}
```



### Deklarasi
Tahap deklarasi adalah tahapan ketika sebuah variable dibuat. Apakah diberi nilai atau tidak.

```c#
class Program {
    static void Main(string[] args) {
        // Deklarasi variable
        int permenDiTanganKiri;
        int permenDiTanganKanan = 3;
    }
}
```



### Inisialisasi
Tahap inisialisasi adalah tahapan ketika sebuah variable diberi nilai.

```c#
class Program {
    // Deklarasi variable
    int jariKakiKiri;
    int jariKakiKanan;

    public Program() {
        // Inisialisasi variable
        jariKakiKiri = 5;
        jariKakiKanan = 5;
    }

    static void Main(string[] args) {
        int permenDiTanganKiri; // → hanya deklarasi
        int permenDiTanganKanan = 3; // → deklarasi dan inisialisasi
    }
}
```



### Print to Console
Apa itu Console? Console adalah program yang beroperasi di lingkungan text hitam putih. Biasanya program-program yang dibuat bekerja di lingkungan ini adalah program yang kecil, simpel, dan melakukan operasi yang tidak kompleks. Atau bisa juga untuk program yang tidak butuh banyak input dari manusia.

Nah lalu yang dimaksud dengan Print to Console disini, tidak ada hubungannya dengan nge-Print ke kertas. Seperti nge-Print tugas, nge-Print makalah. Tetapi yang dimaksud adalah, menampilkan ke Console. Atau menampilkan ke text hitam putih.

```c#
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Ini adalah Print to Console.");
        Console.ReadLine();
    }
}
```

![Print to Console](2020-03-27_22-20-53.png)



### Membuat Library
Library disini adalah berkas / file .dll. Atau file yang bisa digunakan program yang lain. Misalkan ada program A mau menampilkan kalimat "Budi pergi ke Sekolah". Lalu ada program B mau menampilkan kalimat yang mirip, yaitu "Sakha pergi ke Sekolah". Nah, karena secara logika kedua program tersebut sama-sama melakukan hal yang sama hanya dengan berbeda nama orangnya aja. Maka bagian yang mengoperasikan untuk menampilkan kalimat "pergi ke Sekolah" bisa ekstrak dari kedua program tersebut ke satu file yang lain yang tidak bertugas menjalankan operasi tetapi untuk menyimpan operasi.

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

Sebelum bagian program untuk menampilkan kalimat dipisah, kedua program tersebut terlihat seperti di atas. Tetapi setelah dipisahm jadi terlihat seperti di bawah.

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
class ProgramA {
    static void Main(string[] args) {
        var penampil = new PenampilKalimat();
        penampil.TampilkanKalimat("Budi");
        Console.ReadLine();
    }
}
```

```c#
class ProgramB {
    static void Main(string[] args) {
        var penampil = new PenampilKalimat();
        penampil.TampilkanKalimat("Sakha");
        Console.ReadLine();
    }
}
```

![Library](2020-03-27_22-52-45.png)



### Membuat variabel dan memberi nilai
Ketika program C# berjalan, semua operasi dilakukan dengan menggunakan nilai dari variabel. Apakah dibaca dari file atau diambil dari database, atau bisa juga dari internet. Semua nilai-nilai yang dibaca tadi harus dimasukkan ke variabel dulu. Agar bias digunakan di dalam operasi program.

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



### Nilai standar
Ketika suatu variabel tidak diberikan nilai, maka secara otomatis variabel tersebut akan diberi nilai standar.

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

Nilai standarnya berturut-turut adalah:

* `nilaiBoolean` → `false`
* `nilaiChar` → `\0` (Unicode untuk karakter `null`)
* `nilaiDouble` → `0`
* `nilaiFloat` → `0`
* `nilaiInt` → `0`
* `nilaiShort` → `0`
* `nilaiObject` → `null`
* `nilaiString` → `null`

Untuk melihat nilai standar ketika belum di inisialisai  ini hanya bisa menggunakan fitur VS Code. Bernama `variables`. Karena kalau variabel nya ditampilkan akan ada pesan error saat di compile. Sehingga tidak bisa di-compile dan dijalankan. Error ini adalah error dari compiler yang akan ditampilkan ketika ada suatu variable yang akan digunakan tanpa diinisialisasi sebelumnya.

![Nilai standar](2020-03-28_19-16-35.png)



###  Nilai tetap
Seperti namanya, nilai tetap tidak bisa diubah setelah diberi nilai. Ada 2 nilai tetap di C#. Yang satu `readonly`. Yang satu lagi `const`. Bedanya hanya jika `const`, nilainya sama sekali tidak bisa diubah dan tidak diambil dari variabel manapun. Jadi nilainya adalah nilai dirinya sendiri. Sedangkan `readonly`, nilainya hanya bisa diberi sebaris / inline pada saat deklarasi atau di `constructor`.

```c#
class Program {
    const bool bundar = true;

    readonly bool topiSaya = bundar;
    readonly bool bukanTopiSaya;

    public Program() { // ← ini constructor\
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

![Nilai tetap](2020-05-17_204428.png)



### String dasar

```c#
var rawString = @"The following is not expanded to a tab \t";

var escapedString = "The following is not expanded to a tab \\t";

rawString == escapedString // == true
```



### Multi-line String

```c#
// C# allows multi-line literal strings.
// Both the first and last new-line are recognized.
var myString = @"
This is a string that spans
many lines.
";
```



### Interpolasi / penyisipan kata

```c#
// C# uses methods such as String.Format() to interpolate expressions with strings.

var name = "Aaron";
var greeting = String.Format("My name is {0}.", name);

var greetingPolish = String.Format("My Polish name would be {0}ski.", name);

var someProperty = String.Format("{0}px", top + 20);
```



### Concatenation / rentetan kata

```c#
// String concatenation with the '+' operator
var longMessage = "This is a very long line. "
                + "It is concatenated into one string.";
```



### Substring

```c#
"doghouses".Substring(3, 5); // == "house"
// The second argument is a length value.
```



### Awalan dan akhiran

```c#
"racecar".StartsWith("race"); // == true
"racecar".StartsWith("pace"); // == false
```



### Replace

```c#
var doghouzez = "doghouses".Replace('s', 'z');

var regex = new Regex("r");
var newText = regex.Replace("racecar", "sp", 1);
```



### Split

```c#
var animals = "dogs, cats, gophers, zebras";
var individualAnimals = animals.Split(new []{", "}, StringSplitOptions.None);
// == ['dogs', 'cats', 'gophers', 'zebras']
```



### Array / List



### Sort



```c#
var numbers = new List<double>{ 42, 2.1, 5, 0.1, 391 };
numbers.Sort((a, b) => a.CompareTo(b));
// == [0.1, 2.1, 5, 42, 391];

// Or produce new LINQ sequence without modifying numbers
numbers.OrderBy(n => n);
```



### Pasangan Key-Value




```c#
var periodic = new Dictionary<string, string>();

// There's also the concurrent variant
var cc = new ConcurrentDictionary<string, string>();

// C# Dictionary supports keys and values of any Type.
var periodic = new Dictionary<string, string>() {
    { "gold", "AU" },
    { "silver", "AG" }
};

var favoriteIceCream = new Dictionary<object, dynamic>();
favoriteIceCream[new Kid("Billy")] = "vanilla";


// Accessing with a string key.
periodic["gold"] // == 'AU'
periodic["gold"] = "Glitter";

// Get or add
string s;
if (!periodic.TryGetValue("Xenon", out s))
    periodic.Add("Xenon", "XE");

// The concurrent variant has methods like this built-in
cc.TryAdd("Xenon", "XE"));            // true
cc.GetOrAdd("Xenon", (key) => "XE")); // "XE"
```



### Set (daftar unik)



```c#
var fruits = new HashSet<String>();
fruits.Add("Oranges");
fruits.Add("Apples");
Console.WriteLine("{0}", fruits.Count); // == 2

fruits.Add("Oranges");
Console.WriteLine("{0}", fruits.Count); // == 2
```



### Antrian (FIFO / First In First Out)

```c#

var queue = new Queue<String>();
queue.Enqueue("event:32342");
queue.Enqueue("event:49309");

Console.WriteLine("{0}", queue.Count); // 2

var eventId = queue.Dequeue();

Console.WriteLine("{0}", eventId == "event:32342"); // true
Console.WriteLine("{0}", queue.Count); // 1
```



### Alur program

```c#
var bugNumbers = new[] { 3234, 4542, 944, 124 };
if (bugNumbers.Length > 0)
{
    Console.WriteLine("Not ready for release.");
}


var bugNumbers = new[] { 3234, 4542, 944, 124 };
var status = bugNumbers.Length > 0 ? "RED" : "GREEN";

Console.WriteLine("The build is {0}", status);


string myNull = null;

// For nullable types
if (myNull == null)
{
    Console.WriteLine("use == null to check null");
}

// In C# you can also check for the default value
if (myNull == default(MyClass))
{
    Console.WriteLine("It has the default value.");
}



```



## Tingkat Menengah

### Lambda


### Variable Lifetime

Scope
Normal variable

Static Variable

Persistence
Normal Variable

Static Variable


### Collection Pipeline

Map

Filter

Sort

Reduce



## Sumber

https://dartdoc.takyam.com/docs/synonyms/