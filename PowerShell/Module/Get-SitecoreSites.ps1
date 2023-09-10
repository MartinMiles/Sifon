function Get-SitecoreSites([bool]$IsXM){
    
    # $dllToCheck = if ($All) { "\bin\Sitecore.Nexus.Licensing.dll" } else {  }

    if($IsXM){
        Get-ChildItem -Path IIS:\Sites | where { Test-Path($_.PhysicalPath + "\bin\Sitecore.Kernel.dll")  } | where { -not (Test-Path($_.PhysicalPath + "\bin\Sitecore.Framework.Common.dll"))  } |% {$_.Name }
    }
    else{
        Get-ChildItem -Path IIS:\Sites | where { Test-Path($_.PhysicalPath + "\bin\Sitecore.Framework.Common.dll")  } | % {$_.Name }
    }


}

# Sample usage:
#   Get-SitecoreSites                # returns roles for XP (no IDS)
#   Get-SitecoreSites -IsXM $true    # returns roles for XM (no IDS)