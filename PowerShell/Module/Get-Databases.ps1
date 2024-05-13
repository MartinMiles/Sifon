function Get-Databases([string]$ServerInstance, [string]$InstancePrefix){

	Invoke-Sqlcmd -ServerInstance "$ServerInstance" -Database master -Query "SELECT name FROM sys.databases WHERE NAME LIKE '$($InstancePrefix)%'" -TrustServerCertificate | Select -ExpandProperty name 
}
