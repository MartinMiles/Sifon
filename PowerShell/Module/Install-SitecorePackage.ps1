Function Install-Sitecorepackage {
    param(
        [Parameter(Mandatory=$true)]
        [string]$PackageFullPath,

        [Parameter(Mandatory=$true)]
        [string]$Webroot,

        [Parameter(Mandatory=$true)]
        [string]$Hostbase
    )

    $aspxFullpath = $PSCommandPath.Replace('.ps1','.aspx')
    $aspx = Split-Path $aspxFullpath -leaf

    Copy-Item $aspxFullpath -destination $Webroot -force

    $packagesFolder= "$Webroot\App_Data\packages"
    Copy-Item $PackageFullPath -destination $packagesFolder -force

    $moduleToInstall = Split-Path -Path $PackageFullPath -Leaf -Resolve

    Write-Host "Installing module: " $moduleToInstall -ForegroundColor Green ; 
    $urlInstallModules = "$Hostbase/$aspx" + "?modules=" + $moduleToInstall

    try { Invoke-RestMethod $urlInstallModules -TimeoutSec 720 }
    catch { Write-error "Filed to make a request to package installer." }

    Remove-Item -Path "$Webroot\$aspx" -Force
}
