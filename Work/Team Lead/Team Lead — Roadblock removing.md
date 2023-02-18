---
tags:
- Work
- Team-Lead
- Manager
date: 2023-11-05
---

# Roadblock removing

{Content}

<!--

The story you've selected is a real-life example of how a seemingly simple change in a software system can become a complex task due to various factors such as company policies, system architecture, and team communication. 

In this case, the President of the company, Philip, wants to increase the factory's utilization by building more backlog. The Operations Manager, Lee, suggests changing the company policy to allow building more than 3 months of backlog. This change, however, needs to be implemented in the company's legacy software. 

The IT Director, David, assures that it's probably a one-line code change in their core routine. The IT Admin, Judy, assigns a ticket for this request but it needs a section on Business Impact completed and Director approval. 

David emphasizes the urgency of the task, stating that if it's not done right away, they'll have to lay off employees. Judy then fast-tracks the ticket. 

Two days later, David checks the status of the ticket and learns that it's the first Enhancement in the Developer Queue, after 14 Bug Reports. He instructs Judy to mark it urgent and send it to the programmer, Ed, immediately. 

Ed makes the necessary code change and submits it for Code Review. However, the Code Reviewer, Shirley, points out that it's against company policy to have any hard-coded variables and that there are other issues in the code that need to be fixed before it can be moved to production. 

This story illustrates the complexities and challenges that can arise in software development, even for seemingly simple tasks. It highlights the importance of clear communication, efficient processes, and flexible policies in ensuring smooth operations.

Continuing from the previous part, Ed, the programmer, is frustrated with the additional work required to fix preexisting errors in the code that violate new company policy. However, Shirley, the Code Reviewer, insists that these issues need to be addressed before the code can be moved to production.

Ed makes the necessary changes and resubmits the code for review. Meanwhile, Julie from IT Testing informs Ed that Homer, the system for User Acceptance Testing, is not available and suggests using Marge instead. Ed doesn't have access to Marge, so he contacts Joe from IT Security to get permissions.

Joe informs Ed that he cannot grant access to Marge without David's signature, who is out of town. Despite this, Ed insists on getting access as Philip wants the changes implemented right away.

Shirley then points out that Ed's new Parameters record "MonthsOfDemand" needs a better name and should have an audit trail of changes. Ed is confused about this policy, but Shirley assures him that it's a requirement, even though it's not documented anywhere.

Ed makes the necessary changes, renames the Parameters record to "SelectedMonthsOfBacklogDemand", and adds a module to maintain the record and its audit trail. He then submits it for Code Review.

Tony from IT Testing sees the ticket on Marge but doesn't have a Test Plan. Ed suggests running the system the old way and the new way and noting the increase in the total on the WorkOrdersHours report. Tony, however, insists on having user-selected Test Cases, Expected Results, documented Test Runs, and user sign-off.

Two days later, Philip instructs David to move Ed's program to production immediately. David complies.

In total, it took 6 days to change 1 line of mission-critical code. This story highlights the complexities and challenges involved in software development and the importance of clear communication, efficient processes, and flexible policies.

---

Cerita yang Anda pilih adalah contoh nyata tentang bagaimana perubahan sederhana dalam sistem perangkat lunak dapat menjadi tugas yang kompleks karena berbagai faktor seperti kebijakan perusahaan, arsitektur sistem, dan komunikasi tim.

Dalam kasus ini, Presiden perusahaan, Philip, ingin meningkatkan pemanfaatan pabrik dengan membangun lebih banyak backlog. Manajer Operasional, Lee, menyarankan untuk mengubah kebijakan perusahaan agar memungkinkan membangun lebih dari 3 bulan backlog. Namun, perubahan ini perlu diimplementasikan dalam perangkat lunak warisan perusahaan.

Direktur IT, David, meyakinkan bahwa ini mungkin perubahan satu baris kode dalam rutin inti mereka. Admin IT, Judy, menetapkan tiket untuk permintaan ini tetapi perlu bagian tentang Dampak Bisnis yang diselesaikan dan persetujuan Direktur.

David menekankan urgensi tugas, menyatakan bahwa jika tidak segera dilakukan, mereka harus melakukan PHK. Judy kemudian mempercepat tiket.

Dua hari kemudian, David memeriksa status tiket dan mengetahui bahwa ini adalah peningkatan pertama dalam Antrian Pengembang, setelah 14 Laporan Bug. Dia menginstruksikan Judy untuk menandainya sebagai mendesak dan mengirimkannya ke programmer, Ed, segera.

