using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Forms.Profiles.UserControls.Connectivity;
using Sifon.Forms.Profiles.UserControls.Parameters;
using Sifon.Forms.Profiles.UserControls.Remote;
using Sifon.Forms.Profiles.UserControls.Website;

namespace Sifon.Forms.Profiles
{
    internal interface IProfilesView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormSaved;
        event EventHandler<EventArgs> BeforeFormClosing;
        event EventHandler<EventArgs> ContinueWithoutCreatingProfile;
        event EventHandler<EventArgs<int>> TabChanged;

        void CloseDialog();

        void EnableSaveButton(bool value);

        #region Access properties

        UserControls.Profile.Profile Profile { get; }
        Remote Remote { get; }
        Website Website { get; }
        Connectivity Connectivity { get; }
        Parameters Parameters { get; }

        #endregion

        void FocusOnSaveButton();
        void ToggleLastTabs(bool enabled);
    }
}