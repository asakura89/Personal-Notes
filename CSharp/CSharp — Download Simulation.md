---
tags:
- CSharp
- C#
date: 2023-07-19
---

# Download Simulation

Kadang kita butuh tau hasil file dari download function yang kita bikin. Atau sekedar nge-test logic ASP .NET MVC yang kita develop udah bener atau belom.

Mungkin cara ini bisa ngebantu bikin simulasi dari download function. Atau malah nge-simulasiin dari Web Endpoint yang kita develop. Semacem integration test kecil-kecilan.

Steps-nya adalah:
1. Karena ini memang spesifik ke ASP .NET, jadi kita butuh install NuGet package-nya. Di kasus ini pake package Microsoft.AspNet.Mvc versi 5.2.6. Kalo punya ASP .NET yang lebih usang, mungkin ada skenario pake ASP .NET MVC 3. Install dulu installer-nya terus add reference kaya nge-add reference .NET BCL biasa. Add reference-nya System.Web.Mvc.dll.

2. 
