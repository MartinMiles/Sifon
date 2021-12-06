function Install-Sitecore
{
    param(
        [Parameter(Mandatory=$true)]
        $Params
    )

    "."
    Show-Message -Fore white -Back yellow -Text "Sitecore XP0 Installation"
    "."

    # if([System.Environment]::OSVersion.Version.Build -ge 22000)
    # {
    #     New-Item `
    #     'HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.3\Server' `
    #     -Force | Out-Null
            
    #     New-ItemProperty `
    #     -path 'HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.3\Server' `
    #     -name 'Enabled' -value '0' -PropertyType 'DWord' -Force | Out-Null
            
    #     New-ItemProperty `
    #     -path 'HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.3\Server' `
    #     -name 'DisabledByDefault' -value 1 -PropertyType 'DWord' -Force | Out-Null
    # }

    $folder = (Get-Location).Path + "\Downloads\Install"

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