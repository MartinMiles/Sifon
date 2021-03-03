using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;
using Sifon.Code.Statics;
using Sifon.Forms.Base;

namespace Sifon.Forms.Profiles
{
    internal class ProfilesPresenter
    {
        private readonly IProfilesView _view;
        private readonly ISqlServerRecordProvider _sqlService;
        private readonly ISiteProvider _siteProvider;

        internal IProfilesProvider ProfilesProvider { get; private set; }

        #region Properties

        internal IEnumerable<string> Profiles => ProfilesProvider.Read().Select(p => p.ProfileName);

        internal IProfile SelectedProfile => ProfilesProvider.SelectedProfile;

        public IEnumerable<string> SqlServerNames => _sqlService.Read().Select(s => s.RecordName);
        internal bool RemoteNotInitializedExceptionAlredyFired { get; set; }

        #endregion

        public event EventHandler<EventArgs> FormClosing = delegate { };
        public event BaseForm.AsyncEventHandler<EventArgs<bool>> ProfileChanged;



        internal ProfilesPresenter(IProfilesView profilesView)
        {
            ProfilesProvider = Create.New<IProfilesProvider>();

            _view = profilesView;
            _view.FormSaved += FormSaved;
            _view.BeforeFormClosing += (sender, args) => FormClosing(sender, args);
            _view.ContinueWithoutCreatingProfile += ContinueWithoutCreatingProfile;
            _view.TabChanged += TabChanged;

            if (SelectedProfile != null)
            {
                _siteProvider = Create.WithCurrentProfile<ISiteProvider>(_view);
                _sqlService = Create.New<ISqlServerRecordProvider>();
            }
        }

        private void TabChanged(object sender, EventArgs<int> e)
        {
            if (e.Value == 2 && _view.Remote.RemotingEnabled && !ProfilesProvider.SelectedProfile.RemotingEnabled)
            {
                _view.Website.ShowRemoteWarning();
            }
        }

        public async Task<IEnumerable<string>> GetSitecoreSites()
        {
            return await _siteProvider.GetSitecoreSites();
        }

        #region Outer events

        public event EventHandler<EventArgs> RemoteInitialized = delegate { };
        public void Raise_RemoteInitializedEvent()
        {
            RemoteInitialized(this, new EventArgs());
            EnableSaveButton(true);
            FocusOnSaveButton();
        }

        public async void Raise_ProfileChangedEvent(bool value)
        {
            if (ProfileChanged != null)
            {
                await ProfileChanged(this, new EventArgs<bool>(value));
            }
            EnableSaveButton(value);
        }

        public void ToggleLastTabs(bool enabled)
        {
            _view.ToggleLastTabs(enabled);
        }

        #endregion

        public void EnableSaveButton(bool value)
        {
            _view.EnableSaveButton(value);
        }

        private void ContinueWithoutCreatingProfile(object sender, object args)
        {
            CreateDummyProfile();
        }

        public void CreateDummyProfile()
        {
            var fakeLocalProfile = ProfilesProvider.CreateLocal();
            fakeLocalProfile.ProfileName = Settings.ProfileNotCreated;
            fakeLocalProfile.Prefix = "Please submit the actual values instead";
            ProfilesProvider.Add(fakeLocalProfile);
            ProfilesProvider.SelectProfile(fakeLocalProfile.ProfileName);
        }

        private void FormSaved(object sender, EventArgs e)
        {
            var profile = ProfilesProvider.CreateProfile();

            profile.RemotingEnabled = _view.Remote.RemotingEnabled;
            profile.RemoteHost = _view.Remote.RemoteHost;
            profile.RemoteUsername = _view.Remote.RemoteUsername;
            profile.RemotePassword = _view.Remote.RemotePassword;
            profile.RemoteFolder = _view.Remote.RemoteFolder;
            profile.ProfileName = _view.Profile.ProfileName;
            profile.Prefix = _view.Profile.Prefix;

            profile.Webroot = _view.Website?.Webroot ?? "";

            if (_view.Website?.SelectedSite != null)
            {
                profile.Website = _view.Website.SelectedSite == Settings.Dropdowns.NotSet ? "" : _view.Website.SelectedSite;
            }

            profile.Solr = _view.Connectivity == null ||_view.Connectivity.Solr == Settings.Dropdowns.NotSet ? "" : _view.Connectivity.Solr;
            profile.SqlServer = _view.Connectivity == null || _view.Connectivity.Sql == Settings.Dropdowns.NotSet ? "" : _view.Connectivity.Sql;


            profile.Parameters = _view.Parameters != null ? _view.Parameters.Values : new Dictionary<string, string>();

            ProfilesProvider.UpdateSelected(profile);
            ProfilesProvider.Save();

            _view.CloseDialog();
        }

        public void FocusOnSaveButton()
        {
            _view.FocusOnSaveButton();
        }
    }
}
