---
tags:
- Search-chat
- Chat
- Communicate
date: 2022-07-12
---

# Microsoft Teams

MS Teams punya Search bar yang gede di tengah atas app-nya. Dari situ kita bisa search chat dan MS Teams juga support beberapa keyword / syntax. Keyword / syntax ini berlaku ke semua group chat. Kalo mau search di group chat tertentu, masuk dulu ke group chat-nya. Terus pencet <kbd>ctrl-f</kbd>, baru search atau masukin search syntax-nya.



## Search chat by time

Ini beberapa syntax yang di-support MS Teams.
```SQL
sent:"yesterday"
sent:"last week"
(sent>=09/21/2020 AND sent<=09/27/2020)
sent=09/27/2020
sent="09/27/2020"
sent:"09/27/2020"
```
Format tanggal versi web dan versi desktop bisa berbeda. Tergantung dari locale yang di-set di browser. Ini berpengaruh ke format `mm/dd/yyyy` bisa kebalik jadi `dd/mm/yyyy`. Normalnya, di app akan pake format `mm/dd/yyyy`.



## Search chat by person

Chat yang di-chat oleh orang lain atau diri sendiri bisa dicari pake email. Berikut syntax-nya
```SQL
from:"asmnetworklabusr@asm.net"
```



## Search chat by syntax combining

Syntax search MS Teams juga support logical operator `OR` dan `AND`. Jadi kita bisa combine syntax buat search.

Ini contoh buat complex search
```SQL
(from:"bpreman@asm.net" OR from:"preman@asm.net") AND sent:"09/01/2021"
from:"bpreman@asm.net" gajian telat
from:"bpreman@asm.net" AND (sent>="10/01/2020" AND sent<="10/07/2020") AND (*pendapatan* OR *dapat* OR *kurang*)
```


