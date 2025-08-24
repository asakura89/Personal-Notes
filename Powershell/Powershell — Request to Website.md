---
tags:
- Powershell
date: 2023-12-03
---

# Request to Website

```powershell
Clear-Host

#:< Logging >:#
function GetScriptInfo() {
    $workingpath = $null
    If ($PSCommandPath -Eq [System.String]::Empty) {
        # Note: $PSCommandPath will be empty string if it is not ran from script file
        $workingpath = (Get-Item -Path .)
    }
    Else {
        $workingpath = (Get-Item $PSCommandPath)
    }

    If ($workingpath -Eq $null) {
        Return @{
            Name = $null
            FullName = $null
            Directory = $null
        }
    }

    If ($workingpath -Is [System.IO.DirectoryInfo]) {
        Return @{
            Name = $workingpath.BaseName
            FullName = $workingpath.Name
            Directory = $workingpath
        }
    }

    Return @{
        Name = $workingpath.BaseName
        FullName = $workingpath.Name
        Directory = $workingpath.Directory
    }
}

function Log($message, $starting = $false, $writeToScreen = $true) {
    $workingpath = GetScriptInfo
    If ($workingpath.Name -Ne $null) {
        $logname = "$($workingpath.Name)_$([System.DateTime]::Now.ToString("yyyyMMddHHmm")).log"
        $logfile = [System.IO.Path]::Combine($($workingpath.Directory), $logname)

        $logmsg = "[$([System.DateTime]::Now.ToString("yyyy.MM.dd.HH:mm:ss"))] $($message)"
        If ($writeToScreen) {
            Write-Host $logmsg
        }

        If ($starting) {
            $logmsg | Out-File -Encoding "UTF8" -FilePath $logfile
        }
        Else {
            $logmsg | Add-Content -Encoding "UTF8" -Path $logfile
        }
    }
}
#:< Logging End >:#

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

#:< URL Checker >:#
function Request([System.String]$url, [System.String]$httpMethod) {
    $status = 0
    $statusDesc = [System.String]::Empty
    $body = [System.String]::Empty

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

        $stream = $res.GetResponseStream()
        $reader = New-Object System.IO.StreamReader($stream)
        $body = $reader.ReadToEnd()

        $reader.Dispose()
        If ($reader -Ne $null) {
            $reader.Close()
        }
        $stream.Dispose()
        If ($stream -Ne $null) {
            $stream.Close()
        }
        $res.Dispose()
        If ($res -Ne $null) {
            $res.Close()
        }
    }
    Catch [System.Net.WebException] {
        $res = [System.Net.HttpWebResponse]$_.Exception.Response
        $status = [System.Int32]$res.StatusCode
        $statusDesc = $res.StatusDescription

        If ($res.ContentLength -Gt 0) {
            $stream = $res.GetResponseStream()
            $reader = New-Object System.IO.StreamReader($stream)
            $body = $reader.ReadToEnd()

            $reader.Dispose()
            If ($reader -Ne $null) {
                $reader.Close()
            }
            $stream.Dispose()
            If ($stream -Ne $null) {
                $stream.Close()
            }
        }

        Log $_.Exception.Message
    }
    Catch {
        Throw $_.Exception
    }

    Return [PSCustomObject]@{
        Status = $status
        StatusDesc = $statusDesc
        Body = $body
    }
}

function CheckURL([System.String[]]$urls, [System.String[]]$httpMethods) {
    $st = New-Object System.Diagnostics.Stopwatch

    ForEach ($url In $urls) {
        ForEach ($httpMethod In $httpMethods) {
            Log "$($httpMethod) - $($url)"
            Try {
                $st.Start()
                $res = Request $url $httpMethod
                $st.Stop()

                Log "Status Code: $($res.Status), Status: $($res.StatusDesc)"
                Log "Request took $($st.Elapsed.TotalMilliseconds.ToString()) ms"
                $st.Reset()

                $contentType = "unknown"
                If ($res.Body.TrimStart().StartsWith("{") -Or $res.Body.TrimStart().StartsWith("[")) {
                    $contentType = "json"
                }
                ElseIf ($res.Body.TrimStart().StartsWith("<")) {
                    $contentType = "html"
                }

                Log "$($contentType) detected"
            }
            Catch {
                Log "$(GetExceptionMessage $_.Exception)"
            }
        }
    }
}
#:< URL Checker End >:#

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

    CheckURL $urls $httpMethods
}

Log "#:< Script Start >:#"
Run
Log "#:< Script Done >:#"
```

Output-nya

