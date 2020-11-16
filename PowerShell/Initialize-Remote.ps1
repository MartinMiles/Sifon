param(
	[string]$Activity,
	[string]$RemoteHost,
	[PSCredential]$Credentials,
	[string]$RemoteDirectory,
	[string[]]$ModuleFiles
)

$testWSMan = Test-WSMan $RemoteHost -Credential $Credentials -Authentication Negotiate
#Write-Output "Test-WSMan: $testWSMan"

$Session = New-PSSession -ComputerName $RemoteHost -Credential $Credentials
if(-not($Session))
{
	Write-Warning "$RemoteHost inaccessible!"
	exit
}

$remotePath = Invoke-Command -Session $session -ArgumentList $RemoteDirectory -ScriptBlock { param($RemoteDirectory) New-Item -ItemType Directory -Path $RemoteDirectory -Force }

Write-Progress -Activity $Activity -Status "Remote folder created" -PercentComplete 1

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
