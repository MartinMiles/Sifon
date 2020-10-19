function Extract-BackupInfo
(
    [string]$file,
    [string]$info,
    [string]$extractToFile
)
{
    if(Test-Path -Path $file)
    {
        Add-Type -Assembly System.IO.Compression.FileSystem
        $zip = [IO.Compression.ZipFile]::OpenRead($file)
        $zip.Entries | where {$_.Name -like $info} | foreach {[System.IO.Compression.ZipFileExtensions]::ExtractToFile($_, $extractToFile, $true)}
        $zip.Dispose()
        if(Test-Path -Path $extractToFile){
        $xml = [IO.File]::ReadAllText($extractToFile)
        $xml
        Remove-Item -Path $extractToFile -Force -Recurse
        }
    }
}