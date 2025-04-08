---
tags:
- Cmd
date: 2025-04-08
---

# Base commands

1. Clear screen with `cls`
2. Hides commands executed with `@echo off`
3. Jumps to label for easier start with `goto :label_name`
4. Sets variable to be used  later with `set variable_name=variable_value`
5. Use variable with `%variable_name%`

Misal,

```cmd
cls
@echo off
goto :start

:start
    echo Starting Script
    set feigenbaum=46692016
    echo this is feigenbaum %feigenbaum%
    goto :exit

:exit
```

Output

```cmd
Starting Script
this is feigenbaum 46692016
```
