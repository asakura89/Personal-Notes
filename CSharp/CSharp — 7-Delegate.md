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



# Delegate

- [1. Delegate](#1-delegate)
- [2. Action](#2-action)
- [3. Func](#3-func)
- [4. Predicate](#4-predicate)
- [5. IIFE](#5-iife)



## 1. Delegate

`Delegate` ini adalah konsep `function pointer` yang ada di .NET. Dengan adanya `delegate` ini malah ngebawa konsep `functional` ke bahasa yang berkonsep `object oriented` kaya C# ini. 
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

Kalo pake cara Budie, code-nya jadi gini.  

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



## 2. Action

`function` / `Method` sendiri ada 4 jenis.  
1. Tanpa return value
2. Dengan parameter dan tanpa return value
3. Dengan return value
4. Dengan parameter dan dengan return value

Dari keempat ini, `Action` masuk ke kategori no. 1 dan 2 yaitu tanpa return value. Apakah punya parameter atau enggak.  

`Action` ini termasuk delegate yang bisa langsung pake. Jadi gak perlu di definisiin dulu. Karena udah didefinisiin dari BCL-nya (Base Class Library bukan Bunga Citra Lestari) .NET.  

Yang paling dasar ada `Action` aja. Ini merujuk (points / sebagai pointer) ke `function` kategori no. 1. Tanpa return value dan tanpa parameter. 
Ada juga yang `Action<T>`. `T` disini berarti memiliki parameter dengan type `T` (Generic). Ini merujuk ke `function` kategori no. 2. Untuk kategori no. 2 ini ada banyak `overload` (varian dari `function` / `Method`-nya). 
Mulai dari `Action<T>`, atau yang parameter `T`-nya cuma satu. Sampe ke `Action<T, T2, T3 . . . T16>` yang parameter-nya sampe 16. Tapi begitupun daripada sebel diceramahin Budie soal simple code, mending `refactor` deh semua `Method`-nya biar maksimal cuma punya 3 parameter. 
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



## 3. Func

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



## 4. Predicate

Predicate ini secara general adalah `Func` yang return value-nya selalu `Boolean`. Dan bisa dibilang `class` khusus, karena .NET nyediain class `Predicate<T>`.

Cara pakenya? apa? apa? cara pakenya? gampang!

Dari namanya predicate, artinya membuktikan suatu kondisi. Bisa diartikan juga sebagai syarat untuk melakukan suatu action.

Contoh nih ya, contoh predicate sebagai `class` khusus.

```C#
Int32 anggotaPreman = 7;
Int32 palakanPerHari = 30_000;
Int32 totalPalakan = new Func<Int32>(() => anggotaPreman * palakanPerHari)();

Predicate<Int32> apakahTotalMencapaiTarget = palakan => palakan >= 70_000;
Predicate<Int32> apakahJumlahAnggotaCukupBanyak = anggota => anggota > 5;
Boolean mencapaiTarget = apakahTotalMencapaiTarget(totalPalakan);
Boolean anggotaBanyak = apakahJumlahAnggotaCukupBanyak(anggotaPreman);

if (mencapaiTarget)
    Console.WriteLine("Kerja bagus semuanya! Lanjutkan besok-besok.");
    
if (anggotaBanyak)
    Console.WriteLine("Ternyata anggota kita udah banyak banget ya.");
```



Ini contoh lain yang make `Func`

```C#
Int32 anggotaPreman = 7;
Int32 palakanPerHari = 30_000;
Int32 totalPalakan = new Func<Int32>(() => anggotaPreman * palakanPerHari)();

Func<Int32, Boolean> apakahTotalMencapaiTarget = palakan => palakan >= 70_000;
Func<Int32, Boolean> apakahJumlahAnggotaCukupBanyak = anggota => anggota > 5;
Boolean mencapaiTarget = apakahTotalMencapaiTarget(totalPalakan);
Boolean anggotaBanyak = apakahJumlahAnggotaCukupBanyak(anggotaPreman);

if (mencapaiTarget)
    Console.WriteLine("Kerja bagus semuanya! Lanjutkan besok-besok.");
    
if (anggotaBanyak)
    Console.WriteLine("Ternyata anggota kita udah banyak banget ya.");
```



## 5. IIFE

`IIFE` tu apa sik? `IIFE` adalah singkatan dari Immediately Invoked Function Expression.  

Sebenernya `IIFE` ini awal mulanya dari javascript. Javascript sendiri memang menganggap `function` adalah first-class citizen. Artinya `function` yang bisa disimpen di dalem variabel, `function` yang dilempar jadi parameter `function` yang lain itu semua udah biasa banget. Normal. Gadak yang aneh.  

Tapi buat C# di .NET? .NET sendiri punya cara untuk bikin `function` (dalam bahasa .NET disebut `Method`), jadi first-class citizen. Gimana cara .NET? Pake `delegate`.  

```C#
Int32 muridDatangTelatPerHariIni = 7;
Int32 dendaDatangTelat = 30_000;
Int32 totalPemasukanKas = new Func<Int32>(() => muridDatangTelatPerHariIni * dendaDatangTelat).Invoke();
```

Kalo mau pake cara Budie, gak perlu pake `.Invoke()`. Cukup pake `()` aja. Dengan gitu bakal jadi lebih mirip `IIFE` yang ada di javascript.  

```C#
Int32 muridDatangTelatPerHariIni = 7;
Int32 dendaDatangTelat = 30_000;
Int32 totalPemasukanKas = new Func<Int32>(() => muridDatangTelatPerHariIni * dendaDatangTelat)();
```

Apa `IIFE` cuma bisa pake `Func`? Enggak kok. Pake `Action` juga bisa. Nih, biasanya Watie manggilin mentemennya pake ini.  

```C#
new Action(() => Console.WriteLine("Woee... Kumpul klean semua sini! AndBud kalian jugaaa!"))();
```

