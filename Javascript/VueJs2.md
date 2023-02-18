---
tags:
- Javascript
- Vue.js
- Draft
date: 2020-08-28
---


# Bisa Vue.js 2



[TOC]

## Kebutuhan
### Operating System
Semua code dan kebutuhan menjalankan program, dijalankan di atas Windows 10.



### Vue.js
Di waktu tulisan ini dibuat, versi yang digunakan untuk semua program adalah `Vue.js 2.6.11`. Diinstall menggunakan `yarn`.

* yarn -> `yarn add vue@2.6.11`
* npm -> `npm install vue@2.6.11`



### Visual Studio Code
Versi yang digunakan adalah versi terbaru saat tulisan ini dibuat, yaitu `1.48.1`. Install / gunakan versi yang sama atau di atasnya (`>= 1.48.1`).

* [VS Code](https://code.visualstudio.com/download)
* [VS Code 1.48.1](https://update.code.visualstudio.com/1.48.1/win32-x64/stable)



## Persiapan
### Membuat _Default template_

Sebelum mulai jangan lupa siapin html file untuk tampilan.
contohnya bisa pake yang di bawah ini.
```html
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>App</title>
        <script type="module" src="node_modules/vue/dist/vue.js"></script>
        <script type="module" src="index.js"></script>
    </head>
    <body>
        <section id="app"></section>
    </body>
</html>
```

dan _default template_ untuk Vue.js-nya sendiri.
contohnya bisa pake yang di bawah ini.
```javascript
new Vue({
    el: "app",
    data: {}
});
```

## Tingkat awal
### Vue instance

Ketika kita membuat file javascript dan me-_reference_ file tersebut seperti _default template_ di atas, sebenernya kita udah membuat sebuah Vue.js _instance_.


### Data

```javascript
new Vue({
    el: "app",
    data: {
        name: "Frankly Akamanju",
        title: "Office worker"
    }
});
```

```html
...omitted

<section id="app">
    <h1>Hi, {{ name }}</h1>
    <p>You're an {{ title }} now</p>
</section>

...omitted
```

### Methods


```javascript
new Vue({
    el: "app",
    data: {
        name: "Frankly Akamanju",
        title: "Office worker",
        resolutions: [{
                No: 1,
                Title: "stay positive",
                Important: true
            }, {
                No: 2,
                Title: "meet new people",
                Important: false
            }, {
                No: 3,
                Title: "don't get stress",
                Important: true
            }, {
                No: 4,
                Title: "don't complaining / squawking / sighing",
                Important: false
            }
        ]
    },
    methods: {
        GetAllResolutions: () => this.resolutions,
        GetImportantResolutions: () => this.resolutions.filter(res => res.Important)
    }
});
```

```html
...omitted

<section id="app">
    <h1>Hi, {{ name }}</h1>
    <p>You're an {{ title }} now</p>
    <p>And you have {{ GetAllResolutions().length }} resolutions this year.</p>
    <p>But please finish the important ones first. You have {{ GetImportantResolutions().length }} important resolutions.</p>
</section>

...omitted
```
