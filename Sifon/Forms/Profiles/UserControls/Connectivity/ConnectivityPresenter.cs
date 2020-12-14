using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.Model;
using Sifon.Abstractions.PowerShell;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Factories;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    internal class ConnectivityPresenter : BasePresenter
    {
        private readonly IConnectivityView _view;
        private IScriptWrapper<ISolrInfo> _scriptWrapper;
        private ISolrIdentifier _solrIdentifier;

        internal ConnectivityPresenter(IConnectivityView view) : base(view)
        {
            _view = view;
            _view.TestSolr += TestSolr;
            _view.SqlServersUpdated += SqlServersUpdated;
        }

        protected override async Task Loaded(object sender, EventArgs ea)
        {
            Presenter.ProfileChanged += async (s, e) => { await ProfileChanged(s, e as EventArgs<bool>); };
            Presenter.RemoteInitialized += async (s, e) => { await RedrawForm(); };
            Presenter.FormClosing += FormClosing;

            await RedrawForm();
        }

        private async Task RedrawForm()
        {
            if (SelectedProfile != null)
            {
                _view.LoadDatabaseServersDropdown(Presenter.SqlServerNames, SelectedProfile.SqlServerRecord?.RecordName);
                _view.LoadSolrDropdown();
                _view.SetSolrValue(SelectedProfile?.Solr);

                //TODO : Re-use here
                _solrIdentifier = Create.WithCurrentProfile<ISolrIdentifier>(_view);
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

            await Run(e.Value);

            if (_scriptWrapper.Results.Any())
            {
                _displayMessage.ShowInfo(Messages.Profiles.Connectivity.TestSolrCaption, Messages.Profiles.Connectivity.TestSolrSuccessful);
            }
            else
            {
                _displayMessage.ShowError(Messages.Profiles.Connectivity.TestSolrCaption, Messages.Profiles.Connectivity.Errors.TestSolrFailed);
            }

            _view.ToggleControls(true);
        }

        private async Task Run(string url)
        {
            _scriptWrapper = Create.WithParam(_view, SolrInfoExtensions.Convert);
            await _scriptWrapper.Run(Modules.Functions.TestSolrEndpoint, new Dictionary<string, dynamic> {{"Url", url }});
        }

        private async Task ProfileChanged(object sender, EventArgs<bool> e)
        {
            await Task.CompletedTask;

            if (SelectedProfile == null) return;

            _view.ShowSpinnerHideGrid(true);

            await RedrawForm();

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
