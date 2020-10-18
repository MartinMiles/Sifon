Import-Module WebAdministration
Function Get-SiteFolder($name, $type) {

    $ConfigRelativePath = $null
    $XPath = $null
    $AttributeName = $null

    if($type -eq 'XConnect'){

        $ConfigRelativePath = "App_Config\ConnectionStrings.config"
        $XPath = "/connectionStrings/add[@name='xconnect.collection']"
        $AttributeName = "connectionString"
    }
    elseif ($type -eq 'IdentityServer'){

        $ConfigRelativePath = "App_Config\Sitecore\Owin.Authentication.IdentityServer\Sitecore.Owin.Authentication.IdentityServer.config"
        $XPath = "/configuration/sitecore/sc.variable[@name='identityServerAuthority']"
        $AttributeName = "value"
    }    
    elseif ($type -eq 'Commerce'){
        return Get-ChildItem IIS:\Sites | where { (Test-Path($_.physicalPath + '\assets\config.json')) -OR (Test-Path( $_.physicalPath + '\Sitecore.Commerce.Engine.xml'))} | % { $_.physicalPath }
    }
    elseif ($type -eq 'Horizon'){

        [string]$Webroot = Get-SiteFolder -Name $name

        $Config = "$Webroot\App_Config\Modules\Horizon\Sitecore.Horizon.Integration.config"
        
        if(Test-path -Path $Config){
        
            [regex]$pattern = '<setting name="Horizon.ClientHost" value="([^"]*)"'
        
            $content = Get-Content -Path $config
            
            If ($content | Select-String -Pattern $pattern) {
                $horizonHostbase =  $pattern.Matches($content)[0].Groups[1].Value.trim('/')
                if($horizonHostbase){
                    return Get-SiteFolder -Name $([Uri]$horizonHostbase).Host
                }
            }
        }
        exit
    }
    elseif ($type -eq 'PublishingService'){
        $Webroot = Get-SiteFolder -Name $Name
        $ConfigFolder = "$Webroot\App_Config\Modules\PublishingService\"

        if(Test-path -Path $ConfigFolder){
            
            [regex]$pattern = '<setting name="PublishingService.UrlRoot"[^>]*>(.{1,1000})<\/setting>'

            Get-ChildItem $ConfigFolder -Filter "*.config" | % {
                $content = Get-Content -Path $_.FullName
                If ($content | Select-String -Pattern $pattern) {
                    
                    $publishingHostbase =  $pattern.Matches($content)[0].Groups[1].Value.trim('/')
                    if($publishingHostbase){

                        return (Get-SiteFolder -Name $([Uri]$publishingHostbase).Host).trim('\')
                    }
                }
            }
        }
        exit
    }

    $FoundSite = Get-ChildItem IIS:\Sites | Where-Object {$_.Name -eq $name} 
    
    If($FoundSite.physicalPath){
        
        if($null -eq $ConfigRelativePath){
            return $FoundSite.physicalPath
            exit
        }

        $file = $FoundSite.physicalPath + '\' + $ConfigRelativePath

        If(Test-Path $file){
        
            $node = Select-Xml -Path $file -XPath $XPath
            $XconnectURL = $node | Select-Object -ExpandProperty Node | select -ExpandProperty $AttributeName
            $Hostname =  ([System.Uri]$XconnectURL).Host
            
            return Get-ChildItem IIS:\Sites | where { $_.Bindings.Collection.bindingInformation -Match ":$Hostname$" } | select -ExpandProperty physicalPath
        }  
    }
}