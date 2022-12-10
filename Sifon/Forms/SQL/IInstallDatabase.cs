using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;

namespace Sifon.Forms.SQL
{
    public interface IInstallDatabase : ISynchronizeInvoke
    {
        event EventHandler<EventArgs<IDatabaseInstall>> InstallClicked;

        void ToggleControls(bool enabled);
    }
}
