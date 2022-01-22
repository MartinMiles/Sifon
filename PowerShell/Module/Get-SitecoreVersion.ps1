function Get-SitecoreVersion ([string]$Webroot)
{
    $xml = "$Webroot\sitecore\shell\sitecore.version.xml"
    if(Test-Path $xml){
        [xml]$doc = Get-Content $xml
        $version = $doc.information.version
        return $version #.major + "." + $version.minor + "." + $version.build
    }
    else{

    }
}

# Get-SitecoreVersion -Webroot "c:\inetpub\wwwroot\xp.local"