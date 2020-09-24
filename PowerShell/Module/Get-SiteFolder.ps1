Function Get-SiteFolder($Name, $By)
{
    Import-Module WebAdministration

    IF($By -eq 'sitename')
    {
        $FoundSite = Get-ChildItem IIS:\Sites | Where-Object {$_.Name -eq $Name} 
    }
    
    IF($By -eq 'hostname')
    {
        $Websites = Get-ChildItem IIS:\Sites
        foreach ($Site in $Websites) 
        {
            foreach ($Binding in $Site.Bindings.Collection) 
            {
                If($Binding.bindingInformation -Match ":$Name$")
                {
                    $FoundSite = $Site
                }
            }
        }
    }

    If($FoundSite.physicalPath)
    {
        return $FoundSite.physicalPath.trim('\')
    }
}


