using System;
using System.Collections.Generic;
using System.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    internal class ProfilePresenter : BasePresenter
    {
        private readonly IProfileView _view;

        internal IEnumerable<string> Profiles => ProfilesService.Read().Select(p => p.ProfileName);

        public ProfilePresenter(IProfileView view) : base(view)
        {
            _view = view;

            _view.ProfileAdded += ProfileAdded;
            _view.ProfileRenamed += ProfileRenamed;
            _view.SelectedProfileChanged += SelectedProfileChanged;
            _view.SelectedProfileDeleted += SelectedProfileDeleted;
        }

        protected override void Loaded(object sender, EventArgs e)
        {
            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile?.ProfileName);

            bool isFirstRun = Presenter?.SelectedProfile == null;
            if (isFirstRun)
            {
                _view.DisplayFirstRunWarning();
            }
        }

        private void ProfileAdded(object sender, EventArgs<IProfileUserControl> e)
        {
            ProfilesService.Add(e.Value);
            ProfilesService.SelectProfile(e.Value.ProfileName);
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile.ProfileName);
        }

        private void ProfileRenamed(object sender, EventArgs<IProfileUserControl> e)
        {
            SelectedProfile.ProfileName = e.Value.ProfileName;
            SelectedProfile.Prefix = e.Value.Prefix;
            SelectedProfile.AdminUsername = e.Value.AdminUsername;
            SelectedProfile.AdminPassword = e.Value.AdminPassword;
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Profiles, SelectedProfile.ProfileName);
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

            _view.LoadProfilesDropdown(Profiles, SelectedProfile?.ProfileName);
        }
    }
}
