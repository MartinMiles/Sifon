using System;
using System.Collections.Generic;
using System.Linq;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    public class ProfilePresenter : BasePresenter
    {
        private readonly IProfileView _view;

        internal IEnumerable<string> Profiles => ProfilesService.Read().Select(p => p.Name);

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
            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile?.Name);
        }

        private void ProfileAdded(object sender, EventArgs<Tuple<string, string>> e)
        {
            ProfilesService.Add(e.Value.Item1, e.Value.Item2);
            ProfilesService.SelectProfile(e.Value.Item1);
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Presenter.Profiles, Presenter.SelectedProfile.Name);
        }

        private void ProfileRenamed(object sender, EventArgs<Tuple<string, string>> e)
        {
            SelectedProfile.Name = e.Value.Item1;
            SelectedProfile.Prefix = e.Value.Item2;
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Profiles, SelectedProfile.Name);
        }

        private void SelectedProfileChanged(object sender, EventArgs<string> e)
        {
            ProfilesService.SelectProfile(e.Value);

            _view.SetProfileTextbox(SelectedProfile.Name);
            _view.SetPrefixTextbox(SelectedProfile.Prefix);
        }
        private void SelectedProfileDeleted(object sender, EventArgs e)
        {
            ProfilesService.DeleteSelected();
            ProfilesService.Save();

            _view.LoadProfilesDropdown(Profiles, SelectedProfile?.Name);
        }
    }
}
