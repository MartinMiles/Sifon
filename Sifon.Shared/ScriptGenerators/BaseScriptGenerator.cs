using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Shared.ScriptGenerators
{
    internal abstract class BaseScriptGenerator
    {
        protected internal readonly IBackupRestoreModel _model;
        protected internal string executionScript = String.Empty;

        public abstract string Script { get; }
        protected internal ProfilesProvider _profilesService;
        protected internal ServiceScriptGenerator _serviceScriptGenerator;
        protected internal IisScriptGenerator _iisScriptGenerator;
        protected internal FilesScriptGenerator _filesScriptGenerator;

        protected Dictionary<string, string> CommerceSitesParameters => _model.CommerceSites.ToDictionary(s => Path.GetFileName(s.Value), s => s.Key);

        protected internal BaseScriptGenerator(IBackupRestoreModel model, IProfile profile)
        {
            _model = model;

            _profilesService = new ProfilesProvider();
            _serviceScriptGenerator = new ServiceScriptGenerator(profile.Prefix);
            _iisScriptGenerator = new IisScriptGenerator();
            _filesScriptGenerator = new FilesScriptGenerator();
        }

        public string GenerateParameters(Dictionary<string, string> additionalParameters = null)
        {
            var additionalParameterBuilder = new StringBuilder();

            if (additionalParameters != null)
            {
                foreach (var param in additionalParameters)
                {
                    additionalParameterBuilder.AppendLine($"[string]${param.Key},");
                    additionalParameterBuilder.AppendLine($"[string]${param.Key}Folder,");
                }
            }

            return $@"param(
            	        #Comes from profile
	                    [string]${Settings.Parameters.ServerInstance},
                        [string]${Settings.Parameters.Username},
	                    [string]${Settings.Parameters.Password},
	                    [string]${Settings.Parameters.Website}, # ex. instanceName,
	                    [string]${Settings.Parameters.Webroot}, # ex. instanceFolder,

                        #Additional (dynamic) parameters
                        {additionalParameterBuilder}

	                    #Operation parameters
	                    [string]${Settings.Parameters.XConnect},           
	                    [string]${Settings.Parameters.XConnectFolder},           
	                    [string]${Settings.Parameters.IdentityServer},
	                    [string]${Settings.Parameters.Horizon},
	                    [string]${Settings.Parameters.PublishingService},
	                    [string]${Settings.Parameters.IdentityServerFolder},
	                    [string]${Settings.Parameters.TargetFolder},
	                    [string[]]${Settings.Parameters.Databases},
                        [string]${Settings.Parameters.Activity}
                    )";
        }

        protected void ShowFinalOutput(string operationName)
        {
            executionScript += Environment.NewLine;
            executionScript += $@"Write-Output ""#COLOR:Green# {operationName} completed.""";
        }

        protected void SaveScriptToCacheFile()
        {
            if (File.Exists(Script))
            {
                File.Delete(Script);
            }

            File.AppendAllText(Script, executionScript);
        }
    }
}