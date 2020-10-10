param(
	[string]$Filepath
)

if(Test-Path $Filepath){
    $hash = Get-FileHash -Algorithm MD5 $Filepath
    if($hash.Hash -ne $null){
        $hash.Hash.ToLowerInvariant()
    }
}