<p>
  <h1 align="center">Kelompok Belajar Bunga Matahari</h1>
  <h3 align="center" style="margin-top: -2em;">Coding sudah seharusnya menyenangkan!</h3>
  <h5 align="center" style="margin-top: -0.5em;">
    <a href="https://github.com/asakura89/BisaCSharp.git">asakura89</a> /
    <a href="https://choosealicense.com/licenses/unlicense/">UNLICENSE</a>
  </h5>
  <!-- use MistyLightWindows theme -->
</p>




[TOC]



## Interconnected Embracement of Modular Components Addiction (Ice Moca)
Apa itu Ice Moca? Semacam konsep yang terlalu over-engineering untuk nge-solve permasalahan modular component. Modular yang dimaksud disini lebih fokus ke component code yang bisa diganti-ganti seenak jidat tanpa harus recompile seluruh app. Jadi bahasan ini gak akan nge-cover soal modular code architecture kaya clean architecture, onion layers, DDD, atau konsep arsitektur lainnya.

Yang memungkinkan developer untuk bisa mengganti-ganti component seenak jidat udah pasti dengan konsep DI. Tapi karena DI hanya membahas soal object creation dan bukan level component, akan butuh hal lain untuk bisa nerapin DI untuk bisa sampe ke level component. Tapi ada 1 konsep yang sama yang akan dipake di Ice Moca dan di DI, yaitu Reflection. Reflection ini adalah konsep .Net untuk ngebaca metadata dari code untuk bisa utilize object creation secara programmatically ataupun modify instance, atau call method secara dinamis. 

Untuk itu ada 2 hal yang dibutuhin, Application Pipeline dan Event Emitter. 2 hal ini adalah yang membuat Sitecore CMS jadi salah satu CMS yang powerful. Yes, 2 hal ini juga yang akan dicontek dari Sitecore untuk bisa diterapin ke app yang akan di-develop. 

### 1. Application Pipeline

Kalo ngomongin pipeline maka yang banyak tampil dari search engine biasanya cuma 2. CI/CD Pipeline dan ASP .Net Core Middleware Pipeline. Pipeline yang akan dibahas disini adalah konsep pipeline dan penerapannya secara spesifik untuk modularity.

Konsep pipeline umumnya adalah ada component yang menerima input lalu mengeluarkan output untuk bisa di-chaining bareng dengan pipeline lainnya. Hal ini lumrah banget kalo terbiasa pake command-line. Karena command-line apapun pasti punya pipeline dengan istilah pipe output atau piping.

Application Pipeline juga akan make konsep yang sama. Ada satu set mnas

### 2. Event Emitter
