---
tags:
  - Work
  - Team-Lead
date: 2025-03-21
---

# Lesson Learned: Technical Debt

## Gojek Study Case: Using Metrics to Align Business and Technical Debt Management

Salah satu cara buat nge-justify time dan resources yang dipake buat nge-reduce technical debt adalah dengan, pake metrics. Di beberapa kasus, business leaders gak ngeprioritasin Technical Debt karena mereka gak ngeliat return of investment yang langsug. tapi sewaktu technical metrics disambungin ke business outcomes, jadinya lebih gampang buat dapet budget buat ngelakuin technical improvements.

Gojek, ngelakuin hal yang lumayan ngebalik approach lama dari metrics. Daripada misahin technical metrics dan business metrics, mereka ngejadiin developer metrics jadi bagian business strategy dan business metrics jadi bagian engineering goals. Ini lagi ngebikin alignment yang kuat antara technical teams dan business teams.

Contoh, uptime jadi metric penting secara company-wide. Ketika business leaders minta fitur-fitur baru, mereka juga harus nge-consider apa fitur-fitur yang diminta tadi bakal impact uptime. Kalo ada fitur yang impacting system uptime, maka di-deprioritized. Awareness ini jadi ngebikin leaders gak buru-buru buat bikin keputusan karena system stability jadi prioritas utama.

Sama dengan itu misal lagi, order completion rates jadi technical atau engineering metrics. Kalo ada order yang turun dari sejuta ke 900 ribu misalnya dalem sehari, maka developer bakal langsung investigate. Mereka bakal cek apa dikarenakan libur, masalah cuaca, masalah sistem atau apa. Dengan nge-monitor pattern-pattern ini, engineer jadi lebih terlibat sama business impact dari kerjaan mereka.

Integrasi ini juga ngebantu team buat bikin keputusan-keputusan yang lebih mateng dengan mastiin kalo ngebenerin atau nyelesein technical debt selalu dianggap sebagai bagian dari company's growth strategy.
