param(
	[string]$PortalUsername,
	[string]$PortalPassword
)

Write-Output "PortalUsername = $PortalUsername"
Write-Output "PortalPassword = $PortalPassword"

$file = ".\Exchange Framework 2.1.0 rev. 181113.zip"

Write-Output "Sifon-MuteWarnings"
Write-Output "Sifon-MuteProgress"
    Download-Resource -Username $PortalUsername -Password $PortalPassword -ResourceUrl "https://dev.sitecore.net/~/media/C10E96CD1EAC46C49C957D5C3445BFB2.ashx" -TargertFilename $file
Write-Output "Sifon-UnmuteProgress"
Write-Output "Sifon-UnmuteWarnings"

if(Test-Path -Path $file)
{
    $length = (Get-Item $file).length
    $length
    if($length -eq 2448692)
    {
        Remove-Item -Path $file
        return $true
    }
}

return $false