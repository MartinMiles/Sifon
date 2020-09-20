param(
	[string]$RemoteHost,
	[string]$Username,
	[string]$Password,
	[string]$RemoteDirectory,
	[string]$Filename #full path
)

$pass = ConvertTo-SecureString -AsPlainText $Password -Force
$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass
$Session = New-PSSession -ComputerName $RemoteHost -Credential $Cred

$remotePath = Invoke-Command -Session $session -ArgumentList $RemoteDirectory -ScriptBlock { param($RemoteDirectory) New-Item -ItemType Directory -Path $RemoteDirectory -Force }

If ($Filename){
	Copy-Item -Path $Filename -Destination $remotePath.FullName -ToSession $session
	$File = Split-Path $Filename -leaf
	write-Output $remotePath\$File
}
else{
	Write-Output $remotePath
}

Remove-PSSession $Session
