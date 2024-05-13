using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.Model.Fake;
using Sifon.Code.Statics;
using Sifon.Shared.MessageBoxes;
using Sifon.Statics;

namespace Sifon.Forms.SQL
{

    internal class InstallDatabasePresenter
    {
        private readonly IInstallDatabase _view;
        private readonly IProfile _profile;
        private IScriptWrapper<PSObject> _scriptWrapper;
        private IScriptWrapper<PSObject> _sqlScriptWrapper;

        protected readonly IDisplayMessage _displayMessage;

        internal InstallDatabasePresenter(IInstallDatabase view/*, SQLHelper viewHelper*/)
        {
            _view = view;

            _view.InstallClicked += InstallClicked;
            _view.TestSqlClicked += TestSqlClicked;

            _profile = Create.New<IProfilesProvider>().SelectedProfile;

            _scriptWrapper = Create.WithParam(_view, d => d, _profile);

            _displayMessage = new DisplayMessage();
        }

        private async void InstallClicked(object sender, EventArgs<IDatabaseInstall> e)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.DatabaseServerEdition, e.Value.Edition},
                { Settings.Parameters.DatabaseServerVersion, e.Value.Version},
                { Settings.Parameters.DatabaseServerInstance, e.Value.SqlServer},
                { Settings.Parameters.DatabaseServerPassword, e.Value.SqlAdminPassword}
            };

            await _scriptWrapper.Run(Modules.Functions.InstallDatabaseServer, parameters);
            ValidateSqlResult(_scriptWrapper.Results, _scriptWrapper.Errors.Select(ex => ex.Message));

            var result = _scriptWrapper.Results.LastOrDefault();
            _view.UpdateView(result?.BaseObject is bool boolValue && boolValue);
        }

        private async void TestSqlClicked(object sender, EventArgs<ISqlServerRecord> e)
        {
            _view.ToggleControls(false);

            string serverInstance = e.Value.SqlServer.StartsWith(".\\") ? e.Value.SqlServer : $".\\{e.Value.SqlServer}";

            var parameters = new Dictionary<string, dynamic> { { Settings.Parameters.ServerInstance, serverInstance } };
            parameters.Add("Username", e.Value.SqlAdminUsername);
            parameters.Add("Password", e.Value.SqlAdminPassword);

            _sqlScriptWrapper = Create.WithParam(_view, d => d);
            await _sqlScriptWrapper.Run(Modules.Functions.TestSqlServerConnection, parameters);

            ValidateTestSql(_sqlScriptWrapper.Results, _sqlScriptWrapper.Errors.Select(ex => ex.Message));

            _view.ToggleControls(true);
            _view.ToggleSpinner(true);
        }

        private void ValidateTestSql(IEnumerable<PSObject> results, IEnumerable<string> errors)
        {
            if (!results.Any())
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, Messages.SqlSettings.Errors.NoResults);
            }

            if (errors.Any())
            {
                if(errors.First().Contains("Error Locating Server"))
                {
                    _displayMessage.ShowInfo(Messages.SqlSettings.Caption, "Such an instance does not exist, you're good to go!");
                }
            }
            else
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, "Such instance already exists, test out with other parameters.");
            }
        }
        private void ValidateSqlResult(IEnumerable<PSObject> results, IEnumerable<string> errors)
        {
            if (!results.Any())
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, Messages.SqlSettings.Errors.NoResults);
            }

            if (results.Count() > 1)
            {
                var oneBeforeLastResult = results.Take(results.Count() - 1).LastOrDefault();
                if (ValidateQueryTime(oneBeforeLastResult))
                {
                    _displayMessage.ShowInfo(Messages.SqlSettings.Caption, Messages.General.Success);
                }
            }

            if (errors.Any())
            {
                _displayMessage.ShowError(Messages.SqlSettings.Caption, errors.First());
            }
        }

        // TODO: duplicates same method from SqlSettingsPresenter and install sitecore
        private bool ValidateQueryTime(PSObject psObject)
        {
            var queryTime = psObject.Convert<QueryTime>();
            if (queryTime != null && queryTime.TimeOfQuery != DateTime.MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
