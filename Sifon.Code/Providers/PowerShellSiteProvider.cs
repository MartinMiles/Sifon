using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;

namespace Sifon.Code.Providers
{
    internal class PowerShellSiteProvider : ISiteProvider
    {
        private readonly ScriptWrapper<string> _scriptWrapperString;
        private readonly ScriptWrapper<KeyValuePair<string, string>> _scriptWrapper;

        internal PowerShellSiteProvider(IProfile profile, ISynchronizeInvoke invoke)
        {
            _scriptWrapperString = new ScriptWrapper<string>(profile, invoke, d => d.ToString());
            _scriptWrapper = new ScriptWrapper<KeyValuePair<string, string>>(profile, invoke, Convert);
        }

        private KeyValuePair<string, string> Convert(PSObject pso)
        {
            var infos = pso.ToStringArray();
            return infos == null ? default(KeyValuePair<string, string>) : new KeyValuePair<string, string>(infos[0], infos[1]);
        }

        public async Task<IEnumerable<string>> GetSitecoreSites()
        {
            await _scriptWrapperString.Run(Modules.Functions.GetSitecoreSites);
            return _scriptWrapperString.Results;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetBindings(string[] siteNames)
        {
            await _scriptWrapper.Run(Modules.Functions.GetBindings, new Dictionary<string, dynamic> {{ "SiteNameOrPath", siteNames }});
            return _scriptWrapper.Results;
        }

        public async Task<string> GetSitePath(string siteName)
        {
            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Name, siteName }};
            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetXconnect(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                {{ Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.XConnect }};

            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetIDS(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                { { Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.IdentityServer}};

            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<IEnumerable<string>> GetDatabases(string serverInstance, string instancePrefix)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.ServerInstance, serverInstance},
                { Settings.Parameters.InstancePrefix, instancePrefix}
            };

            await _scriptWrapperString.Run(Modules.Functions.GetDatabases, parameters);
            return _scriptWrapperString.Results;
        }

        public async Task<IEnumerable<string>> GetCommerceSites(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                {{ Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, "Commerce" }};

            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results;
        }

        public async Task<IScriptWrapper<string>> GetCommerceDatabases(string siteName)
        {
            var parameters = new Dictionary<string, dynamic> {{ "AuthoringWebroot", siteName}};
            await _scriptWrapperString.Run(Modules.Functions.GetCommerceDatabases, parameters);
            return _scriptWrapperString;
        }

        public async Task<string> GetHorizon(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                {{ Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.Horizon }};

            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }

        public async Task<string> GetPublishingService(string siteName)
        {
            var parameters = new Dictionary<string, dynamic>
                {{ Settings.Parameters.Name, siteName },{ Settings.Parameters.Type, Settings.Parameters.PublishingService }};

            await _scriptWrapperString.Run(Modules.Functions.GetSiteFolder, parameters);
            return _scriptWrapperString.Results.FirstOrDefault();
        }
    }
}