Ed membuat perubahan kode yang diperlukan dan mengirimkannya untuk Ulasan Kode. Namun, Peninjau Kode, Shirley, menunjukkan bahwa melanggar kebijakan perusahaan untuk memiliki variabel yang dikodekan keras dan bahwa ada masalah lain dalam kode yang perlu diperbaiki sebelum dapat dipindahkan ke produksi.

Cerita ini menggambarkan kompleksitas dan tantangan yang dapat muncul dalam pengembangan perangkat lunak, bahkan untuk tugas yang tampaknya sederhana. Ini menyoroti pentingnya komunikasi yang jelas, proses yang efisien, dan kebijakan yang fleksibel dalam memastikan operasi yang lancar.

Melanjutkan dari bagian sebelumnya, Ed, sang programmer, frustrasi dengan pekerjaan tambahan yang diperlukan untuk memperbaiki kesalahan yang ada dalam kode yang melanggar kebijakan perusahaan baru. Namun, Shirley, Peninjau Kode, menegaskan bahwa masalah ini perlu ditangani sebelum kode dapat dipindahkan ke produksi.

Ed membuat perubahan yang diperlukan dan mengirimkan kembali kode untuk ditinjau. Sementara itu, Julie dari IT Testing memberi tahu Ed bahwa Homer, sistem untuk Pengujian Penerimaan Pengguna, tidak tersedia dan menyarankan menggunakan Marge sebagai gantinya. Ed tidak memiliki akses ke Marge, jadi dia menghubungi Joe dari IT Security untuk mendapatkan izin.

Joe memberi tahu Ed bahwa dia tidak dapat memberikan akses ke Marge tanpa tanda tangan David, yang sedang tidak ada di kota. Meskipun demikian, Ed bersikeras untuk mendapatkan akses karena Philip ingin perubahan diimplementasikan segera.

Shirley kemudian menunjukkan bahwa catatan Parameter baru Ed "MonthsOfDemand" perlu nama yang lebih baik dan harus memiliki jejak audit perubahan. Ed bingung tentang kebijakan ini, tetapi Shirley meyakinkannya bahwa ini adalah persyaratan, meskipun tidak didokumentasikan di mana pun.

Ed membuat perubahan yang diperlukan, mengubah nama catatan Parameter menjadi "SelectedMonthsOfBacklogDemand", dan menambahkan modul untuk menjaga catatan dan jejak auditnya. Dia kemudian mengirimkannya untuk Ulasan Kode.

Tony dari IT Testing melihat tiket di Marge tetapi tidak memiliki Rencana Tes. Ed menyarankan menjalankan sistem dengan cara lama dan cara baru dan mencatat peningkatan total pada laporan WorkOrdersHours. Namun, Tony bersikeras untuk memiliki Kasus Tes yang dipilih pengguna, Hasil yang Diharapkan, Tes Run yang didokumentasikan, dan persetujuan pengguna.

Dua hari kemudian, Philip menginstruksikan David untuk segera memindahkan program Ed ke produksi. David mematuhi.

Secara total, dibutuhkan 6 hari untuk mengubah 1 baris kode yang kritis. Cerita ini menyoroti kompleksitas dan tantangan yang terlibat dalam pengembangan perangkat lunak dan pentingnya komunikasi yang jelas, proses yang efisien, dan kebijakan yang fleksibel.


