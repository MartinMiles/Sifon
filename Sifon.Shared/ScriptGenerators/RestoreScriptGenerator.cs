﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Shared.Statics;

namespace Sifon.Shared.ScriptGenerators
{
    internal class RestoreScriptGenerator : BaseScriptGenerator, IScript
    {
        private string ArchiveName => $"{_model.SitecoreInstance.Replace($"{_model.DestinationFolder}\\", "").Replace(".zip", "")}";
        public override string Script => Path.Combine(Settings.Folders.Cache, $"Restore_{ArchiveName}_{DateTime.Now:yyyy-MM-dd}.ps1");

        internal RestoreScriptGenerator(IBackupRestoreModel model, IProfile profile) : base(model, profile)
        {
            executionScript = GenerateParameters(CommerceSitesParameters);

            if (model.ProcessWebroot)
            {
                GenerateFilesystemScript();
            }

            if (model.ProcessDatabases)
            {
                GenerateDatabaseScript();
            }

            GenerateServicesScript();

            ShowFinalOutput("Restore");
            
            SaveScriptToCacheFile();
        }

        private void GenerateFilesystemScript()
        {
            executionScript += _serviceScriptGenerator.Stop(Settings.Services.MarketingAutomation, 10);
            executionScript += _serviceScriptGenerator.Stop(Settings.Services.IndexWorker, 13);
            executionScript += _serviceScriptGenerator.Stop(Settings.Services.ProcessingEngineService, 27);

            if (_model.ProcessWebroot)
            {
                executionScript += _filesScriptGenerator
                    .Restore(Settings.Parameters.Website, Settings.Parameters.Webroot, 20);
            }

            if (_model.ProcessXconnect)
            {
                executionScript += _filesScriptGenerator
                    .Restore(Settings.Parameters.XConnect, Settings.Parameters.XConnectFolder, 40);
            }

            if (_model.ProcessIDS)
            {
                executionScript += _filesScriptGenerator
                    .Restore(Settings.Parameters.IdentityServer, Settings.Parameters.IdentityServerFolder, 50);
            }

            if (_model.ProcessCommerce)
            {
                for(int i = 0; i < _model.CommerceSites.Count(); i++)
                {
                    //var key = CommerceSitesParameters.ElementAt(i).Key;
                    var key = Path.GetFileName(_model.CommerceSites.ElementAt(i).Value);

                    executionScript += _filesScriptGenerator.Restore(key, key+"Folder", 52 + i*2);
                }
            }
        }

        private void GenerateServicesScript()
        {

            int progressCalculation = 80;
            int service1 = 85;
            int service2 = 90;
            int service3 = 95;

            executionScript += _iisScriptGenerator.Start(progressCalculation);
            executionScript += _serviceScriptGenerator.Start(Settings.Services.IndexWorker, service1);
            executionScript += _serviceScriptGenerator.Start(Settings.Services.ProcessingEngineService, service2);
            executionScript += _serviceScriptGenerator.Start(Settings.Services.MarketingAutomation, service3);


            //if (!_model.ProcessDatabases)
            {
                executionScript += "Write-Progress -Activity $activity -CurrentOperation 'restore complete.' -PercentComplete 100";
            }
        }

        private void GenerateDatabaseScript()
        {
            string progressCalculation = _model.ProcessWebroot ? "60 + 20" : "0 + 80";

            var databaseScript = new StringBuilder(Environment.NewLine);
            databaseScript.AppendLine("$i = 0");
            databaseScript.AppendLine("foreach ($database in $databases)");
            databaseScript.AppendLine("{");
            databaseScript.AppendLine("   $i++");
            databaseScript.AppendLine($"   $percentComplete = {progressCalculation} / $databases.Length * $i");
            databaseScript.AppendLine($@"   Write-Progress -Activity $activity -CurrentOperation ""restoring database: $database"" -PercentComplete $percentComplete");

            //TODO: Alter only if exists
            //databaseBackupScript.AppendLine(@"  invoke-sqlcmd -ServerInstance ""$ServerInstance"" -Query ""ALTER DATABASE [$database] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;""");

            var relocate = false;

            if (relocate)
            {
                // TODO: Some of data archives come as "$($database)_Data" others default are "$($database)". Log seems always to be "$($database)_Log"

                databaseScript.AppendLine(@" $sqlServerSnapinVersion = (Get-Command Restore-SqlDatabase).ImplementingType.Assembly.GetName().Version.ToString()  ");
                databaseScript.AppendLine(@" $assemblySqlServerSmoExtendedFullName = ""Microsoft.SqlServer.SmoExtended, Version=$sqlServerSnapinVersion, Culture=neutral, PublicKeyToken=89845dcd8080cc91""  ");
                databaseScript.AppendLine(@" $folder = ""c:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA""  "); // TODO: hardcode: find this folder yourself
                databaseScript.AppendLine(@" $mdf = New-Object ""Microsoft.SqlServer.Management.Smo.RelocateFile, $assemblySqlServerSmoExtendedFullName""(""$($database)"", ""$folder\$database.mdf"")  ");
                databaseScript.AppendLine(@" $ldf = New-Object ""Microsoft.SqlServer.Management.Smo.RelocateFile, $assemblySqlServerSmoExtendedFullName""(""$($database)_Log"", ""$folder\$database.ldf"")  ");
                databaseScript.AppendLine(@" restore-sqldatabase -serverinstance ""$ServerInstance"" -database ""$database"" -backupfile ""$targetFolder\$database.bak"" -RelocateFile @($mdf,$ldf)  ");
            }
            else
            {
                databaseScript.AppendLine(@"   Restore-SqlDatabase -ServerInstance ""$ServerInstance"" -Database ""$database"" -BackupFile ""$targetFolder\$database.bak"" -ReplaceDatabase");
            }

            databaseScript.AppendLine(@"   Write-Output ""Database $database has been restored""");
            databaseScript.AppendLine("}");

            executionScript += databaseScript.ToString();
        }
    }
}
