using System;
using System.Threading.Tasks;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Providers;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Exceptions;
using Sifon.Shared.Providers;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    public class WebsitePresenter : BasePresenter
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
            //TODO: should not call at all, or if call then use other script that get site by folder path and only then takes bindings
            //await GetBindings(e.Value);
        }

        private async Task GetBindings(string website)
        {
            try
            {
                var bindings = await _siteProvider.GetBindings(website);
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

            await GetBindings(SelectedProfile.Website);
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
            _view.SetWebsiteDropdownByProfile(SelectedProfile.Website);
            _view.SetWebrootTextbox(SelectedProfile.Webroot);

            var bindings = await _siteProvider.GetBindings(SelectedProfile.Website);
            _view.ShowSiteHostnames(bindings);
        }
        
        private async void SelectedWebsiteChanged(object sender, EventArgs<string> e)
        {
            var path = await _siteProvider.GetSitePath(e.Value);
            _view.SetWebrootTextbox(path);
        }
    }
}
