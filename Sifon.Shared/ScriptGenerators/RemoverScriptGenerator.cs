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
    internal class RemoverScriptGenerator : BaseScriptGenerator, IScript
    {
        public override string Script => Path.Combine(Settings.Folders.Cache, $"Cleaner_{_model.SitecoreInstance}_{DateTime.Now:yyyy-MM-dd}.ps1");

        internal RemoverScriptGenerator(IBackupRestoreModel model, IProfile profile) : base(model, profile)
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

            ShowFinalOutput("Instance clean-up");

            SaveScriptToCacheFile();
        }

        private void GenerateFilesystemScript()
        {
            try
            {
                int progressCalculation = _model.ProcessDatabases ? 60 : 90;

                executionScript += _serviceScriptGenerator.StopDependentServices();
                
                executionScript += _iisScriptGenerator.Stop(30);

                if (_model.ProcessWebroot)
                {
                    executionScript += _filesScriptGenerator.Remove(Settings.Parameters.Webroot, 40);
                }

                if (_model.ProcessIDS)
                {
                    executionScript += _filesScriptGenerator.Remove(Settings.Parameters.IdentityServerFolder, 43);
                }

                if (_model.ProcessXconnect)
                {
                    executionScript += $@"{Environment.NewLine}Start-Sleep -Seconds 2";
                    executionScript += _filesScriptGenerator.Remove(Settings.Parameters.XConnectFolder, 45);
                }

                if (_model.ProcessHorizon)
                {
                    executionScript += _filesScriptGenerator.Remove(Settings.Parameters.Horizon, 47);
                }
                if (_model.ProcessPublishing)
                {
                    executionScript += _filesScriptGenerator.Remove(Settings.Parameters.PublishingService, 50);
                }


                if (_model.ProcessCommerce)
                {
                    for (int i = 0; i < _model.CommerceSites.Count(); i++)
                    {
                        var key = CommerceSitesParameters.ElementAt(i).Key;
                        executionScript += _filesScriptGenerator.Remove(key, 55+1);
                    }
                }

                executionScript += _iisScriptGenerator.Start(progressCalculation);

                if (!_model.ProcessDatabases)
                {
                    executionScript += "Write-Progress -Activity $activity -CurrentOperation 'instance clean-up complete.' -PercentComplete 100";
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void GenerateDatabaseScript()
        {
            string progressCalculation = _model.ProcessWebroot ? "60 + 40" : "0 + 100";

            var databaseScript = new StringBuilder(Environment.NewLine);
            databaseScript.AppendLine("$i = 0");
            databaseScript.AppendLine("foreach ($database in $databases)");
            databaseScript.AppendLine("{");
            databaseScript.AppendLine("   $i++");
            databaseScript.AppendLine($"   $percentComplete = {progressCalculation} / $databases.Length * $i");
            databaseScript.AppendLine($@"   Write-Progress -Activity $activity -CurrentOperation ""deleting database: $database"" -PercentComplete $percentComplete");
            databaseScript.AppendLine(@"  invoke-sqlcmd -ServerInstance ""$ServerInstance"" -Query ""ALTER DATABASE [$database] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;""");
            databaseScript.AppendLine(@"  invoke-sqlcmd -ServerInstance ""$ServerInstance"" -Query ""Drop database [$database];""");
            databaseScript.AppendLine(@"   Write-Output ""Database $database has been removed""");
            databaseScript.AppendLine("}");
            executionScript += databaseScript.ToString();
        }
    }
}
 