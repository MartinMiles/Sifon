Function Verify-PortalCredentials($PortalCredentials){

    if($null -eq $PortalCredentials){
        Write-Output "-----------------------------------"
        Write-Error  "Sitecore Portal Credentials missing"
        Write-Output "-----------------------------------"
        Write-Output "In order to be able downloading the resorces from Sitecore Developers Portal, please enter your Sitecore credintials first."
        Write-Output "You can do that from 'Sitecore Portal Credentials' under Sifon 'Settings' menu."
        Write-Progress -Activity "Downloading resources from Sitecore Developers Portal" -CurrentOperation "Operation complete" -PercentComplete 100
        exit
    }
}