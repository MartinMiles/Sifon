Set-StrictMode -Version 2.0
#Requires -RunAsAdministrator
#Requires -Modules WebAdministration

$path = (split-path $MyInvocation.MyCommand.Path) 
$getInstance = $path + "\Get-InstanceUrl.ps1"
. $getInstance
$getInstance = $path + "\Install-SitecorePackage.ps1"
. $getInstance
