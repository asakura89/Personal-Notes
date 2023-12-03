---
tags:
- Powershell
- Array
date: 2019-01-11
---

# Array Methods

- [0. Persiapan](#0-persiapan)
- [1. Map](#1-map)
- [2. Filter](#2-filter)
- [3. Sort](#3-sort)
- [4. Aggregate / Reduce](#4-aggregate--reduce)
- [5. Concatenate](#5-concatenate)



Belajar bahasa pemrograman baru apapun itu, paling gampang mulainya yaitu dari manipulasi `Array`. Ini adalah unpopular opinion dari saia 🤣🤣🤣.



## 0. Persiapan

Pertama-tama, nyiapin data _dummy_ nih. Ngambil dari _[Online generator](http://www.convertcsv.com/generate-test-data.htm)_ ini.
Udah gitu masukin ke `$data`. Terus tampilin ke layar dengan manggil `$data` lagi

```powershell
$data = @(
    "Clifford", "Lewis", "Ollie", "Leah", "Kathryn", "Carolyn",
    "Genevieve", "Adam", "Milton", "Eleanor", "Maurice", "Ethel",
    "Charles", "Danny", "Stephen", "Gabriel", "Susan", "Donald",
    "Isabella", "Patrick"
)

$data
```

Btw, karena bakalan di-_run_ di _Server_, jadi better di-_save_ ke `Script.ps1`. Terus _run_!!

Nanti jadi gini.

```powershell
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

Sedikit review nih. Operasi `Array` itu umumnya ada 4. Yaitu adalah jeng-jeng-jeng-jeng!!!!! `Map`, `Filter`, `Sort`, `Aggregate/Reduce`
Kita mulai dari yang pertama dulu yaa.
​


## 1. Map

`Map` di `Powershell` mirip kaya yang ada di `.Net`. _Keyword_-nya `Select-Object`
Sedangkan kalo `.Net` pake `.Select()`
​
```powershell
$counter = 1;
$mapped = $data |
    Select-Object { ("{0}. {1}" -f $counter++,$_) }

$mapped
```

Hasilnya kira-kira kaya di bawah ini nih.

```powershell
 ("{0}. {1}" -f $counter++,$_)
 -------------------------------
 1. Clifford
 1. Lewis
 1. Ollie
 1. Leah
 1. Kathryn
 1. Carolyn
 1. Genevieve
 1. Adam
 1. Milton
 1. Eleanor
 1. Maurice
 1. Ethel
 1. Charles
 1. Danny
 1. Stephen
 1. Gabriel
 1. Susan
 1. Donald
 1. Isabella
 1. Patrick
```

Ada yang aneh gak? Perhatiin gak angkanya? 1 semua kan?

Ternyata itu karena di `Powershell` ada _scope_ di _scripting_-nya. Yang mana `$counter` di dalem _block_ `Select-Object` sewaktu di-`++` gakkan pengaruh ke `$counter` yang di luar
Karena pada dasarnya `Select-Object` ini adalah _function_ yang mana _function_ punya _scope_ sendiri
Bisa dibaca [disini](https://ss64.com/ps/syntax-scopes.html) ya.

Nah, karena kita pake _file_ buat ngejalanin `script`-nya jadi kit pake _scope_ `$script:`

Jadi gini nih.

```powershell
$counter = 1;
$mapped = $data |
    Select-Object { ("{0}. {1}" -f $script:counter++,$_) }

$mapped
```

Hasilnya jadinya bener kaya di bawah ini.

```powershell
 ("{0}. {1}" -f $script:counter++,$_)
 --------------------------------------
 1. Clifford
 2. Lewis
 3. Ollie
 4. Leah
 5. Kathryn
 6. Carolyn
 7. Genevieve
 8. Adam
 9. Milton
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



## 2. Filter

Dan lagi-lagi `Filter` di `Powershell` mirip kaya yang ada di `.Net`
Kalo di `.Net` itu `.Where()`. Kalo di `Powershell`-nya itu `Where-Object`

```powershell
$counter = 1;
$filtered = $data |
    Where-Object { $_.ToLower().Contains("an") }

$mapped = $filtered |
    Select-Object { ("{0}. {1}" -f $script:counter++,$_) }

$mapped
```

Atau bisa sekalian gini

```powershell
$counter = 1;
$data |
    Where-Object { $_.ToLower().Contains("an") } |
    Select-Object { ("{0}. {1}" -f $script:counter++,$_) }
```

_Output_-nya gini.

```powershell
("{0}. {1}" -f $script:counter++,$_)
--------------------------------------
1. Eleanor
2. Danny
3. Susan
```

Nyadar gak kalo di atas ada method `.ToLower()` sama `.Contains()`-nya `.Net`
Yuhuuu. Cadas ye gak? 👍



## 3. Sort

Nah, kali ini `Sort` di `Powershell` beda sama yang ada di `.Net`
`.Net` punya = `.OrderBy()` atau `.OrderByDescending()`. Sedangkan `Powershell` punya = `Sort-Object` atau `Sort-Object -Descending`. Contohnya di bawah ini.

```powershell
$counter = 1;
$filtered = $data |
    Where-Object { `
        $_.ToLower().StartsWith("le") -Or `
        $_.ToLower().EndsWith("el") -Or `
        ($_[0].ToString().ToLower() -Eq "d") `
    }

$sorted = $filtered |
    Sort-Object -Descending { $_ }

$mapped = $sorted |
    Select-Object { ("{0}. {1}" -f $script:counter++,$_) }

$mapped
```

Atau bisa sekalian

```powershell
$counter = 1;
$data |
    Where-Object { `
        $_.ToLower().StartsWith("le") -Or `
        $_.ToLower().EndsWith("el") -Or `
        ($_[0].ToString().ToLower() -Eq "d") `
    } |
    Sort-Object -Descending { $_ } |
    Select-Object { ("{0}. {1}" -f $script:counter++,$_) }
```

Yang mana meng-_output_-kan inih.

```powershell
 ("{0}. {1}" -f $script:counter++,$_)
 --------------------------------------
 1. Lewis
 2. Leah
 3. Gabriel
 4. Ethel
 5. Donald
 6. Danny
```

Setelah beberapa kali _output_, liat gak _header_-nya? `("{0}. {1}" -f $script:counter++,$_)` kan

Itu karena `Select-Object` sejatinya memang untuk `Object`. Apapun yang di _output_-in `Select-Object` pasti `type`-nya `Object`
Apa hubungannya sama _header_ yang _suneh_ (baca: suka aneh) gitu? Itu karena `Select-Object`-nya _projecting anonymous object_
Lalu gimana biar gak _anonymous_? Kita bisa pake yang namanya _computed property_ atau _calculated property_. Contohnya gini.

```powershell
$counter = 1;
$filtered = $data |
    Where-Object {
        $_.ToLower().StartsWith("le") -Or `
        $_.ToLower().EndsWith("el") -Or `
        ($_[0].ToString().ToLower() -Eq "d") `
    }

$sorted = $filtered |
    Sort-Object -Descending { $_ }

$mapped = $sorted |
    Select-Object @{
        Name = "Mapped";
        Expression = {"{0}. {1}" -f $script:counter++,$_}
    }

$mapped
```

Atau

```powershell
$counter = 1;
$data |
    Where-Object {
        $_.ToLower().StartsWith("le") -Or `
        $_.ToLower().EndsWith("el") -Or `
        ($_[0].ToString().ToLower() -Eq "d") `
    } |
    Sort-Object -Descending { $_ } |
    Select-Object @{ `
        Name = "Mapped"; `
        Expression = {"{0}. {1}" -f $script:counter++,$_} `
    }
```

Nanti hasilnya jadi gini.

```powershell
 Mapped
 --------------------------------------
 1. Lewis
 2. Leah
 3. Gabriel
 4. Ethel
 5. Donald
 6. Danny
```

Atau bisa gini

```powershell
$counter = 1;
$filtered = $data |
    Where-Object {
        $_.ToLower().StartsWith("le") -Or `
        $_.ToLower().EndsWith("el") -Or `
        ($_[0].ToString().ToLower() -Eq "d")
    }

$sorted = $filtered |
    Sort-Object -Descending { $_ }

$mappedv1 = $sorted |
    Select-Object @{ `
        Name = "Mapped"; `
        Expression = {"{0}. {1}" -f $script:counter++,$_} `
    }

$mappedv2 = $mappedv1 |
    Select-Object @{ `
        N="Mapped v2"; `
        E={ $_.Mapped } `
    }

$mappedv2
```



## 4. Aggregate / Reduce

`Reduce` di `Powershell` rada beda ya. Soalnya dia pake keyword `ForEach-Object`. Padahal kan ya `foreach` itukan buat `iterate / looping` pada umumnya
Tapi di `Powershell` sendiri ada `ForEarch-Object` ada `ForEach` _statement_. KIta gak perlu bahas disini biar bahasannya gak meluas

Nah, `ForEach-Object` punya `Begin`, `Process`, dan `End`. 3 fitur ini yang bisa dipake buat melakukan `Reduce`

Karena ini fungsi terakhir, jadi kita _combine_ aja semua fungsi-fungsi di atas. _Here goes!_

```powershell
$counter = 1;
$mapped = $data |
    Sort-Object -Descending { $_ } |
    Select-Object `
        @{ N="Index"; E={($script:counter++)} }, `
        @{ N="Name"; E={$_} }

$even = $mapped |
    Where-Object { $_.Index % 2 -Eq 0 } |
    ForEach-Object `
        -Begin { $start = "" } `
        -Process { $start = $start + $_.Index + ": " + $_.Name + ", " } `
        -End { $start.Substring(0, $start.Length -2) }

$odd = $mapped |
    Where-Object { $_.Index % 2 -Ne 0 } |
    ForEach-Object `
        -Begin { $start = "" } `
        -Process { $start = $start + $_.Index + ": " + $_.Name + ", " } `
        -End { $start.Substring(0, $start.Length -2) }

$even
$odd
```

Menghasilkan iniih.

```powershell
 2: Stephen, 4: Ollie, 6: Maurice, 8: Leah, 10: Isabella, 12: Gabriel, 14: Eleanor, 16: Danny, 18: Charles, 20: Adam
 1: Susan, 3: Patrick, 5: Milton, 7: Lewis, 9: Kathryn, 11: Genevieve, 13: Ethel, 15: Donald, 17: Clifford, 19: Carolyn
```



## 5. Concatenate

```powershell
Clear-Host

[System.Collections.Generic.List[System.Int32]]$range = 1..10
[System.Collections.Generic.List[System.Int32]]$range2 = 11..20

$range3 = $range + $range2
$range3

[System.Collections.Generic.List[System.Int32]]$range4 = 45..65 + 78..98

$range4
```

Jadinya gini

```powershell
1
2
3
4
. . . omitted . . .
96
97
98
```

Wuaaahhhh, pada nyangka gak kalo ternyata `Powershell` se-_mancay_ iniihh? Kadang hal-hal kecil semacam ini yang ngasi kita motivasi buat _explore_ lebih jauh lagi

Semangka!! Gas!!