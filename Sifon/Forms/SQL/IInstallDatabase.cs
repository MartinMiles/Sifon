using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.Profiles;

namespace Sifon.Forms.SQL
{
    public interface IInstallDatabase : ISynchronizeInvoke
    {
        event EventHandler<EventArgs<IDatabaseInstall>> InstallClicked;
        event EventHandler<EventArgs<ISqlServerRecord>> TestSqlClicked;

        void UpdateView(bool enabled);
        void ToggleControls(bool enabled);
        void ToggleSpinner(bool enabled);

    }
}
