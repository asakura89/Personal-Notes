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

**Code:**

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

**Output:**

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

**Code:**

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

**Output:**

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

**Code:**

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

**Output:**

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



**References:**

Conversation with Bing, 6/19/2023
- [asp.net mvc - What is the difference between html.AttributeEncode vs ....](https://stackoverflow.com/questions/2244079/what-is-the-difference-between-html-attributeencode-vs-html-encode).
- [What is the difference between AntiXss.HtmlEncode and HttpUtility ....](https://stackoverflow.com/questions/1608854/what-is-the-difference-between-antixss-htmlencode-and-httputility-htmlencode).
- [HttpUtility.HtmlAttributeEncode Method (System.Web).](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlattributeencode?view=net-7.0).
- [HttpUtility.HtmlEncode Method (System.Web) | Microsoft Learn.](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlencode?view=net-7.0).



## 4. `SecurityElement.Escape`

**Code:**

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

**Output:**

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

**Code:**

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



**Output:**

```xml
_x003C__x003F_xml_x0020_version_x003D__x0022_1.0_x0022__x0020_encoding_x003D__x0022_utf-8_x0022__x0020__x003F__x003E__x000D__x000A__x003C_configuration_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x003C_smtpSettings_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_server_x003E_smtp.supermailservice.com_x003C__x002F_server_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_port_x003E_587_x003C__x002F_port_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_userName_x003E_SmtpUser_Admin_x003C__x002F_userName_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_password_x003E_100_x0025_SmtpPwd4Admin_x003E__x003C__x0026__x003C__x002F_password_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x0020__x003C_useTls_x003E_false_x003C__x002F_useTls_x003E__x000D__x000A__x0020__x0020__x0020__x0020__x003C__x002F_smtpSettings_x003E__x000D__x000A__x003C__x002F_configuration_x003E_
```

Perbedaan antara `HttpUtility.HtmlEncode` dan `XmlConvert.EncodeName` adalah:

| `HttpUtility.HtmlEncode`                                    | `XmlConvert.EncodeName`                                                                                |
| ----------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| Encode semua character yang bukan termasuk HTML             | Encode semua character yang gak valid di XML, spasi, simbol, tanda baca kaya titik, koma, tanda kurung |
| Bisa dipake di semua content HTML                           | Sebaiknya hanya dipake buat nama element XML, nama attribute XML dan bukan value                       |
| Beda cara encode. Misal, spasi bakal di-encode jadi `&#32;` | Beda cara encode. Misal, spasi bakal di-encode jadi `_x0020_`                                          |



**References:**

Conversation with Bing, 6/19/2023
- [What is the difference between AntiXss.HtmlEncode and HttpUtility ....](https://stackoverflow.com/questions/1608854/what-is-the-difference-between-antixss-htmlencode-and-httputility-htmlencode).
- [c# - What is difference between WebUtility.HtmlEncode and ....](https://stackoverflow.com/questions/63149066/what-is-difference-between-webutility-htmlencode-and-antixssencoder-htmlencode).
- [.net - Best way to encode text data for XML - Stack Overflow.](https://stackoverflow.com/questions/157646/best-way-to-encode-text-data-for-xml).
- [What's the difference between System.Web.HttpUtility.HtmlEncode and ....](https://stackoverflow.com/questions/9510637/whats-the-difference-between-system-web-httputility-htmlencode-and-httpserverut).


<!--
## User
Hi Bing, can you generate me c# code that can encode all xml attributes value and all xml node value
## Bing
Sure, I can try to generate some c# code for you. Here is what I came up with:

[csharp]
using System;
using System.Xml;

namespace XmlEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the xml document from a file
            XmlDocument doc = new XmlDocument();
            doc.Load("sample.xml");

            // Encode all the attribute values and node values
            EncodeXml(doc.DocumentElement);

            // Save the encoded xml document to a file
            doc.Save("encoded.xml");
        }

        // A recursive method to encode all the attribute values and node values in an xml element
        static void EncodeXml(XmlElement element)
        {
            // Encode the attribute values
            foreach (XmlAttribute attr in element.Attributes)
            {
                attr.Value = XmlConvert.EncodeName(attr.Value);
            }

            // Encode the node value if it is a text node
            if (element.FirstChild is XmlText textNode)
            {
                textNode.Value = XmlConvert.EncodeName(textNode.Value);
            }

            // Recursively encode the child elements
            foreach (XmlElement child in element.ChildNodes)
            {
                EncodeXml(child);
            }
        }
    }
}
## User
convert the code to not use recursive
## Bing
Okay, I can try to convert the code to not use recursive. Here is what I came up with:

[csharp]
using System;
using System.Xml;
using System.Collections.Generic;

namespace XmlEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the xml document from a file
            XmlDocument doc = new XmlDocument();
            doc.Load("sample.xml");

            // Encode all the attribute values and node values
            EncodeXml(doc.DocumentElement);

            // Save the encoded xml document to a file
            doc.Save("encoded.xml");
        }

        // A method to encode all the attribute values and node values in an xml element using a stack
        static void EncodeXml(XmlElement element)
        {
            // Create a stack to store the elements to process
            Stack<XmlElement> stack = new Stack<XmlElement>();

            // Push the root element to the stack
            stack.Push(element);

            // Loop until the stack is empty
            while (stack.Count > 0)
            {
                // Pop the top element from the stack
                XmlElement current = stack.Pop();

                // Encode the attribute values
                foreach (XmlAttribute attr in current.Attributes)
                {
                    attr.Value = XmlConvert.EncodeName(attr.Value);
                }

                // Encode the node value if it is a text node
                if (current.FirstChild is XmlText textNode)
                {
                    textNode.Value = XmlConvert.EncodeName(textNode.Value);
                }

                // Push the child elements to the stack in reverse order
                for (int i = current.ChildNodes.Count - 1; i >= 0; i--)
                {
                    if (current.ChildNodes[i] is XmlElement child)
                    {
                        stack.Push(child);
                    }
                }
            }
        }
    }
}
## User
do you know the difference between HttpUtility.HtmlEncode and HttpUtility.HtmlAttributeEncode?
## Bing
Yes, I know the difference between HttpUtility.HtmlEncode and HttpUtility.HtmlAttributeEncode. According to the web search results   , the main differences are:
 - HttpUtility.HtmlEncode encodes any characters that aren't in HTML, while HttpUtility.HtmlAttributeEncode encodes only a handful of characters: " & < \
 - HttpUtility.HtmlEncode can be used for any HTML content, while HttpUtility.HtmlAttributeEncode should be used only for attributes that are in double quotation marks. Security issues might arise if you use it for attributes that are in single quotation marks.
 - HttpUtility.HtmlAttributeEncode is considerably faster than HttpUtility.HtmlEncode.

