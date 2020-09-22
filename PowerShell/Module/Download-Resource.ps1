Function Download-Resource([string]$Username, [string]$Password, [string]$ResourceUrl, [string]$TargertFilename)
{
	#[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
	#Import-Module "c:\Projects\Sitecore.HabitatHome.Utilities\Shared\assets\modules\SharedInstallationUtilities\SharedInstallationUtilities.psm1" -Force
	#Import-SitecoreInstallFramework -version "2.3.0" -repositoryName "SitecoreGallery" -repositoryUrl "https://sitecore.myget.org/F/sc-powershell/api/v2/"

	Function Prepare-Session
	{
		if (![string]::IsNullOrEmpty($Username) -and ![string]::IsNullOrEmpty($Password)) 
		{
			$secpasswd = ConvertTo-SecureString $Password -AsPlainText -Force
			$credentials = New-Object System.Management.Automation.PSCredential ($Username, $secpasswd)
			$username = $credentials.GetNetworkCredential().UserName
			$password = $credentials.GetNetworkCredential().Password
	
			Invoke-RestMethod -Uri https://dev.sitecore.net/api/authorization -Method Post -ContentType "application/json" -Body "{username: '$username', password: '$password'}" -SessionVariable loginSession -UseBasicParsing
			$global:loginSession = $loginSession
		}
		else 
		{
			throw "Credentials required for download"
		}
	}

	Function Commit-Download
	{
		Prepare-Session

		$ThisScript = $MyInvocation.ScriptName

		$params = @{
			Path         = $ThisScript.Replace(".ps1", ".json")
			LoginSession = $global:loginSession
			Source       = $ResourceUrl
			Destination  = $TargertFilename
		}
		
		Write-Output "Sifon-MuteOutput"
			Install-SitecoreConfiguration  @params
		Write-Output "Sifon-UnmuteOutput"
	}
	Commit-Download
}
