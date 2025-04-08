---
tags:
- Math
date: 2025-04-08
---

# Modulo

Cara memahami modulo:
1. <ins>sisa dari hasil pembagian</ins>
    misal,
    1. contoh 100 % 9
        100/9 = 11 dengan sisa 1
        kenapa?
        karena 11*9 = 99 kalo ditambahin sisa 1 = 100

2. gimana cara taunya hasil pembagian adalah benar segitu?
    <ins>dibalik rumusnya</ins>
    sama kaya contoh di atas
    misal,
    1. contoh 14 % 12
        14/12 = 1 dengan sisa 2
        karena 1*12 = 12 kalo ditambahin sisa 2 = 14
    2. contoh 156 % 37
        156/37 = 4 dengan sisa 8
        karena 4*37 = 148 kalo ditambahin sisa 8 = 156

    jadi rumus kebaliknya adalah `divident - (buang koma(divident/divisor) * divisor)`
    kalo diterapin jadinya gini
    156 - (buang koma(156/37) * 37) = 8
    step-by-step
    1. 156/37 = 4.21
    2. buang koma(4.21) = 4 (buang koma bisa di Math.floor 😊)
    3. 4*37 = 148
    4. 156-148 = 8
