using System;
using System.ComponentModel;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Validation;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    public interface IRemoteView : IBaseView, IFormValidation, ISynchronizeInvoke
    {
        void EnableControls(bool eValue);
        void UpdateButtons();
        void SetCheckbox(bool enabled);
        void SetHostname(string hostname);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetRemoteFolder(string remoteFolder);

        void ToggleTestButton(bool enabled);

        event EventHandler<EventArgs<string>> RemoteInitialized;
        event EventHandler<EventArgs<IRemoteSettings>> TestRemote;
    }
}
