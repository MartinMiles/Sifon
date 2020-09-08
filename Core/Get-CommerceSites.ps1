param(
    [string]$Name
)

Import-Module WebAdministration

$FoundSite = $null

#$FoundSite = Get-IISSite -Name $Name
$FoundSite = Get-ChildItem IIS:\Sites | Where-Object {$_.Name -eq $Name} 
 
 If($FoundSite.physicalPath){

 
  $file = $FoundSite.physicalPath + '\bin\Sitecore.Commerce.Connect.Core.dll'

  If(Test-Path $file){

	$Websites = Get-ChildItem IIS:\Sites

    foreach ($Site in $Websites) {	
        $bizFx = $Site.physicalPath + '\assets\config.json'
         If(Test-Path $bizFx){
            $Site.physicalPath
         }
    }

    foreach ($Site in $Websites) {
	
	  $config = $Site.physicalPath + '\Sitecore.Commerce.Engine.exe.config'

		  If(Test-Path $config){
			$Site.physicalPath
			#$Site.Bindings.Collection.bindingInformation
		}	
         }


  }
}