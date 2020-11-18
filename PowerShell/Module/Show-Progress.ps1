function Show-Progress
(
    [int]$Percent,
    [string]$Activity = 'Operation in progress',
    [string]$Status = ''
)
{
    if($Status.Length > 0){
        Write-Progress -PercentComplete $Percent -Activity $Activity -Status $Status
    }
    else{
        Write-Progress -PercentComplete $Percent -Activity $Activity
    }    
}