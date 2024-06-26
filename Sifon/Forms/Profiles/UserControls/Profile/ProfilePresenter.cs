﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    internal class ProfilePresenter : BasePresenter
    {
        private readonly IProfileView _view;

        internal IEnumerable<string> Profiles => ProfilesService.Read().Select(p => p.ProfileName);

        internal ProfilePresenter(IProfileView view) : base(view)
        {
            _view = view;

            _view.ProfileAdded += ProfileAdded;
            _view.ProfileRenamed += ProfileRenamed;
            _view.SelectedProfileChanged += SelectedProfileChanged;
            _view.SelectedProfileDeleted += SelectedProfileDeleted;
        }

        protected override async Task Loaded(object sender, EventArgs e)
        {
            await Task.CompletedTask;

            
            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile?.ProfileName, Presenter.SelectedProfile.IsXM);
        }

        private void ProfileAdded(object sender, EventArgs<IProfileUserControl> e)
        {
            if (Presenter.Profiles.Count() == 1 && Presenter.Profiles.First() == Settings.ProfileNotCreated)
            {
                ProfilesService.DeleteSelected();
            }

            ProfilesService.Add(e.Value);
            ProfilesService.SelectProfile(e.Value.ProfileName);
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile.ProfileName, Presenter.SelectedProfile.IsXM);
        }

        private void ProfileRenamed(object sender, EventArgs<IProfileUserControl> e)
        {
            SelectedProfile.ProfileName = e.Value.ProfileName;
            SelectedProfile.Prefix = e.Value.Prefix;
            SelectedProfile.AdminUsername = e.Value.AdminUsername;
            SelectedProfile.AdminPassword = e.Value.AdminPassword;
            SelectedProfile.IsXM = e.Value.IsXM;
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Profiles, SelectedProfile.ProfileName, e.Value.IsXM);
        }

        private void SelectedProfileChanged(object sender, EventArgs<string> e)
        {
            ProfilesService.SelectProfile(e.Value);
            _view.SetFields(SelectedProfile);
        }

        private void SelectedProfileDeleted(object sender, EventArgs e)
        {
            ProfilesService.DeleteSelected();
            ProfilesService.Save();

            if (!Profiles.Any())
            {
                Presenter.CreateDummyProfile();
            }

            _view.LoadProfilesDropdown(Profiles, SelectedProfile?.ProfileName, SelectedProfile.IsXM);
        }
    }
}
