---
tags:
- CSharp
date: 2019-05-01
---

# Simple Token

Sama kaya [CSharp — Timestamp](/CSharp/CSharp%20—%20Timestamp.md), bisa dipake buat banyak hal. Contoh yang paling sering adalah buat bikin unique id. Bedanya mungkin lebih ke kalo Timestamp dipake buat unique id yang bisa dibaca sebagai waktu. Sedangkan token lebih ke unique id yang di-generate buat satu waktu itu aja dan gak perlu diinget. Semacam OTP (One-Time Password).

```c#
using System;
using System.Text;

public class GenerateToken {

    const Int32 MaxChar = 8;

    public void Run() {
        String[] alphaNumeric = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,0,1,2,3,4,5,6,7,8,9".Split(',');
        var rand = new Random();
        var strBuilder = new StringBuilder();
        for (Int32 idx = 0; idx < MaxChar; idx++)
            strBuilder.Append(alphaNumeric[rand.Next(0, alphaNumeric.Length -1)]);

        Console.WriteLine("Generated Token: {0}", strBuilder.ToString());
    }
}
// Generated Token: RAGEQU6W
```
