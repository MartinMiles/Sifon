using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Extensions.Models;
using Sifon.Shared.Model;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Helpers
{
    public class SolrIdentifier
    {
        private readonly RemoteScriptCopier _remoteScriptCopier;
        private readonly ScriptWrapper<SolrInfo> _scriptWrapper;
        public event EventHandler<EventArgs<int>> OnProgressReady = delegate { };

        public SolrIdentifier(IProfile profile, ISynchronizeInvoke invoke)
        {
            _remoteScriptCopier = new RemoteScriptCopier(profile, invoke);
            _scriptWrapper = new ScriptWrapper<SolrInfo>(profile, invoke, SolrInfoExtensions.Convert);
            _scriptWrapper.ProgressReady += ProgressReady;
        }

        private void ProgressReady(ProgressRecord data)
        {
            OnProgressReady(this, new EventArgs<int>(data.PercentComplete));
        }

        public async Task<IEnumerable<SolrInfo>> Identify()
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.RetrieveSolr);
            await _scriptWrapper.Run(script);
            return _scriptWrapper.Results.Where(r => r.Directory.NotEmpty() && r.Version != null);
        }

 

        public void Finish()
        {
            _scriptWrapper.Finish();
        }
    }
}
