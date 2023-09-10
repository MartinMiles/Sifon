function Get-SitecoreSites([bool]$All){
    
    $dllToCheck = if ($All) { "\bin\Sitecore.Nexus.Licensing.dll" } else { "\bin\Sitecore.Kernel.dll" }

    Get-ChildItem -Path IIS:\Sites `
    | where { Test-Path($_.PhysicalPath + $dllToCheck)  } `
    | % {$_.Name }
}

# Sample usage:
#   Get-SitecoreSites               # returns web roles only
#   Get-SitecoreSites -All $true    # returns web roles AND xconnect, used from Profiles Websites control