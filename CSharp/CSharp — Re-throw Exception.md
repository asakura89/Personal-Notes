---
tags:
- CSharp
date: 2024-12-30
---

# Re-throw Exception

Re-throwing exceptions bisa mengaburkan atau nyembunyiin actual stack trace-nya. Buat ngeliat gimana maksudnya bisa cobain code ini.

```c#
void Main() {
    try {
        C();
    }
    catch (Exception e) {
        Console.WriteLine(e.GetExceptionMessage());
    }
}

void A() {
    throw new InvalidOperationException("A throw");
}

void B() {
    A();
}

void C() {
    try {
        B();
    }
    catch(Exception ex) {
        /** ~| re-throwing exception |~ */
        throw ex;

        /** ~| just throw |~ */
        // throw;
    }
}

public static class ExceptionExt {
    public static String GetExceptionMessage(this Exception ex) {
        var errorList = new StringBuilder();
        Exception current = ex;
        while (current != null) {
            errorList
                .AppendLine($"Exception: {current.GetType().FullName}")
                .AppendLine($"Message: {current.Message}")
                .AppendLine($"Source: {current.Source}")
                .AppendLine(current.StackTrace)
                .AppendLine();

            current = current.InnerException;
        }

        return errorList.ToString();
    }
}
```


Kalo `throw ex;` yang dipake, nanti stack trace-nya jadi gak lengkap kaya gini dan di-start dari method dimana dia di-re-throw.

```log
Exception: System.InvalidOperationException
Message: A throw
Source: query_qwszil
   at UserQuery.C() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_qwszil.cs:line 51
   at UserQuery.Main() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_qwszil.cs:line 31
```


Kalo `throw;` yang dipake, stack trace-nya lengkap.

```log
Exception: System.InvalidOperationException
Message: A throw
Source: query_voisoo
   at UserQuery.A() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_voisoo.cs:line 39
   at UserQuery.B() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_voisoo.cs:line 43
   at UserQuery.C() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_voisoo.cs:line 51
   at UserQuery.Main() in C:\Users\ASMNetworkLabUsr\AppData\Local\Temp\LINQPad5\_ffcfcvke\query_voisoo.cs:line 31
```



**References:**

- [.net - What is the proper way to rethrow an exception in C#? - Stack Overflow](https://stackoverflow.com/questions/178456/what-is-the-proper-way-to-rethrow-an-exception-in-c)
