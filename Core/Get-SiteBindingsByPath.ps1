param(
    [string]$SitePath
)

Import-Module WebAdministration
$sites = Get-ChildItem -Path IIS:\Sites

$dict = New-Object 'System.Collections.Generic.List[String[]]'
Foreach ($site in $sites)
{
    $path = $site.PhysicalPath.ToString()
    if($SitePath.TrimEnd('\') -eq $path)
    {
		$bindings = Get-WebBinding -Name $site.Name
		$bindings | ForEach-Object {
			[string[]]$arr = $_.protocol,$_.bindingInformation.Split(':')[2]
			$dict.Add($arr)
		}
    }
}
$dict