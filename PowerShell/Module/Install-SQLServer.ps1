function Install-SQLServer
(
	[string]$Edition = "Express",
	[string]$Version = "Latest",
	[string]$Instance = "SQLSERVER",
	[string]$Password = "SA_PASSWORD"
)
{
	# Check if $Instance starts with ".\" and remove it
	if ($Instance.StartsWith(".\")) {
		$Instance = $Instance -replace '^\.\\', ''
	}

	# Define the version and package mappings
	$VersionMappings = @{
		"Express" = @{
			"Latest" = "PARAM NOT USED"
			"2019"   = "2019.20200409"
			"2017"   = "2017.20190916"
			"2016"   = "13.0.1601.5"
		}
		"Developer" = @{
			"Latest" = "sql-server-2022"
			"2022"   = "sql-server-2022"
			"2019"   = "sql-server-2019"
			"2017"   = "sql-server-2017"
			"2016"   = "sql-server-2016-developer-edition"
		}
	}

	# Determine the appropriate package and version or command construction
	$VersionParam = ""
	if ($Edition -eq "Express" -and $Version -ne "Latest") {
		$VersionParam = "--version=" + $VersionMappings[$Edition][$Version]
	}
	
	$Package = if ($Edition -eq "Developer") { $VersionMappings[$Edition][$Version] } else { "sql-server-express" }	

	# Base command for Chocolatey to install SQL Server
	$BaseCommand = "choco install $Package $VersionParam"

	$instanceInfo = ""
	if($Instance -ne ""){
		$InstanceInfo = "/INSTANCEID=$Instance /INSTANCENAME=$Instance"
	}

	# Additional arguments for installation
	if ($Edition -eq "Express") 
	{ 
		$AdditionalArgs = "-o -ia `'/IACCEPTSQLSERVERLICENSETERMS /Q /ACTION=install $InstanceInfo /UPDATEENABLED=FALSE /SECURITYMODE=SQL /SAPWD=$Password'` -f -y"
	}
	else{
		$AdditionalArgs = "--params=`'$InstanceInfo /FEATURES=SQLENGINE /SECURITYMODE=SQL /SAPWD=$Password`'"
	}

	# Construct the command
	$Command = "$BaseCommand $AdditionalArgs"
	
	# Execute the command
	$Command
	Invoke-Expression $Command
	
	try{
		Invoke-Sqlcmd -Query "ALTER LOGIN sa ENABLE" -ServerInstance ".\$Instance"  -TrustServerCertificate
		Invoke-Sqlcmd -Query "ALTER LOGIN sa WITH PASSWORD='$Password'" -ServerInstance ".\$Instance"  -TrustServerCertificate
		Invoke-Sqlcmd -Query "SELECT GETDATE() AS TimeOfQuery" -ServerInstance ".\$Instance" -Username "sa" -Password "$Password"  -TrustServerCertificate

		return $true
	}
	catch{
		return $false
	}
}

# Example:
# Install-SQLServer -Edition "Developer" -Version "2019" -Instance "SQLSERVER" -Password "SA_PASSWORD"