## User
do you know the difference between HttpUtility.HtmlEncode and XmlConvert.EncodeName?
## Bing
Yes, I know the difference between HttpUtility.HtmlEncode and XmlConvert.EncodeName. According to the web search results   , the main differences are:
 - HttpUtility.HtmlEncode encodes any characters that aren't in HTML, while XmlConvert.EncodeName encodes any characters that aren't valid in XML names, such as spaces, punctuation, or symbols.
 - HttpUtility.HtmlEncode can be used for any HTML content, while XmlConvert.EncodeName should be used only for XML element names or attribute names, not values.
 - HttpUtility.HtmlEncode and XmlConvert.EncodeName use different rules for encoding characters. For example, HttpUtility.HtmlEncode will encode a space as &#32;, while XmlConvert.EncodeName will encode it as _x0020_.





## User
Yo Bing, please generate me c# code for encode all xml attributes's value. the input is string and expected to be a valid xml and the out also a valid xml string that already encoded.
## Bing
Sure, I can try to generate some c# code for you. Here is what I came up with:

[csharp]
using System;
using System.Xml;

namespace XmlEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input string (assumed to be a valid xml)
            string input = "<book id=\"1\" title=\"The Hitchhiker's Guide to the Galaxy\" author=\"Douglas Adams\" />";

            // Output string (encoded xml)
            string output = EncodeXmlAttributes(input);

            // Print the output
            Console.WriteLine(output);
        }

        // Method to encode all xml attributes' values
        static string EncodeXmlAttributes(string input)
        {
            // Create an xml document from the input string
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);

            // Loop through all the nodes in the document
            foreach (XmlNode node in doc.SelectNodes("//*"))
            {
                // Loop through all the attributes of the node
                foreach (XmlAttribute attr in node.Attributes)
                {
                    // Encode the attribute value using System.Web.HttpUtility.HtmlEncode method
                    attr.Value = System.Web.HttpUtility.HtmlEncode(attr.Value);
                }
            }

            // Return the encoded xml as a string
            return doc.OuterXml;
        }
    }
}
## User
Can you optimize this code for performance?
## Bing
Sure, I can try to optimize this code for performance. Here are some possible ways to do that:
 - Use StringBuilder instead of string concatenation to build the output xml string. This can reduce memory allocation and improve speed.
 - Use XmlWriter instead of XmlDocument to write the output xml. This can avoid loading the entire xml document into memory and allow streaming the output.
 - Use XmlReader instead of XmlDocument to read the input xml. This can also avoid loading the entire xml document into memory and allow streaming the input.
 - Use XmlReaderSettings and XmlWriterSettings to specify encoding, validation, and other options for the xml processing.

