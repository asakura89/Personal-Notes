---
path: "/2020-06-07"
date: "2020-06-07T05:57:23.486Z"
title: Array Methods
editor: typora with gitlab theme
---

# Array Methods

[TOC]

Pertama kali gue ngerti dalem banget soal *LINQ*-nya *.Net* itu karena *Array Methods*-nya *Javascript*. Karena *by default*, di *Javascript* itu, *function* / *method* adalah *first-class citizen* atau hal yang utama. Makanya di *Javascript*, *function* bisa jadi *parameter*. Terus? apa di *.Net* gak bisa? Bisa banget. Tapi kenapa sebutannya di *Javascript* *first-class citizen* dan di *.Net* enggak? Karena *.Net* dari awal dikembangin, lebih dikenal dengan teknologi berbasis *OOP*.


Di tulisan ini gue mau ngebahas soal beberapa *Array Methods* yang sering banget dipake dan umum.


Di bawah ini, contoh data yang akan kita pake.



**Javascript**
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



**C#**
```C#
 var data = new List<FruitsAndVegs> {
     new FruitsAndVegs { Type = "Fruit", Color = "Red", Name = "Red Apples" },
     new FruitsAndVegs { Type = "Fruit", Color = "Red", Name = "Blood Oranges" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Red", Name = "Beets" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Red", Name = "Red Peppers" },
     new FruitsAndVegs { Type = "Fruit", Color = "Yellow/Orange", Name = "Yellow Apples" },
     new FruitsAndVegs { Type = "Fruit", Color = "Yellow/Orange", Name = "Apricots" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Yellow/Orange", Name = "Yellow Apples" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Yellow/Orange", Name = "Apricots" },
     new FruitsAndVegs { Type = "Fruit", Color = "Blue/Purple", Name = "Blackberries" },
     new FruitsAndVegs { Type = "Fruit", Color = "Blue/Purple", Name = "Blueberries" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Blue/Purple", Name = "Black Olives" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Blue/Purple", Name = "Purple Asparagus" },
     new FruitsAndVegs { Type = "Fruit", Color = "White/Tan/Brown", Name = "Bananas" },
     new FruitsAndVegs { Type = "Fruit", Color = "White/Tan/Brown", Name = "Dates" },
     new FruitsAndVegs { Type = "Vegetables", Color = "White/Tan/Brown", Name = "Cauliflower" },
     new FruitsAndVegs { Type = "Vegetables", Color = "White/Tan/Brown", Name = "Garlic" },
     new FruitsAndVegs { Type = "Fruit", Color = "Green", Name = "Avocados" },
     new FruitsAndVegs { Type = "Fruit", Color = "Green", Name = "Green Apples" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Green", Name = "Artichokes" },
     new FruitsAndVegs { Type = "Vegetables", Color = "Green", Name = "Arugula" }
 };
```



#### 1. ForEach
Dari namanya yang mirip `for` harusnya kita udah bisa nebak nih, kegunaannya apa. *ForEach* dipake buat nge-*loop* / melakukan perulangan dari *item-item* yang ada di dalem *array*.


Dari data buah yang ada di atas kita bisa coba melakukan perulangan.



**Javascript**
```Javascript
 data.forEach(item => console.log(item));
```

![ForEach]()



**C#**
```C#
 data.ForEach(item => Console.WriteLine(item));
```

![ForEach](2020-06-14_222117.png)

Kenapa outputnya semuanya jadi `ArrayMethods.FruitsAndVegs`?
Karena *by default*, `Console.WriteLine` bakalan manggil *method* `.ToString()` dari semua *object* yang dilempar jadi *parameter*-nya.



#### 2. Map
*Map* dipake untuk mengubah atau mentransformasi *array* ke bentuk lain. Atau bahasa teknisnya *projection*. Nah, *projection* ini bisa dipake untuk mengambil bagian tertentu dari sebuah item di dalem *list / array*. Misal dari *object* buah, kita mau ambil namanya aja berdasarkan warnanya.



**Javascript**
```Javascript
 data
     .filter(item => item.Type === "Fruit" && item.Color === "Green")
     .map(fruit => fruit.Name)
     .forEach(name => console.log(name));
```

![Map]()



**C#**
```C#
 data
     .Where(item => item.Type == "Fruit" && item.Color == "Green")
     .Select(fruit => fruit.Name)
     .ToList()
     .ForEach(name => Console.WriteLine(name));
```

![Map](2020-06-14_222730.png)



#### 3. Filter
*Method* ini dipake untuk memilah mana *item* yang sesuai dengan kondisi tertentu. Misal dari data di atas kita mau ambil daftar buah aja. Atau kita mau ambil buah yang hijau aja.



**Javascript**
```Javascript
 let fruits = data.filter(item => item.Type === "Fruit");

 console.table(fruits);
```

![Filter]()



**C#**
```C#
 /* Just fruits */
 data
     .Where(item => item.Type == "Fruit")
     .Select(fruit => fruit.Name)
     .ToList()
     .ForEach(name => Console.WriteLine(name));
 
 /* Just green fruits */
 data
     .Where(item => item.Type == "Fruit" && item.Color == "Green")
     .Select(fruit => fruit.Name)
     .ToList()
     .ForEach(name => Console.WriteLine(name));
```

![Filter](2020-06-14_224849.png)



#### 4. Find

#### 5. Some

#### 6. Every

#### 7. Reduce

#### 8. Includes





#### Bonus

#### 1. Sort

2. Count
3. Sum
4. Max
5. Min

#### 2. Grouping

#### 3. Lookup

