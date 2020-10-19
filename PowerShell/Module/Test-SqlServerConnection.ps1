function Test-SqlServerConnection
(
	[string]$ServerInstance,
	[PSCredential]$SqlCredentials
)
{
	Write-Output "Connecting remote SQL Server $ServerInstance"
	Invoke-Sqlcmd -Hostname $ServerInstance -Credential $SqlCredentials -Query "SELECT GETDATE() AS TimeOfQuery"
}
