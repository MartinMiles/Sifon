function Check-Prerequisites()
{
    function Is-Git($Obj)
    {
        try { 
            return $null -ne $Obj -and $null -ne $Obj.DisplayName -and $Obj.DisplayName.Contains('Git') 
        }
        catch { 
            return $false; 
        }
    }

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
            $WSMan = [bool](Test-WSMan | % { $_.wsmid -ne $null }) 
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

    Write-Progress -Activity "Checking Git" -Status $activity -PercentComplete 57;
    
    $isGitInstalled = $null -ne ( (Get-ItemProperty HKLM:\Software\Microsoft\Windows\CurrentVersion\Uninstall\*) `
        + (Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*) `
        | Where-Object { Is-Git($_) } )
    

        
        Write-Progress -Activity "Checking PowerShell remoting" -Status $activity -PercentComplete 82;

        $remoting = WsMan-Enabled

        Write-Progress -Activity "Checking SIF" -Status $activity -PercentComplete 97;

        $SIF = Verify-SIF

    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;    



    return [System.Tuple]::Create($isChocoInstalled, $isGitInstalled, $remoting,$SIF)
}
