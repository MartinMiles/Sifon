﻿using System;
using System.Collections.Generic;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;

namespace Sifon.Forms.Containers
{
    internal interface IDockerProfilesView
    {
        event EventHandler<EventArgs> Loaded;
        event EventHandler<EventArgs<IContainerProfile>> ProfileAdded;
        event EventHandler<EventArgs<IContainerProfile>> ProfileRenamed;
        event EventHandler<EventArgs<string>> SelectedProfileChanged;
        event EventHandler<EventArgs> SelectedProfileDeleted;

        void LoadProfilesDropdown(IEnumerable<string> profiles, string selectedProfileName);
        void SetFields(IContainerProfile profile);
        void ShowConfirmation();
    }
}