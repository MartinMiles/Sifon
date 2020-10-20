Function Copy-FileToRemote([string]$RemoteHost, [PSCredential]$Credentials, [string]$RemoteDirectory, [string]$Filename)
{
	$Session = New-PSSession -ComputerName $RemoteHost -Credential $Credentials
	$remotePath = Invoke-Command -Session $session -ArgumentList $RemoteDirectory -ScriptBlock { param($RemoteDirectory) New-Item -ItemType Directory -Path $RemoteDirectory -Force }

	If ($Filename){
		Copy-Item -Path $Filename -Destination $RemoteDirectory -ToSession $session
		$File = Split-Path $Filename -leaf
		write-Output $remotePath\$File
	}
	else{
		Write-Output $remotePath
	}

	Remove-PSSession $Session
}
