using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.Model;
using Sifon.Abstractions.PowerShell;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.Statics;

namespace Sifon.Code.Helpers
{
    internal class SolrIdentifier : ISolrIdentifier
    {
        private readonly IScriptWrapper<ISolrInfo> _scriptWrapper;
        public event EventHandler<EventArgs<int>> OnProgressReady = delegate { };

        internal SolrIdentifier(ISynchronizeInvoke invoke)
        {
            _scriptWrapper = Create.WithParam(invoke, SolrInfoExtensions.Convert);
            _scriptWrapper.ProgressReady += ProgressReady;
        }

        private void ProgressReady(ProgressRecord data)
        {
            OnProgressReady(this, new EventArgs<int>(data.PercentComplete));
        }

        public async Task<IEnumerable<ISolrInfo>> Identify()
        {
            await _scriptWrapper.Run(Modules.Functions.FindSolrInstances);
            return _scriptWrapper.Results.Where(r => r.Directory.NotEmpty() && r.Version != null).Distinct();
        }

        public void Finish()
        {
            _scriptWrapper.Finish();
        }
    }
}
