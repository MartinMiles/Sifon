function Find-Indexes
(
    [string]$Webroot,
    [string]$AdminUsername,
    [string]$AdminPassword
)
{
    if (!(Get-Module -ListAvailable -Name SPE))
    {
        return "NO_SPE"
    } 

    [string]$Url = Get-InstanceUrl -Webroot $Webroot
    $session = New-ScriptSession -Username $AdminUsername -Password $AdminPassword -ConnectionUri $Url
    
    $indexes = Invoke-RemoteScript -ScriptBlock {
        Get-SearchIndex | % { $_.Name }
    } -Session $session

    return $indexes
}