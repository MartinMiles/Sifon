param(
    [string]$Name
)

[string]$Webroot = Get-SiteFolder -By "sitename" -Name $Name
$Config = "$Webroot\App_Config\Modules\Horizon\Sitecore.Horizon.Integration.config"

if(Test-path -Path $Config){

    [regex]$pattern = '<setting name="Horizon.ClientHost" value="([^"]*)"'

    $content = Get-Content -Path $config
    If ($content | Select-String -Pattern $pattern) {
        $horizonHostbase =  $pattern.Matches($content)[0].Groups[1].Value.trim('/')
    }
        
    if($horizonHostbase){
        $horizonHost = $([Uri]$horizonHostbase).Host
        Get-SiteFolder -By "hostname" -Name $horizonHost
    }
}