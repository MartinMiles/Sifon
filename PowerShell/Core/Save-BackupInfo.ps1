param
(
   [string]$xml,
   [string]$OutputFile
)

$xml | out-File -FilePath $OutputFile