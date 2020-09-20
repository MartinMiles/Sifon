param(
    [string]$File
)
Remove-Item -Path $File -Force -Recurse
$result = -Not (Test-Path $File)
$result