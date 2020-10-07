using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Providers;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Base;
using Sifon.Code.Events;
using Sifon.Code.Exceptions;
using Sifon.Code.Providers;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal class WebsitePresenter : BasePresenter
    {
        private readonly IWebsiteView _view;
        private readonly ISuperClass _superClass;
        protected ISiteProvider _siteProvider;

        public WebsitePresenter(IWebsiteView view) : base(view)
        {
            _view = view;
            _superClass = new SuperClass();
           
            _view.SelectedWebsiteChanged += SelectedWebsiteChanged;
            _view.WebrootFolderChanged += WebrootFolderChanged;
            _view.FolderBrowserClicked += (sender, args) => _view.SetWebrootTextbox(_superClass.ShowFolderBrowser(SelectedProfile, false));
        }

        private async void WebrootFolderChanged(object sender, EventArgs<string> e)
        {
            await GetBindingsByWebfolder(e.Value);
        }

        private async Task GetBindingsByWebfolder(string webfolder)
        {
            try
            {
                var bindings = await _siteProvider.GetBindingsByPath(webfolder);
                _view.ShowSiteHostnames(bindings);
            }
            catch (RemoteNotInitializedException)
            {
                ShowConnectivityError();
            }
        }

        protected override async void Loaded(object sender, EventArgs e)
        {
            Presenter.ProfileChanged += ProfileChanged;

            _siteProvider = new PowerShellSiteProvider(SelectedProfile, _view);

            await GetSitecoreSites();

            //_view.EnableControls(e.Value);
            _view.SetWebsiteDropdownByProfile(SelectedProfile.Website);
            _view.SetWebrootTextbox(SelectedProfile.Webroot);
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

        private async void ProfileChanged(object sender, EventArgs<bool> e)
        {
            _view.EnableControls(e.Value);
            _view.SetWebsiteDropdownByProfile(SelectedProfile?.Website);
            _view.SetWebrootTextbox(SelectedProfile?.Webroot);

            var bindings = SelectedProfile != null
                ? await _siteProvider.GetBindings(SelectedProfile.Website)
                : new Dictionary<string, string>();

            _view.ShowSiteHostnames(bindings);
        }
        
        private async void SelectedWebsiteChanged(object sender, EventArgs<string> e)
        {
            var path = await _siteProvider.GetSitePath(e.Value);
            _view.SetWebrootTextbox(path);
        }
    }
}
