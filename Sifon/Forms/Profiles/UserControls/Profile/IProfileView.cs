using System;
using System.Collections.Generic;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    public interface IProfileView : IBaseView
    {
        event EventHandler<EventArgs<Tuple<string, string>>> ProfileAdded;
        event EventHandler<EventArgs<Tuple<string, string>>> ProfileRenamed;
        event EventHandler<EventArgs<string>> SelectedProfileChanged;
        event EventHandler<EventArgs> SelectedProfileDeleted;

        void LoadProfilesDropdown(IEnumerable<string> profiles, string selectedProfileName);
        void SetProfileTextbox(string name);
        void SetPrefixTextbox(string name);
        void DisplayFirstRunWarning(bool visible);
    }
}
