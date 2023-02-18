---
tags:
- Powershell
- WPF
- App
date: 2023-06-22
---

# WPF App

## Creating Window

```powershell
Add-Type -AssemblyName PresentationFramework

$window = New-Object System.Windows.Window
$window.Title = "Hello"

$app = New-Object System.Windows.Application 
$app.Run($window)

[void]$window.ShowDialog()
```

Ternyata `$app.Run($window)` dan `[void]$window.ShowDialog()` punya fungsi yang sama, sama-sama bisa nampilin window dialog. Terus kalo run script ini di Powershell ISE, gakkan bisa create instance Application lagi (Application punya WPF App). Jadi script-nya bakal error. Karena Powershell ISE udah create instance-nya dan gak bisa create 2 Application instance di dalem 1 AppDomain.

Ini error-nya.

```powershell
New-Object : Exception calling ".ctor" with "0" argument(s): "Cannot create more than one 
System.Windows.Application instance in the same AppDomain."
```

Cek disini [\[Link\]](Powershell%20%E2%80%94%20Powershell%20ISE.md) buat ngecek script ini jalan di Powershell ISE atau bukan.

Jadi kalo mau run WPF App bisa gini.

```powershell
Clear-Host

Add-Type -AssemblyName PresentationFramework

$window = New-Object System.Windows.Window
$window.Title = "Hello"

If ($psISE -Eq $null) {
    $app = New-Object System.Windows.Application 
    $app.Run($window)
}
Else {
    [void]$window.ShowDialog()
}
```

Terus yang paling penting, kalo udah nge-run di 1 console. Jangan re-use console-nya buat bikin WPF App lagi. Jadinya error karena Application instance-nya masih ada di session itu. Sama di Powershell ISE, kadang kalo beberapa kali di-reuse, jadi nge-crash. Gatau kenapa, karena harusnya gak modify Application instance.