---
tags:
- Life
- Thought
date: 2023-06-21
---

# If I want to sell tickets

## Determine Pricing

Katakanlah ada 94 Issue tickets atau mungkin bug tickets. Tapi kan gak semuanya bugs. Ada yang cuma permintaan client buat ngecek possibility apa App-nya bisa diginiin, digituin. Ada juga yang langsung minta buat ditambahin fitur. Macem-macem. Ya balik lagi ke tiket yang ada 94 tadi.

Dari 94 tiket ini ada 3 jenis priority. Paling prioritas atau bisa dibilang urgent itu Level 1 atau disingkat L1. Ada priority Level 2, penting. Terakhir ada Level 3, yang bisa dibilang gak penting-penting amat tapi perlu buat diselesein.

Selain priority, ada complexity. Complexity juga ada 3, simple to do, medium to do, complex to do.

Ada lagi severity. Low, medium, high. Semakin tinggi severity, semakin besar impact dari issue ini ke pengguna.

Dari semua informasi ini, kira-kira gimana nih kalo semisal tiket ini mau dijual? Apa yang bisa nentuin harga 1 tiket beda sama harga tiket yang lainnya? Berarti kita mesti nentuin faktor yang memberatkan suatu tiket jadi harganya bisa melambung.

Kalo misal kita breakdown, property dari masing-masing tiket terus kita kasi faktor pemberat mungkin bisa jadi kaya gini.

1. Priority:
    - L1/High: faktor = 3
    - L2/Medium: faktor = 2
    - L3/Low: faktor = 1

2. Complexity:
    - Simple: faktor = 1
    - Medium: faktor = 2
    - Complex: faktor = 3

3. Severity:
    - Low: faktor = 1
    - Medium: faktor = 2
    - High: faktor = 3

Kalo digambarin, mungkin contohnya bisa gini:

| Ticket ID | Priority | Complexity | Severity | Weightage |
|-----------|----------|------------|----------|-----------|
| Ticket-01 | Low      | Simple     | Low      | 3         |
| Ticket-02 | Medium   | Medium     | Medium   | 6         |
| Ticket-03 | High     | Complex    | High     | 9         |
| Ticket-04 | Low      | Medium     | Medium   | 5         |
| Ticket-05 | High     | Simple     | Medium   | 6         |
| Ticket-06 | Medium   | Simple     | Low      | 4         |

Nah kalo udah ada faktor pemberat gini berarti kita bisa masuk ke tahap selanjutnya yaitu nentuin harga dasar. Seandainya kita nentuin harga dasar Rp. 5 per poin faktor, berarti tinggal kali aja faktor sama harga dasar. Tapi gimana kalo semisal ada region lain dimana secara pendapatan rata-rata di atas pendapatan rata-rata dari region awal. Mungkin bisa dimasukin juga jadi faktor pengali.

| Ticket ID | Priority | Complexity | Severity | Weightage | Region | Regional Weight | Price    |
|-----------|----------|------------|----------|-----------|--------|-----------------|----------|
| Ticket-01 | Low      | Simple     | Low      | 3         | A      | 1               | Rp. 15   |
| Ticket-01 | Low      | Simple     | Low      | 3         | B      | 1.5             | Rp. 22.5 |
| Ticket-02 | Medium   | Medium     | Medium   | 6         | A      | 1               | Rp. 30   |
| Ticket-02 | Medium   | Medium     | Medium   | 6         | B      | 1.5             | Rp. 45   |
| Ticket-03 | High     | Complex    | High     | 9         | A      | 1               | Rp. 45   |
| Ticket-03 | High     | Complex    | High     | 9         | B      | 1.5             | Rp. 67.5 |
| Ticket-04 | Low      | Medium     | Medium   | 5         | A      | 1               | Rp. 25   |
| Ticket-04 | Low      | Medium     | Medium   | 5         | B      | 1.5             | Rp. 37.5 |
| Ticket-05 | High     | Simple     | Medium   | 6         | A      | 1               | Rp. 30   |
| Ticket-05 | High     | Simple     | Medium   | 6         | B      | 1.5             | Rp. 45   |
| Ticket-06 | Medium   | Simple     | Low      | 4         | A      | 1               | Rp. 20   |
| Ticket-06 | Medium   | Simple     | Low      | 4         | B      | 1.5             | Rp. 30   |



## Thinking Steps

1. <ins>Understanding the problem:</ins> Ngertiin dulu problem-nya apa. Problem ini soal 94 tiket maintenance di JIRA. Dan kita mau jual tiket ini. Bisa jadi ada developer outsource yang mau ngambil satu buat dikerjain gitu yakan. Siapa tau. Nah gimana caranya Karena masing-masing tiket punya atribut atau properti yang bisa di jadiin variabel. Yang mana variabel ini bisa di-quantify.
2. <ins>Identifying the variables:</ins> Basis dari quantifiable-nya ini bisa diambil dari variabel-variabel yang sempet disebutin tadi.
   1. Priority
   2. Complexity
   3. Severity
   4. \<Atribut/properti lain\>
3. <ins>Formula creation:</ins> Dari sini kita bisa assign nilai. Nilai ini yang bikin tiket-tiket tadi bisa-calculate. Karena tiket-tiket tadi bisa di-calculate, hasil kalkulasinya yang kita bisa bikin jadi harga nantinya. Karena berdasarkan hasil kalkulasi kita jadi lebih gampang buat nentuin hasil kalkulasi tertinggi dan hasil kalkulasi terendah. Yang mana ketika di-sorting, nilai ini jadi bisa diarahin jadi ke real prioritization. Atau prioritas sebenernya yang udah mempertimbangkan faktor-faktor kaya priority, severity dkk tadi. Pengarahan si nilai hasil tadi juga bisa diarahin ke pricing. Semakin tinggi nilai hasil, semakin mahal harganya.
