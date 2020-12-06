function Install-ModuleFromGithub
(
	[string]$UriBase, 
	[string]$ModuleName
)
{
	$moduleFolder = "c:\Program Files\WindowsPowerShell\Modules\$ModuleName\"
	Remove-Item $moduleFolder -Recurse -ErrorAction Ignore
	New-Item -ItemType Directory -Force -Path $moduleFolder

	$psm = "$ModuleName.psm1"
	Invoke-RestMethod ($UriBase) -OutFile ($moduleFolder + $psm)
}

# Install-ModuleFromGithub -ModuleName 'SharedInstallationUtilities' -UriBase "https://raw.githubusercontent.com/Sitecore/Sitecore.HabitatHome.Utilities/master/Shared/assets/modules/SharedInstallationUtilities/SharedInstallationUtilities.psm1"