---
tags:
- Powershell
date: 2023-12-03
---

# Request to Website

```powershell
Clear-Host

#:< Exception Helper >:#
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
#:< Exception Helper End >:#

#:< Logging >:#
function Log($message) {
    $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
    Write-Host $logmsg
}
#:< Logging End >:#

function Request([System.String]$url, [System.String]$httpMethod) {
    $status = 0
    $statusDesc = [System.String]::Empty
    Try {
        $req = [System.Net.WebRequest]::Create($url) -As [System.Net.HttpWebRequest]
        $req.Method = $httpMethod
        If ($url.Contains("https")) {
            # .Net issue. Need to force it to TLS1.2.
            [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12
        }

        [System.Net.HttpWebRequest]::DefaultCachePolicy = New-Object System.Net.Cache.HttpRequestCachePolicy([System.Net.Cache.HttpRequestCacheLevel]::NoCacheNoStore)
        $res = [System.Net.HttpWebResponse]$req.GetResponse()
        $status = [System.Int32]$res.StatusCode
        $statusDesc = $res.StatusDescription
        $res.Dispose()
        If ($res -Ne $null) {
            $es.Close()
        }
    }
    Catch [System.Net.WebException] {
        $res = [System.Net.HttpWebResponse]$_.Exception.Response
        $status = [System.Int32]$res.StatusCode
        $statusDesc = $res.StatusDescription
        Log $_.Exception.Message
    }
    Catch {
        Throw $_.Exception
    }

    Return "Status Code: $($status), Status: $($statusDesc)"
}

function Run() {
    $httpMethods = @(
        "GET",
        "HEAD",
        "POST",
        "PUT",
        "DELETE",
        "TRACE",
        "CONNECT",
        "OPTIONS",
        "MERGE",
        "PATCH"
    )

    $urls = @(
        "https://localsite.net"
        "https://google.com"
        "https://bing.com"
    )

    ForEach ($url In $urls) {
        ForEach ($httpMethod In $httpMethods) {
            Log "$($httpMethod) - $($url)"
            Try {
                Log "$(Request $url $httpMethod)"
            }
            Catch {
                Log "$(GetExceptionMessage $_.Exception)"
            }
        }
    }
}

Log ":: Start Script ::"
Run
Log ":: Finish Script ::"
```

Output-nya

```powershell
[2023.12.03.14:37:44] :: Start Script ::
[2023.12.03.14:37:44] GET - https://localsite.net
[2023.12.03.14:37:45] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at System.Management.Automation.Interpreter.ActionCallInstruction`2.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)


[2023.12.03.14:37:47] HEAD - https://localsite.net
[2023.12.03.14:37:47] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at System.Management.Automation.Interpreter.ActionCallInstruction`2.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)


[2023.12.03.14:37:48] POST - https://localsite.net
[2023.12.03.14:37:49] The remote server returned an error: (411) Length Required.
[2023.12.03.14:37:49] Status Code: 411, Status: Length Required
[2023.12.03.14:37:49] PUT - https://localsite.net
[2023.12.03.14:37:49] The remote server returned an error: (411) Length Required.
[2023.12.03.14:37:49] Status Code: 411, Status: Length Required
[2023.12.03.14:37:49] DELETE - https://localsite.net
[2023.12.03.14:37:49] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:49] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:49] TRACE - https://localsite.net
[2023.12.03.14:37:50] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:50] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:50] CONNECT - https://localsite.net
[2023.12.03.14:37:50] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:50] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:50] OPTIONS - https://localsite.net
[2023.12.03.14:37:51] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:51] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:51] MERGE - https://localsite.net
[2023.12.03.14:37:52] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:52] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:52] PATCH - https://localsite.net
[2023.12.03.14:37:52] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:52] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:52] GET - https://google.com
[2023.12.03.14:37:52] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at System.Management.Automation.Interpreter.ActionCallInstruction`2.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)


[2023.12.03.14:37:54] HEAD - https://google.com
[2023.12.03.14:37:54] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at System.Management.Automation.Interpreter.ActionCallInstruction`2.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)
   at System.Management.Automation.Interpreter.EnterTryCatchFinallyInstruction.Run(InterpretedFrame frame)


[2023.12.03.14:37:57] POST - https://google.com
[2023.12.03.14:37:57] The remote server returned an error: (411) Length Required.
[2023.12.03.14:37:57] Status Code: 411, Status: Length Required
[2023.12.03.14:37:57] PUT - https://google.com
[2023.12.03.14:37:57] The remote server returned an error: (411) Length Required.
[2023.12.03.14:37:57] Status Code: 411, Status: Length Required
[2023.12.03.14:37:57] DELETE - https://google.com
[2023.12.03.14:37:58] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:58] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:58] TRACE - https://google.com
[2023.12.03.14:37:58] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:58] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:58] CONNECT - https://google.com
[2023.12.03.14:37:58] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:58] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:58] OPTIONS - https://google.com
[2023.12.03.14:37:58] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:58] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:58] MERGE - https://google.com
[2023.12.03.14:37:59] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:59] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:59] PATCH - https://google.com
[2023.12.03.14:37:59] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.14:37:59] Status Code: 405, Status: Method Not Allowed
[2023.12.03.14:37:59] GET - https://bing.com
[2023.12.03.14:37:59] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at lambda_method(Closure , Object[] , StrongBox`1[] , InterpretedFrame )


[2023.12.03.14:38:01] HEAD - https://bing.com
[2023.12.03.14:38:01] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at lambda_method(Closure , Object[] , StrongBox`1[] , InterpretedFrame )


[2023.12.03.14:38:02] POST - https://bing.com
[2023.12.03.14:38:02] The remote server returned an error: (411) Length Required.
[2023.12.03.14:38:02] Status Code: 411, Status: Length Required
[2023.12.03.14:38:02] PUT - https://bing.com
[2023.12.03.14:38:03] The remote server returned an error: (411) Length Required.
[2023.12.03.14:38:03] Status Code: 411, Status: Length Required
[2023.12.03.14:38:03] DELETE - https://bing.com
[2023.12.03.14:38:03] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at lambda_method(Closure , Object[] , StrongBox`1[] , InterpretedFrame )


[2023.12.03.14:38:05] TRACE - https://bing.com
[2023.12.03.14:38:06] The remote server returned an error: (403) Forbidden.
[2023.12.03.14:38:06] Status Code: 403, Status: Forbidden
[2023.12.03.14:38:06] CONNECT - https://bing.com
[2023.12.03.14:38:06] The remote server returned an error: (400) Bad Request.
[2023.12.03.14:38:06] Status Code: 400, Status: Bad Request
[2023.12.03.14:38:06] OPTIONS - https://bing.com
[2023.12.03.14:38:06] 
Exception: System.Management.Automation.RuntimeException
Message: You cannot call a method on a null-valued expression.
Source: System.Management.Automation
   at System.Management.Automation.ExceptionHandlingOps.CheckActionPreference(FunctionContext funcContext, Exception exception)
   at lambda_method(Closure , Object[] , StrongBox`1[] , InterpretedFrame )


[2023.12.03.14:38:08] MERGE - https://bing.com
[2023.12.03.14:38:08] The remote server returned an error: (400) Bad Request.
[2023.12.03.14:38:08] Status Code: 400, Status: Bad Request
[2023.12.03.14:38:08] PATCH - https://bing.com
[2023.12.03.14:38:08] The remote server returned an error: (411) Length Required.
[2023.12.03.14:38:08] Status Code: 411, Status: Length Required
[2023.12.03.14:38:08] :: Finish Script ::
```
