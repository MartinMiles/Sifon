using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Code.Factories;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Code.ScriptGenerators
{
    internal abstract class BaseScriptGenerator
    {
        protected internal readonly IBackupRemoverViewModel _model;
        protected internal string executionScript = String.Empty;

        public abstract string Script { get; protected set; }
        protected internal IProfilesProvider _profilesProvider;
        protected internal IServiceScriptGenerator _serviceScriptGenerator;
        protected internal IisScriptGenerator _iisScriptGenerator;
        protected internal FilesScriptGenerator _filesScriptGenerator;

        protected Dictionary<string, string> CommerceSitesParameters => _model.CommerceSites.ToDictionary(s => Path.GetFileName(s.Value), s => s.Key);

        protected internal BaseScriptGenerator(IBackupRemoverViewModel model, IProfile profile)
        {
            _model = model;

            _profilesProvider = Create.New<IProfilesProvider>();
            _serviceScriptGenerator = Create.WithCurrentProfile<IServiceScriptGenerator>();
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
	                    [string]${Settings.Parameters.Website}, # ex. instanceName,
	                    [string]${Settings.Parameters.Webroot}, # ex. instanceFolder,

                        #Additional (dynamic) parameters
                        {additionalParameterBuilder}

	                    #Operation parameters
	                    [string]${Settings.Parameters.XConnect},           
	                    [string]${Settings.Parameters.XConnectFolder},           
	                    [string]${Settings.Parameters.IdentityServer},
	                    [string]${Settings.Parameters.IdentityServerFolder},
	                    [string]${Settings.Parameters.Horizon},
	                    [string]${Settings.Parameters.HorizonFolder},
	                    [string]${Settings.Parameters.PublishingService},
	                    [string]${Settings.Parameters.PublishingServiceFolder},
	                    [string]${Settings.Parameters.TargetFolder},
	                    [string[]]${Settings.Parameters.Databases},
                        [string]${Settings.Parameters.Activity}
                    )";
        }

        protected void ShowFinalOutput(string operationName)
        {
            executionScript += Environment.NewLine;
            executionScript += ".";
            executionScript += Environment.NewLine;
            executionScript += $@"Show-Message -Fore White -Back Yellow -Text ""{operationName} completed.""";
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