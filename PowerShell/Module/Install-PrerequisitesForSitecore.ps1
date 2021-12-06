function Install-Sitecore
{
    param(
        [Parameter(Mandatory=$true)]
        $Params
    )

    if($Params.InstallPrerequisites)
    {
        "."
        $prereqs = "$folder\prerequisites.json"
        (Get-Content $prereqs).replace('https://download.microsoft.com/download/C/F/F/CFF3A0B8-99D4-41A2-AE1A-496C08BEB904/WebPlatformInstaller_amd64_en-US.msi', 'https://go.microsoft.com/fwlink/?LinkId=287166') | Set-Content $prereqs
        (Get-Content $prereqs).replace('https://download.microsoft.com/download/6/E/4/6E48E8AB-DC00-419E-9704-06DD46E5F81D/NDP472-KB4054530-x86-x64-AllOS-ENU.exe', 'https://go.microsoft.com/fwlink/?linkid=863265') | Set-Content $prereqs

        Show-Progress -Percent 11  -Activity "Installing prerequisites"  -Status "Installing prerequisites"
        Write-Output "Sifon-MuteProgress"
            Install-SitecoreConfiguration -Path $prereqs

            "==================================="
            "Installing additional prerequisites:"
            "==================================="
            function Install-Feature ($feature)
            {
                $mst = (Get-WindowsOptionalFeature -online -FeatureName $feature).State
                if($mst -and $mst -eq 'Enabled')
                {
                    "$feature already enabled"
                }
                else
                {
                    "Installing $feature ..."
                    Enable-WindowsOptionalFeature -online -FeatureName $feature 
                    "$feature has been installed"
                }
            }            
            
            # Install-Feature("IIS-NetFxExtensibility")
            # Install-Feature("IIS-ASPNET")
            # Install-Feature("IIS-HttpRedirect")
            # Install-Feature("IIS-BasicAuthentication")
            Install-Feature("IIS-ManagementScriptingTools")
            Install-Feature("IIS-HostableWebCore")

        Write-Output "Sifon-UnmuteProgress"        
    }
}