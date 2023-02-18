---
tags:
- CSharp
- C#
- Draft
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



# DataTable

- [1. `DataTable` vs Collections](#1-datatable-vs-collections)
- [2. Manipulasi data](#2-manipulasi-data)
- [3. `DataView`](#3-dataview)
- [4. `Linq-to-DataTable`](#4-linq-to-datatable)



Dulu kala sebelum `Linq` (dibaca ling secara resmi, tapi AndBud dan Watie suka ngebaca lingki) populer, `DataTable` jadi pilihan utama buat manipulasi data. Dengan adanya `Linq` di .NET 3.5, semua manupulasi data bisa langsung dilakuin di `Array` (`String[]`, `Int32[]` atau yang lain bukan class `System.Array`) atau `List` dengan gampang. Tipe data buat nyimpen data pun jadi beragam dan peminat `List` jadi membludak. Tapi bukan berarti `DataTable` jadi gak kepake. Masih banyak code yang make `DataTable`. Contohnya hampir semua library 3rd party yang untuk ngolah Excel masih pake `DataTable`. Dari BCL (~~Bunga Citra Lestari~~ Base Class Library) .NET sendiri juga masih pake. Contohnya ADO.NET. ADO.NET punya clasa yang namanya `DataAdapter`. `DataAdapter` punya method yang namanya `.Fill()` dan parameter-nya adalah `DataTable` kosong yang bakal diisi sama data.



## 1. `DataTable` vs Collections

Terus apa yang bedain `DataTable` sama `Array` atau `List`?

Yang pertama `DataTable` ada di `namespace` `System.Data`, sedangkan `Array` ada di `namespace` `System` kalau inisialisasinya pake .NET Framework type ketimbang built-in type. Misal `String[]` ketimbang `string[]` atau `Single[]` ketimbang `float[]`. Sedangkan `List` ada di `namespace` `System.Collections` dan `System.Collections.Generic`.

Terus perbedaan yang kedua, struktur data `Array` atau `List` adalah daftar dari object. Misal ada `Array` atau `List` kaya di bawah ini.

```C#
var namaBuah = new String[] { "Jambu", "Stroberi", "Nangka" };
var umurPembeli = new Int32[] { 15, 62, 30, 12, 17 };

public class Pembeli {
    public String Tampilan;
    public Int32 UmurKiraKira;
}

var dataPembeli = new List<Pembeli> {
    new Pembeli { Tampilan = "Anak sekolahan", UmurKiraKira = 15 },
    new Pembeli { Tampilan = "Kakek-kakek", UmurKiraKira = 62 },
    new Pembeli { Tampilan = "Buk-ibuk", UmurKiraKira = 30 },
    new Pembeli { Tampilan = "Bocah", UmurKiraKira = 12 },
    new Pembeli { Tampilan = "Anak sekolahan", UmurKiraKira = 17 }
};
```

Maka bisa digambarin kaya gini.

![img](_media/BungaMatahari-DataTable-Collections.drawio.svg)

Kalo semisal data di atas kita bikin ulang pake `DataTable`, jadinya kaya di bawah ini.

```C#
var namaBuah = new DataTable();
namaBuah.Columns.Add(new DataColumn("Nama", typeof(String)));

DataRow row = namaBuah.NewRow();
row["Nama"] = "Jambu";
namaBuah.Rows.Add(row);

row = namaBuah.NewRow();
row["Nama"] = "Stroberi";
namaBuah.Rows.Add(row);

row = namaBuah.NewRow();
row["Nama"] = "Nangka";
namaBuah.Rows.Add(row);

var umurPembeli = new DataTable();
umurPembeli.Columns.Add(new DataColumn("Umur", typeof(Int32)));

row = umurPembeli.NewRow();
row["Umur"] = 15;
umurPembeli.Rows.Add(row);

row = umurPembeli.NewRow();
row["Umur"] = 62;
umurPembeli.Rows.Add(row);

row = umurPembeli.NewRow();
row["Umur"] = 30;
umurPembeli.Rows.Add(row);

row = umurPembeli.NewRow();
row["Umur"] = 12;
umurPembeli.Rows.Add(row);

row = umurPembeli.NewRow();
row["Umur"] = 17;
umurPembeli.Rows.Add(row);

var dataPembeli = new DataTable();
dataPembeli.Columns.AddRange(new [] {
    new DataColumn("Tampilan", typeof(String)),
    new DataColumn("UmurKiraKira", typeof(Int32))
});

row = dataPembeli.NewRow();
row["Tampilan"] = "Anak Sekolahan";
row["UmurKiraKira"] = 15;
dataPembeli.Rows.Add(row);

row = dataPembeli.NewRow();
row["Tampilan"] = "Kakek-kakek";
row["UmurKiraKira"] = 62;
dataPembeli.Rows.Add(row);

row = dataPembeli.NewRow();
row["Tampilan"] = "Buk-ibuk";
row["UmurKiraKira"] = 30;
dataPembeli.Rows.Add(row);

row = dataPembeli.NewRow();
row["Tampilan"] = "Bocah";
row["UmurKiraKira"] = 12;
dataPembeli.Rows.Add(row);

row = dataPembeli.NewRow();
row["Tampilan"] = "Anak Sekolahan";
row["UmurKiraKira"] = 17;
dataPembeli.Rows.Add(row);
```

Dan bisa digambarin kaya gini.

![img](_media/BungaMatahari-DataTable-Table.drawio.svg)

Perbedaan mendasarnya adalah `DataTable` punya kolom dan baris persis table di Database.



## 2. Manipulasi data

## 3. `DataView`

## 4. `Linq-to-DataTable`




Resources:

- [Draw.io diagram](_media/BungaMatahari-DataTable.xml)