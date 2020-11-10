using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model;

namespace Sifon.Abstractions.Helpers
{
    public interface ISolrIdentifier
    {
        event EventHandler<EventArgs<int>> OnProgressReady;
        Task<IEnumerable<ISolrInfo>> Identify();
        void Finish();
    }
}
