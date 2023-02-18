---
tags:
- Golang
date: 2024-04-21
---

# Random Number

> ❗ Note
> 
> go version = 1.21.0

`ryang\ryandom_number_generator.go`

```go
package ryang

import (
    "math/rand"
    "time"
)

const feigenbaum = 46692016

func Ryandomize(lowerBound, upperBound int32) int32 {
    seed := time.Now().UnixNano() % feigenbaum
    rnd := rand.New(rand.NewSource(seed))
    return lowerBound + rnd.Int31n(upperBound-lowerBound)
}

func RyandomizeUpperBound(upperBound int32) int32 {
    return Ryandomize(0, upperBound)
}
```

semenjak go 1.11, semua lib harus dijadiin module. gak bisa di-refer pake relative path lagi. jadi ini mesti define `go.mod`

`ryan\go.mod`

```go
module askscratchpad/golang/ryang

go 1.21.0

```

ini `main.go` yang manggil generator-nya

```go
package main

import (
    "askscratchpad/golang/ryang"
    "fmt"
)

func main() {
    fmt.Println(ryang.Ryandomize(5, 10))
    fmt.Println(ryang.RyandomizeUpperBound(10))
}
```

ini `go.mod` buat main

```go
module askscratchpad/golang

go 1.21.0

require askscratchpad/golang/ryang v1.0.0

replace askscratchpad/golang/ryang => ./ryang

```

jangan luppa `go build` dulu di semua folder module. berarti di kasus ini di folder `ryang`.


