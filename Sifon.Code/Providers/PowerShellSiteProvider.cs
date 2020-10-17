using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Model.Response;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;

namespace Sifon.Code.Providers
{
    public class PowerShellSiteProvider : ISiteProvider
    {
        private readonly ScriptWrapper<string> _scriptWrapperString;
        private readonly ScriptWrapper<KeyValuePair<string, string>> _scriptWrapper;
        private readonly RemoteScriptCopier _remoteScriptCopier;

        public PowerShellSiteProvider(IProfile profile, ISynchronizeInvoke invoke)
        {
            _scriptWrapperString = new ScriptWrapper<string>(profile, invoke, d => d.ToString());
            _scriptWrapper = new ScriptWrapper<KeyValuePair<string, string>>(profile, invoke, Convert);
            _remoteScriptCopier = new RemoteScriptCopier(profile, invoke);
        }

        private KeyValuePair<string, string> Convert(PSObject pso)
        {
            var infos = pso.ToStringArray();
            return infos == null ? default(KeyValuePair<string, string>) : new KeyValuePair<string, string>(infos[0], infos[1]);
        }

        public async Task<IEnumerable<string>> GetSitecoreSites()
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetSitecoreSites);
            await _scriptWrapper.Run(script);
            return _scriptWrapper.Results.Select(s => s.Key);
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetBindings(string siteName)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetSiteBindings);
            await _scriptWrapper.Run(script, new Dictionary<string, dynamic> {{ "SiteName", siteName }});
            return _scriptWrapper.Results;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetBindingsByPath(string webfolder)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetSiteBindingsByPath);
            await _scriptWrapper.Run(script, new Dictionary<string, dynamic> { { "SitePath", webfolder } });
            return _scriptWrapper.Results;
        }

        public async Task<string> GetSitePath(string siteName)
        {
            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Name, siteName }};
            await _scriptWrapperString.Run(Settings.Module.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetXconnect(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                {{ Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.XConnect }};

            await _scriptWrapperString.Run(Settings.Module.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetIDS(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                { { Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.IdentityServer}};

            await _scriptWrapperString.Run(Settings.Module.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<IScriptWrapperResponse<string>> GetDatabases(string serverInstance, string instancePrefix)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.RetrieveDatabases);

            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.ServerInstance, serverInstance},
                { Settings.Parameters.InstancePrefix, instancePrefix}
            };

            await _scriptWrapperString.Run(script, parameters);
            return _scriptWrapperString;
        }

        public async Task<IEnumerable<string>> GetCommerceSites(string siteName)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetCommerceSites);

            var parameters = new Dictionary<string, dynamic> {{Settings.Parameters.Name, siteName}};
            await _scriptWrapperString.Run(script, parameters);
            return _scriptWrapperString.Results;
        }

        public async Task<IScriptWrapperResponse<string>> GetCommerceDatabases(string siteName)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetCommerceDatabases);

            var parameters = new Dictionary<string, dynamic> {{Settings.Parameters.Webroot, siteName}};
            await _scriptWrapperString.Run(script, parameters);
            return _scriptWrapperString;
        }

        public async Task<string> GetHorizon(string siteName)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetHorizonFolder);

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Name, siteName }};

            await _scriptWrapperString.Run(script, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetPublishingService(string siteName)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetPublishingServiceFolder);

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Name, siteName}};

            await _scriptWrapperString.Run(script, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }
    }
}
