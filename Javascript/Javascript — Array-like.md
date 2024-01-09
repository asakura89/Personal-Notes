---
tags:
- Javascript
- Array
date: 2024-01-09
---

# Array-like

Sewaktu kita pake `document.querySelectorAll` misalnya, result-nya gak terus array, tapi `NodeList`. ini bikin repot sewaktu mau ngeproses pake array methods kaya `map`, `reduce`, dkk.

contohnya gini,

```javascript
/* ES5 jaman saia belajar js */
"use strict";
var selector = "[class^=TreeView__UlBox-sc] > li span.PRIVATE_TreeView-item-content-text > span";
var nodes = $(selector); // pake jQuery 😆
var texts = nodes.map(function (n) { return n.innerText; });

/* jaman now */
let selector = "[class^=TreeView__UlBox-sc] > li span.PRIVATE_TreeView-item-content-text > span";
let nodes = document.querySelectorAll(selector);
let texts = nodes.map(n => n.innerText);
```

Ini bakal error "Uncaught TypeError: nodes.map is not a function" karena `map` cuma applicable ke array.

Maka dari itulah, `NodeList` disebut array-like dan butuh di-convert ke array biar bisa diproses dengan gampang pake method-method array.

Caranya?

```javascript
/* ES5 jaman saia belajar js */
var nodeArrs = Array.prototype.slice.call(nodes);
var texts = nodeArrs.map(function (n) { return n.innerText; });

/* jaman now */
let nodeArrs = Array.prototype.slice.call(nodes);
let texts = nodes.map(n => n.innerText);
```

Kenapa pake `Array.prototype.`, gak langsung `Array.` aja `slice()`-nya?

Karena `slice()` bukan static method.

Ada juga `Array.from()`, tapi method ini available di ES2015 ke atas.

```javascript
var nodeArrs = Array.from(nodes); // ini bakal error kalo bukan ES5, tapi browser modern gakkan ngasi error karena udah support
var texts = nodeArrs.map(function (n) { return n.innerText; });
```

Jadi kalo targetnya ES5, gakkan available. Pertanyaannya ngapain ngurusin ES5? Kan skrg udah ada ES2024, ada babel, ada tsc. Ya, mungkin butuh deep dive knowledge sampe ke paling basic? Malah ekstrimnya lagi pake ES3.1. Tapi jauh banget sih fiturnya sama ES5. jadi better ES5 aja.

