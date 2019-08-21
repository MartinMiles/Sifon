iisreset /stop
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory(""{GetFilesystemBackupArchive}"", ""{targetDirectory}"")
iisreset /start

Restore-SqlDatabase -ServerInstance \"{SqlServer}\" -Database \"{databaseName}\" -BackupFile \"{backupFile}\" -ReplaceDatabase