```powershell
[2023.12.03.18:38:22] #:< Script Start >:#
[2023.12.03.18:38:22] GET - https://localsite.net
[2023.12.03.18:38:22] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:22] Status Code: 0, Status: 
[2023.12.03.18:38:22] Request took 127.7892 ms
[2023.12.03.18:38:22] unknown detected
[2023.12.03.18:38:22] HEAD - https://localsite.net
[2023.12.03.18:38:22] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:22] Status Code: 0, Status: 
[2023.12.03.18:38:22] Request took 116.4427 ms
[2023.12.03.18:38:22] unknown detected
[2023.12.03.18:38:22] POST - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 105.9538 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] PUT - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 112.5436 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] DELETE - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 114.0425 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] TRACE - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 114.1989 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] CONNECT - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 132.3082 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] OPTIONS - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 125.5541 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] MERGE - https://localsite.net
[2023.12.03.18:38:23] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:23] Status Code: 0, Status: 
[2023.12.03.18:38:23] Request took 127.4621 ms
[2023.12.03.18:38:23] unknown detected
[2023.12.03.18:38:23] PATCH - https://localsite.net
[2023.12.03.18:38:24] The underlying connection was closed: An unexpected error occurred on a send.
[2023.12.03.18:38:24] Status Code: 0, Status: 
[2023.12.03.18:38:24] Request took 119.398 ms
[2023.12.03.18:38:24] unknown detected
[2023.12.03.18:38:24] GET - https://google.com
[2023.12.03.18:38:24] Status Code: 200, Status: OK
[2023.12.03.18:38:24] Request took 284.8302 ms
[2023.12.03.18:38:24] html detected
[2023.12.03.18:38:24] HEAD - https://google.com
[2023.12.03.18:38:24] Status Code: 200, Status: OK
[2023.12.03.18:38:24] Request took 144.0022 ms
[2023.12.03.18:38:24] unknown detected
[2023.12.03.18:38:24] POST - https://google.com
[2023.12.03.18:38:24] The remote server returned an error: (411) Length Required.
[2023.12.03.18:38:24] Status Code: 411, Status: Length Required
[2023.12.03.18:38:24] Request took 150.1959 ms
[2023.12.03.18:38:24] html detected
[2023.12.03.18:38:24] PUT - https://google.com
[2023.12.03.18:38:24] The remote server returned an error: (411) Length Required.
[2023.12.03.18:38:24] Status Code: 411, Status: Length Required
[2023.12.03.18:38:24] Request took 194.4663 ms
[2023.12.03.18:38:24] html detected
[2023.12.03.18:38:24] DELETE - https://google.com
[2023.12.03.18:38:25] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:25] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:25] Request took 190.5545 ms
[2023.12.03.18:38:25] html detected
[2023.12.03.18:38:25] TRACE - https://google.com
[2023.12.03.18:38:25] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:25] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:25] Request took 191.2947 ms
[2023.12.03.18:38:25] html detected
[2023.12.03.18:38:25] CONNECT - https://google.com
[2023.12.03.18:38:25] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:25] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:25] Request took 182.0531 ms
[2023.12.03.18:38:25] html detected
[2023.12.03.18:38:25] OPTIONS - https://google.com
[2023.12.03.18:38:25] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:25] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:25] Request took 202.215 ms
[2023.12.03.18:38:25] html detected
[2023.12.03.18:38:25] MERGE - https://google.com
[2023.12.03.18:38:26] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:26] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:26] Request took 190.9691 ms
[2023.12.03.18:38:26] html detected
[2023.12.03.18:38:26] PATCH - https://google.com
[2023.12.03.18:38:26] The remote server returned an error: (405) Method Not Allowed.
[2023.12.03.18:38:26] Status Code: 405, Status: Method Not Allowed
[2023.12.03.18:38:26] Request took 203.9226 ms
[2023.12.03.18:38:26] html detected
[2023.12.03.18:38:26] GET - https://bing.com
[2023.12.03.18:38:26] Status Code: 200, Status: OK
[2023.12.03.18:38:26] Request took 414.6216 ms
[2023.12.03.18:38:26] html detected
[2023.12.03.18:38:26] HEAD - https://bing.com
[2023.12.03.18:38:26] Status Code: 200, Status: OK
[2023.12.03.18:38:26] Request took 247.0313 ms
[2023.12.03.18:38:26] unknown detected
[2023.12.03.18:38:26] POST - https://bing.com
[2023.12.03.18:38:27] The remote server returned an error: (411) Length Required.
[2023.12.03.18:38:27] Status Code: 411, Status: Length Required
[2023.12.03.18:38:27] Request took 35.6771 ms
[2023.12.03.18:38:27] html detected
[2023.12.03.18:38:27] PUT - https://bing.com
[2023.12.03.18:38:27] The remote server returned an error: (411) Length Required.
[2023.12.03.18:38:27] Status Code: 411, Status: Length Required
[2023.12.03.18:38:27] Request took 105.5036 ms
[2023.12.03.18:38:27] html detected
[2023.12.03.18:38:27] DELETE - https://bing.com
[2023.12.03.18:38:27] Status Code: 200, Status: OK
[2023.12.03.18:38:27] Request took 344.538 ms
[2023.12.03.18:38:27] html detected
[2023.12.03.18:38:27] TRACE - https://bing.com
[2023.12.03.18:38:27] The remote server returned an error: (403) Forbidden.
[2023.12.03.18:38:27] Status Code: 403, Status: Forbidden
[2023.12.03.18:38:27] Request took 107.8149 ms
[2023.12.03.18:38:27] html detected
[2023.12.03.18:38:27] CONNECT - https://bing.com
[2023.12.03.18:38:27] The remote server returned an error: (400) Bad Request.
[2023.12.03.18:38:27] Status Code: 400, Status: Bad Request
[2023.12.03.18:38:27] Request took 26.422 ms
[2023.12.03.18:38:27] html detected
[2023.12.03.18:38:27] OPTIONS - https://bing.com
[2023.12.03.18:38:28] Status Code: 200, Status: OK
[2023.12.03.18:38:28] Request took 745.6624 ms
[2023.12.03.18:38:28] html detected
[2023.12.03.18:38:28] MERGE - https://bing.com
[2023.12.03.18:38:28] The remote server returned an error: (400) Bad Request.
[2023.12.03.18:38:28] Status Code: 400, Status: Bad Request
[2023.12.03.18:38:28] Request took 143.2399 ms
[2023.12.03.18:38:28] html detected
[2023.12.03.18:38:28] PATCH - https://bing.com
[2023.12.03.18:38:28] The remote server returned an error: (411) Length Required.
[2023.12.03.18:38:28] Status Code: 411, Status: Length Required
[2023.12.03.18:38:28] Request took 176.5582 ms
[2023.12.03.18:38:28] html detected
[2023.12.03.18:38:28] #:< Script Done >:#
```
