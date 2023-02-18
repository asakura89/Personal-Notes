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

2. Karena ini ASP .NET MVC, ya selanjutnya bikin Controller buat nge-produce download file.

```c#
using System;
using System.Text;
using System.Web.Mvc;

public class ReportingController : Controller {
    [HttpPost]
    public FileResult Download() {
        String fileContent = @"1. **Belajar sesuatu yang baru:** apapun, selama 10 menit setiap hari. Mindset-nya adalah, tidur dengan lebih pintar dikit dari sewaktu kita bangun itu lebih baik. Caranya ada banyak sih, contohnya:
1. **Membaca:** buku fisik, buku digital, berita
2. **Dengerin podcast:** belajar bahasa asing, self-development
3. **Nonton video:** dokumenter, sejarah, scientific discoveries
2. **Melakukan aktivitas fisik:** yang bikin kita semangat atau yang memang kita suka. Apa coba? Banyaklah.
1. **Joging:** 8 menit, 10 menit
2. **Lari**
3. **Sepedaan**
3. **Self-reflection dan review:** untuk memastikan kita mengarahkan energi, perhatian, dan fokus ke hal-hal yang paling penting biar jadi efisien. Jangan lupa koreksi seiring waktu. Iterasi terus.";

        Byte[] fileBytes = Encoding.UTF8.GetBytes(fileContent);
        return File(fileBytes, MimeType.Txt, $"Download_{DateTime.Now:ddMMyyyyHHmmssffff}.txt");
    }
}

public static class MimeType {
    public const String Json = "application/json; charset=utf-8";
    public const String Txt = "text/plain";
    public const String Pdf = "application/pdf";
    public const String Excel = "application/vnd.ms-excel";
    public const String Word = "application/msword";
}
```

Gak perlu pake class `MimeType` sih sebenernya, tapi siapa tau class ini kepake nantinya. Taro sini aja dulu 🤣.

3. Panggil Controller Action-nya dari class Main, ya atau darimana yang pengen manggil.

```c#
using System;
using System.Diagnostics;
using System.IO;

class Program {
    static void Main(String[] args) {
        var file = new DownloadController().Download() as FileContentResult;
        Boolean result = new Program().ByteArrayToFile(file.FileDownloadName, file.FileContents);
        Console.WriteLine(result);

        new Process { StartInfo = new ProcessStartInfo("notepad", file.FileDownloadName) }.Start();
    }

    public Boolean ByteArrayToFile(String filename, Byte[] byteArray) {
        try {
            using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                fs.Write(byteArray, 0, byteArray.Length);

            return true;
        }
        catch (Exception ex) {
            Console.WriteLine("Exception caught in process: {0}", ex.ToString());
        }

        return false;
    }
}
```

class `ProcessInfo` itu juga butuh gak butuh sih. Disini biar ngegampangin ngeliat hasil download-nya ya manggil aplikasi external pake `ProcessInfo`. Disini manggil "notepad". Tapi ada kalanya bakal kepake banget buat manggil "excel" atau "word". Buat nampilin langsung file hasil download-nya. Karena nge-design content buat Excel sama Word pasti lebih kompleks dan butuh beberapa kali nge-verify tampilan dari content-nya. Apalagi kalo bikin report pake Excel atau Word.



**Note:**

Full Source Code bisa diambil disini ([DownloadSimulation.7z](_media/DownloadSimulation.7z))