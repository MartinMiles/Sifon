function Get-SitecoreVersion 
(
    [string]$Webroot,
    [switch]$ToString = $false
    
)
{
    $xml = "$Webroot\sitecore\shell\sitecore.version.xml"
    if(Test-Path $xml){
        [xml]$doc = Get-Content $xml
        $version = $doc.information.version
        if($ToString){
            return $version.major + "." + $version.minor + "." + $version.build
        }
        else{
            return $version
        }
    }
    else{
            throw [System.Exception] "$xml not found."
    }
}

# Get-SitecoreVersion -Webroot "c:\inetpub\wwwroot\xp.local" -ToString  