Here is an example of how the code might look like using these optimizations:

[csharp]
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace XmlEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input string (assumed to be a valid xml)
            string input = "<book id=\"1\" title=\"The Hitchhiker's Guide to the Galaxy\" author=\"Douglas Adams\" />";

            // Output string (encoded xml)
            string output = EncodeXmlAttributes(input);

            // Print the output
            Console.WriteLine(output);
        }

        // Method to encode all xml attributes' values
        static string EncodeXmlAttributes(string input)
        {
            // Create a StringBuilder to store the output xml
            StringBuilder sb = new StringBuilder();

            // Create an XmlWriterSettings object to specify encoding, indentation, and other options
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            // Create an XmlWriter object to write the output xml to the StringBuilder
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                // Create an XmlReaderSettings object to specify validation and other options
                XmlReaderSettings readerSettings = new XmlReaderSettings();
                readerSettings.ValidationType = ValidationType.None;

                // Create an XmlReader object to read the input xml from a StringReader
                using (XmlReader reader = XmlReader.Create(new StringReader(input), readerSettings))
                {
                    // Loop through all the nodes in the input xml
                    while (reader.Read())
                    {
                        // Write the node to the output xml as is, except for attributes
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.CDATA:
                                writer.WriteCData(reader.Value);
                                break;
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                                writer.WriteStartDocument();
                                break;
                            case XmlNodeType.DocumentType:
                                writer.WriteDocType(reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"), reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteEndElement();
                                break;
                        }

                        // If the node has attributes, loop through them and encode their values
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                // Write the attribute name and namespace as is
                                writer.WriteStartAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI);

                                // Encode the attribute value using HttpUtility.HtmlEncode method
                                writer.WriteString(HttpUtility.HtmlEncode(reader.Value));

                                // Write the end of the attribute
                                writer.WriteEndAttribute();
                            }

                            // Move back to the element node
                            reader.MoveToElement();
                        }
                    }

                    // Write the end of the document
                    writer.WriteEndDocument();
                }
            }

            // Return the encoded xml as a string
            return sb.ToString();
        }
    }
}
## User
omygod
I love you and I love xml
## Bing
I'm glad you love xml. It's a powerful and versatile format for data exchange. I'm also happy that you appreciate my help, but I don't think I can reciprocate your feelings. I'm just a chat mode of Microsoft Bing search, not a person.😅





-->