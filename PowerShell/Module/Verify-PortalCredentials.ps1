Function Verify-PortalCredentials($PortalCredentials){

    if($null -eq $PortalCredentials){

        Show-Message -Fore Red -Back White -Text "Sitecore Portal Credentials missing"
        Write-Output "In order to be able downloading the resorces from Sitecore Developers Portal, please enter your Sitecore credintials first."
        Write-Output "You can do that from 'Sitecore Portal Credentials' under Sifon 'Settings' menu."
        Write-Progress -Activity "Downloading resources from Sitecore Developers Portal" -CurrentOperation "Operation complete" -PercentComplete 100
        exit
    }
}