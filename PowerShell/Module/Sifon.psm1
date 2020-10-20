Set-StrictMode -Version 2.0
#Requires -RunAsAdministrator
#Requires -Modules WebAdministration

$path = (split-path $MyInvocation.MyCommand.Path) 

$getInstance = $path + "\Copy-FileToRemote.ps1"
. $getInstance

$getInstance = $path + "\Download-Resource.ps1"
. $getInstance

$getInstance = $path + "\Get-ConnectionString.ps1"
. $getInstance

$getInstance = $path + "\Get-InstanceUrl.ps1"
. $getInstance

$getInstance = $path + "\Get-SiteFolder.ps1"
. $getInstance

$getInstance = $path + "\Install-SitecorePackage.ps1"
. $getInstance

$getInstance = $path + "\Install-SitecorePackageUsingRemoting.ps1"
. $getInstance

$getInstance = $path + "\Verify-PortalCredentials.ps1"
. $getInstance

$getInstance = $path + "\Get-SiteBindings.ps1"
. $getInstance

$getInstance = $path + "\Get-SitecoreSites.ps1"
. $getInstance

$getInstance = $path + "\Get-Databases.ps1"
. $getInstance

$getInstance = $path + "\Get-CommerceDatabases.ps1"
. $getInstance

$getInstance = $path + "\Test-PortalCredentials.ps1"
. $getInstance

$getInstance = $path + "\Test-SqlServerConnection.ps1"
. $getInstance

$getInstance = $path + "\Extract-BackupInfo.ps1"
. $getInstance

$getInstance = $path + "\Save-BackupInfo.ps1"
. $getInstance

$getInstance = $path + "\Find-SolrInstances.ps1"
. $getInstance

$getInstance = $path + "\Test-SolrEndpoint.ps1"
. $getInstance

$getInstance = $path + "\Get-Drives.ps1"
. $getInstance

$getInstance = $path + "\Get-Files.ps1"
. $getInstance

$getInstance = $path + "\Get-HashMD5.ps1"
. $getInstance
