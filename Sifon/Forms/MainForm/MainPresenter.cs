using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.Providers;
using Sifon.Forms.Base;
using Sifon.Shared.BackupInfo;
using Sifon.Shared.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Filesystem;
using Sifon.Shared.Model;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.ScriptGenerators;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.MainForm
{
    internal class MainPresenter : ScriptablePresenter
    {
        private readonly ISuperClass _superClass;
        private readonly IFilesystem _filesystem;

        internal MainPresenter(IMainView view): base(view)
        {
            if (!_profilesService.Any)
            {
                var provider = new ProfilesProvider();
                provider.Save();

                InstallModuleOnfirstRun();

                view.ForceProfileDialogOnFirstRun();
                _profilesService.Read();
            }

            _superClass = new SuperClass();
            _filesystem = new FilesystemFactory(SelectedProfile, _view).CreateLocal();


            _view.FormLoaded += Loaded;
            _view.SelectedProfileChanged += SelectedProfileChanged;
            _view.ProfilesToolStripClicked += ProfilesToolStripClicked;

            _view.BackupToolStripClicked += BackupToolStripClicked;
            _view.RestoreToolStripClicked += RestoreToolStripClicked;
            _view.RemoveToolStripClicked += RemoveToolStripClicked;
            _view.ScriptToolStripClicked += ScriptToolStripClicked;
            
        }

        private void InstallModuleOnfirstRun()
        {
            var ps = PowerShell.Create();
            ps.AddCommand(".\\PowerShell\\Module\\_deploy_to_modules.ps1");
            ps.Invoke();
        }

        private IEnumerable<string> JustReadProfileNames => _profilesService.Read().Select(p => p.ProfileName);

        private void Loaded(object sender, EventArgs e)
        {
            if (SelectedProfile != null)
            {
                var profileNames = JustReadProfileNames;
                _view.LoadProfilesSelector(profileNames, SelectedProfile.ProfileName);
                _view.ToolStripsEnabled(ToolStripsEnabled(profileNames));
                _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Settings.Folders.Plugins));
            }
            else
            {
                _view.TerminateAsEmptyProfile();
            }
        }

        private string CaptionSuffix => _superClass.AppendEnvironmentToCaption(_profilesService.SelectedProfile);

        private async Task<string> LocalOrRemote(string script)
        {
            var _remoteScriptCopier = new RemoteScriptCopier(_profilesService.SelectedProfile, _view);
            return await _remoteScriptCopier.CopyIfRemote(script);
        }

        #region Backup-Remove-Restore


        private async void BackupToolStripClicked(object sender, EventArgs<IBackupRestoreModel> e)
        {
            model = e.Value;

            await BackupInfoExtensions.CreateBackupInfo(model.SitecoreInstance, SelectedProfile.Webroot, SelectedProfile, _view);

            if (model.XConnect.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.XConnect, SelectedProfile, _view);
            }

            if (model.IdentityServer.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.IdentityServer, SelectedProfile, _view);
            }

            if (model.Horizon.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.Horizon, SelectedProfile, _view);
            }

            if (model.PublishingService.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.PublishingService, SelectedProfile, _view);
            }

            if (model.CommerceSites != null && model.CommerceSites.Any())
            {
                foreach (var commerceSite in model.CommerceSites)
                {
                    await BackupInfoExtensions.CreateBackupInfo(string.Empty, commerceSite.Key, SelectedProfile, _view);
                }
            }

            var parameters = new Dictionary<string, dynamic> { { Settings.Parameters.Activity, Messages.Activities.Backup } };
            _profilesService.AddScriptProfileParameters(parameters);
            _profilesService.AddScriptModelParameters(parameters, model);
            _profilesService.AddCommerceScriptParameters(parameters, model.CommerceSites);

            PrepareAndStart(await LocalOrRemote(ScriptFactory.Create(model, SelectedProfile).Script), parameters);
        }

        private async void RemoveToolStripClicked(object sender, EventArgs<IBackupRestoreModel> e)
        {
            var model = e.Value;

            var parameters = new Dictionary<string, dynamic> { { Settings.Parameters.Activity, Messages.Activities.Remove } };
            _profilesService.AddScriptProfileParameters(parameters);
            _profilesService.AddScriptModelParameters(parameters, model);
            _profilesService.AddCommerceScriptParameters(parameters, model.CommerceSites);

            PrepareAndStart(await LocalOrRemote(ScriptFactory.Create(model, SelectedProfile).Script), parameters);
        }

        private async void RestoreToolStripClicked(object sender, EventArgs<IBackupRestoreModel> e)
        {
            var model = e.Value;

            var parameters = new Dictionary<string, dynamic> { { Settings.Parameters.Activity, Messages.Activities.Restore } };
            _profilesService.AddScriptProfileParameters(parameters);
            _profilesService.AddScriptModelParameters(parameters, model);
            _profilesService.AddCommerceScriptParameters(parameters, model.CommerceSites);

            // pass zip archive as $Website into restore script (a minor hack)
            parameters[Settings.Parameters.Website] = model.SitecoreInstance;

            PrepareAndStart(await LocalOrRemote(ScriptFactory.Create(model, SelectedProfile).Script), parameters);
         }

        #endregion

        private async void ScriptToolStripClicked(object sender, EventArgs<string> e)
        {
            var parameters = new Dictionary<string, dynamic>();
            _profilesService.AddScriptProfileParameters(parameters);
            _settingsProvider.AddScriptSettingsParameters(parameters);
            _containersProvider.AddContainersParameters(parameters);

            string script = await LocalOrRemote(e.Value);
            PrepareAndStart(script, parameters);
        }

        private void SelectedProfileChanged(object sender, EventArgs<string> e)
        {
            _profilesService.SelectProfile(e.Value);
            _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Settings.Folders.Plugins));
            _view.SetCaption(CaptionSuffix);

            _view.ToolStripsEnabled(ToolStripsEnabled(JustReadProfileNames));
        }

        private void ProfilesToolStripClicked(object sender, EventArgs e)
        {
            _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Settings.Folders.Plugins));
            _view.ToolStripsEnabled(ToolStripsEnabled(JustReadProfileNames));

            if (SelectedProfile != null)
            {
                _view.LoadProfilesSelector(JustReadProfileNames, SelectedProfile.ProfileName);
            }
            else
            {
                _view.TerminateAsEmptyProfile();
            }
        }

        private bool ToolStripsEnabled(IEnumerable<string> profileNames)
        {
            return profileNames.Any()
                   && !string.IsNullOrWhiteSpace(SelectedProfile.SqlServerRecord?.RecordName)
                   && (!SelectedProfile.RemotingEnabled || SelectedProfile.RemoteFolder.NotEmpty());
        }

        protected override PluginMenuItem GetPluginsAndScripts(string baseDirectory)
        {
            var di = new DirectoryInfo(baseDirectory);

            var menuItem = new PluginMenuItem
            {
                DirectoryName = di.Name,
                DirectoryFullPath = di.FullName,
                Scripts = _filesystem.GetFiles(di.FullName, ".ps1"),
                Plugins = _filesystem.GetFiles(di.FullName, ".dll")
            };

            foreach (var chilDirectory in di.GetDirectories())
            {
                if (chilDirectory.Name == ".git")
                {
                    continue;
                }

                menuItem.Children.Add(GetPluginsAndScripts(chilDirectory.FullName));
            }

            return menuItem;
        }
    }
}
