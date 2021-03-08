using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Events;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Model;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Code.Extensions.Models;
using Sifon.Code.Factories;
using Sifon.Code.Model.Fake;
using Sifon.Code.PowerShell;
using Sifon.Forms.Initialize;
using Sifon.Shared.MessageBoxes;
using Sifon.Statics;
using Sifon.Code.Statics;

namespace Sifon.Forms.Install
{
    internal class InstallPresenter
    {
        private readonly IInstallView _view;
        protected readonly IDisplayMessage _displayMessage;
        private IScriptWrapper<ISolrInfo> _scriptWrapper;
        private IScriptWrapper<PSObject> _sqlScriptWrapper;

        internal InstallPresenter(IInstallView view)
        {
            _view = view;
            _displayMessage = new DisplayMessage();

            _view.TestRemote += async (s, e) => { await TestRemote(s, e as EventArgs<IRemoteSettings>); };
            _view.TestSolr += TestSolr;
            _view.TestSqlClicked += TestSqlClicked;
        }


        private async void TestSqlClicked(object sender, EventArgs<ISqlServerRecord, IRemoteSettings> e)
        {
            var profile = CreateProfileFromRemoteSettings(e.Value2);

            _view.ToggleControls(false);

            var parameters = new Dictionary<string, dynamic> { { Settings.Parameters.ServerInstance, e.Value1.SqlServer } };
            var credentials = new PSCredential(e.Value1.SqlAdminUsername, e.Value1.SqlAdminPassword.ToSecureString());
            parameters.Add(Settings.Parameters.SqlCredentials, credentials);

            _sqlScriptWrapper = Create.WithParam(_view, d => d, profile);
            await _sqlScriptWrapper.Run(Modules.Functions.TestSqlServerConnection, parameters);

            ValidateSqlResult(_sqlScriptWrapper.Results, _sqlScriptWrapper.Errors.Select(ex => ex.Message));

            _view.ToggleControls(true);
        }

        private void ValidateSqlResult(IEnumerable<PSObject> results, IEnumerable<string> errors)
        {
            if (!results.Any())
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, Messages.SqlSettings.Errors.NoResults);
                return;
            }

            if (ValidateQueryTime(results.Last()))
            {
                _displayMessage.ShowInfo(Messages.SqlSettings.Caption, Messages.General.Success);
            }

            if (errors.Any())
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, errors.First());
            }
        }

        // TODO: duplicates same method from SqlSettingsPresenter
        private bool ValidateQueryTime(PSObject psObject)
        {
            var queryTime = psObject.Convert<QueryTime>();
            if (queryTime != null && queryTime.TimeOfQuery != DateTime.MinValue)
            {
                return true;
            }

            return false;
        }

        private IProfile CreateProfileFromRemoteSettings(IRemoteSettings remoteSettings)
        {
            var profileProvider = Create.New<IProfilesProvider>();
            return profileProvider.CreateProfile(remoteSettings);
        }

        private async Task TestRemote(object sender, EventArgs<IRemoteSettings> e)
        {
            var scriptWrapper = new ScriptWrapper<string>(CreateProfileFromRemoteSettings(e.Value), _view, d => d.ToString());

            await scriptWrapper.Run("dir");

            if (scriptWrapper.Errors.Any() && scriptWrapper.Errors.First() is RemoteTimeoutException)
            {
                _displayMessage.ShowError("Connection Error", "Failed to connect to remote machine with specified parameters");
            }

            if (scriptWrapper.Results.Any() && _displayMessage.ShowYesNo("Connection successful",
                    "Your connection details are valid.\n\nWould you like to initialize remote host for Sifon?"))
            {
                var initializeForm = new InitRemote
                {
                    StartPosition = FormStartPosition.CenterParent,
                    RemoteSettings = _view
                };
                if (initializeForm.ShowDialog() == DialogResult.OK && initializeForm.RemoteFolder.NotEmpty())
                {
                    _view.RemoteFolder = initializeForm.RemoteFolder;
                }

                initializeForm.Dispose();
            }

            _view.SetRemoteSettings(_view);
        }

        private async void TestSolr(object sender, EventArgs<string, IRemoteSettings> e)
        {
            _view.ToggleControls(false);

            _scriptWrapper = Create.WithParam(_view, SolrInfoExtensions.Convert, CreateProfileFromRemoteSettings(e.Value2));
            await _scriptWrapper.Run(Modules.Functions.TestSolrEndpoint, new Dictionary<string, dynamic> { { "Url", e.Value1 } });

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
    }
}
