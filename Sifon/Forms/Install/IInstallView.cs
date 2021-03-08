using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;

namespace Sifon.Forms.Install
{
    internal interface IInstallView : IRemoteSettings, ISynchronizeInvoke
    {
        event EventHandler<EventArgs> Loaded;
        //event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;

        event BaseForm.AsyncEventHandler<EventArgs<IRemoteSettings>> TestRemote;
        event EventHandler<EventArgs<string, IRemoteSettings>> TestSolr;
        event EventHandler<EventArgs<ISqlServerRecord, IRemoteSettings>> TestSqlClicked;

        void SetRemoteSettings(IRemoteSettings remoteSettings);
        void ToggleControls(bool enabled);
    }
}
