# This function is conservated until futher version, despite it works. Initially supposed to read showConfig.aspx, it got stuck with inablity of getting through Idetity Server
# Three commented lines below culd be uncommented to attempt getting through woth JWT access token, which itself works

function Read-UrlContent
(
    [string]$Webroot = $null,
    [string]$Hostbase = $null,
    [string]$RelativeUrl
)
{
add-type @"
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    public class TrustAllCertsPolicy : ICertificatePolicy {
        public bool CheckValidationResult(
            ServicePoint srvPoint, X509Certificate certificate,
            WebRequest request, int certificateProblem) {
            return true;
        }
    }
"@
    [System.Net.ServicePointManager]::CertificatePolicy = New-Object TrustAllCertsPolicy
  
    if($null -eq $Hostbase -or $Hostbase.Length -eq 0)
    {
        if($null -eq $Webroot)
        {
            exit
        }

        $Hostbase = Get-InstanceUrl -Webroot $Webroot
    }

    # $token = Get-IdentityToken -identityserverUrl 'https://sitecoreBase.identityserver' -username 'sitecore\admin' -password 'b'
    # $headers = @{Authorization = "Bearer $token"}
    # $request = (Invoke-WebRequest -Uri ($Hostbase + $RelativeUrl) -UseBasicParsing -Headers $headers)    

    $request = (Invoke-WebRequest -Uri ($Hostbase + $RelativeUrl) -UseBasicParsing)
    return $request.Content
}
