function Install-Sitecore
{
    param(
        [Parameter(Mandatory=$true)]
        $Params
    )

    "."
    Show-Message -Fore white -Back yellow -Text "Sitecore XP0 Installation"
    "."

    $folder = (Get-Location).Path + "\Downloads\Install"
    
    $WindowsBuildNumber = (get-wmiobject -Class win32_OperatingSystem).BuildNumber;
    $buildNumber = [int]$WindowsBuildNumber
    
    # change and test for XM
    if($buildNumber -ge 22000)
    {
        $json = "$folder\xconnect-xp0.json"
        Write-Output $json
        (Get-Content $json -raw) -replace '{?\s*\"Name\": \"\[variable\(''Services\.MarketingAutomationEngine\.Name''\)\]\",?\s*\"Status\": \"Running\"?\s*},', '' | Out-File $json -NoNewLine
    }    


 
     If($Params.IsXM) 
     { 
        $SiteCoreContentManagementPackage = (Get-ChildItem "$folder\Sitecore * rev. * (XM) (OnPrem)_cm.scwdp.zip").FullName
        $SitecoreContentDeliveryPackage = (Get-ChildItem "$folder\Sitecore * rev. * (XM) (OnPrem)_cd.scwdp.zip").FullName
        $IdentityServerPackage = (Get-ChildItem "$folder\Sitecore.IdentityServer * rev. * (OnPrem)_identityserver.scwdp.zip").FullName
        "SiteCoreContentManagementPackage = $SiteCoreContentManagementPackage"
        "SitecoreContentDeliveryPackage = $SitecoreContentDeliveryPackage"
        "IdentityServerPackage = $IdentityServerPackage"

        $singleDeveloperParams = @{
        Path = "$folder\\XM1-SingleDeveloper.json"
        SqlServer = $Params.SqlServer
        SqlAdminUser = $Params.SqlAdminUser
        SqlAdminPassword = $Params.SqlAdminPassword
        SitecoreAdminPassword = $Params.SitecoreAdminPassword
        SolrUrl = $Params.SolrUrl
        SolrRoot = $Params.SolrRoot
        SolrService = $Params.SolrService
        Prefix = $Params.Prefix
        IdentityServerCertificateName = $Params.IdentityServerSiteName
        IdentityServerSiteName = $Params.IdentityServerSiteName
        LicenseFile = $Params.LicenseFile
        SiteCoreContentManagementPackage = (Get-ChildItem "$folder\Sitecore * rev. * (XM) (OnPrem)_cm.scwdp.zip").FullName
        SitecoreContentDeliveryPackage = (Get-ChildItem "$folder\Sitecore * rev. * (XM) (OnPrem)_cd.scwdp.zip").FullName
        IdentityServerPackage = (Get-ChildItem "$folder\Sitecore.IdentityServer * rev. * (OnPrem)_identityserver.scwdp.zip").FullName
        SitecoreContentManagementSitename = $Params.SitecoreSiteName
        SitecoreContentDeliverySitename = $Params.SitecoreSiteName + "_cd"
        PasswordRecoveryUrl = "https://$($Params.SitecoreSiteName)"
        SitecoreIdentityAuthority = "https://$($Params.IdentityServerSiteName)"
        ClientSecret =  "SIF-Default"
        AllowedCorsOrigins = "https://$($Params.SitecoreSiteName)"
        SitePhysicalRoot = $Params.SitePhysicalRoot
        Update = $false
        DeployToElasticPoolName = ""
        }
    }

    else { 
        $singleDeveloperParams = @{
        Path = "$folder\\XP0-SingleDeveloper.json"
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
    }

    Push-Location $folder
    Write-Output "Sifon-MuteProgress"
        Install-SitecoreConfiguration @singleDeveloperParams *>&1 | Tee-Object "$folder\SingleDeveloper.log"
    Write-Output "Sifon-UnmuteProgress"
    Pop-Location

    if(Test-Path -Path $folder)
    {
        Write-Output "Sifon-MuteErrors"
            Remove-Item -LiteralPath $folder -Force -Recurse | Out-Null
        Write-Output "Sifon-UnmuteErrors"
    }

    if($buildNumber -ge 22000)
    {
        "."
        "."
        $Win11_Message  = @(
            "Attention!",
            "",
            "It looks as the target machine run on Windows 11, therefore an extra step may be required.",
            "",
            "Marketing Automation service is currently stopped, you can start it manually in few steps.",
            "Please select and right-click the URL below to open it in a browser to find out more info.",
            "",
            "https://sifon.uk/docs/Windows-11.md"
            );

        Show-Message -Fore white -Back yellow -Text $Win11_Message
        "."
        "."
    }
    
    Show-Progress -Percent 100  -Activity "Done"  -Status "Done"
}