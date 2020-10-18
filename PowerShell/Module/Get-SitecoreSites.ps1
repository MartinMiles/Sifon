function Get-SitecoreSites(){
    Get-ChildItem -Path IIS:\Sites | where { Test-Path($_.PhysicalPath + "\bin\Sitecore.Kernel.dll") } | % {$_.Name }
}