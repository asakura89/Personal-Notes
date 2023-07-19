---
tags:
- Powershell
- Command
- Powershell-Command
- PSCommand
date: 2020-04-25
---

# PSCommand

## Search PSCommand

```powershell
Clear-Host

Get-Command |
    Select-Object @{
        L="SimpleName"; `
        E={ $(`
            If ($_.CommandType -Eq "Function") { "Func" } `
            ElseIf ($_.CommandType -Eq "Cmdlet") { "CmdL" } `
            Else { "Othr" }`
        ) + ": " + $_.Name }} |
    Select-Object -ExpandProperty SimpleName |
    Sort-Object @{E={ $_ }} |
    Select-String "Item"
```

Contoh hasil run

```powershell
CmdL: Add-ADSConfigurationItemsToApplication
CmdL: Add-AzureRmDataLakeStoreItemContent
CmdL: Backup-AzureRmBackupItem
CmdL: Backup-AzureRmRecoveryServicesBackupItem
CmdL: Clear-Item
CmdL: Clear-ItemProperty
CmdL: Copy-Item
CmdL: Copy-ItemProperty
CmdL: Edit-HSMItem
CmdL: Export-AzureRmDataLakeStoreItem
CmdL: Get-AzureRmBackupItem
CmdL: Get-AzureRmDataLakeAnalyticsCatalogItem
CmdL: Get-AzureRmDataLakeStoreChildItem
CmdL: Get-AzureRmDataLakeStoreItem
CmdL: Get-AzureRmDataLakeStoreItemAclEntry
CmdL: Get-AzureRmDataLakeStoreItemContent
CmdL: Get-AzureRmDataLakeStoreItemOwner
CmdL: Get-AzureRmDataLakeStoreItemPermission
CmdL: Get-AzureRmRecoveryServicesAsrProtectableItem
CmdL: Get-AzureRmRecoveryServicesAsrReplicationProtectedItem
CmdL: Get-AzureRmRecoveryServicesBackupItem
CmdL: Get-AzureRmSiteRecoveryProtectableItem
CmdL: Get-AzureRmSiteRecoveryReplicationProtectedItem
CmdL: Get-AzureWebsiteMetric
CmdL: Get-ChildItem
CmdL: Get-ControlPanelItem
CmdL: Get-EMSDItemList
CmdL: Get-HSMItem
CmdL: Get-HSMItemList
CmdL: Get-Item
CmdL: Get-ItemProperty
CmdL: Get-ItemPropertyValue
CmdL: Get-SSMComplianceItemsList
CmdL: Get-WebItemState
CmdL: Import-AzureRmDataLakeStoreItem
CmdL: Invoke-Item
CmdL: Join-AzureRmDataLakeStoreItem
CmdL: Move-AzureRmDataLakeStoreItem
CmdL: Move-Item
CmdL: Move-ItemProperty
CmdL: New-AzureRmDataLakeStoreItem
CmdL: New-AzureRmRecoveryServicesAsrProtectableItem
CmdL: New-AzureRmRecoveryServicesAsrReplicationProtectedItem
CmdL: New-AzureRmSiteRecoveryReplicationProtectedItem
CmdL: New-HSMItem
CmdL: New-Item
CmdL: New-ItemProperty
CmdL: Remove-ADSConfigurationItemsFromApplication
CmdL: Remove-AzureRmDataLakeStoreItem
CmdL: Remove-AzureRmDataLakeStoreItemAcl
CmdL: Remove-AzureRmDataLakeStoreItemAclEntry
CmdL: Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem
CmdL: Remove-AzureRmSiteRecoveryReplicationProtectedItem
CmdL: Remove-HSMItem
CmdL: Remove-Item
CmdL: Remove-ItemProperty
CmdL: Rename-Item
CmdL: Rename-ItemProperty
CmdL: Restart-WebItem
CmdL: Restore-AzureRmBackupItem
CmdL: Restore-AzureRmRecoveryServicesBackupItem
CmdL: Set-AzureRmDataLakeStoreItemAcl
CmdL: Set-AzureRmDataLakeStoreItemAclEntry
CmdL: Set-AzureRmDataLakeStoreItemExpiry
CmdL: Set-AzureRmDataLakeStoreItemOwner
CmdL: Set-AzureRmDataLakeStoreItemPermission
CmdL: Set-AzureRmRecoveryServicesAsrReplicationProtectedItem
CmdL: Set-AzureRmSiteRecoveryReplicationProtectedItem
CmdL: Set-Item
CmdL: Set-ItemProperty
CmdL: Show-ControlPanelItem
CmdL: Start-WebItem
CmdL: Stop-WebItem
CmdL: Test-AzureRmDataLakeAnalyticsCatalogItem
CmdL: Test-AzureRmDataLakeStoreItem
CmdL: Write-SSMComplianceItem
Func: Get-DAEntryPointTableItem
Func: Get-TestDriveItem
Func: New-DAEntryPointTableItem
Func: Remove-DAEntryPointTableItem
Func: Rename-DAEntryPointTableItem
Func: Reset-DAEntryPointTableItem
Func: Set-DAEntryPointTableItem
Othr: Add-AdlStoreItemContent
Othr: Export-AdlStoreItem
Othr: Get-AdlCatalogItem
Othr: Get-AdlStoreChildItem
Othr: Get-AdlStoreItem
Othr: Get-AdlStoreItemAclEntry
Othr: Get-AdlStoreItemContent
Othr: Get-AdlStoreItemOwner
Othr: Get-AdlStoreItemPermission
Othr: Get-ASRProtectableItem
Othr: Get-ASRReplicationProtectedItem
Othr: Import-AdlStoreItem
Othr: Join-AdlStoreItem
Othr: Move-AdlStoreItem
Othr: New-AdlStoreItem
Othr: New-ASRProtectableItem
Othr: New-ASRReplicationProtectedItem
Othr: Remove-AdlStoreItem
Othr: Remove-AdlStoreItemAcl
Othr: Remove-AdlStoreItemAclEntry
Othr: Remove-ASRReplicationProtectedItem
Othr: Set-AdlStoreItemAcl
Othr: Set-AdlStoreItemAclEntry
Othr: Set-AdlStoreItemExpiry
Othr: Set-AdlStoreItemOwner
Othr: Set-AdlStoreItemPermission
Othr: Set-ASRReplicationProtectedItem
Othr: Test-AdlCatalogItem
Othr: Test-AdlStoreItem
```



## Get specific command

```powershell
Clear-Host

