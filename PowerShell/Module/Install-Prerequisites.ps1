# function Install-Prerequisites($InstallChoco, $InstallGit, $InstallWinRM, $InstallSIF)
function Install-Prerequisites([bool[]]$InstallValues)
{
    [bool]$InstallChoco = $InstallValues[0]
    [bool]$InstallGit = $InstallValues[1]
    [bool]$InstallWinRM = $InstallValues[2]
    [bool]$InstallSIF = $InstallValues[3]
    [bool]$InstallNetCore = $InstallValues[4]

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
        choco install git.install /GitOnlyOnPath --force  | Out-Null
        $env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User") 
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

    function Install-SIF
    {
        try 
        {
            Install-PackageProvider -Name NuGet -Force
            
            if($null -eq (Get-PSRepository -name SitecoreGallery -ErrorAction SilentlyContinue))
            {
                Register-PSRepository -Name SitecoreGallery https://sitecore.myget.org/F/sc-powershell/api/v2
            }
            
            Install-Module SitecoreInstallFramework -Force
            return $true
        }
        catch  
        {
            return $false
        }
    }

    function Install-NetCore
    {
        choco install dotnetcore-sdk --force  | Out-Null
        return (Verify-NetCore -Type 'SDK')
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
        Write-Progress -Activity "Installing PowerShell Remoting" -Status $activity -PercentComplete 71;
        $Remoting = Install-Remoting
    }

    [bool]$SIF = $false;
    if($InstallSIF){
        Write-Progress -Activity "Installing SIF" -Status $activity -PercentComplete 83;
        $SIF = Install-SIF
    }

    [bool]$NetCore = $false;
    if($InstallNetCore){
        Write-Progress -Activity "Installing .NET Core SDk" -Status $activity -PercentComplete 97;
        $NetCore = Install-NetCore
    }

    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;

    return @($Choco, $Git, $Remoting, $SIF, $NetCore)
}
