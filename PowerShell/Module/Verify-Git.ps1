Function Verify-Git
{
        try {
            git --version | Out-Null
            return $true
        }
        catch{
            return $false
        }    
}
