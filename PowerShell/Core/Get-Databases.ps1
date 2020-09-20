param(
	[string]$ServerInstance,
	[string]$InstancePrefix
)

Invoke-Sqlcmd -ServerInstance "$ServerInstance" -Database master -Query "SELECT name FROM sys.databases WHERE NAME LIKE '$($InstancePrefix)%'" | Select -ExpandProperty name 