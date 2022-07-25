---
tags:
- IIS
date: 2022-07-25
---

# All Things .NET — IIS Auto recycle

Jadi ternyata IIS punya jadwal recycle otomatis. Yaitu 29 jam sekali. Artinya recycle ini bisa berjalan kapan aja. Hari pertama mungkin berjalan jam 5 pagi. Hari kedua jalan jam 6 pagi. Dan seterusnya.

Buat website yang harus up 24x7, ini bisa jadi masalah. Karena sewaktu IIS recycle, website bakal lemot. Jadi ada baiknya kalo auto recycle ini di-set manual. Di jam yang ditentukan. Yang pasti di luar peak hours.