param(
	[string]$Type,
	[string]$Directory

)

If ($Type -eq 'File'){
  ls -File $Directory |  ForEach-Object { $_.FullName }
}
If ($Type -eq 'Directory'){
  ls -Directory $Directory |  ForEach-Object { $_.FullName }
}
