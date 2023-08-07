function Verify-NetCoreHosting
(
    [string]$MinimumVersion,
    [switch]$Verbose = $false
)
{
    
    $DotNetCoreMinimumRuntimeVersion = [System.Version]::Parse($MinimumVersion)

    $runtimes = (dir (Get-Command dotnet).Path.Replace('dotnet.exe', 'shared\Microsoft.NETCore.App')).Name
    
    if($null -ne $runtimes -and $runtimes.Count -ge 0)   
    {
        foreach ($runtime in $runtimes) {
            $RuntimeVersion = [System.Version]::Parse($runtime)
            
            if($RuntimeVersion -ge $DotNetCoreMinimumRuntimeVersion) 
            {
                if($Verbose)
                {
                    Write-Host "The host has installed the following .NET Core Runtime: $RuntimeVersion (MinimumVersion requirement: $DotNetCoreMinimumRuntimeVersion)"
                }
            
                return $true
            }
        }
    }
    return $false;
}

# Verify-NetCoreHosting -MinimumVersion "6.0.11"
