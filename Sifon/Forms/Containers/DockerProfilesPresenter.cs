using System;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Events;
using Sifon.Shared.Providers.Profile;

namespace Sifon.Forms.Containers
{
    internal class DockerProfilesPresenter
    {
        private readonly IDockerProfilesView _view;
        private readonly ContainersProvider _containersProvider;

        public DockerProfilesPresenter(IDockerProfilesView view)
        {
            _view = view;
            _view.Loaded += Loaded;

            _view.ProfileAdded += ProfileAdded;
            _view.ProfileRenamed += ProfileRenamed;
            _view.SelectedProfileChanged += SelectedProfileChanged;
            _view.SelectedProfileDeleted += SelectedProfileDeleted;

            _containersProvider = new ContainersProvider();
        }

        protected void Loaded(object sender, EventArgs e)
        {
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ProfileName);
        }

        private void ProfileAdded(object sender, EventArgs<IContainerProfile> e)
        {
            _containersProvider.Add(e.Value);
            _containersProvider.SelectProfile(e.Value.ProfileName);
            _containersProvider.Save();

            _view.SetFields(_containersProvider.SelectedProfile);
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ProfileName);
        }

        private void ProfileRenamed(object sender, EventArgs<IContainerProfile> e)
        {
            var profile = _containersProvider.SelectedProfile;

            profile.ProfileName = e.Value.ProfileName;
            profile.Repository = e.Value.Repository;
            profile.Folder = e.Value.Folder;
            profile.AdminPassword = e.Value.AdminPassword;
            profile.SaPassword = e.Value.SaPassword;
            _containersProvider.Save();
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ProfileName);
        }

        private void SelectedProfileChanged(object sender, EventArgs<string> e)
        {
            _containersProvider.SelectProfile(e.Value);
            _view.SetFields(_containersProvider.SelectedProfile);
        }

        private void SelectedProfileDeleted(object sender, EventArgs e)
        {
            _containersProvider.DeleteSelected();
            _containersProvider.Save();

            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ProfileName);
        }
    }
}
