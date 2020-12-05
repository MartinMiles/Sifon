function Install-ModuleFromGithub
(
	[string]$ModuleName, 
	[string]$ModuleSubfolder = $ModuleName
)
{
	$moduleFolder = "c:\Program Files\WindowsPowerShell\Modules\$ModuleSubfolder\"
	Remove-Item $moduleFolder -Recurse -ErrorAction Ignore
	New-Item -ItemType Directory -Force -Path $moduleFolder

	$UriBase = "https://raw.githubusercontent.com/Sitecore/Sitecore.HabitatHome.Utilities/master/Shared/assets/modules/$ModuleSubfolder/"
	$psd = "$ModuleName.psd1"
	$psm = "$ModuleName.psm1"

	Invoke-RestMethod ($UriBase + $psm) -OutFile ($moduleFolder + $psm)
	Invoke-RestMethod ($UriBase + $psd) -OutFile ($moduleFolder + $psd)
}
