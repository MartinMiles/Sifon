using System;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.Providers.Profile;

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
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ContainerProfileName);
        }

        private void ProfileAdded(object sender, EventArgs<IContainerProfile> e)
        {
            _containersProvider.Add(e.Value);
            _containersProvider.SelectProfile(e.Value.ContainerProfileName);
            _containersProvider.Save();

            _view.SetFields(_containersProvider.SelectedProfile);
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ContainerProfileName);
        }

        private void ProfileRenamed(object sender, EventArgs<IContainerProfile> e)
        {
            var profile = _containersProvider.SelectedProfile;

            profile.ContainerProfileName = e.Value.ContainerProfileName;
            profile.Repository = e.Value.Repository;
            profile.Folder = e.Value.Folder;
            profile.SitecoreAdminPassword = e.Value.SitecoreAdminPassword;
            profile.SaPassword = e.Value.SaPassword;
            profile.InitializeScript = e.Value.InitializeScript;
            profile.Notes = e.Value.Notes;

            _containersProvider.Save();
            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ContainerProfileName);
            _view.ShowConfirmation();
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

            _view.LoadProfilesDropdown(_containersProvider.Profiles, _containersProvider.SelectedProfile?.ContainerProfileName);
        }
    }
}