[It Takes 6 Days to Change 1 Line of Code - ed weissman (posthaven.com)](https://edw519.posthaven.com/it-takes-6-days-to-change-1-line-of-code)


---

# Overcoming Software Development Bottlenecks in a Manufacturing Company

## Background/What happened
The President of a manufacturing company wanted to increase factory utilization by building more backlog. However, this required a change in the company's policy and its implementation in the legacy software system. The IT team faced several challenges in implementing this seemingly simple change due to company policies, system architecture, and team communication.

## Problem
- **Company Policies**: The company had strict policies regarding code changes, such as not allowing hard-coded variables. This resulted in additional work for the programmer, Ed, who had to refactor his code to comply with these policies.
- **System Architecture**: The company's legacy software system was not designed to easily accommodate changes. This made the task of changing a single line of code more complex than it initially seemed.
- **Team Communication**: There were communication gaps between different teams, such as the IT team and the Operations team. This led to misunderstandings and delays in implementing the change.

## Proposed Solution
- **Company Policies**: The company could consider revising its policies to be more flexible and accommodating of necessary changes. This could include allowing certain exceptions to the policy of not having hard-coded variables, especially for urgent tasks that have a significant impact on the company's operations.
- **System Architecture**: The company could invest in updating its legacy software system to a more modern and flexible one. This would make it easier to implement changes and improve the overall efficiency of the system.
- **Team Communication**: The company could implement better communication strategies, such as regular meetings between different teams, to ensure everyone is on the same page. This would help prevent misunderstandings and ensure tasks are completed more efficiently.

## Request
To implement these solutions, the following resources and support from the top management would be required:
- **Policy Revision**: Support from the top management would be needed to revise the company's policies. This could involve discussions with various stakeholders to understand the implications of the proposed changes.
- **System Upgrade**: Significant resources would be required to upgrade the company's legacy software system. This would include hiring external consultants or allocating additional budget for the IT team.
- **Improved Communication**: The top management could facilitate better communication by setting up regular meetings between different teams and encouraging open and transparent communication. This could involve providing training to team leaders on effective communication strategies.


# Mengatasi Hambatan Pengembangan Perangkat Lunak di Perusahaan Manufaktur

## Latar Belakang/Apa yang terjadi
Presiden perusahaan manufaktur ingin meningkatkan pemanfaatan pabrik dengan membangun lebih banyak backlog. Namun, ini memerlukan perubahan dalam kebijakan perusahaan dan implementasinya dalam sistem perangkat lunak warisan. Tim IT menghadapi beberapa tantangan dalam menerapkan perubahan yang tampaknya sederhana ini karena kebijakan perusahaan, arsitektur sistem, dan komunikasi tim.

## Masalah
- **Kebijakan Perusahaan**: Perusahaan memiliki kebijakan yang ketat mengenai perubahan kode, seperti tidak mengizinkan variabel yang dikodekan keras. Ini menghasilkan pekerjaan tambahan bagi programmer, Ed, yang harus merombak kodenya untuk mematuhi kebijakan ini.
- **Arsitektur Sistem**: Sistem perangkat lunak warisan perusahaan tidak dirancang untuk dengan mudah mengakomodasi perubahan. Ini membuat tugas mengubah satu baris kode menjadi lebih kompleks dari yang tampaknya.
- **Komunikasi Tim**: Ada kesenjangan komunikasi antara tim yang berbeda, seperti tim IT dan tim Operasional. Ini mengarah pada kesalahpahaman dan penundaan dalam menerapkan perubahan.

## Solusi yang Diusulkan
- **Kebijakan Perusahaan**: Perusahaan dapat mempertimbangkan untuk merevisi kebijakannya agar lebih fleksibel dan mengakomodasi perubahan yang diperlukan. Ini bisa mencakup membiarkan beberapa pengecualian pada kebijakan tidak memiliki variabel yang dikodekan keras, terutama untuk tugas mendesak yang memiliki dampak signifikan pada operasi perusahaan.
- **Arsitektur Sistem**: Perusahaan dapat berinvestasi dalam memperbarui sistem perangkat lunak warisannya menjadi yang lebih modern dan fleksibel. Ini akan memudahkan implementasi perubahan dan meningkatkan efisiensi sistem secara keseluruhan.
- **Komunikasi Tim**: Perusahaan dapat menerapkan strategi komunikasi yang lebih baik, seperti pertemuan reguler antara tim yang berbeda, untuk memastikan semua orang berada di halaman yang sama. Ini akan membantu mencegah kesalahpahaman dan memastikan tugas diselesaikan dengan lebih efisien.

## Permintaan
Untuk menerapkan solusi ini, sumber daya dan dukungan berikut dari manajemen puncak akan dibutuhkan:
- **Revisi Kebijakan**: Dukungan dari manajemen puncak akan dibutuhkan untuk merevisi kebijakan perusahaan. Ini bisa melibatkan diskusi dengan berbagai pemangku kepentingan untuk memahami implikasi dari perubahan yang diusulkan.
- **Peningkatan Sistem**: Sumber daya signifikan akan dibutuhkan untuk meningkatkan sistem perangkat lunak warisan perusahaan. Ini akan mencakup mempekerjakan konsultan eksternal atau mengalokasikan anggaran tambahan untuk tim IT.
- **Komunikasi yang Lebih Baik**: Manajemen puncak dapat memfasilitasi komunikasi yang lebih baik dengan mengatur pertemuan reguler antara tim yang berbeda dan mendorong komunikasi yang terbuka dan transparan. Ini bisa melibatkan memberikan pelatihan kepada pemimpin tim tentang strategi komunikasi yang efektif.

-->