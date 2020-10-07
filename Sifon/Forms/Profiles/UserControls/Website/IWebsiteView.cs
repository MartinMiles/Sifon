using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal interface IWebsiteView : IBaseView, ISynchronizeInvoke
    {
        event EventHandler<EventArgs<string>> SelectedWebsiteChanged;
        event EventHandler<EventArgs<string>> WebrootFolderChanged;
        event EventHandler<EventArgs> FolderBrowserClicked;

        void EnableControls(bool eValue);
        void LoadWebsitesDropdown(IEnumerable<string> sites);
        void SetWebrootTextbox(string path);
        void ShowSiteHostnames(IEnumerable<KeyValuePair<string, string>> hostnames);
        void SetWebsiteDropdownByProfile(string website);
    }
}
