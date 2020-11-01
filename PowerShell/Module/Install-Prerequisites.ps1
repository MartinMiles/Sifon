function Install-Prerequisites($InstallChoco, $InstallGit, $InstallWinRM)
{
    function Is-ChocoInstalled
    {
        try {
                choco -v
                return $true
        }
        catch {
            return $false
        }
    }

    function Install-Chocolatey 
    {    
        #[CmdletBinding(SupportsShouldProcess = $True)]
        param ()
        if (!(Is-ChocoInstalled))
        {
            try 
            {
                iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) | Out-Null
                
                if (Is-ChocoInstalled)
                {
                    choco feature enable -n=allowGlobalConfirmation  | Out-Null
                    return $true
                }
            }
            catch {
                $_.Exception.Message
            }
        }
        else {
            return $true
        }
        return $false;
    }

    function Install-Git
    {
        choco install git.install -version 1.9.5.20150114 --force  | Out-Null
        return $true
    }

	function Install-Remoting
    {
        try 
        {
            Get-NetConnectionProfile | Set-NetConnectionProfile -NetworkCategory Private
            Enable-PSRemoting -force | Out-Null
            Set-Item wsman:localhost\client\trustedhosts -Value * -force 
            return $true
        }
        catch 
        {
            $_.Exception.Message | Out-Null
        }

        return $false
    }

    $activity = "Installing prerequisites"


    [bool]$Choco = $false;
    if($InstallChoco){
        Write-Progress -Activity "Installing Chocolatey" -Status $activity -PercentComplete 3;
        $Choco = Install-Chocolatey
    }

    [bool]$Git = $false;
    if($InstallGit){
        Write-Progress -Activity "Installing Git" -Status $activity -PercentComplete 52;
        $Git = Install-Git
    }

    [bool]$Remoting = $false;
    if($InstallWinRM){
        Write-Progress -Activity "Installing PowerShell Remoting" -Status $activity -PercentComplete 83;
        $Remoting = Install-Remoting
    }

    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;

    return [System.Tuple]::Create($Choco, $Git, $Remoting)
}
