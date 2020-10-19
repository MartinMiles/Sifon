function Save-BackupInfo([string]$xml, [string]$OutputFile)
{
    Write-Output $xml | out-File -FilePath $OutputFile
}

