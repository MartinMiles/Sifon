function Verify-NetCore([string]$Type = 'runtime')
{

    if($Type -eq 'runtime')
    {
        try{
            dotnet --info | Out-Null
            return $true
        }
        catch{
            return $false
        }
    }

    if($Type -eq 'SDK')
    {
        try{
            return $null -ne (dotnet --list-sdks)
        }
        catch{
            return $false
        }
    }

}
