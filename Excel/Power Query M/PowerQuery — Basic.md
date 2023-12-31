---
tags:
- Excel
- Power-Query-M
date: 2023-12-31
---

# Basic

- [What is](#what-is)
- [Data Types](#data-types)
- [`let` and `in` keywords](#let-and-in-keywords)
- [Selecting Excel Table](#selecting-excel-table)
- [Filters](#filters)
- [Extract text](#extract-text)
- [Data cleaning](#data-cleaning)
- [Sort](#sort)
- [Finalizing](#finalizing)



## What is

Power Query M adalah programming language punya Microsoft yang dibikin buat nge-process dan analyze data. Yang gak bisa cuma visualize data. Jadi kalo mau visualize, bisa pake fitur chart dari excel. Tapi prepapre data buat chart-nya bisa pake Power Query M.



## Data Types

Primitive data types biasanya sebutan buat semua data type built-in dari language tertentu, dalam konteks sekarang berarti data types built-in punya M-language. Di M-language, primitive data types-nya ada banyak (bisa baca [dari sini](https://powerquery.how/data-types/) atau [dari sini](https://learn.microsoft.com/en-us/powerquery-m/m-spec-types)). Tapi yang paling sering kepake adalah ini:
1. <ins>`text`:</ins> Semua text masuk data type ini. Kalo di language lain biasa disebut `string`.
2. <ins>`number`:</ins> Semua angka dengan koma dan tanpa koma masuk kesini. Di language lain biasa disebut `decimal`. Tapi kalo pengen angka tanpa koma, bisa pake data type yang beda dikit, yaitu `Int64.Type`.
3. <ins>`logical`:</ins> Ini di language lain suka disebut `boolean` atau `bool`. Data type ini cuma berisi 2 jenis value. Antara `true` atau `false` aja.
4. <ins>`date`:</ins> Ini adalah tanggal tanpa jam.
5. <ins>`datetime`:</ins> Dan ini adalah tanggal dengan jam.
6. <ins>`list`:</ins> Data type ini isinya list of value, atau biasa disebut `array` di language lain.
7. <ins>`table`:</ins> Ini data type yang gak umum di language lain. Biasanya bakal butuh nge-define custom data type. Tapi di M, table ini bakal data type yang paling sering jadi input dan output.
8. <ins>`function`:</ins> Di language lain ini disebut `lambda`. Jadi ini termasuk high order function. Karena di-assign sebagai parameter.
9. <ins>`any`:</ins> Data type ini nerima value apapun. Mungkin kalo bingung mau kategoriin suatu value karena terlalu banyak jenis bisa set ke any aja. Misal kalo ada kolom data yang isinya kombinasi dari angka, teks, kosong (tanpa isi).



## `let` and `in` keywords

`let` adalah keyword buat nge-initialize dan nge-assign variable, juga buat ngelakuin kalkulasi/process. Sedangkan `in` adalah keyword buat nge-output hasil process terakhir, pada umumnya. Tapi kalo mau nge-output hasil process yang tengah, juga bisa.



## Selecting Excel Table

Disini gak cuma select (ngambil) data dari original Excel Table tapi juga convert column type-nya.

_NOTE: contoh excel dengan data ada disini [Adventure Works Product.xlsx](_media/Adventure%20Works%20Product.xlsx)_

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    TransformedTypes = Table.TransformColumnTypes(
        Source,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type datetime},
            {"SellEndDate", type any},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    )
in
    TransformedTypes
```

Output-nya

| ProductName      | ProductNumber | Color | SafetyStockLevel | SellStartDate  | SellEndDate | LocationName           | Shelf | Bin   | Quantity |
| :--------------- | :------------ | :---- | :--------------- | :------------- | :---------- | :--------------------- | :---- | :---- | :------- |
| Adjustable Race  | AR-5381       |       | 1000             | 4/30/2008 0:00 | -           | Tool Crib              | A     | 1     | 408      |
| Adjustable Race  | AR-5381       |       | 1000             | 4/30/2008 0:00 | -           | Miscellaneous Storage  | B     | 5     | 324      |
| Adjustable Race  | AR-5381       |       | 1000             | 4/30/2008 0:00 | -           | Subassembly            | A     | 5     | 353      |
| Bearing Ball     | BA-8327       |       | 1000             | 4/30/2008 0:00 | -           | Tool Crib              | A     | 2     | 427      |
| Bearing Ball     | BA-8327       |       | 1000             | 4/30/2008 0:00 | -           | Miscellaneous Storage  | B     | 1     | 318      |
| Bearing Ball     | BA-8327       |       | 1000             | 4/30/2008 0:00 | -           | Subassembly            | A     | 6     | 364      |
| BB Ball Bearing  | BE-2349       |       | 800              | 4/30/2008 0:00 | -           | Tool Crib              | A     | 7     | 585      |
| BB Ball Bearing  | BE-2349       |       | 800              | 4/30/2008 0:00 | -           | Miscellaneous Storage  | B     | 9     | 443      |
| BB Ball Bearing  | BE-2349       |       | 800              | 4/30/2008 0:00 | -           | Subassembly            | A     | 10    | 324      |
|                  |               |       | ... omitted ...  |                |             |                        |       |       |          |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     |  73      |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     |  60      |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 102      |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 121      |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     |  32      |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 108      |
| Road-150 Red, 52 | BK-R93R-52    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     |  52      |
| Road-150 Red, 52 | BK-R93R-52    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     |  76      |
| Road-150 Red, 56 | BK-R93R-56    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 112      |
| Road-150 Red, 56 | BK-R93R-56    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     |  51      |
|                  |               |       | ... omitted ...  |                |             |                        |       |       |          |



## Filters

Filters kalo di LINQ yang ada di .NET atau di SQL language buat database biasa disebut "Where". Atau bahasa teknis lainnya disebut "Predicate". Fungsinya buat ngefilter data dengan kriteria tertentu terus ambil yang masuk kriteria aja.

Contoh, kalo ngeliat contoh data ([Adventure Works Product.xlsx](_media/Adventure%20Works%20Product.xlsx)), di kolom "SellEndDate" ada data yang isinya "-". Sedangkan kalo ngeliat nama kolomnya "Date" udah pasti harusnya isinya tanggal. Tapi, ini juga bisa dimaksud dengan ada data yang memang gak punya tanggal berakhir dijual. Mungkin ini product yang terus diproduksi tanpa ada system musiman sama sekali. Jadi make sense. Nah tapi gimana kalo kita pengen ngambil data product yang musiman aja. Disini kita bisa pake filter.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    TransformedTypes = Table.TransformColumnTypes(
        Source,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type datetime},
            {"SellEndDate", type any},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each [SellEndDate] <> "-"
    )
in
    #"Seasoned Products"
```

Output-nya

| ProductName            | ProductNumber | Color | SafetyStockLevel | SellStartDate  | SellEndDate | LocationName           | Shelf | Bin   | Quantity |
| :--------------------- | :------------ | :---- | :--------------- | :------------- | :---------- | :--------------------- | :---- | :---- | :------- |
| Mountain Bike Socks, M | SO-B909-M     | White | 4                | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 180      |
| Mountain Bike Socks, L | SO-B909-L     | White | 4                | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 216      |
| Road-150 Red, 62       | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 73       |
| Road-150 Red, 62       | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 60       |
| Road-150 Red, 44       | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 102      |
| Road-150 Red, 44       | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 121      |
| Road-150 Red, 48       | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 32       |
| Road-150 Red, 48       | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 108      |
| Road-150 Red, 52       | BK-R93R-52    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 52       |
| Road-150 Red, 52       | BK-R93R-52    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 76       |
| Road-150 Red, 56       | BK-R93R-56    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 112      |
| Road-150 Red, 56       | BK-R93R-56    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 51       |
|                        |               |       | ... omitted ...  |                |             |                        |       |       |          |



## Extract text

Dari sini kita bisa liat kalo hasilnya nyampur antara sepeda dan aksesoris. Gimana kalo kita mau ngambil sepeda doang? Karena gak ada kategori yang bilang product X adalah sepeda dan product Y adalah aksesoris, kita bisa coba pisahin berdasarkan ProductNumber misalnya.

Kalo ngeliat polanya, ProductNumber punya identifier 2 character di depan. Jadi kita bisa pake 2 character ini sebagai category identifier. Sepeda = BK, berdasarkan pola di data.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    TransformedTypes = Table.TransformColumnTypes(
        Source,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type datetime},
            {"SellEndDate", type any},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> "-" and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    #"Seasoned Products"
```

Output-nya

| ProductName      | ProductNumber | Color | SafetyStockLevel | SellStartDate  | SellEndDate | LocationName           | Shelf | Bin   | Quantity |
| :--------------- | :------------ | :---- | :--------------- | :------------- | :---------- | :--------------------- | :---- | :---- | :------- |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 73       |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 60       |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 102      |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 121      |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Finished Goods Storage | N/A   | 0     | 32       |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011 0:00 | 41058       | Final Assembly         | N/A   | 0     | 108      |
|                  |               |       | ... omitted ...  |                |             |                        |       |       |          |



## Data cleaning

Kalo ngeliat dari output data terakhir, SellEndDate kok number ya, padahal kan namanya aja ada "Date"-nya. Kalo ngeliat dari `Table.TransformColumnTypes` function di code-nya, SellEndDate di-convert ke data type any. Jadi hasil output-nya ditampilin apa adanya sesuai data aslinya ketika disimpen ke excel, yaitu number yang merepresentasiin tanggal. Terus gimana biar orang yang ngebaca datanya bisa baca dengan jelas. Kalo gini kan gak ngerti orang juga apa maksudnya 41058. Ini makanya penting buat ngelakuin data cleaning.



### Step 1 — Fix SellEndDate type

Karena seharusnya data type SellEndDate adalah `date`, jadi letsego (pake nada mario) kita benerin.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    TransformedTypes = Table.TransformColumnTypes(
        Source,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type datetime},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> "-" and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    #"Seasoned Products"
```

Output-nya

```log
DataFormat.Error: We couldn't parse the input provided as a Date value.
Details:
    -
```

Uwaaah, error.

Ini karena, ternyata data SellEndDate ada yang berisi text "-". Kaya yang udah dijelasin di bagian [Filters](#filters), gak semua data SellEndDate isinya date. Gimana caranya biar data type-nya gak any tapi juga gak error? Kita bisa pake workaround yaitu semua tanggal yang gak ada, atau "-", diganti sama tanggal yang gak make sense secara real-life tapi valid secara pemrograman. Apa itu? Tanggal 1 Januari tahun 1. Caranya? Kita bisa pake `ReplaceValue`.


```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        Source,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type datetime},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> "-" and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    #"Seasoned Products"
```

Dari ngeliat output-nya, OK. Gadak error.



### Step 2 — Fix SellStartDate type

Selain SellEndDate, ternyata SellStartDate juga salah data type. Enggak salah banget sih, tapi rada gak pas dikit aja. Data dari dua kolom ini gak punya jam yang bener, dan jam juga gak relevan karena kita gakkan cek jam dari tanggal-tanggal penjualan mulai dan penjualan selese. Kita cuma butuh tanggal, paling enggak buat sekarang. Karena ada system yang penjualannya meriksa jam, karena cuma dijual tengah malem misalnya, atau promo cuma tengah malem. Yaoke lanjut.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        Source,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> "-" and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    #"Seasoned Products"
```

Sejauh ini aman, lanjut.



### Step 3 — Use correct filters

Etapi, kan harusnya kita ngambil data yang tanggal jualannya gak musiman, kok sekarang data yang tanggal-nya gak bener (secara common sense), yang 1 januari, malah masuk. Ini karena filter sebelumnya yang kita pake itu `[SellEndDate] <> "-"` sedangkan sekarang udah gak ada tanggal yang "-". Jadi filter-nya ngeproses-proses aja yang tanggalnya 1 januari.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        Source,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    #"Seasoned Products" = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> #date(1, 1, 1) and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    #"Seasoned Products"
```

Nah, sekarang udah bener.

Ebentar, karena filter kita sekarang udah spesifik cuma ngambil data sepeda, nama table "Seasoned Products" udah gak relevan lagi. Letsego fix it.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        Source,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    Bike = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> #date(1, 1, 1) and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    )
in
    Bike
```

Output setelah cleaning

| ProductName      | ProductNumber | Color | SafetyStockLevel | SellStartDate | SellEndDate | LocationName           | Shelf | Bin   | Quantity |
| :--------------- | :------------ | :---- | :--------------- | :------------ | :---------- | :--------------------- | :---- | :---- | :------- |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011     | 5/29/2012   | Finished Goods Storage | N/A   | 0     | 73       |
| Road-150 Red, 62 | BK-R93R-62    | Red   | 100              | 5/31/2011     | 5/29/2012   | Final Assembly         | N/A   | 0     | 60       |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011     | 5/29/2012   | Finished Goods Storage | N/A   | 0     | 102      |
| Road-150 Red, 44 | BK-R93R-44    | Red   | 100              | 5/31/2011     | 5/29/2012   | Final Assembly         | N/A   | 0     | 121      |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011     | 5/29/2012   | Finished Goods Storage | N/A   | 0     | 32       |
| Road-150 Red, 48 | BK-R93R-48    | Red   | 100              | 5/31/2011     | 5/29/2012   | Final Assembly         | N/A   | 0     | 108      |
| Road-150 Red, 52 | BK-R93R-52    | Red   | 100              | 5/31/2011     | 5/29/2012   | Finished Goods Storage | N/A   | 0     | 52       |
|                  |               |       | ... omitted ...  |               |             |                        |       |       |          |



## Sort

Sekarang data-nya udah bersih. Kita pengen tau nih yang stock-nya paling banyak yang mana. Kita bisa urutin berdasarkan stock terbanyak.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        Source,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            {"SafetyStockLevel", Int64.Type},
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            {"Shelf", type text},
            {"Bin", Int64.Type},
            {"Quantity", Int64.Type}
        }
    ),
    Bike = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> #date(1, 1, 1) and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    ),
    SortedByLargestStock = Table.Sort(
        Bike, {
            {"Quantity", Order.Descending}
        }
    )
in
    SortedByLargestStock
```

Output-nya

| ProductName            | ProductNumber | Color | SafetyStockLevel | SellStartDate | SellEndDate | LocationName           | Shelf | Bin   | Quantity |
| :--------------------- | :------------ | :---- | :--------------- | :------------ | :---------- | :--------------------- | :---- | :---- | :------- |
| Road-650 Black, 52     | BK-R50B-52    | Black | 100              | 5/31/2011     | 5/29/2013   | Final Assembly         | N/A   | 0     | 123      |
| Road-150 Red, 44       | BK-R93R-44    | Red   | 100              | 5/31/2011     | 5/29/2012   | Final Assembly         | N/A   | 0     | 121      |
| Road-650 Red, 48       | BK-R50R-48    | Red   | 100              | 5/31/2011     | 5/29/2013   | Final Assembly         | N/A   | 0     | 121      |
| Mountain-300 Black, 40 | BK-M47B-40    | Black | 100              | 5/30/2012     | 5/29/2013   | Final Assembly         | N/A   | 0     | 121      |
| Road-650 Black, 60     | BK-R50B-60    | Black | 100              | 5/31/2011     | 5/29/2013   | Finished Goods Storage | N/A   | 0     | 116      |
| Mountain-100 Black, 42 | BK-M82B-42    | Black | 100              | 5/31/2011     | 5/29/2012   | Final Assembly         | N/A   | 0     | 116      |
| Road-450 Red, 52       | BK-R68R-52    | Red   | 100              | 5/31/2011     | 5/29/2012   | Finished Goods Storage | N/A   | 0     | 116      |
|                        |               |       | ... omitted ...  |               |             |                        |       |       |          |



## Selecting specific columns

Gak semua kolom kadang gak butuh kita bawa buat di-present.

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    RemoveIrrelevantCols = Table.RemoveColumns(
        Source, {
            "SafetyStockLevel", "Shelf", "Bin"
        }
    ),
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        RemoveIrrelevantCols,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            /* {"SafetyStockLevel", Int64.Type}, */
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            /* {"Shelf", type text},
            {"Bin", Int64.Type}, */
            {"Quantity", Int64.Type}
        }
    ),
    Bike = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> #date(1, 1, 1) and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK"
    ),
    SortedByLargestStock = Table.Sort(
        Bike, {
            {"Quantity", Order.Descending}
        }
    )
in
    SortedByLargestStock
```

Output-nya

| ProductName            | ProductNumber | Color | SellStartDate    | SellEndDate | LocationName           | Quantity |
| :--------------------- | :------------ | :---- | :--------------- | :---------- | :--------------------- | :------- |
| Road-650 Black, 52     | BK-R50B-52    | Black | 5/31/2011        | 5/29/2013   | Final Assembly         | 123      |
| Road-150 Red, 44       | BK-R93R-44    | Red   | 5/31/2011        | 5/29/2012   | Final Assembly         | 121      |
| Road-650 Red, 48       | BK-R50R-48    | Red   | 5/31/2011        | 5/29/2013   | Final Assembly         | 121      |
| Mountain-300 Black, 40 | BK-M47B-40    | Black | 5/30/2012        | 5/29/2013   | Final Assembly         | 121      |
| Road-650 Black, 60     | BK-R50B-60    | Black | 5/31/2011        | 5/29/2013   | Finished Goods Storage | 116      |
| Mountain-100 Black, 42 | BK-M82B-42    | Black | 5/31/2011        | 5/29/2012   | Final Assembly         | 116      |
| Road-450 Red, 52       | BK-R68R-52    | Red   | 5/31/2011        | 5/29/2012   | Finished Goods Storage | 116      |
|                        |               |       | ... omitted ...  |             |                        |          |



## Finalizing

Okay, di step terakhir, kita lakuin semua buat finalizing data presentation biar bisa dikonsumsi dengan baik. Letsego!

```m
let
    Source = Excel.CurrentWorkbook(){[Name="ProductsRaw"]}[Content],
    RemoveIrrelevantCols = Table.RemoveColumns(
        Source, {
            "SafetyStockLevel", "Shelf", "Bin"
        }
    ),
    ReplaceDashDateToOneJan = Table.ReplaceValue(
        RemoveIrrelevantCols,
        "-", #date(1, 1, 1), Replacer.ReplaceValue, {"SellEndDate"}
    ),
    TransformedTypes = Table.TransformColumnTypes(
        ReplaceDashDateToOneJan,{
            {"ProductName", type text},
            {"ProductNumber", type text},
            {"Color", type text},
            /* {"SafetyStockLevel", Int64.Type}, */
            {"SellStartDate", type date},
            {"SellEndDate", type date},
            {"LocationName", type text},
            /* {"Shelf", type text},
            {"Bin", Int64.Type}, */
            {"Quantity", Int64.Type}
        }
    ),
    Bike = Table.SelectRows(
        TransformedTypes,
        each
            [SellEndDate] <> #date(1, 1, 1) and
            /* Text.Start([ProductNumber], 2) = "BK" */
            /* Text.StartsWith([ProductNumber], "BK") */
            Text.Range([ProductNumber], 0, 2) = "BK" and
            [LocationName] = "Finished Goods Storage" and
            Date.Year([SellEndDate]) = 2013
    ),
    AddTempColToBeSorted = Table.AddColumn(
        Bike,
        "ProductNoToBeSorted",
        each Text.Start([ProductNumber], 4),
        type text
    ),
    SortedByLargestStock = Table.Sort(
        AddTempColToBeSorted, {
            {"Quantity", Order.Descending},
            {"ProductNoToBeSorted", Order.Ascending}
        }
    ),
    CleanTempCols = Table.RemoveColumns(
        SortedByLargestStock,
        { "ProductNoToBeSorted" }
    ),
    Indexed = Table.AddIndexColumn(
        CleanTempCols,
        "#", 1, 1, Int64.Type
    ),
    ReorderCols = Table.ReorderColumns(
        Indexed, {
            "#", "ProductName", "ProductNumber", "Color",
            "SellStartDate", "SellEndDate", "LocationName", "Quantity"
        }
    )
in
    ReorderCols
```

Output-nya

| #     | ProductName            | ProductNumber | Color | SellStartDate | SellEndDate | LocationName           | Quantity |
| :---- | :--------------------- | :------------ | :---- | :------------ | :---------- | :--------------------- | :------- |
| 1     | Road-650 Black, 60     | BK-R50B-60    | Black | 5/31/2011     | 5/29/2013   | Finished Goods Storage | 116      |
| 2     | Road-250 Red, 44       | BK-R89R-44    | Red   | 5/30/2012     | 5/29/2013   | Finished Goods Storage | 112      |
| 3     | Road-650 Red, 58       | BK-R50R-58    | Red   | 5/31/2011     | 5/29/2013   | Finished Goods Storage | 112      |
| 4     | Road-650 Black, 52     | BK-R50B-52    | Black | 5/31/2011     | 5/29/2013   | Finished Goods Storage | 104      |
| 5     | Mountain-300 Black, 40 | BK-M47B-40    | Black | 5/30/2012     | 5/29/2013   | Finished Goods Storage | 102      |
| 6     | Road-650 Red, 48       | BK-R50R-48    | Red   | 5/31/2011     | 5/29/2013   | Finished Goods Storage | 102      |
| 7     | Road-650 Black, 62     | BK-R50B-62    | Black | 5/31/2011     | 5/29/2013   | Finished Goods Storage | 100      |
|       |                        |               |       | ... omitted ... |           |                        |          |

