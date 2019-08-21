param(
	[string]$siteName
)

$site = Get-IISSite $siteName
$dict = New-Object 'System.Collections.Generic.List[String[]]'
$site.Bindings | ForEach-Object {
[string[]]$arr = $_.protocol,$_.bindingInformation.Split(':')[2]
    $dict.Add($arr)
}
$dict