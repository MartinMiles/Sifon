using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles.UserControls.Base;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal interface IWebsiteView : IBaseView, ISynchronizeInvoke
    {
        //event EventHandler<EventArgs<string>> SelectedWebsiteChanged;
        event BaseForm.AsyncEventHandler<EventArgs<SelectedWebsiteChangedArgs>> SelectedWebsiteChanged;
        event BaseForm.AsyncEventHandler<EventArgs<string[]>> WebrootFolderChanged;
        event EventHandler<EventArgs<TextBox>> FolderBrowserClicked;

        void EnableControls(bool eValue);
        void LoadWebsitesDropdown(IEnumerable<string> sites);
        void SetWebrootTextbox(TextBox folderTextBox, string path);
        void SetPathTextboxes(string pathCM, string pathCD);
        void ShowSiteHostnames(IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames);
        void SetWebsiteDropdownByProfile(IProfile profile);
        void SetHandlers();
        void SetLables(bool isXM);
    }
}
