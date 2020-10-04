using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Events;
using Sifon.Shared.Providers;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Profiles
{
    public class ProfilesPresenter
    {
        private readonly IProfilesView _view;
        private readonly SqlServerRecordProvider _sqlService;
        private readonly PowerShellSiteProvider _siteProvider;
        internal ProfilesProvider ProfilesService { get; private set; }

        #region Properties

        internal IEnumerable<string> Profiles => ProfilesService.Read().Select(p => p.ProfileName);

        internal IProfile SelectedProfile => ProfilesService.SelectedProfile;

        public IEnumerable<string> SqlServerNames => _sqlService.Read().Select(s => s.RecordName);
        internal bool RemoteNotInitializedExceptionAlredyFired { get; set; }

        #endregion

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

        public event EventHandler<EventArgs> FormClosing = delegate { };

        public event EventHandler<EventArgs<bool>> ProfileChanged = delegate { };

        public void Raise_ProfileChangedEvent(bool value)
        {
            ProfileChanged(this, new EventArgs<bool>(value));
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

        public ProfilesPresenter(IProfilesView profilesView)
        {
            ProfilesService = new ProfilesProvider();

            _view = profilesView;
            _view.FormSaved += FormSaved;
            _view.BeforeFormClosing += (sender, args) => FormClosing(sender, args);

            if (SelectedProfile != null)
            {
                _siteProvider = new PowerShellSiteProvider(SelectedProfile, _view);
                _sqlService = new SqlServerRecordProvider();
            }
        }

        private void FormSaved(object sender, EventArgs e)
        {
            var profile = ProfilesService.CreateProfile();

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

            ProfilesService.UpdateSelected(profile);
            ProfilesService.Save();
            _view.CloseDialog();
        }

        public void FocusOnSaveButton()
        {
            _view.FocusOnSaveButton();
        }
    }
}
