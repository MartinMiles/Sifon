# function Install-Prerequisites($InstallChoco, $InstallGit, $InstallWinRM, $InstallSIF, $InstallNetCore, $InstallSqlServer)
function Install-Prerequisites([bool[]]$InstallValues)
{
    [bool]$InstallChoco = $InstallValues[0]
    [bool]$InstallGit = $InstallValues[1]
    [bool]$InstallWinRM = $InstallValues[2]
    [bool]$InstallSIF = $InstallValues[3]
    [bool]$InstallNetCore = $InstallValues[4]
    [bool]$InstallSqlServer = $InstallValues[5]

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
        $ProgressPreference = "SilentlyContinue"
        choco install git.install /GitOnlyOnPath --force  | Out-Null
        $env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User") 
        $ProgressPreference = "Continue"

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
        $ProgressPreference = "SilentlyContinue"
        choco install dotnetcore-sdk --force  | Out-Null
        choco install dotnet-6.0-sdk --force  | Out-Null
        $env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User") 
        $ProgressPreference = "Continue"

        return (Verify-NetCore -Type 'SDK')
    }

    function Verify-SqlServer
    {
        if (Get-Module -ListAvailable -Name SqlServer){
    		return $true
	} 
	else {
		return $false
	}
    }

    function Install-SqlServer
    {
        $ProgressPreference = "SilentlyContinue"
	Install-Module SqlServer -AllowClobber -Force  | Out-Null
        $ProgressPreference = "Continue"

        return (Verify-SqlServer)
    }


    $activity = "Installing prerequisites"


    [bool]$Choco = $false;
    if($InstallChoco){
        Write-Progress -Activity "Installing Chocolatey" -Status $activity -PercentComplete 3;
        $Choco = Install-Chocolatey
    }

    [bool]$Git = $false;
    if($InstallGit){
        Write-Progress -Activity "Installing Git" -Status $activity -PercentComplete 22;
        $Git = Install-Git
    }

    [bool]$Remoting = $false;
    if($InstallWinRM){
        Write-Progress -Activity "Installing PowerShell Remoting" -Status $activity -PercentComplete 47;
        $Remoting = Install-Remoting
    }

    [bool]$SIF = $false;
    if($InstallSIF){
        Write-Progress -Activity "Installing SIF" -Status $activity -PercentComplete 53;
        $SIF = Install-SIF
    }

    [bool]$NetCore = $false;
    if($InstallNetCore){
        Write-Progress -Activity "Installing .NET Core SDk" -Status $activity -PercentComplete 71;
        $NetCore = Install-NetCore
    }

    [bool]$SqlServer = $false;
    if($InstallSqlServer){
        Write-Progress -Activity "Installing SQL Server PowerShell module" -Status $activity -PercentComplete 83;
        $SqlServer = Install-SqlServer
    }


    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;

    return @($Choco, $Git, $Remoting, $SIF, $NetCore, $SqlServer)
}
