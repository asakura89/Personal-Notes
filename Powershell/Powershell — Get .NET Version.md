---
tags:
- Powershell
- dotNET-Version
date: 2024-02-19
---

# Get .NET Version

To determine which **.NET Framework** versions are installed on your computer, you can use a few different methods:

1. **Control Panel**:
    - Go to the **Start menu** and select **Control Panel**.
    - Click on **Programs** or **Programs and Features**.
    - Scroll down to find **Microsoft .NET Framework** entries.
    - Check the version number next to each entry (usually in the format "vX.Y.ZZZZ").

2. **PowerShell**:
    - Open **PowerShell** (you can search for it in the Start menu).
    - Type the following command and press **Enter**:
        ```
        Get-ChildItem 'HKLM:\\SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full' | Get-ItemProperty -Name Release | ForEach-Object { $_.Release }
        ```
    - The output will represent the version of **.NET Framework** installed on your machine.

3. **Registry**:
    - The version of **.NET Framework (4.5 and later)** installed on your computer is listed in the registry at:
        ```
        HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full
        ```
    - If the **Full** subkey is missing, then **.NET Framework 4.5 or above** isn't installed. The **Release** value in the registry represents the version of **.NET Framework** installed.

Remember that **.NET Framework** consists of two main components: a set of assemblies (which provide functionality for your apps) and the common language runtime (CLR) that manages and executes your app's code. You can also use community-maintained tools to detect which **.NET Framework** versions are installed. Happy coding! 🚀

Source: Conversation with Bing, 2/19/2024
(1) How to Check Microsoft .NET Framework Version - Process Street. https://www.process.st/how-to/check-microsoft-net-framework-version/.
(2) How to: Determine which .NET Framework versions are installed. https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed.
(3) How to Check the .NET Framework Version on Windows 10. https://www.howtogeek.com/731913/how-to-check-the-.net-framework-version-on-windows-10/.
(4) How to check .NET Framework version on Windows 10 and 11. https://www.windowscentral.com/how-quickly-check-net-framework-version-windows-10.
(5) null. https://github.com/jmalarcon/DotNetVersions.
(6) null. https://github.com/EliteLoser/DotNetVersionLister.