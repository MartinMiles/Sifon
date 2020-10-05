using System;
using System.IO;
using System.Linq;
using System.Text;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Shared.Statics;

namespace Sifon.Shared.ScriptGenerators
{
    internal class BackupScriptGenerator : BaseScriptGenerator, IScript
    {
        public override string Script { get; protected set; }

        internal BackupScriptGenerator(IBackupRemoverViewModel model, IProfile profile) : base(model, profile)
        {
            Script = Path.Combine(Settings.Folders.Cache, $"Backup_{profile.Website}_{DateTime.Now:yyyy-MM-dd}.ps1");

            executionScript = GenerateParameters(CommerceSitesParameters);

            GenerateFilesystemScript();

            if (model.ProcessDatabases)
            {
                GenerateDatabaseScript();
            }

            ShowFinalOutput("Backup");

            SaveScriptToCacheFile();
        }

        private void GenerateFilesystemScript()
        {
            // TODO: re-work progress calculation
            //string progressCalculation = _model.ProcessDatabases ? "60" : "90";

            executionScript += _serviceScriptGenerator.StopDependentServices();

            executionScript += _iisScriptGenerator.Stop(18);

            if (_model.WebsiteChecked)
            {
                executionScript += _filesScriptGenerator.Backup(Settings.Parameters.Webroot, 20);
            }

            if (_model.XConnectChecked)
            {
                executionScript += _filesScriptGenerator.Backup(Settings.Parameters.XConnectFolder, 30);
            }

            if (_model.IdentityChecked)
            {
                executionScript += _filesScriptGenerator.Backup(Settings.Parameters.IdentityServerFolder, 40);
            }

            if (_model.PublishingChecked)
            {
                executionScript += _filesScriptGenerator.Backup(Settings.Parameters.HorizonFolder, 45);
            }
            if (_model.HorizonChecked)
            {
                executionScript += _filesScriptGenerator.Backup(Settings.Parameters.PublishingServiceFolder, 50);
            }

            if (_model.CommerceChecked)
            {
                for (int i = 0; i < _model.CommerceSites.Count; i++)
                {
                    var folderName = CommerceSitesParameters.ElementAt(i).Key;
                    executionScript += _filesScriptGenerator.Backup(folderName, 50+i);
                }
            }

            executionScript += _iisScriptGenerator.Start(55);

            executionScript += _serviceScriptGenerator.StartService(Settings.Services.IndexWorker, 56);
            executionScript += _serviceScriptGenerator.StartService(Settings.Services.ProcessingEngineService, 57);
            executionScript += _serviceScriptGenerator.StartService(Settings.Services.MarketingAutomation, 58);

            if (_model.HorizonChecked)
            {
                //TODO: Own starting script from plugin
                //Start-Process -FilePath $exe  -NoNewWindow
                //executionScript += _serviceScriptGenerator.StartService(Settings.Process.PublishingHost, 59);
            }

            if (!_model.ProcessDatabases)
            {
                executionScript += "Write-Progress -Activity $activity -CurrentOperation 'backup complete.' -PercentComplete 100";
            }
        }

        private void GenerateDatabaseScript()
        {
            string progressCalculation = _model.WebsiteChecked ? "60 + 40" : "0 + 100";

            var databaseScript = new StringBuilder(Environment.NewLine);
            databaseScript.AppendLine("$i = 0");
            databaseScript.AppendLine("foreach ($database in $databases)");
            databaseScript.AppendLine("{");
            databaseScript.AppendLine("   $i++");
            databaseScript.AppendLine($@"   Write-Progress -Activity $activity -CurrentOperation ""backing up database: $database"" -PercentComplete ({progressCalculation}/$databases.Length*$i)");
            databaseScript.AppendLine(@"   Backup-SqlDatabase -ServerInstance ""$ServerInstance"" -Database ""$database"" -BackupFile ""$targetFolder\$database.bak""");
            databaseScript.AppendLine(@"   Write-Output ""Database $database has been backed up""");
            databaseScript.AppendLine("}");
            executionScript += databaseScript.ToString();
        }
    }
}