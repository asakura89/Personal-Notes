---
tags:
- Work
- Ways-of-Work
date: 2023-07-23
---

# API QA and Prod Strategies

{Content}

<!--
Essay: Effective API Testing and Agile Development Processes

Introduction:
In today's fast-paced software development landscape, efficient testing of APIs (Application Programming Interfaces) is crucial to ensure the quality and reliability of software products. This conversation provides insights into how QA (Quality Assurance) teams at various companies are testing their APIs, the integration between unit tests and integration tests, and the importance of user-centric PRDs (Product Requirement Documents) in the agile development process. Let's delve into the key takeaways from this discussion.

Section 1: API Testing Strategies

1.1 Staging and Production Testing:
The conversation reveals that companies employ automated integration testing in staging environments to ensure thorough testing of APIs. These tests are performed before deploying the software to production. By cherry-picking specific data and excluding certain operations, the staging environment can be kept clean. This approach allows developers to validate the expected behavior of APIs without polluting the production environment.

1.2 Automated Testing in Pipelines:
Automated API testing is incorporated into the deployment pipeline, ensuring that every new feature or change is tested systematically. Test engineers (TEs) collaborate with the development team to create and update automated tests as part of their sprint tasks. By integrating automated tests into the pipeline, companies can detect issues early and maintain a high level of software quality.

Section 2: Integration Tests and Unit Tests

2.1 Integration Testing:
Integration tests focus on real interactions with APIs, as opposed to unit tests that simulate or mock the behavior of APIs. These tests ensure that multiple components of the system work together as expected in a real environment. By executing integration tests, QA teams can validate that the APIs meet the expected requirements and function correctly within the broader system context.

2.2 Unit Testing and Isolation:
Unit tests, on the other hand, are employed to test individual units or components of the system in isolation. These tests verify that specific features or functionalities work as intended. By isolating the unit being tested, developers can pinpoint issues within a specific component and ensure its proper functioning.

Section 3: PRDs and Task Breakdown

3.1 User Journey-based PRDs:
The conversation highlights the preference for PRDs based on the user journey. By structuring the PRD around user stories and expectations, product managers can effectively communicate the desired end goal. This user-centric approach ensures that the development team understands the overall purpose and context of the features being implemented.

3.2 Engineering Task Breakdown:
To handle large user stories or complex features, the conversation suggests breaking them down into smaller tasks. This breakdown is typically done in the RFC (Request for Comments) document, where engineering teams provide a detailed breakdown of the tasks required to implement a user story. The RFC document also references the PRD to ensure alignment between the user expectations and the technical implementation.

Section 4: Ticketing and Acceptance Criteria

4.1 Ticketing and Task Relationship:
Tickets for task assignments are not necessarily the same as user stories. In most cases, task tickets are linked to the corresponding user stories, forming a hierarchy. As the linked tasks are completed, the entire user story is tested by the product/QA team. This approach ensures that all supporting tasks are completed before the user story is validated.

4.2 Acceptance Criteria Alignment:
Acceptance criteria (AC) play a vital role in defining the expected behavior and outcomes for user stories and related tasks. AC for user stories are derived from the PRD, while AC for engineering tasks outline specific requirements related to the database model, API functionality, and user interface. All AC must support the overall AC defined in the user story.

Conclusion:
Efficient API testing is essential for ensuring the quality and reliability of software products. By incorporating automated integration testing in staging environments, companies can maintain a clean testing environment while thoroughly validating the APIs. The integration of unit tests and integration tests allows developers and QA teams to verify both isolated components and their interactions within the system. User-centric PRDs based on user journeys facilitate effective communication between product managers and development teams, ensuring a clear understanding of end goals. Task breakdown and proper alignment of acceptance criteria help streamline the development process and maintain a balance between business requirements and technical implementation. By adopting these strategies, organizations can enhance their API testing practices and foster successful agile development processes.




User
Please translate this to bahasa
ChatGPT
Esai: Uji Coba API yang Efektif dan Proses Pengembangan Agile

Pendahuluan:
Dalam lanskap pengembangan perangkat lunak yang cepat saat ini, pengujian yang efisien terhadap API (Antarmuka Pemrograman Aplikasi) sangat penting untuk memastikan kualitas dan kehandalan produk perangkat lunak. Percakapan ini memberikan wawasan tentang bagaimana tim QA (Quality Assurance) di berbagai perusahaan menguji API mereka, integrasi antara pengujian unit dan pengujian integrasi, dan pentingnya PRD (Dokumen Persyaratan Produk) yang berpusat pada pengguna dalam proses pengembangan yang agile. Mari kita bahas beberapa poin utama dari diskusi ini.

Bagian 1: Strategi Uji Coba API

1.1 Uji Coba Staging dan Produksi:
Percakapan ini mengungkapkan bahwa perusahaan menggunakan pengujian integrasi otomatis di lingkungan staging untuk memastikan pengujian yang komprehensif terhadap API. Pengujian ini dilakukan sebelum perangkat lunak dideploy ke produksi. Dengan memilih data tertentu dan mengesampingkan operasi tertentu, lingkungan staging dapat tetap bersih. Pendekatan ini memungkinkan pengembang memvalidasi perilaku yang diharapkan dari API tanpa mengotori lingkungan produksi.

