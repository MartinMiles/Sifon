function Show-Message {
param (
    [string[]]$Text,
    [string]$Fore,
    [string]$Back
    )
    
    $fc = "#COLOR:$Fore#".ToUpper()
    $bc = "#COLOR:$Back#".ToUpper()
    $len = ($Text | Measure-Object -Maximum -Property Length).Maximum
    $frame = "=" * $len

    Write-Output "$bc$frame"

    foreach ($line in $Text) {
        Write-Output "$fc$line"
    }
    
    Write-Output "$bc$frame"
}
