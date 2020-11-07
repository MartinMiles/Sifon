using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Model;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    internal interface IConnectivityView : IBaseView, ISynchronizeInvoke
    {
        event EventHandler<EventArgs> SqlServersUpdated;
        event EventHandler<EventArgs<string>> TestSolr;

        void ToggleControls(bool eValue);
        void SetSolrDropdownByProfile(string solrUrl);
        void LoadSolrDropdown();
        void LoadDatabaseServersDropdown(IEnumerable<string> sqlServers, string selectedSqlServerName);
        void SetSolrCombobox(IEnumerable<SolrInfo> solrs, bool isRemote);
        void SetSolrValue(string selectedProfileSolr);
        void ShowSpinnerHideGrid(bool visible);
        void UpdateProgress(int value);
        void NotifyRemoteNotInitialized();
    }
}
