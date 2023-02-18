---
tags:
- Concept
date: 2024-01-28
---

# Semantic Version across platform

Berdasarkan Semantic Versioning spec <ins>[disini](https://semver.org/spec/v2.0.0.html)</ins>, Major kalo ada incompatible API changes, Minor kalo ada fitur baru yang masih backward compatible, dan Patch kalo ada bug fix yang masih backward compatible.

Tapi pada kenyataannya banyak juga software-software yang incrementing Minor version yang gak backward compatible. Artinya, spec ini masih bisa di-adapt tergantung kebutuhan. Ya memang gak mesti saklek. Tapi at least ada baseline-nya. Gitu kan?

Terus gimana kalo kita develop software yang berbentuk product dan can be used across multiple devices/platforms?

Mungkin bisa di-modify jadi gini `PRODUCT_MAJOR.PLATFORM_SPECIFIC_PRODUCT_ITERATION.PLATFORM_SPECIFIC_PRODUCT_PATCH` daripada sekedar `MAJOR.MINOR.PATCH`. Dengan breakdown kaya gini:
1. `PRODUCT_MAJOR`: Ini kalo ada fitur yang mau diimplemen di semua platform, gak cuma spesifik ke platform tertentu.
2. `PLATFORM_SPECIFIC_PRODUCT_ITERATION`: Kalo ada fitur yang apakah backward compatible atau enggak, mau diimplemen ke platform tertentu tanpa ngerubah behavior/feature design dari product yang bikin interaction bisa jadi berbeda ditiap platform, contoh di android bisa schedule task tapi di iOS gak bisa.
3. `PLATFORM_SPECIFIC_PRODUCT_PATCH`: Ini kalo ada fix, security patch, atau apapun yang berkaitan sama product di spesifik platform tertentu. Kalo untuk support ke platform yang sama dengan version yang berbeda, harusnya masuk ke `PRODUCT_INTERATION` ketimbang `PRODUCT_PATCH`. Contoh, buat bisa support android 7 harus install product versi 4.108.0 sedangkan product versi stable terakhir yaitu 4.107.213 itu support android 6.

Jadi secara product, kita bisa bilang "pakailah Product version 4" buat bilang kalo versi 4 ini support di semua platform. Atau "pakailah Product versi 4.108 di android dan 4.73 di iOS" buat cobain fitur Y.
