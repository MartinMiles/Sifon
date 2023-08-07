function Install-SQLServer
(
	[string]$Instance = "SQLSERVER",
	[string]$Password = "SA_PASSWORD"
)
{
	#if instance starts with .\ - trim it

	choco install sql-server-express -o -ia "'/IACCEPTSQLSERVERLICENSETERMS /Q /ACTION=install /INSTANCEID=$Instance /INSTANCENAME=SQLSERVER /UPDATEENABLED=FALSE /SECURITYMODE=SQL /SAPWD=$Password'" -f -y
	Invoke-Sqlcmd -Query "ALTER LOGIN sa ENABLE" -ServerInstance ".\$Instance"
	Invoke-Sqlcmd -Query "ALTER LOGIN sa WITH PASSWORD='$Password'" -ServerInstance ".\$Instance"

	Invoke-Sqlcmd -Query "SELECT GETDATE() AS TimeOfQuery" -ServerInstance ".\$Instance" -Username "sa" -Password "$Password"

	return $true
}
