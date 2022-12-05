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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Helpers;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Statics;

namespace Sifon.Forms.Solr
{
    internal class InstallSolrPresenter
    {
        private readonly IInstallSolr _view;
        private readonly SolrHelper _viewHelper;
        private readonly IProfile _profile;
        private readonly IScriptWrapper<bool> _scriptWrapper;
        private ISolrIdentifier _solrIdentifier;

        internal InstallSolrPresenter(IInstallSolr view, SolrHelper viewHelper)
        {
            _view = view;
            _view.LoadedAsync += async (s, e) => { await Loaded(s, e); };
            _viewHelper = viewHelper;
            _view.InstallClicked += InstallClicked;
            _view.UninstallClicked += async (s, e) => { await UninstallClicked(s, (EventArgs<string>)e); };
            _view.ClosingForm += ClosingForm;

            _profile = Create.New<IProfilesProvider>().SelectedProfile;

            _scriptWrapper = Create.WithParam(_view, d => bool.Parse(d.ToString()), _profile);

            _view.FolderBrowserClicked += (sender, e) => e.Value1.Text = ShowFolderSelector(_profile, e.Value2);
        }

        protected async Task Loaded(object sender, EventArgs ea)
        {
            _view.SetCaption($" - {_profile.WindowCaptionSuffix}");

            _view.ToggleControls(false);
            await RedrawForm();
            _view.ToggleControls(true);
        }

        private async Task RedrawForm()
        {
            if (_profile != null)
            {
                _solrIdentifier = Create.WithCurrentProfile<ISolrIdentifier>(_view);
                _solrIdentifier.OnProgressReady += (sender, args) => _viewHelper.UpdateProgress(args.Value);

                if (!_profile.RemotingEnabled || _profile.RemoteFolder.NotEmpty())
                {
                    _view.ShowSpinnerHideGrid(true);

                    try
                    {
                        _viewHelper.SetSolrGrid(await _solrIdentifier.Identify(), _profile?.RemotingEnabled ?? false);
                    }
                    catch (RemoteNotInitializedException)
                    {
                        ShowConnectivityError();
                    }
                    catch
                    {
                        // need to silently continue here
                    }

                    _view.ShowSpinnerHideGrid(false);
                }
                else
                {
                    _viewHelper.NotifyRemoteNotInitialized();
                }
            }
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        private async void InstallClicked(object sender, EventArgs<ISolrInstall> e)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.SolrVersion, e.Value.Version},
                { Settings.Parameters.SolrPort, e.Value.Port},
                { Settings.Parameters.SolrHostname, e.Value.Hostname},
                { Settings.Parameters.SolrFolder, e.Value.Folder}
            };

            await _scriptWrapper.Run(Modules.Functions.InstallSolr, parameters);
            _view.UpdateView(_scriptWrapper.Results.Last());

            await _view.OnLoad();
        }

        private async Task UninstallClicked(object sender, EventArgs<string> e)
        {
            string pattern = "(\\w{1}:\\\\.*)\\\\solr-(\\d\\.\\d{1,2}\\.\\d)\\\\.*";

            var regex = new Regex(pattern);
            var match = regex.Match(e.Value);
            if (match.Success)
            {
                var parameters = new Dictionary<string, dynamic>
                {
                    { Settings.Parameters.SolrVersion, match.Groups[2].Value},
                    { Settings.Parameters.SolrPort, SolrHelper.SuggestValidPort(match.Groups[2].Value.Replace(".",""))},
                    { Settings.Parameters.SolrHostname, "localhost"},
                    { Settings.Parameters.SolrFolder, match.Groups[1].Value},
                    { Settings.Parameters.SolrUninstall, true}
                };

                await _scriptWrapper.Run(Modules.Functions.InstallSolr, parameters);
                _view.UpdateView(_scriptWrapper.Results.Last());

                await _view.OnLoad();
            }
            else
            {
                _view.ShowError("Operation failed", "This instance is likely installed outside this tool or no longer exists.");
            }
        }

        protected void ShowConnectivityError()
        {
            _view.ShowError(Messages.Profiles.Connectivity.Errors.ProfileDamaged, Messages.Profiles.Connectivity.Errors.RemoteFoldermissing);
        }

        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper.Finish();
        }
    }
}
