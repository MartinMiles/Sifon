using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Model;
using Sifon.Code.PowerShell;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;

namespace Sifon.Code.Helpers
{
    public class SolrIdentifier
    {
        private readonly ScriptWrapper<SolrInfo> _scriptWrapper;
        public event EventHandler<EventArgs<int>> OnProgressReady = delegate { };

        public SolrIdentifier(IProfile profile, ISynchronizeInvoke invoke)
        {
            _scriptWrapper = new ScriptWrapper<SolrInfo>(profile, invoke, SolrInfoExtensions.Convert);
            _scriptWrapper.ProgressReady += ProgressReady;
        }

        private void ProgressReady(ProgressRecord data)
        {
            OnProgressReady(this, new EventArgs<int>(data.PercentComplete));
        }

        public async Task<IEnumerable<SolrInfo>> Identify()
        {
            await _scriptWrapper.Run(Modules.Functions.FindSolrInstances);
            return _scriptWrapper.Results.Where(r => r.Directory.NotEmpty() && r.Version != null);
        }

        public void Finish()
        {
            _scriptWrapper.Finish();
        }
    }
}
