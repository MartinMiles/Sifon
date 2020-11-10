using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Forms.Base;
using Sifon.Code.Statics;
using Sifon.ViewModels;

namespace Sifon.Forms.Remover
{
    internal class RemoverPresenter : BaseBackupRestorePresenter
    {
        private readonly IRemoverView _view;
        private Dictionary<string, string> _commerceSites;

        internal RemoverPresenter(IRemoverView removerView) : base(removerView)
        {
            _view = removerView;

            _view.LoadedAsync += async (s, e) => { await Loaded(s, e); };
            _view.InstanceChanged += async (s, e) => { await InstanceChanged(s, e as EventArgs<string>); };
            _view.DatabaseFilterChanged += async (s, e) => { await DatabaseFilterChanged(s, e as EventArgs<string>); };
            _view.BeforeFormClosing += ClosingForm;

            _scriptWrapper.Complete += Complete;
        }

        private async Task Loaded(object sender, EventArgs e)
        {
            var instances = await _siteProvider.GetSitecoreSites();
            _view.PopulateInstancesDropdown(instances);
        }

        private void Complete(IScriptRunner sender)
        {
            _view.FinishUI();
        }

        private async Task DatabaseFilterChanged(object sender, EventArgs<string> e)
        {
            _view.ToggleControls(false);
            await UpdateDatabasesListbox(e.Value);
            _view.ToggleControls(true);
        }

        private async Task InstanceChanged(object sender, EventArgs<string> e)
        {
            _view.ToggleControls(false);

            var viewModel = await BuildViewModel(e.Value);
            _view.SetWebfoldersAndCheckboxes(viewModel);

            var prefix = _profileProvider.FindPrefixByName(e.Value);

            string databaseSearchPrefix = e.Value == Settings.ManualEntry ? String.Empty : prefix;
            await UpdateDatabasesListbox(databaseSearchPrefix);

            _view.ToggleControls(true);
        }

        private async Task<IBackupRestoreFolders> BuildViewModel(string siteName)
        {
            _commerceSites = (await _siteProvider.GetCommerceSites(siteName)).ToDictionary(s => s, s => s);

            var model = new BackupRemoverViewModel
            {
                WebsiteFolder = await _siteProvider.GetSitePath(siteName),
                XConnectFolder = siteName == Settings.ManualEntry ? String.Empty : await _siteProvider.GetXconnect(siteName),
                IdentityFolder = siteName == Settings.ManualEntry ? String.Empty : await _siteProvider.GetIDS(siteName),
                HorizonFolder = siteName == Settings.ManualEntry ? String.Empty : await _siteProvider.GetHorizon(siteName),
                PublishingFolder = siteName == Settings.ManualEntry ? String.Empty : await _siteProvider.GetPublishingService(siteName),
                CommerceSites = _commerceSites
            };

            return model;
        }

        private async Task UpdateDatabasesListbox(string filterValue)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "ServerInstance", _profileProvider.SelectedProfileSql.SqlServer},
                { "InstancePrefix", filterValue }
            };

            _view.ToggleControls(false);

            await _scriptWrapper.Run(Modules.Functions.GetDatabases, parameters);

            if (_commerceSites.Any())
            {
                var commerceDatabases = await _siteProvider.GetCommerceDatabases(_commerceSites.Select(i => i.Key).Last());
                _scriptWrapper.Results.AddRange(commerceDatabases.Results);
            }

            _view.PopulateDatabasesListboxForSite(_scriptWrapper.Results.Where(d => !Settings.Databases.ForbiddenDatabases.Contains(d)), _scriptWrapper.Errors.Select(ex => ex.Message));
        }
    }
}
