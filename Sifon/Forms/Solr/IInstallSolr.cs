using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.Solr
{
    internal interface IInstallSolr : ISynchronizeInvoke
    {
        event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;
        event EventHandler<EventArgs> ClosingForm;
        event EventHandler<EventArgs<ISolrInstall>> InstallClicked;
        event BaseForm.AsyncEventHandler<EventArgs<string>> UninstallClicked;
        event EventHandler<EventArgs<TextBox, bool>> FolderBrowserClicked;

        Task OnLoad();
        void UpdateView(bool enabled);
        void SetCaption(string suffix);
        void ShowSpinnerHideGrid(bool visible);
        void ShowError(string caption, string message);
        void ToggleControls(bool enabled);
    }
}
