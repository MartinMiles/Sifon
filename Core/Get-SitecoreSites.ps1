Import-Module WebAdministration
$sites = Get-ChildItem -Path IIS:\Sites

$dict = New-Object 'System.Collections.Generic.List[String[]]'
Foreach ($site in $sites)
{
    $path = $site.PhysicalPath.ToString()
    if(Test-Path -Path $path\bin\Sitecore.Kernel.dll)
    {
        [string[]]$arr = $site.Name,$path
        $dict.Add($arr)
    }
}
$dict