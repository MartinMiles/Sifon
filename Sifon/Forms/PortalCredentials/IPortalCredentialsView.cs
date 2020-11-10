using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;

namespace Sifon.Forms.PortalCredentials
{
    internal interface IPortalCredentialsView : ISynchronizeInvoke, IBaseForm
    {
        event EventHandler<EventArgs<IPortalCredentials>> TestClicked;
        event EventHandler<EventArgs<IPortalCredentials>> ValuesChanged;

        void SetTextboxValues(ISettingRecord entity);
        void ToggleControls(bool enabled);
        void ShowInfo(string caption, string message);
        void ShowError(string caption, string message);
    }
}
