function Check-Prerequisites()
{
    function Has-Choco
    {
        try { 
            choco | Out-Null
            return $true
        }
        catch { 
            return $false; 
        }
    }

    function WsMan-Enabled
    {

        try {
            $WSMan = [bool](Test-WSMan -ErrorAction SilentlyContinue | % { $_.wsmid -ne $null }) 
            return $WSMan
        }
        catch {
            return $false
        }
    }

    function Verify-SIF
    {
        $version = Get-Module SitecoreInstallFramework -ListAvailable | Select-Object -Property Version
        return $null -ne $version
    }

    $activity = "Checking prerequisites"

    Write-Progress -Activity "Checking Chocolatey" -Status $activity -PercentComplete 3;
    
    $isChocoInstalled = Has-Choco

    Write-Progress -Activity "Checking Git" -Status $activity -PercentComplete 38;
    
    $isGitInstalled = Verify-Git 

    Write-Progress -Activity "Checking PowerShell remoting" -Status $activity -PercentComplete 61;

    $remoting = WsMan-Enabled

    Write-Progress -Activity "Checking SIF" -Status $activity -PercentComplete 83;

    $SIF = Verify-SIF

    Write-Progress -Activity "Checking .NET Core SDK" -Status $activity -PercentComplete 97;

    $NetCore = (Verify-NetCore -Type 'SDK')

    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;    

    return @($isChocoInstalled, $isGitInstalled, $remoting, $SIF, $NetCore)
}
