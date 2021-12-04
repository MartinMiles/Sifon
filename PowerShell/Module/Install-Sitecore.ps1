function Install-Sitecore
{
    param(
        [Parameter(Mandatory=$true)]
        $Params
    )

    "."
    Show-Message -Fore white -Back yellow -Text "Sitecore XP0 Installation"
    "."

    "Parameters:"
    "==========="
    "Installation package: $($Params.DownloadFile)"
    "Install prerequisites: $($Params.InstallPrerequisites)"
    "Create Sifon profile: $($Params.CreateProfile)"
    "."
    
    $Url = "https://sitecoredev.azureedge.net/~/media/" + $Params.DownloadHash + ".ashx"
    
    # todo copy license to destination (on remote)

    New-Item -ItemType Directory -Force -Path ((Get-Location).Path + "\Downloads\") | Out-Null

    [string]$FullPath = (Get-Location).Path + "\Downloads\" + $Params.DownloadFile
    if(!(Test-Path -Path $FullPath))
    {
        "."
        Show-Message -Fore white -Back LightGray -Text @("Sitecore installation package not found locally.","Downloading it from Sitecore development portal.")
        "."    
        Show-Progress -Percent 3  -Activity "Downloading $($Params.DownloadFile) ..."  -Status "Downloading Sitecore"
        Write-Output "Sifon-MuteProgress"
            Invoke-WebRequest -Uri $Url -OutFile $FullPath
        Write-Output "Sifon-UnmuteProgress"
    }
    else
    {
        "Found file: $FullPath"
    }

    if(!(Test-Path -Path $FullPath))
    {
        "."
        Show-Message -Fore red -Back yellow -Text @("XP0 installer not downloaded.","File missing at: $FullPath")    

        exit
    }

    $folder = (Get-Location).Path + "\Downloads\Install"

    if(Test-Path -Path $folder)
    {
        Write-Output "Sifon-MuteErrors"
            Remove-Item -LiteralPath $folder -Force -Recurse | Out-Null
        Write-Output "Sifon-UnmuteErrors"
    }

    New-Item -ItemType Directory -Force -Path $folder | Out-Null
    Show-Progress -Percent 8  -Activity "Extracting $($Params.DownloadFile) ..."  -Status "Extracting Sitecore"
    Write-Output "Sifon-MuteProgress"
        "Extracting installation package: $FullPath"
        Expand-Archive -Path $FullPath -DestinationPath $folder
        "."
        $conf = Get-ChildItem -Path $folder -Filter "XP0 Configuration files*.zip"
        
        Expand-Archive -Path "$folder\$conf" -DestinationPath $folder
    Write-Output "Sifon-UnmuteProgress"


    if($Params.InstallPrerequisites)
    {
        $prereqs = "$folder\prerequisites.json"
        (Get-Content $prereqs).replace('https://download.microsoft.com/download/C/F/F/CFF3A0B8-99D4-41A2-AE1A-496C08BEB904/WebPlatformInstaller_amd64_en-US.msi', 'https://go.microsoft.com/fwlink/?LinkId=287166') | Set-Content $prereqs
        (Get-Content $prereqs).replace('https://download.microsoft.com/download/6/E/4/6E48E8AB-DC00-419E-9704-06DD46E5F81D/NDP472-KB4054530-x86-x64-AllOS-ENU.exe', 'https://go.microsoft.com/fwlink/?linkid=863265') | Set-Content $prereqs

        Show-Progress -Percent 11  -Activity "Installing prerequisites"  -Status "Installing prerequisites"
        Write-Output "Sifon-MuteProgress"
            Install-SitecoreConfiguration -Path $prereqs
        Write-Output "Sifon-UnmuteProgress"        
    }

    # Install XP0 via combined partials file.
    $singleDeveloperParams = @{
        Path = "$folder\XP0-SingleDeveloper.json"
        SqlServer = $Params.SqlServer
        SqlAdminUser = $Params.SqlAdminUser
        SqlAdminPassword = $Params.SqlAdminPassword
        SitecoreAdminPassword = $Params.SitecoreAdminPassword
        SolrUrl = $Params.SolrUrl
        SolrRoot = $Params.SolrRoot
        SolrService = $Params.SolrService
        Prefix = $Params.Prefix
        XConnectCertificateName = $Params.XConnectSiteName
        IdentityServerCertificateName = $Params.IdentityServerSiteName
        IdentityServerSiteName = $Params.IdentityServerSiteName
        LicenseFile = $Params.LicenseFile
            XConnectPackage = (Get-ChildItem "$folder\Sitecore * rev. * (OnPrem)_xp0xconnect.scwdp.zip").FullName
            SitecorePackage = (Get-ChildItem "$folder\Sitecore * rev. * (OnPrem)_single.scwdp.zip").FullName
            IdentityServerPackage = (Get-ChildItem "$folder\Sitecore.IdentityServer * rev. * (OnPrem)_identityserver.scwdp.zip").FullName
        XConnectSiteName = $Params.XConnectSiteName
        SitecoreSitename = $Params.SitecoreSiteName
            PasswordRecoveryUrl = "https://$($Params.SitecoreSiteName)"
            SitecoreIdentityAuthority = "https://$($Params.IdentityServerSiteName)"
            XConnectCollectionService = "https://$($Params.XConnectSiteName)"
            ClientSecret = "SIF-Default"
            AllowedCorsOrigins = "https://$($Params.SitecoreSiteName)"
            SitePhysicalRoot = $Params.SitePhysicalRoot
    }

    Push-Location $folder
    Write-Output "Sifon-MuteProgress"
        Install-SitecoreConfiguration @singleDeveloperParams *>&1 | Tee-Object "$folder\XP0-SingleDeveloper.log"
    Write-Output "Sifon-UnmuteProgress"
    Pop-Location

    if(Test-Path -Path $folder)
    {
        Write-Output "Sifon-MuteErrors"
            Remove-Item -LiteralPath $folder -Force -Recurse | Out-Null
        Write-Output "Sifon-UnmuteErrors"
    }

    Show-Progress -Percent 100  -Activity "Done"  -Status "Done"
}