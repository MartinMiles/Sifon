Function Install-SitecorePackage($InstanceUrl, $Username, $Password, $Package, $RemoveAfterInstall = $false)
{
    Import-Module -Name SPE

    Write-Output "Sending SPE remote call to: $InstanceUrl"    
    $session = New-ScriptSession -Username $Username -Password $Password -ConnectionUri $InstanceUrl
    Invoke-RemoteScript -ScriptBlock {
        Install-Package -Path "$($using:Package)" -InstallMode Overwrite
    } -Session $session
}

# Install-SitecorePackage -InstanceUrl "https://platform" -Username "admin" -Password "b" -PackageToInstall "c:\inetpub\wwwroot\platform\App_Data\packages\Sitecore Publishing Module 10.0.0.0 rev. r00568.2697.zip"