using System;
using Sifon.Code.Statics;

namespace Sifon.Code.ScriptGenerators
{
    public class FilesScriptGenerator
    {
        public string Backup(string siteFolderParamName, int percents)
        {
            string _suffix = siteFolderParamName != Settings.Parameters.Webroot ? $".{siteFolderParamName}" : String.Empty;
            
            return $@"
                    $destinationFile = ""$targetFolder\$Website{_suffix}.zip""
                    Write-Progress -Activity $activity -CurrentOperation ""creating $Website{_suffix} website archive"" -PercentComplete {percents}
                    If(Test-path $destinationFile) {{Remove-item $destinationFile}}
                    Add-Type -assembly 'system.io.compression.filesystem'
                    [io.compression.zipfile]::CreateFromDirectory(${siteFolderParamName}, $destinationFile)
                    Remove-Item ${siteFolderParamName}\BackupInfo.xml
                ";
        }

        public string Restore(string zipArchiveParameterName, string destinationFolderParameterName, int percents)
        {
            return $@"
                    Write-Progress -Activity $activity -CurrentOperation ""restoring ${zipArchiveParameterName} web folder from archive"" -PercentComplete {percents}
                    Add-Type -AssemblyName System.IO.Compression.FileSystem
                    [System.IO.Compression.ZipFile]::ExtractToDirectory(${zipArchiveParameterName}, ${destinationFolderParameterName})
                    Remove-Item ${destinationFolderParameterName}\BackupInfo.xml
                    Write-Output ""Webfolder for ${zipArchiveParameterName} has been restored from backup""
                ";
        }

        public string Remove(string webfolderParameterName, int percents)
        {
            return $@"
                    Write-Progress -Activity $activity -CurrentOperation 'removing {webfolderParameterName} web folder' -PercentComplete {percents}
                    Remove-Item ""${webfolderParameterName}\*"" -Recurse
                    Write-Output ""Webfolder ${webfolderParameterName} has been cleaned out""
                    ";
        }
    }
}
