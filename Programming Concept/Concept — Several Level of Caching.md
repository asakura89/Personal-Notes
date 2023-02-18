---
tags:
- Research
- Concept
date: 2024-03-22
---

# Several Level of Caching

> There are only two hard things in Computer Science: cache invalidation and naming things.
>
> — <cite>[Phil Karlton][0]</cite>

[0]: https://www.karlton.org/2017/12/naming-things-hard/

1. <ins>Client-Level Caching:</ins> Caching level ini dilakuin di browser atau di mobile app. Biasanya caching ini buat nge-cache data dari network call. Caranya bisa dengan nge-setup HTTP headers tertentu buat minta client gimana nge-cache-nya, kapan nge-cache-nya dan expiry-nya kapan.

2. <ins>CDN-Level Caching:</ins> Content Delivery Networks (CDNs) dipake buat nge-cache static assets. Dan biasanya ditaro atau lokasi cache-nya deket sama lokasi user buat nge-reduce latency. Sewaktu user buka suatu page, terus page-nya butuh static assets kaya image kah, css kah, client script kah, nanti CDN bakal nge-servr dari edge server terdekat. Kalo assets-nya gak ada, CDN-nya bakal ambil dulu dari origin server, atau server asal website, terus baru deh di-cache buat future requests. Ngeimplementasiinnya biasanya pake CDN services. Yang paling umum misalnya Akamai.

3. <ins>Web Server-Level Caching:</ins> Web server bisa di-configure buat bikin cache dari responses dari resource atau URL yang sering di-request. Jadi web server-nya bakal nge-serve langsung dari cache tanpa harus minta ke server asal (server dimana web/app di-host). Jadi ngurangin load atau beban ke server asal dan juga database. Salah satu tool yang bisa dipake, Varnish HTTP Cache.

4. <ins>Database-Level Caching:</ins> Database biasanya punya built-in cache. Contohnya yang paling umum, database bakal nge-cache query yang paling sering di-execute. Buat cache jenis lain butuh di-configure dulu. Yang paling sederhana misal nge-setup View buat table-table yang sering diakses.

5. <ins>Application-Level Caching:</ins> Level ini ada banyak jenis cache. Ada yang built-in in-memory cache. Ada 3rd party library buat connect ke database specific ditujukan buat caching kaya Redis. Caching level ini biasanya berurusan sama data. Semua data yang sering diakses bakal di-cache dan di-update sewaktu data berubah. Misal sewaktu data bakal ditulis ke database utama, sekalian nge-update cache.

Walaupun sebenernya caching ini bisa ngebantu buat speed up app dan improve performance, tapi jangan lupa kalo implementing cache ini bakal nge-affect architecture dari keseluruhan system. Jadi ini bakal introduces complexity. Apalagi nge-refresh cache-nya, atau berdasarkan quote di atas, cache invalidation. Belom lagi mikirin gimana strategi kalo cache penuh secara memnory ataupun storage. Belom lagi milihin request, query, atau data mana aja yang mestinya di-cache. Jangan sampe gak optimal terus malah jadi performance decrease.



**References:**

- How does Caching on the Backend work? (System Design Fundamentals) ([Video](https://www.youtube.com/watch?v=bP4BeUjNkXc), [Subtitle](_media/How%20does%20Caching%20on%20the%20Backend%20work%20\(System%20Design%20Fundamentals\)%20-%20English%20-generated\).srt.md))
