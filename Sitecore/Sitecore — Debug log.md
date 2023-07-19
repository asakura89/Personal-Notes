---
tags:
- Sitecore
date: 2022-11-28
---

# Sitecore Debug log

Lokasi-lokasi file config untuk debug log di Sitecore 9.1 XP.



## Sitecore Content Management dan Sitecore Reporting

1. `<site_root>/App_Config/Sitecore.config`  
    `conversionPattern` dari tiap-tiap `appender` bawaannya gak di-setup dengan parameter nama class. Jadi harus ditambahin sendiri.
    
    ```c#
    // bawaannya
    %4t %d{ABSOLUTE} %-5p %m%n
    
    // di-update jadi
    %4t %d{ABSOLUTE} %-5p [%c] %m%n
    ```
    
    Karena Sitecore pake log4net, jadi bisa di-configure sebagaimana log4net biasanya. Misalnya `level` tiap-tiap `logger` yang tadinya `INFO` bisa diganti jadi `DEBUG`.
    
    Atau kalo memang pengen langsung seluruh system Sitecore yang mau dinyalain debug log-nya, bisa dari `priority` dari `root` di-update jadi `DEBUG`.

2. `<site_root>\App_Config\Sitecore\CMS.Core\Sitecore.JSNLog.config`
3. `<site_root>\App_Config\Sitecore\ContentSearch\Sitecore.ContentSearch.config`
4. `<site_root>\App_Config\Sitecore\EmailExperience\Sitecore.EDS.Core.config`
5. `<site_root>\App_Config\Sitecore\EmailExperience\Sitecore.EmailExperience.Core.config`
6. `<site_root>\App_Config\Sitecore\EmailExperience\Sitecore.ExM.Framework.config`
    Beda sama log4net config, yang ini nge-update `EXM.Debug` jadi `true`.

7. `<site_root>\App_Config\Sitecore\ExperienceContentManagement.Administration\Sitecore.ExperienceContentManagement.Administration.config`
8. `<site_root>\App_Config\Sitecore\FederatedExperienceManager\Sitecore.FXM.config`
9. `<site_root>\App_Config\Sitecore\Marketing.xDB\Sitecore.Analytics.Processing.Aggregation.config`
10. `<site_root>\App_Config\Sitecore\Marketing.xDB\Sitecore.Xdb.Processing.ContactMerge.config`
11. `<site_root>\App_Config\Sitecore\Owin\Sitecore.Owin.config`



## Sitecore Cortex Processing

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`
    Karena instance Cortex Processing ini pake Serilog, config yang di-update pun beda. `Default` dari `MinimumLevel` di-update dari `Information` ke `Debug`.

2. `<site_root>\App_Data\jobs\continuous\ProcessingEngine\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`



## Sitecore Cortex Reporting

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`



## Sitecore Identity Server

1. `<site_root>\sitecorehost.xml`
    Identity Server juga pake Serilog kaya Sitecore Cortex



## Sitecore xConnect Collection

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`



## Sitecore xConnect Collection Search

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`
2. `<site_root>\App_Data\jobs\continuous\IndexWorker\App_data\config\sitecore\CoreServices\sc.Serilog.xml`



## Sitecore xConnect Marketing Automation

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`
2. `<site_root>\App_Data\jobs\continuous\AutomationEngine\App_Data\Config\sitecore\CoreServices\sc.Serilog.xml`



## Sitecore xConnect Marketing Automation Reporting

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`



## Sitecore xConnect Reference Data

1. `<site_root>\App_Data\Config\Sitecore\CoreServices\sc.Serilog.xml`