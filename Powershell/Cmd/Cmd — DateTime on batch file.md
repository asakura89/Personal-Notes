---
tags:
- Cmd
date: 2025-07-06
---

# DateTime on batch file

```cmd
cls
@echo off
goto :start

:start
    echo ::Starting Script::

    REM /**~ Generate date time ~*/
    REM /**~ Be aware that `wmic` command is deprecated, ~*/
    REM /**~ but I hate combining batch command with powershell 😔 ~*/
    for /f "skip=1 tokens=1" %%x in ('wmic os get localdatetime') do if not defined ldt set ldt=%%x
    echo localdatetime: %ldt%

    REM /**~ Split the date ~*/
    set year=%ldt:~0,4%
    set month=%ldt:~4,2%
    set day=%ldt:~6,2%

    echo year: %year%, month: %month%, day: %day%

    REM /**~ Split the time ~*/
    set hour=%ldt:~8,2%
    set minute=%ldt:~10,2%
    set second=%ldt:~12,2%

    echo hour: %hour%, minute: %minute%, second: %second%

    REM /**~ Date and Timestamp ~*/
    set datestr=%year%%month%%day%
    set timestamp=%hour%%minute%%second%

    echo datestring: %datestr%
    echo timestamp: %timestamp%

    REM /**~ Combine all together ~*/
    set filename=%datestr%_%timestamp%_snapshot.json

    echo filename: %filename%

    goto :exit

:exit
    echo ::Script Done::
```

Output

```cmd
::Starting Script::
localdatetime: 20250706003943.377000+420
year: 2025, month: 07, day: 06
hour: 00, minute: 39, second: 43
datestring: 20250706
timestamp: 003943
filename: 20250706_003943_snapshot.json
::Script Done::
```
