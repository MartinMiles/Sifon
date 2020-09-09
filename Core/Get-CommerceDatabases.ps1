param(
    [string]$Webroot
)

$config1 = "$Webroot\wwwroot\data\Environments\Plugin.SQL.PolicySet-1.0.0.json"
$config2 = "$Webroot\wwwroot\bootstrap\Global.json"

If(Test-Path $config1){

    $json = (Get-Content $config1 -Raw) | ConvertFrom-Json
    if($json.Policies.'$values'.Database)
    {
        $json.Policies.'$values'.Database
    }
}

If(Test-Path $config2){

    $json = (Get-Content $config2 -Raw)  | ConvertFrom-Json
    	ForEach ($value in $json.Policies.'$values') {
		if($value.Database)
        {
            $value.Database
        }
	}    
}