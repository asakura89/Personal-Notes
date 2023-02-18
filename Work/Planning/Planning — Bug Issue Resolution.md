---
tags:
- Work
- Planning
- Draft
date: 2023-06-10
---

# Bug Issue Resolution

1. <ins>Regular Monitoring and User Feedback:</ins> Terapin sistem monitoring yang rutin buat mantau fungsionalitas website, dan dorong atau minta user buat nge-report issue-issue dengan segera. Ini bisa ngebantu ngedeteksi masalah lebih awal. Se-simpel bikin task scheduler buat ngecek websitenya down apa enggak. Kalo mau yang lebih baik, terapin automated UI test di Staging. Jadi ketika banyak tiket yang naik ke Staging, issue-nya bisa ketauan lebih awal sebelum user report. Di-combine dengan CI/CD. Tapi tanpa CI/CD-pun harusnya bisa.
2. <ins>Documentation and Configuration Checks:</ins> Maintain dokumentasi yang lengkap soal file paths dan configuration. Lokasi file dan file-file config ini penting banget buat didokumentasiin karena kita gak bisa inget sama hal-hal remeh tapi critical kaya gini. Karena jumlahnya ada banyak banget. Dokumen ini juga butuh di-review dan di-update regularly biar align terus sama structure aplikasi yang terbaru.
3. <ins>Automated Testing:</ins> Baca poin satu. Automated test ini ada dua. Dari sisi UI dan dari sisi code. Kalo dari sisi UI, UI automated test, harus bikin scriptnya dan regularly di-update. Kalo dari sisi code, ini adalah unit test dan integration test. Unit dan integration test biasanya part of development, jadi gak automated secara scheduled gitu. Biasanya di-integrate ke CI/CD pipeline.
