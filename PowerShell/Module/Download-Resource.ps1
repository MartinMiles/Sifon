Function Download-Resource([PSCredential]$PortalCredentials, [string]$ResourceUrl, [string]$TargertFilename)
{
	Function Prepare-Session
	{
		if ($null -ne $PortalCredentials) 
		{
			$username = $PortalCredentials.GetNetworkCredential().UserName
			$password = $PortalCredentials.GetNetworkCredential().Password
	
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
