using System;
using System.ComponentModel;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Validation;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    internal interface IRemoteView : IBaseView, IFormValidation, ISynchronizeInvoke
    {
        void EnableControls(bool eValue);
        void UpdateButtons();
        void SetCheckbox(bool enabled);
        void SetHostname(string hostname);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetRemoteFolder(string remoteFolder);

        void ToggleTestButton(bool enabled);

        event EventHandler<EventArgs<bool>> ToggleLastTabs;
        event EventHandler<EventArgs<string>> RemoteInitialized;
        event EventHandler<EventArgs<IRemoteSettings>> TestRemote;
    }
}
