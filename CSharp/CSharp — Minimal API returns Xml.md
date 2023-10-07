---
tags:
- CSharp
- C#
- XML
- Minimal-API
- .NET-6
date: 2023-07-01
---

# Minimal API returns Xml

Minimal API ini by-default bakal bikin simple Http Controller yang nge-return Http Result. By-default ya bakal nge-return JSON. Karena Output Serializer-nya cuma ada JSON Serializer.

Kita code kaya gini juga dia set Content-Type di Http Header-nya jadi `application/json`.

```c#
// Program.cs

app.MapGet("/ajax", (HttpContext ctx) => {
    ctx.Response.ContentType = "application/xml";
    return new List<String> {
        "One",
        "Two",
        "Three"
    };
});
```

Jadi gimana dong? Butuh nambahin Mvc Controller terus tambahin XmlSerializer ke list Serializer-nya. Configure dulu `Program.cs` buat pake Mvc Controller.

Cara pertama:

```c#
// Program.cs

// . . . omitted builder configured . . .
builder.Services
    .AddControllers()
    .AddXmlSerializerFormatters();

// . . . omitted app configured . . .
app.MapControllers();
```

Atau pake cara kedua:

```c#
// Program.cs

using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml;

// . . . omitted builder configured . . .
builder.Services
    .AddMvc()
    .AddMvcOptions(opt => opt.OutputFormatters.Add(
        new XmlDataContractSerializerOutputFormatter(
            new XmlWriterSettings {
                Encoding = Encoding.UTF8,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                Async = true,
                OmitXmlDeclaration = true
            }
        )
    ));

// . . . omitted app configured . . .
app.MapControllers();
```

Terus tambahin Controller-nya. Jangan lupa set Content-Type ke xml buat maksa response ke xml ketimbang diminta sama client (Accept header yang dikirim browser).

```c#
// Controllers/AjaxController.cs

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")] // app.MapControllers() di Program.cs bakal butuh attribute ini
public class AjaxController : ControllerBase {
    [HttpGet]
    public IActionResult Get() {
        Response.ContentType = "application/xml";
        return new ObjectResult(new List<String> {
            "One",
            "Two",
            "Three"
        });
    }
}
```

Coba liat juga code ini buat alternatif
1. [Riku/Riku/Controllers/AjaxController.cs at master · asakura89/Riku](https://github.com/asakura89/Riku/blob/master/Riku/Controllers/AjaxController.cs)
2. [Riku/Riku/Startup.cs at master · asakura89/Riku](https://github.com/asakura89/Riku/blob/master/Riku/Startup.cs#L17-L30)