---
tags:
- Golang
date: 2023-12-24
---

# Read File

> ❗ Note
> 
> go version = 1.21.0

`logthis.go`

```go
package main

import (
    "fmt"
    "os"
    "path/filepath"
    "time"
    "strings"
    "errors"
)

func getAppInfo() (string, string, error) {
    app, err := os.Executable()
    if err != nil {
        return "", "", err
    }

    absPath, err := filepath.Abs(app)
    if err != nil {
        return "", "", err
    }

    dir := filepath.Dir(absPath)
    name := filepath.Base(absPath)

    return dir, name, nil
}

func preprocessLog(message string) (string, string, error) {
    dir, name, err := getAppInfo()
    if err != nil {
        return "", "", err
    }

    if name == "" {
        return "", "", errors.New("There's problem in determining app name")
    }

    now := time.Now()
    name = strings.Trim(name, ".exe")
    logname := fmt.Sprintf("%s_%s.log", name, now.Format("200601021504"))
    logfile := filepath.Join(dir, logname)
    logmsg := fmt.Sprintf("[%s] %s\n", now.Format("2006.01.02.15:04:05"), message)

    return logfile, logmsg, nil
}

func StartLogThis(message string, writeToScreen bool) {
    logfile, logmsg, err := preprocessLog(message)
    if err != nil {
        fmt.Print(err)
        return
    }

    if writeToScreen {
        fmt.Print(logmsg)
    }

    err = os.WriteFile(logfile, []byte(logmsg), 0644)
    if err != nil {
        fmt.Print(err)
        return
    }
}

func LogThisNext(message string, writeToScreen bool) {
    logfile, logmsg, err := preprocessLog(message)
    if err != nil {
        fmt.Print(err)
        return
    }

    if writeToScreen {
        fmt.Print(logmsg)
    }

    file, err := os.OpenFile(logfile, os.O_APPEND|os.O_CREATE|os.O_WRONLY, 0644)
    if err != nil {
        fmt.Print(err)
        return
    }

    defer file.Close()
    _, err = file.WriteString(logmsg)
    if err != nil {
        fmt.Print(err)
        return
    }
}
```

`main.go`

```go
package main

func main() {
    StartLogThis("``:: Start Script ::'", true)
    LogThisNext("Doing something ...", true)
    LogThisNext("Doing another thing ...", true)
    LogThisNext(".:: Finish Script ::.", true)
}
```

Output-nya

```go
[2023.12.24.20:24:26] ``:: Start Script ::'
[2023.12.24.20:24:26] Doing something ...
[2023.12.24.20:24:26] Doing another thing ...
[2023.12.24.20:24:26] .:: Finish Script ::.
```