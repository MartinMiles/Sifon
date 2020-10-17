
function Get-SiteBindings([string]$SiteNameOrPath)
{
    $SitePath = $SiteNameOrPath

    if(!(Test-Path -Path $SiteNameOrPath)){
         $SitePath =  Get-SiteFolder -name $SiteNameOrPath
    }
    
    Import-Module WebAdministration
    $sites = Get-ChildItem -Path IIS:\Sites

    $dict = New-Object 'System.Collections.Generic.List[String[]]'

    Get-ChildItem -Path IIS:\Sites | where { $_.PhysicalPath.ToString() -eq $SitePath} | % { Get-WebBinding -Name $_.Name } | % { [string[]]$arr = $_.protocol,$_.bindingInformation.Split(':')[2]; $dict.Add($arr) }
    return $dict
}