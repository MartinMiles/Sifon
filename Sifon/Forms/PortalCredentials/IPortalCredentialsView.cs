﻿using System;
using System.ComponentModel;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Events;

namespace Sifon.Forms.PortalCredentials
{
    public interface IPortalCredentialsView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs<ISettingRecord>> TestClicked;
        event EventHandler<EventArgs<ISettingRecord>> ValuesChanged;
        event EventHandler<EventArgs> FormLoad;

        void SetTextboxValues(ISettingRecord entity);
        void ToggleControls(bool enabled);
        void ShowInfo(string caption, string message);
        void ShowError(string caption, string message);
    }
}