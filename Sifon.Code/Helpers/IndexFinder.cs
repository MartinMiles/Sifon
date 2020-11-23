using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Factories;
using Sifon.Code.Statics;

namespace Sifon.Code.Helpers
{
    internal class IndexFinder : IIndexFinder
    {
        private readonly IScriptWrapper<string> _scriptWrapper;
        private readonly IProfile _profile;

        internal IndexFinder(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _scriptWrapper = Create.WithParam(invoke, s => s?.ToString(), profile);
        }

        public async Task<IEnumerable<string>> FindAll()
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.Webroot, _profile.Webroot },
                { Settings.Parameters.AdminUsername, _profile.AdminUsername },
                { Settings.Parameters.AdminPassword, _profile.AdminPassword }
            };

            await _scriptWrapper.Run(Modules.Functions.FindIndexes, parameters);
            return _scriptWrapper.Results;
        }
    }
}
