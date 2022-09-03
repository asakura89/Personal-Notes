---
tags:
- Snippet
- Powershell
- Env-Var
- Env
- Environment-Variable
- Environment
date: 2020-05-25
---

# Get Environment Variable

## All Environment Variable

Buat nge-list semua _env var_ bisa pake code ini
```powershell
Clear-Host
Get-ChildItem Env:*
```



Contoh hasil run
```powershell
Name                           Value                                                                                          
----                           -----                                                                                          
ProgramFiles(x86)              C:\Program Files (x86)                                                                         
DOTNET_BIN                     C:\Program Files\dotnet\                                                                       
ProgramW6432                   C:\Program Files                                                                               
ChocolateyInstall              C:\ProgramData\chocolatey                                                                      
PYTHON_BIN                     C:\Python36-32                                                                                 
ORIGINAL_JAVA_BIN              C:\Program Files (x86)\Java\jdk1.8.0_192\bin                                                   
Path                           C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot\bin;C:\Users\ASMNetworkLabUsr\AppData\Local...
PWSH                           C:\PowerShell-6.1.3-win-x64                                                                    
MS_OJDK_11                     C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot                                               
MS_OJDK_17_BIN                 C:\Program Files\Microsoft\jdk-17.0.0.35-hotspot\bin                                           
SystemRoot                     C:\WINDOWS                                                                                     
JAVA_BIN                       C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot\bin                                           
OS                             Windows_NT                                                                                     
DART_SDK                       C:\Program Files\Dart\dart-sdk                                                                 
PYTHON_SCRIPTS                 C:\Python36-32\Scripts                                                                         
CommonProgramFiles             C:\Program Files\Common Files                                                                  
SystemDrive                    C:                                                                                             
YARN_GLOBAL                    C:\Users\ASMNetworkLabUsr\AppData\Local\Yarn\bin                                               
ProgramData                    C:\ProgramData                                                                                 
GOROOT                         C:\Go\                                                                                         
HOMEPATH                       \Users\ASMNetworkLabUsr\                                                                        
MS_OJDK_17                     C:\Program Files\Microsoft\jdk-17.0.0.35-hotspot                                               
SESSIONNAME                    Console                                                                                        
DriverData                     C:\Windows\System32\Drivers\DriverData                                                         
HOMEDRIVE                      C:                                                                                             
windir                         C:\WINDOWS                                                                                     
MS_OJDK_11_BIN                 C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot\bin                                           
FLUTTER_BIN                    C:\flutter\bin                                                                                 
ERLANG_HOME                    C:\Program Files\erl10.5                                                                       
ProgramFiles                   C:\Program Files                                                                               
ComSpec                        C:\WINDOWS\system32\cmd.exe                                                                    
JAVA_HOME                      C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot\                                              
ORIGINAL_JAVA_HOME             C:\Program Files (x86)\Java\jdk1.8.0_192                                                       
MS_OJDK_16                     C:\Program Files\Microsoft\jdk-16.0.2.7-hotspot                                                
CommonProgramW6432             C:\Program Files\Common Files                                                                  
MS_OJDK_16_BIN                 C:\Program Files\Microsoft\jdk-16.0.2.7-hotspot\bin                                            
CommonProgramFiles(x86)        C:\Program Files (x86)\Common Files                                                            
DOTNET_TOOLS                   %USERPROFILE%\.dotnet\tools                                                                    
PUBLIC                         C:\Users\Public                                                                                
```



## Path

Path di _env var_ adalah hal yang paling sering dicari atau dicek. Karena kadang ada console app yang udah di-update version-nya tapi masih gak ke-update di command prompt / Powershell karena path-nya ketimpa duplikat misalnya.



Ini command buatr nge-list semua path
```powershell
Clear-Host
$Env:Path -Split ";"
```



Kalo butuh buat nyari path tertentu bisa pake `Select-String`
misal, butuh buat nyari java path
bisa pake comand ini
```powershell
Clear-Host
$Env:Path -Split ";" | Select-String "java|jdk"
```



Contoh hasil run
```powershell
C:\Program Files\Microsoft\jdk-11.0.12.7-hotspot\bin
C:\Program Files (x86)\Common Files\Oracle\Java\javapath
C:\ProgramData\Oracle\Java\javapath
```



## User Information

Selain path, sebenernya ada banyak yang lain. Kaya yang ada di section paling atas yang ini  [[Powershell — Get Environment Variable#All Environment Variable|All Environment Variable]]. Yang paling sering dibutuhin adalah informasi user yang lagi nge-run script. Mungkin bisa buat identifier dari file yang di-generate dari suatu script atau bisa jadi untuk sistem audit trail.

Buat ngambil data user-nya sendiri, bisa pake script di bawah ini
```powershell
Clear-Host

@{
    User = $Env:Username
    UserProfile = $Env:UserProfile
    AppDataRoaming = $Env:AppData
    AppDataRoaming2 = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ApplicationData)
    AppDataRoaming3 = [System.Environment]::GetFolderPath("ApplicationData")
    AppDataLocal = $Env:LocalAppData
    AppDataLocal2 = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::LocalApplicationData)
    AppDataLocal3 = [System.Environment]::GetFolderPath("LocalApplicationData")
} | 
Format-List
```



Contoh hasil run
```powershell
Name  : UserProfile
Value : C:\Users\ASMNetworkLabUsr

Name  : AppDataLocal
Value : C:\Users\ASMNetworkLabUsr\AppData\Local

Name  : AppDataRoaming
Value : C:\Users\ASMNetworkLabUsr\AppData\Roaming

Name  : User
Value : asmnetworklabusr

Name  : AppDataLocal2
Value : C:\Users\ASMNetworkLabUsr\AppData\Local

Name  : AppDataRoaming2
Value : C:\Users\ASMNetworkLabUsr\AppData\Roaming

Name  : AppDataLocal3
Value : C:\Users\ASMNetworkLabUsr\AppData\Local

Name  : AppDataRoaming3
Value : C:\Users\ASMNetworkLabUsr\AppData\Roaming
```



Contoh untuk generate file name bisa pake script di bawah
```powershell
Clear-Host

$cleanedUname = $Env:Username.
    Replace(".", "").
    Replace("-", "_")

$datetime = [System.DateTime]::Now.ToString("yyyyMMddHHmm")
$filename = "$($cleanedUname)_$($datetime)"

Write-Host $filename
```



Contoh hasil run
```powershell
asmnetworklabusr_202207111736
```