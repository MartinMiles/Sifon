param(
    [string]$Name
)

[string]$Webroot = Get-SiteFolder -By "sitename" -Name $Name
$ConfigFolder = "$Webroot\App_Config\Modules\PublishingService\"

if(Test-path -Path $ConfigFolder){

    [regex]$pattern = '<setting name="PublishingService.UrlRoot"[^>]*>(.{1,1000})<\/setting>'

    Get-ChildItem $ConfigFolder -Filter "*.config" | 
        
        ForEach-Object {
            $content = Get-Content -Path $_.FullName
            If ($content | Select-String -Pattern $pattern) {
                $publishingHostbase =  $pattern.Matches($content)[0].Groups[1].Value.trim('/')
            }
        }
        
    if($publishingHostbase){
        $publishingHost = $([Uri]$publishingHostbase).Host
        Get-SiteFolder -By "hostname" -Name $publishingHost
    }
}