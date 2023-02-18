---
tags:
- Golang
date: 2024-04-21
---

# Initializing Class

> ❗ Note
> 
> go version = 1.21.0



## Without class

Di Golang, initializing class jadi copy object ini rada gak relevant karena type simplifying by design-nya itu.

Contoh kita punya file `a.go` di dalem folder `packageA`. terus di `a.go` ini package-nya kita define juga `packageA` karena bia konsisten juga biar gak ambigu. Nah berarti kan `a.go` isinya gini.

```go
package packageA

func SomeFunc() {}
```

Karena `a.go` adalah file `.go`, masuk akal dong kalo di file ini ada class bernama `A`?

Anggaplah kita punya method/function bernama `SomeFunc` yang kerjaannya nge-returns angka konstan misalnya. Berarti masuk akal juga dong kalo `SomeFunc` ini adalah function punya class `A`. Karena gak bisa dong function berdiri sendiri? Gitu kan pikiran kita?

Gini dong berarti `a.go` kita tadi?

```go
package packageA

type A struct {}

func (a *A) SomeFunc() (int32) {
    return 46692016
}
```

Terus di `main.go` kita manggilnya gini kan?

```go
package main

import (
    "packageA"
    "fmt"
)

func main() {
    a := packageA.A{}
    angka := a.SomeFunc()
    fmt.Println(angka)
}
```

Output-nya

```go
46692016
```

Tapi di Golang, si class A (atau di Golang nyebutnya struct atau type) ini itu gak masuk akal. Karena tanpa harus punya struct pun kita bisa manggil function-nya. Disini function ini lebih ke function static yang gak perlu ada clas/struct-nya. Karena toh gak ada property yang butuh di-modify value-nya. Yaudah aja langsung function-nya aja. Jadi gini si `a.go` sama `main.go`-nya.


```go
// a.go
package packageA

func SomeFunc() (int32) {
    return 46692016
}

// main.go
package main

import (
    "packageA"
    "fmt"
)

func main() {
    angka := packageA.SomeFunc()
    fmt.Println(angka)
}
```



## With `New()`

Anggaplah kita punya `b.go` dari `packageB`. Terus di `b.go` ini ada struct atau class `B` yang ngurusin soal storage misalnya. Misal kaya gini.

```go
package packageB

type B struct {
    internalStorage map[string]interface{}
}

func (b *B) Add(key string, value interface{}) (bool) {
    if b.ContainsKey(key) {
        return false
    }

    b.internalStorage[key] = value
    return true
}

func (b *B) Get(key string) (interface{}) {
    if !b.ContainsKey(key) {
        return nil
    }

    return b.internalStorage[key]
}

func (b *B) ContainsKey(key string) (bool) {
    _, ok := b.internalStorage[key]
    return ok
}
```

Dipanggillah dari `main.go` kaya gini

```go
package main

import (
    "packageB"
    "fmt"
)

type temp struct {
    TempPropA string
    TempPropB int
}

func main() {
    b := packageB.B{}
    _ = b.Add("temp", &temp {
        TempPropA: "hello",
        TempPropB: 8,
    })
}
```

jeng jeng jeng jeng, error

```go
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
panic: assignment to entry in nil map

goroutine 1 [running]:
main.(*B).Add(...)
        D:/Workspace/code/AskScratchpad/GolangScratchpad/main.go:77
main.main()
        D:/Workspace/code/AskScratchpad/GolangScratchpad/main.go:50 +0x86
exit status 2
PS D:\Workspace\code\AskScratchpad\GolangScratchpad>
```

Karena di `b.go` si dictionary/map-nya belom di-initialized. Biasanya di C#, Java, yang OOP-nya kentel banget, semua object, property, atau field yang dibutuhin suatu class bakal di-initialized di constructor. Tapi kan di Golang gadak constructor. Makanya biasanya di beberapa project OSS (Open-source software), ada function specific buat nge-initialize suatu class/struct. Yaitu `New()` biasanya juga `New()` ini suka nerima parameter config biar sekalian initialize object sekalian juga terima config dari luar.

Berarti `b.go` jadi gini

```go
package packageB

type B struct {
    internalStorage map[string]interface{}
}

func New() *B {
    return &B {
        internalStorage: make(map[string]interface{}),
    }
}

func (b *B) Add(key string, value interface{}) (bool) {
    if b.ContainsKey(key) {
        return false
    }

    b.internalStorage[key] = value
    return true
}

func (b *B) Get(key string) (interface{}) {
    if !b.ContainsKey(key) {
        return nil
    }

    return b.internalStorage[key]
}

func (b *B) ContainsKey(key string) (bool) {
    _, ok := b.internalStorage[key]
    return ok
}
```

Dipanggil dari `main.go`-nya kaya gini

```go
package main

import (
    "packageB"
    "fmt"
)

type temp struct {
    TempPropA string
    TempPropB int
}

func main() {
    b := packageB.New()
    _ = b.Add("temp", &temp {
        TempPropA: "hello",
        TempPropB: 8,
    })
}
```

Gak error kan. Nah skrg buat ngebuktiin kalo `temp` object-nya ke store ke map-nya, coba kita giniin `b.go`-nya

```go
// . . . omitted . . .

func main() {
    b := packageB.New()
    keyExist := b.ContainsKey("temp")
    val := b.Get("temp")

    fmt.Println(keyExist)
    fmt.Println(val)

    _ = b.Add("temp", &temp {
        TempPropA: "hello",
        TempPropB: 8,
    })

    keyExist = b.ContainsKey("temp")
    val = b.Get("temp")

    fmt.Println(keyExist)
    fmt.Println(val)
}

// . . . omitted . . .
```

Output-nya gini

```go
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> go run main.go
false
<nil>
true
&{hello 8}
PS D:\Workspace\code\AskScratchpad\GolangScratchpad> 
```
