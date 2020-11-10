using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Validation;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles.UserControls.Base;

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
        event BaseForm.AsyncEventHandler<EventArgs<IRemoteSettings>> TestRemote;
    }
}
