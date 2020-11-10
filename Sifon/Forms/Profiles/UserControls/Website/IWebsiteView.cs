using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles.UserControls.Base;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal interface IWebsiteView : IBaseView, ISynchronizeInvoke
    {
        //event EventHandler<EventArgs<string>> SelectedWebsiteChanged;
        event BaseForm.AsyncEventHandler<EventArgs<string>> SelectedWebsiteChanged;
        event BaseForm.AsyncEventHandler<EventArgs<string>> WebrootFolderChanged;
        event EventHandler<EventArgs> FolderBrowserClicked;

        void EnableControls(bool eValue);
        void LoadWebsitesDropdown(IEnumerable<string> sites);
        void SetWebrootTextbox(string path);
        void ShowSiteHostnames(IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames);
        void SetWebsiteDropdownByProfile(string website);
    }
}
