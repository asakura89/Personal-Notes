---
tags:
- CSharp
- C#
date: 2023-09-06
---

# Nuget package copy to bin

By default, .NET (tested di .NET 6 dan .NET 7) gak nge-copy Nuget package ke bin folder. Nuget package di refer lewat file *.deps.json. Buat beberapa logic yang butuh load dynamic dll, ini gak bakalan bisa works. Tapi ada cara buat nge-force Nuget package ini jadi bisa di output-in ke bin folder. Pake config `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>` taro di .prj file.

Ini contoh .prj file yang udah ditambahin config CopyLocal-nya.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <!-- config-nya ditaro di bawah `TargetFramework` -->
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies> 
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="DotNetZip" Version="1.16.0" />
  </ItemGroup>
</Project>
```



**References:**

- [PackageReference assembly is not included in the bin dir of a .NET standard project · Issue #747 · dotnet/sdk · GitHub](https://github.com/dotnet/sdk/issues/747#issuecomment-518156718)
