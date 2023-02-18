---
tags:
- Javascript
- Array-Method
- Collection-Pipeline
date: 2020-06-07
---

# Array Methods

Data yang dipake

```Javascript
 let data = [
     { "Type": "Fruit", "Color": "Red", "Name": "Red Apples" },
     { "Type": "Fruit", "Color": "Red", "Name": "Blood Oranges" },
     { "Type": "Vegetables", "Color": "Red", "Name": "Beets" },
     { "Type": "Vegetables", "Color": "Red", "Name": "Red Peppers" },
     { "Type": "Fruit", "Color": "Yellow/Orange", "Name": "Yellow Apples" },
     { "Type": "Fruit", "Color": "Yellow/Orange", "Name": "Apricots" },
     { "Type": "Vegetables", "Color": "Yellow/Orange", "Name": "Yellow Apples" },
     { "Type": "Vegetables", "Color": "Yellow/Orange", "Name": "Apricots" },
     { "Type": "Fruit", "Color": "Blue/Purple", "Name": "Blackberries" },
     { "Type": "Fruit", "Color": "Blue/Purple", "Name": "Blueberries" },
     { "Type": "Vegetables", "Color": "Blue/Purple", "Name": "Black Olives" },
     { "Type": "Vegetables", "Color": "Blue/Purple", "Name": "Purple Asparagus" },
     { "Type": "Fruit", "Color": "White/Tan/Brown", "Name": "Bananas" },
     { "Type": "Fruit", "Color": "White/Tan/Brown", "Name": "Dates" },
     { "Type": "Vegetables", "Color": "White/Tan/Brown", "Name": "Cauliflower" },
     { "Type": "Vegetables", "Color": "White/Tan/Brown", "Name": "Garlic" },
     { "Type": "Fruit", "Color": "Green", "Name": "Avocados" },
     { "Type": "Fruit", "Color": "Green", "Name": "Green Apples" },
     { "Type": "Vegetables", "Color": "Green", "Name": "Artichokes" },
     { "Type": "Vegetables", "Color": "Green", "Name": "Arugula" }
 ];
```



## 1. ForEach

Dari namanya yang mirip `for` harusnya kita udah bisa nebak nih, kegunaannya apa. ForEach dipake buat nge-loop / melakukan perulangan dari item-item yang ada di dalem array.

Dari data buah yang ada di atas kita bisa coba melakukan perulangan.

```Javascript
 data.forEach(item => console.log(item));
```



## 2. Map

Map dipake untuk mengubah atau mentransformasi array ke bentuk lain. Atau bahasa teknisnya projection. Nah, projection ini bisa dipake untuk mengambil bagian tertentu dari sebuah item di dalem list / array. Misal dari object buah, kita mau ambil namanya aja berdasarkan warnanya.

```Javascript
 data
     .filter(item => item.Type === "Fruit" && item.Color === "Green")
     .map(fruit => fruit.Name)
     .forEach(name => console.log(name));
```



## 3. Filter

Method ini dipake untuk memilah mana item yang sesuai dengan kondisi tertentu. Misal dari data di atas kita mau ambil daftar buah aja. Atau kita mau ambil buah yang hijau aja.

```Javascript
 let fruits = data.filter(item => item.Type === "Fruit");

 console.table(fruits);
```



## 4. Find

## 5. Some

## 6. Every

## 7. Reduce

## 8. Includes





## Bonus

### 1. Sort

2. Count
3. Sum
4. Max
5. Min

### 2. Grouping

### 3. Lookup



Baca juga [CSharp — 5-Collection-Pipeline](/CSharp/CSharp%20—%205-Collection-Pipeline.md)
