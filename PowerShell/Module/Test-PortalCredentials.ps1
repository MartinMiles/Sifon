
function Test-PortalCredentials([PSCredential]$PortalCredentials)
{
    $DownloadsFolderPath = (Get-Location).Path + "\Downloads"
    New-Item -ItemType Directory -Force -Path $DownloadsFolderPath | Out-Null

    $file = "$DownloadsFolderPath\Sitecore.Platform.Assemblies 10.0.0 rev. 004346.zip"

    Write-Output "Sifon-MuteWarnings"
    Write-Output "Sifon-MuteProgress"
        Download-Resource -PortalCredentials $PortalCredentials -ResourceUrl "https://dev.sitecore.net/~/media/E85A860E718C4FF9B00D56AB306019FA.ashx" -TargertFilename $file
    Write-Output "Sifon-UnmuteProgress"
    Write-Output "Sifon-UnmuteWarnings"

    if(Test-Path -Path $file)
    {
        $length = (Get-Item $file).length
        $length
        if($length -eq 17345)
        {
            Remove-Item -Path $file
            return $true
        }
    }

    return $false
}