Get-Command |
    Select-Object @{`
        L="SimpleName"; `
        E={ $(`
            If ($_.CommandType -Eq "Function"){ "Func" } `
            ElseIf ($_.CommandType -Eq "Cmdlet") { "CmdL" } `
            Else { "Othr" }) + ": " + $_.Name }`
        } |
    Select-Object -ExpandProperty SimpleName |
    Sort-Object @{E={ $_ }} |
    Select-String '^CmdL.+(Format|Out)-.+'
```

Contoh hasil run

```powershell
CmdL: Format-Custom
CmdL: Format-List
CmdL: Format-SecureBootUEFI
CmdL: Format-Table
CmdL: Format-Wide
CmdL: Out-Default
CmdL: Out-File
CmdL: Out-GridView
CmdL: Out-Host
CmdL: Out-Null
CmdL: Out-Printer
CmdL: Out-String
```



## Top 10

```powershell
Clear-Host

Get-Command |
    Select-Object @{`
        L="SimpleName"; `
        E={ $(`
            If ($_.CommandType -Eq "Function"){ "Func" } `
            ElseIf ($_.CommandType -Eq "Cmdlet") { "CmdL" } `
            Else { "Othr" }) + ": " + $_.Name }`
        } |
    Select-Object -ExpandProperty SimpleName |
    Sort-Object @{E={ $_ }} |
    Select-Object -First 10
```

Contoh hasil run

```powershell
CmdL: Add-AASScalableTarget
CmdL: Add-ACMCertificateTag
CmdL: Add-ADSConfigurationItemsToApplication
CmdL: Add-AGResourceTag
CmdL: Add-ALXBDeviceToRoom
CmdL: Add-ALXBResourceTag
CmdL: Add-ALXBSkillGroupToRoom
CmdL: Add-AppvClientConnectionGroup
CmdL: Add-AppvClientPackage
CmdL: Add-AppvPublishingServer
```



## Top 5 Last 5

```powershell
Clear-Host

Get-Command |
    Select-Object @{`
        L="SimpleName"; `
        E={ $(`
            If ($_.CommandType -Eq "Function"){ "Func" } `
            ElseIf ($_.CommandType -Eq "Cmdlet") { "CmdL" } `
            Else { "Othr" }) + ": " + $_.Name }`
        } |
    Select-Object -ExpandProperty SimpleName |
    Sort-Object @{E={ $_ }} |
    Select-Object -First 5 -Last 5
```

Contoh hasil run

```powershell
CmdL: Add-AASScalableTarget
CmdL: Add-ACMCertificateTag
CmdL: Add-ADSConfigurationItemsToApplication
CmdL: Add-AGResourceTag
CmdL: Add-ALXBDeviceToRoom
Othr: Write-CFGEvaluations
Othr: Write-CSDDocuments
Othr: Write-CTEventSelectors
Othr: Write-CWLLogEvents
Othr: Write-FileSystemCache
```