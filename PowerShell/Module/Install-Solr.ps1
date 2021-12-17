function Install-Solr
(
	[string]$Version = "8.8.2",
	[string]$Folder = "c:\solr",
	[string]$Port = "8882",
	[string]$Hostname = "localhost",
	[bool]$Uninstall = $false
)
{
	[bool]$folderExists = Test-Path ($Folder + '\solr-' + $Version)

	if($folderExists)
	{
		if($false -eq $Uninstall){
			return $false
		}
	}

	if(!($folderExists))
	{
		if($true -eq $Uninstall){
			return $false
		}
	}

	# $moduleName = 'SharedInstallationUtilities'
	# Install-ModuleFromGithub -ModuleName $moduleName -UriBase "https://raw.githubusercontent.com/Sitecore/Sitecore.HabitatHome.Utilities/master/Shared/assets/modules/SharedInstallationUtilities/SharedInstallationUtilities.psm1"
	# Import-Module -Name $moduleName
	
	$sif = Get-Module -ListAvailable -Name 'SitecoreInstallFramework'
	if ($sif)
	{
		Import-SitecoreInstallFramework -version $sif.Version -repositoryName "SitecoreGallery" -repositoryUrl "https://sitecore.myget.org/F/sc-powershell/api/v2/"    

 		$jsonName = "c:\Program Files\WindowsPowerShell\Modules\Sifon\" + $MyInvocation.MyCommand.Name + '.json'

		$solrInstallConfigurationPath = Resolve-Path $jsonName

		$params = @{
			SolrVersion       = $Version
			SolrDomain        = $Hostname
			SolrPort          = $Port
			SolrInstallRoot   = $Folder
			SolrServicePrefix = ""
		}

		if ($Uninstall){
			Install-SitecoreConfiguration -Path $solrInstallConfigurationPath @params -Uninstall
		}
		else {
			Install-SitecoreConfiguration -Path $solrInstallConfigurationPath @params
		}

		Remove-Item -LiteralPath "c:\Program Files\WindowsPowerShell\Modules\$moduleName" -Force -Recurse
		return $true
	}
	else
	{
		return $false
	}
}
