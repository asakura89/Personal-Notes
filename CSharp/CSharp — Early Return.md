---
tags:
- CSharp
- C#
- Draft
date: 2023-08-17
---

<p>
  <h1 style="text-align:center;font-size:1.25em;margin-top:24px;margin-bottom:16px;font-weight:600;line-height:1.25">Kelompok Belajar Bunga Matahari</h1>
  <h3 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">Coding sudah seharusnya menyenangkan!</h3>
  <h5 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">
    <a href="https://github.com/asakura89">asakura89</a> /
    <a href="https://opensource.org/licenses/0BSD">BSD Zero Clause</a>
  </h5>
</p>



# Early return

Pernah liat code yang `if-else` nested-nya sampe bejibun, 6 lapis. Gelo. Contohnya gini nih misal.

```c#
using static System.Console;

public void ProsesHasilTes(PengambilTes pengambilTes) {
    if (pengambilTes.NilaiTotal >= Tes.MinimumNilaiKualifikasi) {
        if (pengambilTes.NilaiPengetahuanTertulis >= 75 &&
            pengambilTes.NilaiPraktik >= 90 &&
            pengambilTes.NilaiSpesifikProjek >= 75)
            WriteLine("Uwah, luar biasa sekali, kamu adalah salah satu yang terbaik nilainya!");
        else
            WriteLine("Mantap, kamu lulus!");
    }
    else
        WriteLine("Butuh ambil remedial.");
}
```

Code di atas ini bisa di-simplify pake early return. Sesuai namanya, early return ini ya return-nya di awal. Kalo di-refactor jadi gini.

```c#
using static System.Console;

public void ProsesHasilTes(PengambilTes pengambilTes) {
    if (pengambilTes.NilaiTotal < Tes.MinimumNilaiKualifikasi) {
        WriteLine("Butuh ambil remedial");
        return;
    }

    Boolean loloskah1 = pengambilTes.NilaiPengetahuanTertulis >= 75;
    Boolean loloskah2 = pengambilTes.NilaiPraktik >= 90;
    Boolean loloskah3 = pengambilTes.NilaiSpesifikProjek >= 75;
    if (loloskah1 && loloskah2 && loloskah3) {
        WriteLine("Uwah, luar biasa sekali, kamu adalah salah satu yang terbaik nilainya!");
        return;
    }
    
    WriteLine("Mantap, kamu lulus!");
}
```

Logic-nya ada berubah dikit tapi jadinya gak perlu nested.