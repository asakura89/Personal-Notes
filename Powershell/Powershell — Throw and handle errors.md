---
tags:
- Powershell
- Handle-Errors
- Errors
- Error
date: 2020-10-27
---

# Throw and handle errors

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