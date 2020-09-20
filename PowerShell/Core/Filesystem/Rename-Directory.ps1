param(
    [string]$OldPath,
    [string]$NewPath
)
Rename-Item -path $OldPath -newName $NewPath
Test-Path $NewPath