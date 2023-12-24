---
tags:
- Golang
date: 2023-12-24
---

# Read File

> ❗ Note
> 
> go version = 1.21.0

```go
package main

import (
    "encoding/hex"
    "fmt"
    "strings"
    "time"
)

func main() {
    now := time.Now()
    parts := strings.Split(now.Format("2006 01 02 15 04 05 .000000000"), " ")
    for _, val := range parts {
        fmt.Println(val)
        b := []byte(val)
        fmt.Println(b)
        fmt.Println(hex.EncodeToString(b))
    }

    fmt.Println(hex.EncodeToString([]byte("real string")))
}
```

Output-nya

```go
2023
[50 48 50 51]
32303233
12
[49 50]
3132
24
[50 52]
3234
23
[50 51]
3233
07
[48 55]
3037
48
[52 56]
3438
.785842800
[46 55 56 53 56 52 50 56 48 48]
2e373835383432383030
7265616c20737472696e67
```