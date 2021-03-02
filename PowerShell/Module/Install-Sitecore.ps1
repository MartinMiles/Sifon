function Install-Sitecore
{
    param(
        [Parameter(Mandatory=$true)]
        $Params
    )

    $Params.DownloadFile
    $Url = "https://sitecoredev.azureedge.net/~/media/" + $Params.DownloadHash + ".ashx"

    "InstallPrerequisites = $($Params.InstallPrerequisites)"
    "CreateProfile = $($Params.CreateProfile)"
    "."

    # todo copy license to destination (on remote)

    New-Item -ItemType Directory -Force -Path ((Get-Location).Path + "\Downloads\") | Out-Null

    [string]$FullPath = (Get-Location).Path + "\Downloads\" + $Params.DownloadFile
    if(!(Test-Path -Path $FullPath))
    {
        Show-Progress -Percent 10  -Activity "Downloading $($Params.DownloadFile) ..."  -Status "Downloading Sitecore"
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

    New-Item -ItemType Directory -Force -Path $folder | Out-Null
    Show-Progress -Percent 15  -Activity "Extracting $($Params.DownloadFile) ..."  -Status "Extracting Sitecore"
    Write-Output "Sifon-MuteProgress"
        Expand-Archive -Path $FullPath -DestinationPath $folder
        
        $conf = Get-ChildItem -Path $folder -Filter "XP0 Configuration files*.zip"
        
        Expand-Archive -Path "$folder\$conf" -DestinationPath $folder
    Write-Output "Sifon-UnmuteProgress"


    if($Params.InstallPrerequisites)
    {
        Show-Progress -Percent 21  -Activity "Installing prerequisites"  -Status "Installing prerequisites"
        Write-Output "Sifon-MuteProgress"
            Install-SitecoreConfiguration -Path "$folder\prerequisites.json"
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
    Install-SitecoreConfiguration @singleDeveloperParams *>&1 | Tee-Object "$folder\XP0-SingleDeveloper.log"
    Pop-Location

    Write-Output "Sifon-MuteErrors"
    if(Test-Path -Path $folder)
    {
        Remove-Item -LiteralPath $folder -Force -Recurse | Out-Null
    }
    Write-Output "Sifon-UnmuteErrors"


    Show-Progress -Percent 100  -Activity "Done"  -Status "Done"

}