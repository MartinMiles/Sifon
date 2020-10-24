function Install-Prerequisites
{
    function Install-Chocolatey 
    {    
        [CmdletBinding(SupportsShouldProcess = $True)]
        param ()
        Write-FPLog -Category Info -Message "verifying chocolatey is installed"
        if ((powershell choco -v) -eq $null)
        {
            Write-FPLog -Category Info -Message "installing chocolatey..."
            try {
                iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
                choco feature enable -n=allowGlobalConfirmation
                return $true
            }
            catch {
                Write-FPLog -Category Error -Message $_.Exception.Message
            }
        }
        else {
            Write-FPLog -Category Info -Message "chocolatey is already installed"
        }
        return $false;
    }

    function Install-Git
    {
        cinst git
        return $true
    }

    $activity = "Installing prerequisites"

    Write-Progress -Activity "Installing Chocolatey" -Status $activity -PercentComplete 3;
    $Choco = Install-Chocolatey

    Write-Progress -Activity "Installing Git" -Status $activity -PercentComplete 62;
    $Git = Install-Git

    Write-Progress -Activity "Done" -Status $activity -PercentComplete 100;

    return [System.Tuple]::Create($Choco, $Git)
}