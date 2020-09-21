Function Get-ConnectionString($ConfigPath, $DbName)
{
    if([System.IO.File]::Exists($ConfigPath))
    {
        $xml = [xml](get-content $ConfigPath)
        $dbInfo = $xml.SelectNodes("/connectionStrings/add[@name='$DbName']") | Select connectionString
        IF($dbInfo){
            return $dbInfo.connectionString
        }
        else
        {
            Write-Output "No database information found"
        }
    }
    else
    {
        Write-Output "Config does not exist at: $ConfigPath"
    }
}
