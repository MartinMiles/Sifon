function Test-SqlServerConnection
(
	[string]$ServerInstance,
	[PSCredential]$SqlCredentials = $null,
	[string]$Username = $null,
	[string]$Password = $null
)
{
	Write-Output "Connecting remote SQL Server $ServerInstance"
	
	if($Username -eq $null -or $Password -eq $null){
		Invoke-Sqlcmd -Hostname $ServerInstance -Credential $SqlCredentials -Query "SELECT GETDATE() AS TimeOfQuery"
	}
	else
	{
		Invoke-Sqlcmd -Query "SELECT GETDATE() AS TimeOfQuery" -ServerInstance "$ServerInstance" -Username "$Username" -Password "$Password"
	}	
}
