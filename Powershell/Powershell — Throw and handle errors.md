---
tags:
- Powershell
- Handle-Errors
- Errors
- Error
date: 2020-10-27
---

# Throw and handle errors

## Simple

```powershell
Clear-Host

function Log($message) {
    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    Write-Host $logmsg
}

Try {
    Try {
        Throw New-Object System.InvalidOperationException("yaharo")
    }
    Catch {
        Log $("Exception thrown: `n" + `
            $_.Exception.ItemName + " `n" + `
            $_.Exception.Message + " `n" + `
            $_.Exception.StackTrace)

        Throw
    }

    Try {
        Write-Error -Message "yaharo" -ErrorAction Stop
    }
    Catch {
        Log $("Error written: `n" + `
            $_.Exception.ItemName + " `n" + `
            $_.Exception.Message + " `n" + `
            $_.Exception.StackTrace)

        Throw
    }
}
Catch {
    Log $("Error caught: `n" + `
        $_.Exception.ItemName + " `n" + `
        $_.Exception.Message + " `n" + `
        $_.Exception.StackTrace)
}
```

Contoh hasil run

```powershell
[2023.05.31.16:56:24] Exception thrown: 
 
yaharo 

[2023.05.31.16:56:24] Error caught: 
 
yaharo 

```



## Advance

```powershell
Clear-Host

function Log($message) {
    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    Write-Host $logmsg
}

function GetExceptionMessage([System.Exception]$ex) {
    $errorList = New-Object System.Text.StringBuilder
    [System.Exception]$current = $ex;
    While ($current -Ne $null) {
        [void]$errorList.AppendLine()
        [void]$errorList.AppendLine("Exception: $($current.GetType().FullName)")
        [void]$errorList.AppendLine("Message: $($current.Message)")
        [void]$errorList.AppendLine("Source: $($current.Source)")
        [void]$errorList.AppendLine($current.StackTrace)
        [void]$errorList.AppendLine()

        $current = $current.InnerException
    }

    Return $errorList.ToString()
}

Try {
    Try {
        Throw New-Object System.InvalidOperationException("yaharo")
    }
    Catch {
        Log $( `
            "Exception thrown: `n" + `
            $(GetExceptionMessage $_.Exception) `
        )

        Throw
    }

    Try {
        Write-Error -Message "yaharo" -ErrorAction Stop
    }
    Catch {
        Log $( `
            "Error written: `n" + `
            $(GetExceptionMessage $_.Exception) `
        )

        Throw
    }
}
Catch {
    Log $( `
        "Error caught: `n" + `
        $(GetExceptionMessage $_.Exception) `
    )
}

Try {
    Log "Get-ExceptionMessage test start."
    Invoke-WebRequest -Method "GET" "https://fake.webaddress.com/"
}
Catch {
    Log "$(GetExceptionMessage $_.Exception)"
}
Finally {
    Log "Get-ExceptionMessage test finish."
}
```

Contoh hasil run

```powershell
[2023.12.03.13:23:32] Exception thrown: 

Exception: System.InvalidOperationException
Message: yaharo
Source: 



[2023.12.03.13:23:32] Error caught: 

Exception: System.InvalidOperationException
Message: yaharo
Source: 



[2023.12.03.13:23:32] Get-ExceptionMessage test start.
[2023.12.03.13:23:33] 
Exception: System.Net.WebException
Message: The request was aborted: Could not create SSL/TLS secure channel.
Source: Microsoft.PowerShell.Commands.Utility
   at Microsoft.PowerShell.Commands.WebRequestPSCmdlet.GetResponse(WebRequest request)
   at Microsoft.PowerShell.Commands.WebRequestPSCmdlet.ProcessRecord()


[2023.12.03.13:23:33] Get-ExceptionMessage test finish.
```