Set-StrictMode -Version 2.0
#Requires -RunAsAdministrator
#Requires -Modules WebAdministration

$path = (split-path $MyInvocation.MyCommand.Path) 
$loggerPath = $path + "\Dummy-Function.ps1"
. $loggerPath
$getInstance = $path + "\Get-InstanceUrl.ps1"
. $getInstance
