using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;
using Sifon.Code.Statics;
using Sifon.Shared.Forms.FolderBrowserDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sifon.Forms.Solr
{
    internal class InstallSolrPresenter
    {
        private readonly IInstallSolr _view;
        private readonly IProfile _profile;
        private readonly IScriptWrapper<bool> _scriptWrapper;

        internal InstallSolrPresenter(IInstallSolr view)
        {
            _view = view;
            _view.FormLoad += FormLoad;
            _view.InstallClicked += InstallClicked;
            _view.ClosingForm += ClosingForm;

            _profile = Create.New<IProfilesProvider>().SelectedProfile;

            _scriptWrapper = Create.WithParam(_view, d => bool.Parse(d.ToString()), _profile);
            //_scriptWrapper.ProgressReady += ProgressReady;
            //_scriptWrapper.ErrorReady += ErrorReady;

            _view.FolderBrowserClicked += (sender, e) => e.Value1.Text = ShowFolderSelector(_profile, e.Value2);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _view.SetCaption($" - {_profile.WindowCaptionSuffix}");
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        private async void InstallClicked(object sender, EventArgs<ISolrInstall> e)
        {
            string version = e.Value.Version;
            string folder = e.Value.Folder;

            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.SolrVersion, e.Value.Version},
                { Settings.Parameters.SolrPort, e.Value.Port},
                { Settings.Parameters.SolrHostname, e.Value.Hostname},
                { Settings.Parameters.SolrFolder, e.Value.Folder}
            };

            await _scriptWrapper.Run(Modules.Functions.InstallSolr, parameters);
            _view.UpdateView(_scriptWrapper.Results.Last());
        }

        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper.Finish();
        }
    }
}
