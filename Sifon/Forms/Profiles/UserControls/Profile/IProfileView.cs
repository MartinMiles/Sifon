﻿using System;
using System.Collections.Generic;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    internal interface IProfileView : IBaseView
    {
        event EventHandler<EventArgs<IProfileUserControl>> ProfileAdded;
        event EventHandler<EventArgs<IProfileUserControl>> ProfileRenamed;
        event EventHandler<EventArgs<string>> SelectedProfileChanged;
        event EventHandler<EventArgs> SelectedProfileDeleted;

        void LoadProfilesDropdown(IEnumerable<string> profiles, string selectedProfileName, bool isXM);

        void SetFields(IProfileUserControl profile);
    }
}
