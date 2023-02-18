---
tags:
- Go
- Draft
date: 2023-08-12
---

<p>
  <h1 style="text-align:center;font-size:1.25em;margin-top:24px;margin-bottom:16px;font-weight:600;line-height:1.25">Kelompok Belajar Bunga Matahari</h1>
  <h3 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">Coding sudah seharusnya menyenangkan!</h3>
  <h5 style="text-align:center;font-size:16px;margin-top:0;margin-bottom:16px;line-height:1.5">
    <a href="https://github.com/asakura89">asakura89</a> /
    <a href="https://opensource.org/licenses/0BSD">BSD Zero Clause</a>
  </h5>
</p>



# Perkenalan

## 1. Entry Point

```go
package main

import "fmt"

func main() {
    // ^ Method ini adalah Entry Point.
}
```



## 2. Constructor

Di go gak ada constructor kaya C#, tapi bisa di-recreate. Artinya diakalin

```go
package main

import "fmt"

type Program struct { }
// ^ ini class

func NewProgram() *Program {
    return &Program{}
}
// ini bisa dianggap sbg pura-puranya constructor

func main() {
    program := NewProgram()
}
```



## 3. Deklarasi

Tahap deklarasi adalah tahapan sewaktu variabel dibuat. Apakah diberi nilai atau enggak.

```go
package main

func main() {
    // Deklarasi variabel
    var permenDiTanganKiri int
    var permenDiTanganKanan int = 3

    // atau gini
    permenDiTanganKanan := 3
}
```



## 4. Inisialisasi

Tahap inisialisasi adalah tahapan sewaktu variabel diberi nilai.

```go
package main

type Program struct {
    // Deklarasi variabel
    jariKakiKiri int
    jariKakiKanan int
}

func NewProgram() *Program {
    program := &Program{
        // Inisialisasi variabel
        jariKakiKiri: 5,
        jariKakiKanan: 5,
    }

    return program
}

func main() {
    var permenDiTanganKiri int // → hanya deklarasi
    var permenDiTanganKanan int = 3 // → deklarasi dan inisialisasi

    // atau bisa gini
    permenDiTanganKanan := 3 // → deklarasi dan inisialisasi
    // kalo pake `:=` gak perlu type information, jadi bisa langsung
    // mirip kaya `var` di C#

    // ini kalo mau inisialisasi ulang
    permenDiTanganKanan = 6

    // gak bisa gini
    permenDiTanganKanan := 6
    // karena ini syntax deklarasi, yang mana pasti error
    // kan udah didekalarasi di atas

    // go juga strong type, jadi gak bisa gini
    permenDiTanganKanan = "yuhuueoo"

    _ = permenDiTanganKiri // Akal-akalan biar gak kena error "unused variable"
    _ = permenDiTanganKanan // Akal-akalan biar gak kena error "unused variable"
}
```

### 4.1. Array Initializer

```go
package main

func main() {
    var arrayPertama [3]string
    arrayKedua := [3]string{"Ini", "array", "kedua"}
    arrayKetiga := []string{"Ini", "array", "ketiga"}
    arrayKeempat := [...]string{"Ini", "array", "keempat"}
    // arrayKelima := {"Ini", "array", "kelima"} // Ini gak bisa di Golang, gakkan ke-compile
    arrayKeenam := []string{"Ini", "array", "keenam"}

    _ = arrayPertama
    _ = arrayKedua
    _ = arrayKetiga
    _ = arrayKeempat
    _ = arrayKeenam
}
```


## Function Overload

Di Golang gak ada function overload. Code ini bakal ngeluarin compile-time error

```go
package main

import (
    "math/rand"
    "time"
    "fmt"
)

func main() {
    fmt.Println(Ryandomize(10))
}

const feigenbaum = 46692016

func Ryandomize(lowerBound, upperBound int32) int32 {
    seed := time.Now().UnixNano() % feigenbaum
    rnd := rand.New(rand.NewSource(seed))
    return lowerBound + rnd.Int31n(upperBound-lowerBound)
}

func Ryandomize(upperBound int32) int32 {
    return Ryandomize(0, upperBound)
}
```

error-nya

```log
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
# command-line-arguments
.\main.go:10:28: not enough arguments in call to Ryandomize
        have (number)
        want (int32, int32)
.\main.go:22:6: Ryandomize redeclared in this block
        .\main.go:15:6: other declaration of Ryandomize
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> 
```

tapi kalo code-nya kaya gini

```go
// . . . omitted . . .

func main() {
    fmt.Println(RyandomizeUpper(10))
}

func Ryandomize(lowerBound, upperBound int32) int32 {
    // . . . omitted . . .
}

func RyandomizeUpper(upperBound int32) int32 {
    return Ryandomize(0, upperBound)
}
```

bisa

```go
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
5
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
2
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
3
```

Jadi harus pinter-pinter nyari nama buat function yang overloading function lainnya

