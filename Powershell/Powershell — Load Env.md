---
tags:
- Powershell
- DotEnv
- .env
- env
- Config
date: 2024-01-20
---

# Load Env

```powershell
Clear-Host

function LoadEnv([System.String]$envContent) {
    $content = $envContent.Trim()
    If ([System.String]::IsNullOrEmpty($content)) {
        Return $null
    }

    $envData = New-Object 'System.Collections.Generic.Dictionary[System.String,System.String]'
    $pattern = "^(?<key>[a-zA-Z0-9.\-_ ]+)(?:\s*?(?:=|:)\s*?)(?<value>`"[^`"]+`"|[^#\r\n]+)"
    $options = [System.Text.RegularExpressions.RegexOptions]::Compiled `
        -Bor [System.Text.RegularExpressions.RegexOptions]::IgnoreCase `
        -Bor [System.Text.RegularExpressions.RegexOptions]::Multiline
    $regex = New-Object System.Text.RegularExpressions.Regex($pattern, $options)
    $matches = $regex.Matches($content)
    ForEach ($match In $matches) {
        If ($match.Success) {
            $key = $match.Groups["key"].Value
            If ($envData.ContainsKey($key)) {
                $envData[$key] = $match.Groups["value"].Value
            }
            Else {
                $envData.Add($key, $match.Groups["value"].Value)
            }
        }
    }

    Return $envData
}

function LoadEnvFromPath([System.String]$envPath) {
    If (-Not (Test-Path $envPath)) {
        Throw New-Object System.IO.FileNotFoundException($envPath)
    }

    $content = [System.IO.File]::ReadAllText($envPath)
    $envData = LoadEnv $content
    
    Return $envData
}

(LoadEnvFromPath "D:\Personal-Notes\Powershell\_media\Load-Env.config.env") | Format-Table
```

Isi dari `Load-Env.config.env` adalah

```env
STRIPE_API_KEY=scr_12345
TWILIO_API_KEY=abcd1234
LISTEN_ADDRESS=0.0.0.0
MONGO_HOST=mongo
MONGO_URL=mongodb://mongo/mainnode?directConnection=true
WEB_API_PASSWORD=mainnode
WEB_API_USER=mongo_main
WEB_HOST=web
email_template="<ins><strong>Reminder: ${Date}</strong></ins>
<em>Approve my PR ASAP sir!</em>"
```

Contoh hasil run

```powershell
Key              Value
---              -----
STRIPE_API_KEY   scr_12345
TWILIO_API_KEY   abcd1234
LISTEN_ADDRESS   0.0.0.0
MONGO_HOST       mongo
MONGO_URL        mongodb://mongo/mainnode?directConnection=true
WEB_API_PASSWORD mainnode
WEB_API_USER     mongo_main
WEB_HOST         web
email_template   "<ins><strong>Reminder: ${Date}</strong></ins>...
```


**References:**

- https://github.com/bkeepers/dotenv/blob/master/lib/dotenv/parser.rb