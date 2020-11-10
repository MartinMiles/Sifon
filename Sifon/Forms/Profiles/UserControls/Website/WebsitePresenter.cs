using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Exceptions;
using Sifon.Code.Factories;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal class WebsitePresenter : BasePresenter
    {
        private readonly IWebsiteView _view;
        protected ISiteProvider _siteProvider;

        internal WebsitePresenter(IWebsiteView view) : base(view)
        {
            _view = view;
           
            _view.SelectedWebsiteChanged += async (s, e) => { await SelectedWebsiteChanged(s, e as EventArgs<string>); };
            //_view.WebrootFolderChanged += WebrootFolderChanged;
            _view.WebrootFolderChanged += async (s, e) => { await WebrootFolderChanged(s, e as EventArgs<string>); };
            _view.FolderBrowserClicked += (sender, args) => _view.SetWebrootTextbox(ShowFolderSelector(SelectedProfile, false));
        }

        protected override async Task Loaded(object sender, EventArgs ea)
        {
            Presenter.ProfileChanged += async (s, e) => { await ProfileChanged(s, e as EventArgs<bool>); };

            _siteProvider = Create.WithCurrentProfile<ISiteProvider>(_view);

            await GetSitecoreSites();

            //_view.EnableControls(e.Value);
            _view.SetWebsiteDropdownByProfile(SelectedProfile.Website);
            _view.SetWebrootTextbox(SelectedProfile.Webroot);
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        private async Task WebrootFolderChanged(object sender, EventArgs<string> e)
        {
            try
            {
                var bindings = await _siteProvider.GetBindings(e.Value);
                _view.ShowSiteHostnames(bindings, ControlSettings.Grid.HostnameColumns);
            }
            catch (RemoteNotInitializedException)
            {
                ShowConnectivityError();
            }
        }

        private async Task GetSitecoreSites()
        {
            try
            {
                var sitecoreSites = await Presenter.GetSitecoreSites();
                _view.LoadWebsitesDropdown(sitecoreSites);
            }
            catch (RemoteNotInitializedException)
            {
                ShowConnectivityError();
            }
        }

        private async Task ProfileChanged(object sender, EventArgs<bool> e)
        {
            _view.EnableControls(e.Value);
            _view.SetWebsiteDropdownByProfile(SelectedProfile?.Website);
            _view.SetWebrootTextbox(SelectedProfile?.Webroot);

            var bindings = SelectedProfile != null
                ? await _siteProvider.GetBindings(SelectedProfile.Website)
                : new Dictionary<string, string>();

            _view.ShowSiteHostnames(bindings, ControlSettings.Grid.HostnameColumns);
        }
        
        private async Task SelectedWebsiteChanged(object sender, EventArgs<string> e)
        {
            _view.EnableControls(false);

            var path = await _siteProvider.GetSitePath(e.Value);
            _view.SetWebrootTextbox(path);

            _view.EnableControls(true);
        }
    }
}
