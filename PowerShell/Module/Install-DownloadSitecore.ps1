function Install-DownloadSitecore
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

    # Sample path: c:\Program Files\Sifon\Downloads\10.0.1\On Premises deployment\Sitecore 10.0.1 rev. 004842 (WDP XP0 packages).zip
    $directory = (Get-Location).Path + "\Downloads\" + $Params.DownloadFolder + "\On Premises deployment\"

    New-Item -ItemType Directory -Force -Path $directory | Out-Null

    [string]$FullPath = $directory + $Params.DownloadFile
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
}