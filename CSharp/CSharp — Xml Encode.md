---
tags:
- CSharp
- C#
- XML
- Encode
date: 2023-06-19
---

# Xml Encode

## 1. Original

### Code

```c#
var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>";

Console.WriteLine(xmlString);
```



### Output

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>
```



Perlu dicatet kalo XML di atas ini adalah invalid XML. Kenapa? karena ada char `>`, `<`, dan `&` yang enggak di-encode di node `password`. Tapi kita gakkan permasalahin karena memang bukan mau divalidasi, melainkan di-encode.



## 2. `HttpUtility.HtmlEncode`

### Code

```c#
using System.Web; // harus refer System.Web.dll

var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>";

Console.WriteLine(HttpUtility.HtmlEncode(xmlString));
```



### Output

```xml
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
    &lt;smtpSettings&gt;
        &lt;server&gt;smtp.supermailservice.com&lt;/server&gt;
        &lt;port&gt;587&lt;/port&gt;
        &lt;userName&gt;SmtpUser_Admin&lt;/userName&gt;
        &lt;password&gt;100%SmtpPwd4Admin&gt;&lt;&amp;&lt;/password&gt;
        &lt;useTls&gt;false&lt;/useTls&gt;
    &lt;/smtpSettings&gt;
&lt;/configuration&gt;
```



## 3. `HttpUtility.HtmlAttributeEncode`

### Code

```c#
using System.Web; // harus refer System.Web.dll

var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>";

Console.WriteLine(HttpUtility.HtmlAttributeEncode(xmlString));
```



### Output

```xml
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?>
&lt;configuration>
    &lt;smtpSettings>
        &lt;server>smtp.supermailservice.com&lt;/server>
        &lt;port>587&lt;/port>
        &lt;userName>SmtpUser_Admin&lt;/userName>
        &lt;password>100%SmtpPwd4Admin>&lt;&amp;&lt;/password>
        &lt;useTls>false&lt;/useTls>
    &lt;/smtpSettings>
&lt;/configuration>
```



Perbedaan antara `HttpUtility.HtmlEncode` dan `HttpUtility.HtmlAttributeEncode` adalah:

| `HttpUtility.HtmlEncode`                        | `HttpUtility.HtmlAttributeEncode`                                                                                                                                                                                                                                                                                                                                 |
| ----------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Encode semua character yang bukan termasuk HTML | Hanya meng-encode characted ini aja, `" & < \`                                                                                                                                                                                                                                                                                                                    |
| Bisa dipake di semua content HTML               | Sebaiknya hanya dipake buat attribute yang double quote. Karena kalo dipake buat attribute yang single quote, bisa jadi ada security issue. [.NET 4.8 Official Doc](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlattributeencode?view=netframework-4.8#system-web-httputility-htmlattributeencode(system-string-system-io-textwriter)) |
|                                                 | Lebih kenceng dari HttpUtility.HtmlEncode                                                                                                                                                                                                                                                                                                                         |



References:

Conversation with Bing, 6/19/2023
- [asp.net mvc - What is the difference between html.AttributeEncode vs ....](https://stackoverflow.com/questions/2244079/what-is-the-difference-between-html-attributeencode-vs-html-encode).
- [What is the difference between AntiXss.HtmlEncode and HttpUtility ....](https://stackoverflow.com/questions/1608854/what-is-the-difference-between-antixss-htmlencode-and-httputility-htmlencode).
- [HttpUtility.HtmlAttributeEncode Method (System.Web).](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlattributeencode?view=net-7.0).
- [HttpUtility.HtmlEncode Method (System.Web) | Microsoft Learn.](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlencode?view=net-7.0).



## 4. `SecurityElement.Escape`

### Code

```c#
using System.Security;

var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>";

Console.WriteLine(SecurityElement.Escape(xmlString));
```



### Output

```xml
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
    &lt;smtpSettings&gt;
        &lt;server&gt;smtp.supermailservice.com&lt;/server&gt;
        &lt;port&gt;587&lt;/port&gt;
        &lt;userName&gt;SmtpUser_Admin&lt;/userName&gt;
        &lt;password&gt;100%SmtpPwd4Admin&gt;&lt;&amp;&lt;/password&gt;
        &lt;useTls&gt;false&lt;/useTls&gt;
    &lt;/smtpSettings&gt;
&lt;/configuration&gt;
```



Hasilnya sama dengan `HttpUtility.HtmlEncode`.



## 5. `XmlConvert.EncodeName`

### Code

```c#
using System.Security;

var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
    <smtpSettings>
        <server>smtp.supermailservice.com</server>
        <port>587</port>
        <userName>SmtpUser_Admin</userName>
        <password>100%SmtpPwd4Admin><&</password>
        <useTls>false</useTls>
    </smtpSettings>
</configuration>";

Console.WriteLine(XmlConvert.EncodeName(xmlString));
```



### Output

```xml
_x003C__x003F_xml_x0020_version_x003D__x0022_1.0_x0022__x0020_encoding_x003D__x0022_utf-8_x0022__x0020__x003F__x003E__x000D__x000A__x003C_configuration_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x003C_smtpSettings_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_server_x003E_smtp.supermailservice.com_x003C__x002F_server_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_port_x003E_587_x003C__x002F_port_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_userName_x003E_SmtpUser_Admin_x003C__x002F_userName_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_password_x003E_100_x0025_SmtpPwd4Admin_x003E__x003C__x0026__x003C__x002F_password_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_useTls_x003E_false_x003C__x002F_useTls_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x003C__x002F_smtpSettings_x003E__x000D__x000A__x003C__x002F_configuration_x003E_
```



Perbedaan antara `HttpUtility.HtmlEncode` dan `XmlConvert.EncodeName` adalah:

| `HttpUtility.HtmlEncode`                                    | `XmlConvert.EncodeName`                                                                                |
| ----------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| Encode semua character yang bukan termasuk HTML             | Encode semua character yang gak valid di XML, spasi, simbol, tanda baca kaya titik, koma, tanda kurung |
| Bisa dipake di semua content HTML                           | Sebaiknya hanya dipake buat nama element XML, nama attribute XML dan bukan value                       |
| Beda cara encode. Misal, spasi bakal di-encode jadi `&#32;` | Beda cara encode. Misal, spasi bakal di-encode jadi `_x0020_`                                          |



References:

Conversation with Bing, 6/19/2023
- [What is the difference between AntiXss.HtmlEncode and HttpUtility ....](https://stackoverflow.com/questions/1608854/what-is-the-difference-between-antixss-htmlencode-and-httputility-htmlencode).
- [c# - What is difference between WebUtility.HtmlEncode and ....](https://stackoverflow.com/questions/63149066/what-is-difference-between-webutility-htmlencode-and-antixssencoder-htmlencode).
- [.net - Best way to encode text data for XML - Stack Overflow.](https://stackoverflow.com/questions/157646/best-way-to-encode-text-data-for-xml).
- [What's the difference between System.Web.HttpUtility.HtmlEncode and ....](https://stackoverflow.com/questions/9510637/whats-the-difference-between-system-web-httputility-htmlencode-and-httpserverut).


