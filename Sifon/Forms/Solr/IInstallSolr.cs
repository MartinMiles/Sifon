using System;
using System.ComponentModel;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;

namespace Sifon.Forms.Solr
{
    public interface IInstallSolr : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoad;
        event EventHandler<EventArgs> ClosingForm;
        event EventHandler<EventArgs<ISolrInstall>> InstallClicked;
        event EventHandler<EventArgs<TextBox, bool>> FolderBrowserClicked;

        void UpdateView(bool enabled);
        void SetCaption(string suffix);
    }
}
