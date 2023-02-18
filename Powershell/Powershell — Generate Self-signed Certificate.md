---
tags:
- Powershell
- Certificate
date: 2023-09-26
---

# Generate Self-signed Certificate

```powershell
$personal = New-SelfSignedCertificate `
    -Subject "*.dev.localmachine.com" `
    -DnsName "*.dev.localmachine.com" `
    -CertStoreLocation Cert:\LocalMachine\My `
    -NotAfter (Get-Date).AddYears(100) `
    -FriendlyName "*.dev.localmachine.com Self-Signed Certificate"

$clone = Get-ChildItem Cert:\LocalMachine\My | `
    Where-Object {$_.Subject -like "*.dev.localmachine.com"}

<#
$root = New-SelfSignedCertificate `
    -CloneCert $clone `
    -CertStoreLocation Cert:\LocalMachine\CA
#>
```