1.2 Pengujian Otomatis dalam Pipa Garis:
Pengujian API otomatis diintegrasikan ke dalam pipa garis penerapan, sehingga setiap fitur baru atau perubahan diuji secara sistematis. Insinyur pengujian (TE) bekerja sama dengan tim pengembangan untuk membuat dan memperbarui pengujian otomatis sebagai bagian dari tugas sprint mereka. Dengan mengintegrasikan pengujian otomatis ke dalam pipa garis, perusahaan dapat mendeteksi masalah secara dini dan menjaga tingkat kualitas perangkat lunak yang tinggi.

Bagian 2: Pengujian Integrasi dan Pengujian Unit

2.1 Pengujian Integrasi:
Pengujian integrasi fokus pada interaksi nyata dengan API, berbeda dengan pengujian unit yang mensimulasikan atau memanipulasi perilaku API. Pengujian ini memastikan bahwa komponen-komponen sistem bekerja bersama sesuai yang diharapkan dalam lingkungan yang nyata. Dengan melakukan pengujian integrasi, tim QA dapat memvalidasi bahwa API memenuhi persyaratan yang diharapkan dan berfungsi dengan baik dalam konteks sistem secara keseluruhan.

2.2 Pengujian Unit dan Isolasi:
Di sisi lain, pengujian unit digunakan untuk menguji unit atau komponen-komponen individu sistem secara terisolasi. Pengujian ini memverifikasi bahwa fitur atau fungsionalitas tertentu bekerja sesuai yang diinginkan. Dengan mengisolasi unit yang diuji, pengembang dapat menemukan masalah di dalam komponen tertentu dan memastikan fungsi yang tepat.

Bagian 3: PRD dan Pembagian Tugas

3.1 PRD Berdasarkan Perjalanan Pengguna:
Percakapan ini menyoroti preferensi terhadap PRD yang berpusat pada perjalanan pengguna. Dengan mengatur PRD berdasarkan cerita pengguna dan harapan, manajer produk dapat secara efektif berkomunikasi tentang tujuan akhir yang diinginkan. Pendekatan yang berpusat pada pengguna ini memastikan tim pengembangan memahami tujuan keseluruhan dan konteks fitur yang diimplementasikan.

3.2 Pembagian Tugas Teknik:
Untuk mengatasi cerita pengguna yang besar atau fitur yang kompleks, percakapan menyarankan untuk memecahnya menjadi tugas-tugas yang lebih kecil. Pembagian ini biasanya dilakukan dalam dokumen RFC (Permintaan Komentar), di mana tim teknik memberikan rincian tugas yang diperlukan untuk mengimplementasikan cerita pengguna. Dokumen RFC juga merujuk ke PRD untuk memastikan kesesuaian antara harapan pengguna dan implementasi teknis.

Bagian 4: Tiket dan Kriteria Penerimaan

4.1 Tiket dan Hubungan Tugas:
Tiket untuk penugasan tugas tidak selalu sama dengan cerita pengguna. Dalam sebagian besar kasus, tiket tugas terkait dengan cerita pengguna yang sesuai, membentuk hierarki. Setelah semua tugas pendukung selesai, seluruh cerita pengguna diuji oleh tim produk/QA. Pendekatan ini memastikan bahwa semua tugas pendukung selesai sebelum cerita pengguna diverifikasi.

4.2 Kesesuaian Kriteria Penerimaan:
Kriteria penerimaan (AC) memainkan peran penting dalam mendefinisikan perilaku dan hasil yang diharapkan untuk cerita pengguna dan tugas terkait. AC untuk cerita pengguna didasarkan pada PRD, sedangkan AC untuk tugas teknik menguraikan persyaratan spesifik terkait model basis data, fungsionalitas API, dan antarmuka pengguna. Semua AC harus mendukung AC keseluruhan yang ditentukan dalam cerita pengguna.

Kesimpulan:
Pengujian API yang efisien sangat penting untuk memastikan kualitas dan kehandalan produk perangkat lunak. Dengan menggabungkan pengujian integrasi otomatis di lingkungan staging, perusahaan dapat menjaga kebersihan lingkungan pengujian sambil secara menyeluruh memvalidasi API. Integrasi pengujian unit dan pengujian integrasi memungkinkan pengembang dan tim QA memverifikasi komponen yang terisolasi dan interaksinya dalam sistem. PRD yang berpusat pada pengguna membantu komunikasi yang efektif antara manajer produk dan tim pengembangan, memastikan pemahaman yang jelas tentang tujuan akhir. Pembagian tugas dan kesesuaian kriteria penerimaan membantu mengoptimalkan proses pengembangan dan menjaga keseimbangan antara persyaratan bisnis dan implementasi teknis. Dengan mengadopsi strategi-strategi ini, organisasi dapat meningkatkan praktik pengujian API mereka dan memperkuat proses pengembangan agile yang sukses.
-->