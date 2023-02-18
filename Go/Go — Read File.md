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
    "fmt"
    "log"
    "os"
    "io"
)

func readFileAsText(filename string) (string, error) {
    file, err := os.Open(filename)
    if err != nil {
        return "", err
    }

    defer file.Close()

    contentBytes, err := io.ReadAll(file)
    // contentBytes, err := os.ReadFile(file.Name()) // bisa gini juga
    if err != nil {
        return "", err
    }

    contentText := string(contentBytes)
    return contentText, nil
}

func main() {
    filename := "D:\\Personal-Notes\\Powershell\\_media\\Load-Xml.config.xml"
    content, err := readFileAsText(filename)
    if err != nil {
        log.Fatal(err)
    }

    fmt.Println(content)
}
```

