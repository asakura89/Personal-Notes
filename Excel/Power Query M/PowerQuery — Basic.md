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
- [Cleaning data](#cleaning-data)



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



## Cleaning data

