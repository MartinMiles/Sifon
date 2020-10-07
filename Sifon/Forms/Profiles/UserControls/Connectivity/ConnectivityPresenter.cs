using System;
using System.Collections.Generic;
using System.Linq;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Helpers;
using Sifon.Code.Model;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    internal class ConnectivityPresenter : BasePresenter
    {
        private readonly IConnectivityView _view;
        private ScriptWrapper<SolrInfo> _scriptWrapper;
        private SolrIdentifier _solrIdentifier;
        private RemoteScriptCopier _remoteScriptCopier;

        public ConnectivityPresenter(IConnectivityView view) : base(view)
        {
            _view = view;
            _view.TestSolr += TestSolr;
            _view.SqlServersUpdated += SqlServersUpdated;
        }
        protected override void Loaded(object sender, EventArgs e)
        {
            Presenter.ProfileChanged += ProfileChanged;
            Presenter.RemoteInitialized += RemoteInitialized;
            Presenter.FormClosing += FormClosing;
            RedrawForm();
        }

        private void RemoteInitialized(object sender, EventArgs e)
        {
            RedrawForm();
        }

        private async void RedrawForm()
        {
            if (SelectedProfile != null)
            {
                _view.LoadDatabaseServersDropdown(Presenter.SqlServerNames, SelectedProfile.SqlServerRecord?.RecordName);
                _view.LoadSolrDropdown();
                _view.SetSolrValue(SelectedProfile?.Solr);

                _solrIdentifier = new SolrIdentifier(SelectedProfile, _view);
                _solrIdentifier.OnProgressReady += (sender, args) => _view.UpdateProgress(args.Value);

                if (!SelectedProfile.RemotingEnabled || SelectedProfile.RemoteFolder.NotEmpty())
                {
                    _view.ShowSpinnerHideGrid(true);

                    try
                    {
                        if (SelectedProfile != null)
                        {
                            _view.SetSolrGrid(await _solrIdentifier.Identify(), SelectedProfile?.RemotingEnabled ?? false);
                            _view.SetSolrDropdownByProfile(SelectedProfile?.Solr);
                        }
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
                    _view.NotifyRemoteNotInitialized();
                }
            }
        }

        private async void TestSolr(object sender, EventArgs<string> e)
        {
            _view.ToggleControls(false);

            _remoteScriptCopier = new RemoteScriptCopier(SelectedProfile, _view);
            _scriptWrapper = new ScriptWrapper<SolrInfo>(SelectedProfile, _view, SolrInfoExtensions.Convert);

            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.TestSolr);
            var parameters = new Dictionary<string, dynamic> {{"Url", $"{e.Value}/admin/info/system?wt=json"} };

            await _scriptWrapper.Run(script, parameters);

            if (_scriptWrapper.Results.Any())
            {
                _formValidation.ShowInfo(Messages.Profiles.Connectivity.TestSolrCaption, Messages.Profiles.Connectivity.TestSolrSuccessful);
            }
            else
            {
                _formValidation.ShowError(Messages.Profiles.Connectivity.TestSolrCaption, Messages.Profiles.Connectivity.Errors.TestSolrFailed);
            }

            _view.ToggleControls(true);
        }

        private void ProfileChanged(object sender, EventArgs<bool> e)
        {
            if (SelectedProfile == null) return;

            _view.ShowSpinnerHideGrid(true);

            RedrawForm();

            _view.ToggleControls(e.Value);
        }

        private void SqlServersUpdated(object sender, EventArgs e)
        {
            ProfilesService.Read();
            _view.LoadDatabaseServersDropdown(Presenter.SqlServerNames, SelectedProfile?.SqlServerRecord?.RecordName);
        }

        private void FormClosing(object sender, EventArgs e)
        {
            _scriptWrapper?.Finish();
            _solrIdentifier.Finish();
        }
    }
}
