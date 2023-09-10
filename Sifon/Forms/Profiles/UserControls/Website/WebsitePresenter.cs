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
using System.Linq;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal class WebsitePresenter : BasePresenter
    {
        private readonly IWebsiteView _view;
        protected ISiteProvider _siteProvider;

        internal WebsitePresenter(IWebsiteView view) : base(view)
        {
            _view = view;
           
            _view.SelectedWebsiteChanged += async (s, e) => { await SelectedWebsiteChanged(s, e as EventArgs<SelectedWebsiteChangedArgs>); };
            
            _view.WebrootFolderChanged += async (s, e) => { await RetrieveAndShowHostnames(s, e as EventArgs<string[]>); };
            _view.FolderBrowserClicked += (sender, args) => _view.SetWebrootTextbox(args.Value, ShowFolderSelector(SelectedProfile, false));
        }

        protected override async Task Loaded(object sender, EventArgs ea)
        {
            Presenter.ProfileChanged += async (s, e) => { await ProfileChanged(s, e as EventArgs<bool>); };
            Presenter.TopologyChanged += async (s, e) => { await TopologyChanged(s, e as EventArgs<bool>); };

            _siteProvider = Create.WithCurrentProfile<ISiteProvider>(_view);

            await GetSitecoreSites();

            //_view.EnableControls(e.Value);

            var isXM = SelectedProfile.IsXM;

            _view.SetWebsiteDropdownByProfile(SelectedProfile);
            _view.SetPathTextboxes(SelectedProfile.Webroot, isXM ? SelectedProfile.CDSiteRoot: SelectedProfile.XConnectSiteRoot);

            _view.SetHandlers();
            _view.SetLables(isXM);
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        private async Task GetSitecoreSites()
        {
            try
            {
                var sitecoreSites = await Presenter.GetSitecoreSites();
                _view.LoadWebsitesDropdown(sitecoreSites);

                var sites = sitecoreSites.Cast<string>().ToArray();

                var path1 = await _siteProvider.GetSitePath(sites[0]);
                var path2 = await _siteProvider.GetSitePath(sites[1]);
                _view.SetPathTextboxes(path1, path2);

                var bindings = await _siteProvider.GetBindings(sites);
                _view.ShowSiteHostnames(bindings, ControlSettings.Grid.HostnameColumns);
            }
            catch (RemoteNotInitializedException)
            {
                ShowConnectivityError();
            }
        }

        private async Task TopologyChanged(object sender, EventArgs<bool> e)
        {
            _view.SetLables(e.Value);
        }
        private async Task ProfileChanged(object sender, EventArgs<bool> e)
        {
            _view.EnableControls(e.Value);
            _view.SetWebsiteDropdownByProfile(SelectedProfile);
            //_view.SetWebrootTextbox(SelectedProfile?.Webroot);
            _view.SetPathTextboxes(SelectedProfile?.Webroot, SelectedProfile?.CDSiteRoot);

            var param = new[] 
            { 
                SelectedProfile.Website, 
                SelectedProfile.IsXM 
                    ? SelectedProfile.CDSiteName 
                    : SelectedProfile.XConnectSiteName 
            };

            var bindings = SelectedProfile != null
                ? await _siteProvider.GetBindings(param)
                : new Dictionary<string, string>();

            _view.ShowSiteHostnames(bindings, ControlSettings.Grid.HostnameColumns);
        }

        private async Task SelectedWebsiteChanged(object sender, EventArgs<SelectedWebsiteChangedArgs> e)
        {
            _view.EnableControls(false);

            var path = await _siteProvider.GetSitePath(e.Value.Value);
            _view.SetWebrootTextbox(e.Value.TextBox, path);

            var bindings = await _siteProvider.GetBindings(e.Value.Sites);
            _view.ShowSiteHostnames(bindings, ControlSettings.Grid.HostnameColumns);

            _view.EnableControls(true);
        }

        private async Task RetrieveAndShowHostnames(object sender, EventArgs<string[]> e)
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
    }
}
