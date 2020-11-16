function Show-Progress
(
    [int]$Percent,
    [string]$Activity = '',
    [string]$Status = ''
)
{
    Write-Progress -Activity $Activity -Status $Status -PercentComplete $Percent
}