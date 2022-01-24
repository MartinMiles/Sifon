function Verify-NetCoreHosting
(
    [string]$MinimumVersion,
    [switch]$Verbose = $false
)
{
    $DotNetCoreMinimumRuntimeVersion = [System.Version]::Parse($MinimumVersion)

    $DotNETCoreUpdatesPath = "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Updates\.NET Core"
    $DotNetCoreItems = Get-Item -ErrorAction Stop -Path $DotNETCoreUpdatesPath
    $MinimumDotNetCoreRuntimeInstalled = $False

    $DotNetCoreItems.GetSubKeyNames() | Where { $_ -Match "Microsoft .NET Core.*Windows Server Hosting" } | ForEach-Object {

                $registryKeyPath = Get-Item -Path "$DotNETCoreUpdatesPath\$_"

                $dotNetCoreRuntimeVersion = $registryKeyPath.GetValue("PackageVersion")

                $dotNetCoreRuntimeVersionCompare = [System.Version]::Parse($dotNetCoreRuntimeVersion)

                if($dotNetCoreRuntimeVersionCompare -ge $DotNetCoreMinimumRuntimeVersion) {
                                
                                if($Verbose){
                                    Write-Host "The host has installed the following .NET Core Runtime: $_ (MinimumVersion requirement: $DotNetCoreMinimumRuntimeVersion)"
                                }

                                $MinimumDotNetCoreRuntimeInstalled = $True
                }
    }

    if ($MinimumDotNetCoreRuntimeInstalled -eq $False) {
            if($Verbose){
                Write-host ".NET Core Runtime (MiniumVersion $DotNetCoreMinimumRuntimeVersion) is required." -foreground Red
            }
    }

    return $MinimumDotNetCoreRuntimeInstalled
}

# Verify-NetCoreHosting -MinimumVersion "3.1.0"