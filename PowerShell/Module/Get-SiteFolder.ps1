Import-Module WebAdministration
Function Get-SiteFolder($name, $type) {

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

    If($name){

        $FoundSite = Get-ChildItem IIS:\Sites | Where-Object {$_.Name -eq $name} 

        If($FoundSite.physicalPath){

            if($ConfigRelativePath -eq $null){
                $FoundSite.physicalPath
                exit
            }

            $file = $FoundSite.physicalPath + '\' + $ConfigRelativePath

            If(Test-Path $file){
            
                $node = Select-Xml -Path $file -XPath $XPath
                $XconnectURL = $node | Select-Object -ExpandProperty Node | select -ExpandProperty $AttributeName
                $Hostname =  ([System.Uri]$XconnectURL).Host
                
                Get-ChildItem IIS:\Sites | where { $_.Bindings.Collection.bindingInformation -Match ":$Hostname$" } | select -ExpandProperty physicalPath

            }  
        }
    }
}