Function Install-SitecorePackage($InstanceUrl, $Username, $Password, $Package)
{
    Import-Module -Name SPE

    Write-Output "Sending SPE remote call to: $InstanceUrl"    
    $session = New-ScriptSession -Username $Username -Password $Password -ConnectionUri $InstanceUrl
    Invoke-RemoteScript -ScriptBlock {
        Install-Package -Path "$($using:Package)" -InstallMode Overwrite
    } -Session $session
}

