param(
    [string]$Name,
    [string]$ConfigRelativePath,
    [string]$XPath,
    [string]$AttributeName
)

Import-Module WebAdministration

$FoundSite = $null


If($Name){

	$FoundSite = Get-ChildItem IIS:\Sites | Where-Object {$_.Name -eq $Name} 

 
 If($FoundSite.physicalPath){
 
  $file = $FoundSite.physicalPath + '\' + $ConfigRelativePath

  If(Test-Path $file){
  
      $node = Select-Xml -Path $file -XPath $XPath
      $XconnectURL = $node | Select-Object -ExpandProperty Node | Select -ExpandProperty $AttributeName
      $Hostname = $XconnectURL.Replace('https://','')
      
      foreach ($Site in Get-ChildItem IIS:\Sites) {


        foreach ($Binding in $Site.Bindings.Collection) {
            
            If($Binding.bindingInformation -Match ":$Hostname$"){
                
                $Site.physicalPath
            }
        }
   }
  }  
 }
}