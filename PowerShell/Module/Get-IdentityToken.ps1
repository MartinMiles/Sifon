function Get-IdentityToken
(
    $identityserverUrl,
    $username = "sitecore\admin",
    $password = "b"
)
{
    $tokenendpointurl = $identityserverUrl + "/connect/token"
    $granttype = "password" # client_credentials / password 
    $client_id = "sifon-api"
    $client_secret = "ClientSecret"
    $scope = "openid"

    function Convert-FromBase64StringWithNoPadding([string]$data)
    {
        $data = $data.Replace('-', '+').Replace('_', '/')
        switch ($data.Length % 4)
        {
            0 { break }
            2 { $data += '==' }
            3 { $data += '=' }
            default { throw New-Object ArgumentException('data') }
        }
        return [System.Convert]::FromBase64String($data)
    }

    function FetchToken
    {
        $body = @{
            grant_type = $granttype
            scope = $scope
            client_id = $client_id
            client_secret = $client_secret    
            username = $username
            password = $password
        }
            
        $resp = Invoke-RestMethod -Method Post -Body $body -Uri $tokenendpointurl 
        $parts = $resp.access_token.Split('.');

        $baseDecoded = Convert-FromBase64StringWithNoPadding($parts[1])
        $decoded = [System.Text.Encoding]::UTF8.GetString($baseDecoded)

        # Write-Host "`***** SUCCESSFULLY FETCHED TOKEN ***** `n" -foreground Green

        # Write-Host "`JWT payload: `n" -foreground Yellow
        $decoded = $decoded | ConvertFrom-Json | ConvertTo-Json
        # Write-Host $decoded -foreground White

        # Write-Host
        # Write-Host "`ACCESSTOKEN: `n" -foreground Yellow
        return ($resp.access_token | Format-Table -Wrap | Out-String ) # -foreground White
        # Write-Host    
    }  

        try
    {
        return FetchToken
    }
    catch 
    {          
        Write-Host "`***** FETCHING TOKEN EXPERIENCED ERROR ***** `n" -foreground Red     
        Write-Host $_  -foreground Red
        Write-Host     
    }
}
