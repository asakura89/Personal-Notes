---
tags:
- Work
- Planning
- Pricing
date: 2023-12-05
---

# Testing pricing quotation

- [Automated test](#automated-test)
- [Manual test](#manual-test)
- [Performance test](#performance-test)
- [Penetration test](#penetration-test)



## TL;DR

1. <ins>Test:</ins> Biasa ada Automated testing, Manual testing, Performance testing, Penetration testing.
2. <ins>Pemisahan effort pricing:</ins> Seringkali di tiap pricing buat testing, kita lupa kalo ngebenerin/nge-fixing hasil test-nya biar meet sama kriteria juga butuh di-charge ke customer/client.



## Automated test

Ketika ngelakuin automated testing sekali, apakah itu E2E test (end-to-end automated testing yang biasanya scripted integration testing mirip unit test) atau UI automated test, script-nya hanya akan relevan buat kondisi saat itu aja. Dalem artian, ketika ada change request atau ada perubahan dari sisi UI ataupun backend, script automated testing ini pasti butuh berubah. Jadi jangan lupa buat masukin effort di pricing quotation change request di masa mendatang kalo ada perubahan yang ber-impact ke feature yang di-automated-test.



## Manual test

Test ini biasanya dilakuin sama developer secara langsung ketika development suatu feature udah selese. Ada juga yang dilakuin sama QA di Staging. Manual test ini dilakuin step by step berdasarkan test cases. Jadi effort yang dikeluarin tergantung jumlah test cases yang dibuat. Dan manual test yang dilakuin developer dan QA harus dipisah. Dan jangan skip manual test dari developer.



## Performance test

Test buat performance biasanya optional. Karena belom tentu suatu change request butuh performance test. Tapi ketika butuh, yang perlu diperhatiin adalah tujuan dari performance test-nya. Misal ada performance test yang cuma ya buat investigasi dan report. Jadi gak ada follow up action setelahnya. Atau follow up action-nya adalah hal yang berbeda yang dipisah dari test tersebut. Kalo kaya gini, berarti pricing cuma berlaku buat testing aja. Tapi kalo hasil performance test butuh di-follow up, maka paling enggak harus ada dua round dari test. Yang pertaman test buat dapet hasil bagian mana yang butuh di-improve atau di-fix. Round keduanya adalah test untuk verifikasi hasil fixing/improvement yang dilakuin.

Disini bakal ada beberapa komponen buat jadi item di pricing. Dua round testing biasanya udah termasuk dari pricing testing. Tapi yang perlu diperhatiin adalah effort buat fixing, ini butuh dipisah. Atau kalo memang udah sepaket, berarti harus ada scope yang jelas. Misal hanya untuk fixing 3 item yang teridentifikasi butuh di-fix. Karena kalo enggak, bakal jadi hal yang merugikan secara tenaga di sesi testing ini.

Fixing atau improvement ini juga harus mempertimbanging beberapa item pricing. Misal, apakah hanya fixing secara code tanpa merupah arsitektur? Atau apakah ada perubahan yang mencakup perubahan aristektur? Karena dua hal ini harusnya di-charge terpisah atau jadi item pricing yang berbeda.



## Penetration test

Penetration test pricing component kurang lebih sama dengan performance test. Ada test, ada code changes, ada architectural changes.