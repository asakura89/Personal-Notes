<p>
  <h1 align="center">Kelompok Belajar Bunga Matahari</h1>
  <h3 align="center" style="margin-top: -2em;">Coding sudah seharusnya menyenangkan!</h3>
  <h5 align="center" style="margin-top: -0.5em;">
    <a href="https://github.com/asakura89/BisaCSharp.git">asakura89</a> /
    <a href="https://choosealicense.com/licenses/unlicense/">UNLICENSE</a>
  </h5>
  <!-- use MistyLightWindows theme -->
</p>



[TOC]



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



