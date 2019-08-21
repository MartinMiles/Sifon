param(
	[string]$ServerInstance = '.',
	[string]$Username,
	[string]$Password
)

$output = [string]"Connecting remote SQL Server $ServerInstance"
Write-Output $output

Invoke-Sqlcmd -ServerInstance "$ServerInstance" `
    -Username "$Username" `
    -Password "$Password" `
-Query "SELECT GETDATE() AS TimeOfQuery"