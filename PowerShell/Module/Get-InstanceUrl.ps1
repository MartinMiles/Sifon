Import-Module WebAdministration

Function Get-InstanceUrl($Webroot) {


    $sites = Get-ChildItem -Path IIS:\Sites

    $dict = New-Object 'System.Collections.Generic.List[String[]]'
    Foreach ($site in $sites)
    {
        $path = $site.PhysicalPath.ToString()

        if($Webroot.TrimEnd('\') -eq $path)
        {
            $bindings = [PowerShell]::Create().AddCommand("Get-WebBinding"). `
                AddParameter("Name", $site.Name).Invoke()

            $bindings | ForEach-Object {
                [string[]]$arr = $_.protocol,$_.bindingInformation.Split(':')[2]
                $dict.Add($arr)
            }
        }
    }

    If($dict.Count -gt 0)
    {
        $Url = $dict[0][0] + "://" + $dict[0][1]
        return $Url 
    }
}

