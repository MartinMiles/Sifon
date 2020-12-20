using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.Profiles;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;

namespace Sifon.Code.Helpers
{
    public class RequestHelper : IRequestHelper
    {
        private readonly IProfile _profile;
        private readonly ScriptWrapper<string> _scriptWrapper;

        public RequestHelper(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _scriptWrapper = new ScriptWrapper<string>(profile, invoke, d => d.ToString());
        }

        public async Task<string> ReadUrlContent(string url)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "Webroot", _profile.Webroot },
                { "RelativeUrl", url }
            };

            await _scriptWrapper.Run(Modules.Functions.ReadUrlContent, parameters);
            return string.Join("\r\n", _scriptWrapper.Results);
        }
    }
}
