using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
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

        protected readonly IDisplayMessage _displayMessage;

        internal InstallDatabasePresenter(IInstallDatabase view/*, SQLHelper viewHelper*/)
        {
            _view = view;

            _view.InstallClicked += InstallClicked;

            _profile = Create.New<IProfilesProvider>().SelectedProfile;

            _scriptWrapper = Create.WithParam(_view, d => d, _profile);

            _displayMessage = new DisplayMessage();
        }

        private async void InstallClicked(object sender, EventArgs<IDatabaseInstall> e)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.DatabaseServerInstance, e.Value.Instance},
                { Settings.Parameters.DatabaseServerPassword, e.Value.Password}
                //{ Settings.Parameters.SolrHostname, e.Value.Hostname},
                //{ Settings.Parameters.SolrFolder, e.Value.Folder}
            };

            await _scriptWrapper.Run(Modules.Functions.InstallDatabaseServer, parameters);
            ValidateSqlResult(_scriptWrapper.Results, _scriptWrapper.Errors.Select(ex => ex.Message));
            
            _view.ToggleControls(true);

            //await _view.OnLoad();
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
