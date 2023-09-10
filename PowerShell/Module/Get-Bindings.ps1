
function Get-Bindings([string[]]$SiteNameOrPath)
{
    Import-Module WebAdministration
    $sites = Get-ChildItem -Path IIS:\Sites

    $dict = New-Object 'System.Collections.Generic.List[String[]]'

    foreach ($SitePath in $SiteNameOrPath) {

        if(!(Test-Path -Path $SitePath)){
            $SitePath =  Get-SiteFolder -name $SitePath
        }
        Get-ChildItem -Path IIS:\Sites | where { $_.PhysicalPath.ToString() -eq $SitePath} | % { Get-WebBinding -Name $_.Name } | % { [string[]]$arr = $_.protocol,$_.bindingInformation.Split(':')[2]; $dict.Add($arr) }
    }
    return $dict
}

# Sample usage:
#   Get-Bindings @("cm.xm.local", "cd.xm.local")
#   Get-Bindings @("C:\inetpub\wwwroot\cm.xm.local", "C:\inetpub\wwwroot\cd.xm.local")