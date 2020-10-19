$ModulesDirectory = "c:\Program Files\WindowsPowerShell\Modules\Sifon"
$sourceFolder = split-path -parent $MyInvocation.MyCommand.Definition
$psd1 = "$sourceFolder\Sifon.psd1"

$manifest = @{
	Path 			    = $psd1
	Author 			    = 'Martin Miles'
	CompanyName 		= 'Perfecta Ltd'
	Copyright 		    = '(c)2020 Martin Miles. All rights reserved.'
	Description 		= '09addons module contains useful Add-ons to Windows PowerShell ISE'
	GUID 			    = 'e382b374-6ffb-4ae7-9b40-0f99518640ad'
	ModuleVersion 		= '0.99'
	PowerShellVersion 	= '5.1'
	FunctionsToExport 	= 'Copy-FileToRemote','Download-Resource','Get-ConnectionString','Get-InstanceUrl','Get-SiteFolder','Install-SitecorePackage','Install-SitecorePackageUsingRemoting','Verify-PortalCredentials','Get-SiteBindings','Get-SitecoreSites','Get-Databases','Get-CommerceDatabases','Test-PortalCredentials'
	ReleaseNotes 		= 'Accompanies Sifon. You may obtain your copy from https://Sifon.UK'
	RootModule 		    = 'Sifon.psm1'
}
New-ModuleManifest @manifest

New-Item -ItemType Directory -Path $ModulesDirectory -force
Get-ChildItem -Path $ModulesDirectory -Include * -File -Recurse | foreach { $_.Delete()}
Copy-Item -Path "$sourceFolder\*" -Destination $ModulesDirectory -Recurse