---
tags:
- How-to
- Git
date: 2023-04-29
---

# Merge conflict

Demi menjaga historical yang bener dan code changes yang saling timpa, ketika merge conflict, cek dulu file history file yang lagi conflict. Diskusi ke orang yang terkahir kali update file-nya, dan merge bareng-bareng. Karena yang tau perubahan lama orang yang sebelumnya, dan yang tau perubahan paling baru adalah kita sendiri sebagai yang kena merge conflict.



## Pull Request

Bikin branch merge conflict terpisah yang akan di-Pull request ke main branch. Ini lebih gampang dikontrol ketimbang pake cara BitBucket yang merge main branch ke feature branch. Kenapa? karena feature branch ini kan gak cuma di-merge ke satu main branch aja. Biasanya bakal ada 3 main branches, atau 3 environment branches, atau 3 deployment branches, apapun istilahnya. Kalo pake cara BitBucket di branch development terus feature branch ini di merge ke branch staging, nanti bakal ada unstable feature yang seharusnya belom naik ke staging jadi kebawa. Begitupun pas mau merge ke branch production.

