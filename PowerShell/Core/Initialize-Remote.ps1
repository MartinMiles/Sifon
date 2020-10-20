param(
	[string]$Activity,
	[string]$RemoteHost,
	[string]$Username,
	[string]$Password,
	[string]$RemoteDirectory,
	[string[]]$ModuleFiles
)

$pass = ConvertTo-SecureString -AsPlainText $Password -Force
$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass
$Session = New-PSSession -ComputerName $RemoteHost -Credential $Cred

$remotePath = Invoke-Command -Session $session -ArgumentList $RemoteDirectory -ScriptBlock { param($RemoteDirectory) New-Item -ItemType Directory -Path $RemoteDirectory -Force }

Write-Progress -Activity $Activity -Status "Remote folder created" -PercentComplete 1

# If ($Filenames)
# {	
	
# 	For ($i=0; $i -lt $Filenames.Length; $i++) 
# 	{
#   		Copy-Item -Path $Filenames[$i] -Destination $remotePath.FullName -ToSession $session
# 		$File = Split-Path $Filenames[$i] -leaf
# 		Write-Progress -Activity $Activity -Status "Copying files: $File" -PercentComplete (($i) * 50 / $Filenames.Length);
# 	}
# }

$ModulesPath = Invoke-Command -Session $session -ScriptBlock { New-Item -ItemType Directory -Path "$Env:Programfiles\WindowsPowerShell\Modules\Sifon" -Force }
if($ModuleFiles){

	For ($i=0; $i -lt $ModuleFiles.Length; $i++) 
	{
  		Copy-Item -Path $ModuleFiles[$i] -Destination $ModulesPath.FullName -ToSession $session
		$File = Split-Path $ModuleFiles[$i] -leaf
		Write-Progress -Activity $Activity -Status "Copying files: $File" -PercentComplete ($i * 100 / $ModuleFiles.Length);
	}

	Write-Output "$remotePath|$ModulesPath"
}

Write-Progress -Activity $Activity -Status "initialize operation complete." -PercentComplete 100

Remove-PSSession $Session
