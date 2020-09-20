 Try {
add-type @"
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;

    public static class CustomCertificateValidationCallback {
        public static void Install() 
        {
            ServicePointManager.ServerCertificateValidationCallback += CustomCertificateValidationCallback.CheckValidationResult;
        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
"@
} Catch { }
[CustomCertificateValidationCallback]::Install()

   $TCPProperties = [System.Net.NetworkInformation.IPGlobalProperties]::GetIPGlobalProperties()            
    $Connections = $TCPProperties.GetActiveTcpListeners()            
  
  $list = New-Object 'System.Collections.Generic.List[String[]]'
 
   $IgnorePorts = 80,135,139,443,445,1434
 
   $AllPorts = $Connections | Where-Object {$_.address.AddressFamily -eq "InterNetwork" } | Select-Object -Property Port 
 
   $PortsList =  New-Object System.Collections.ArrayList($null)
   Foreach ($port in $AllPorts){
		If($IgnorePorts.Contains($port.Port)) {continue}
		[void]$PortsList.Add($port)
   }
	$Ports = $PortsList.ToArray()
	
For ($i=0; $i -le $Ports.Length; $i++) 
{
	$port = $Ports[$i]
	
	Write-Progress -Activity "Checking ports" -Status $port -PercentComplete (($i+1) * 100 / $Ports.Length);

	If($IgnorePorts.Contains($port.Port)) {continue}

    [System.Uri]$Url = "https://localhost:" + $port.Port + "/solr/admin/info/system?wt=json"
    
    $RestError = $null
    Try {
      $response = Invoke-RestMethod -Uri $Url -Method Get -ErrorVariable RestError -ErrorAction SilentlyContinue -TimeoutSec 2
    } Catch {
      $RestError = $_
    }

    if ($RestError)
    {
        $HttpStatusCode = $RestError.ErrorRecord.Exception.Response.StatusCode.value__
        $HttpStatusDescription = $RestError.ErrorRecord.Exception.Response.StatusDescription

        #Throw "Http Status Code: $($HttpStatusCode) `nHttp Status Description: $($HttpStatusDescription)"
        #Write-Output "Failed $port.Port"
    }
    else {
    
        #Write-Output "Success $port.Port"
        $path = $response.solr_home 
        $version = $response.lucene | Select-Object -Property solr-spec-version 
        #$version| Get-Member

        [string[]]$arr = $port.Port,$version,$path
        $list.Add($arr)
    }
}

$list