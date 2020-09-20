param(
    [string]$Directory
)
Remove-Item -LiteralPath $Directory -Force -Recurse
$result = -Not (Test-Path $Directory)
$result