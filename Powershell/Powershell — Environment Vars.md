---
tags:
- Powershell
date: 2023-12-22
---

# Environment Vars

```powershell
Clear-Host

$filename = "b.txt"

"## Env Vars" | Out-File -Encoding "UTF8" -FilePath $filename
"  " | Add-Content -Encoding "UTF8" -Path $filename
"1. Machine" | Add-Content -Encoding "UTF8" -Path $filename
$envVars = [Environment]::GetEnvironmentVariables("Machine")
foreach ($var in $envVars.Keys) {
    "$var => $($envVars[$var])" | Add-Content -Encoding "UTF8" -Path $filename
}
"  " | Add-Content -Encoding "UTF8" -Path $filename

"2. User" | Add-Content -Encoding "UTF8" -Path $filename
$envVars = [Environment]::GetEnvironmentVariables("User")
foreach ($var in $envVars.Keys) {
    "$var => $($envVars[$var])" | Add-Content -Encoding "UTF8" -Path $filename
}
"  " | Add-Content -Encoding "UTF8" -Path $filename

"3. Process" | Add-Content -Encoding "UTF8" -Path $filename
$envVars = [Environment]::GetEnvironmentVariables("Process")
foreach ($var in $envVars.Keys) {
    "$var => $($envVars[$var])" | Add-Content -Encoding "UTF8" -Path $filename
}
"  " | Add-Content -Encoding "UTF8" -Path $filename
```

Code-nya ampas bat sumpah 🤣
Biarin dah yang penting jalan

