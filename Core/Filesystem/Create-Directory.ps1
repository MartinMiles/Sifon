param(
    [string]$Directory
)

$out = New-Item -ItemType directory -Path $Directory
Test-Path $Directory