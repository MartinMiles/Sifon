param(
	[string]$Activity,
	[string]$RemoteHost,
	[string]$Username,
	[string]$Password,
	[string]$RemoteDirectory,
	[string[]]$Filenames
)

$pass = ConvertTo-SecureString -AsPlainText $Password -Force
$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass
$Session = New-PSSession -ComputerName $RemoteHost -Credential $Cred

$remotePath = Invoke-Command -Session $session -ArgumentList $RemoteDirectory -ScriptBlock { param($RemoteDirectory) New-Item -ItemType Directory -Path $RemoteDirectory -Force }

If ($Filenames)
{	
	Write-Progress -Activity $Activity -Status "Remote folder created" -PercentComplete 0
	
	For ($i=0; $i -le $Filenames.Length; $i++) 
	{
  		Copy-Item -Path $Filenames[$i] -Destination $remotePath.FullName -ToSession $session
		$File = Split-Path $Filenames[$i] -leaf
		Write-Progress -Activity $Activity -Status "Copying files: $File" -PercentComplete (($i) * 100 / $Filenames.Length);
	}

	Write-Progress -Activity $Activity -Status "operation complete." -PercentComplete 100

	Write-Output $remotePath
}

Remove-PSSession $Session
