---
tags:
- Golang
date: 2023-12-24
---

# Read File

> ❗ Note
> 
> go version = 1.21.0

`simplid.go`

```go
package main

import (
    "strings"
    "time"
)

func GenerateSimpleUniqueId() string {
    now := time.Now()
    time1 := strings.Split(now.Format("20060102150405.000000000"), ".")
    time2 := strings.Split(now.Format("0102150405.0000"), ".")
    allParts := time1[0] + time1[1] + time2[0] + time2[1]
    allParts = allParts[:32]

    return allParts
}
```

`main.go`

```go
package main

import (
    "fmt"
)

func main() {
    generated := GenerateSimpleUniqueId()
    fmt.Println(generated)
    fmt.Println(len(generated))
}
```

Output-nya

```go
20231224231136284124000122423113
32
```