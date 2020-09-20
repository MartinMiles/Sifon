$manifest = @{
	Path 			    = 'c:\Program Files\WindowsPowerShell\Modules\Sifon\Sifon.psd1'
	Author 			    = 'Martin Miles'
	CompanyName 		= 'Perfecta Ltd'
	Copyright 		    = '(c)2020 Martin Miles. All rights reserved.'
	Description 		= '09addons module contains useful Add-ons to Windows PowerShell ISE'
	GUID 			    = 'e382b374-6ffb-4ae7-9b40-0f99518640ad'
	ModuleVersion 		= '0.9.6'
	PowerShellVersion 	= '5.1'
	FunctionsToExport 	= 'Get-InstanceUrl', 'Dummy-Function'
	ReleaseNotes 		= 'Accompanies Sifon. You may obtain your copy from https://Sifon.UK'
	RootModule 		    = 'Sifon.psm1'
}
New-ModuleManifest @manifest