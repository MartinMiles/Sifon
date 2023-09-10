using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Metacode;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Forms.Base;
using Sifon.Code.BackupInfo;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.Model;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.MainForm
{
    internal class MainPresenter : ScriptablePresenter
    {
        internal MainPresenter(IMainView view): base(view)
        {
            if (!_profilesProvider.Any)
            {
                // first time run
                if (!view.ShowFirstRunDialog())
                {
                    throw new InvalidOperationException("Exited by user");
                }
                
                var provider = Create.New<IProfilesProvider>();
                provider.Save();

                CreateDummyProfile(provider);

                //view.ForceProfileDialogOnFirstRun();
                _profilesProvider.Read();
            }

            _view.FormLoaded += Loaded;
            _view.SelectedProfileChanged += SelectedProfileChanged;
            _view.ProfilesToolStripClicked += ProfilesToolStripClicked;
            _view.SettingsChanged += SettingsChanged;
            _view.InstallToolStripClicked += InstallToolStripClicked; 
            _view.BackupToolStripClicked += BackupToolStripClicked;
            _view.RestoreToolStripClicked += RestoreToolStripClicked;
            _view.RemoveToolStripClicked += RemoveToolStripClicked;
            _view.ScriptToolStripClicked += async (s, e) => { await ScriptToolStripClicked(s, e as EventArgs<string>); };
        }

        // copied from ProfilesPresenter
        public void CreateDummyProfile(IProfilesProvider profilesProvider)
        {
            var fakeLocalProfile = profilesProvider.CreateLocal();
            fakeLocalProfile.ProfileName = Settings.ProfileNotCreated;
            fakeLocalProfile.Prefix = "Please submit the actual values instead";
            profilesProvider.Add(fakeLocalProfile);
            profilesProvider.SelectProfile(fakeLocalProfile.ProfileName);
        }

        private string WinformsAssemblyLocation => typeof(Form).Assembly.Location;

        private IEnumerable<string> JustReadProfileNames => _profilesProvider.Read().Select(p => p.ProfileName);

        private void Loaded(object sender, EventArgs e)
        {
            if (SelectedProfile != null)
            {
                var profileNames = JustReadProfileNames;
                _view.LoadProfilesSelector(profileNames, SelectedProfile.ProfileName);
                _view.ToolStripsEnabled(ToolStripsEnabled(profileNames));

                UpdatePluginsMenu(IsLocal);
            }
            else
            {
                _view.TerminateAsEmptyProfile();
            }
        }

        private async Task<string> LocalOrRemote(string script)
        {
            var _remoteScriptCopier = Create.WithCurrentProfile<IRemoteScriptCopier>(_view);
            return await _remoteScriptCopier.CopyIfRemote(script);
        }

        #region Install-Backup-Remove-Restore

        private async void InstallToolStripClicked(object sender, EventArgs<dynamic> e)
        {
            var dictionary = new Dictionary<string, object> { { "Params", e.Value } };

            await PrepareAndStart(Modules.Functions.InstallDownloadSitecore, dictionary, e.Value.Profile);
            await PrepareAndStart(Modules.Functions.InstallPrerequisitesForSitecore, dictionary, e.Value.Profile);
            await PrepareAndStart(Modules.Functions.InstallSitecore, dictionary, e.Value.Profile);

            if (e.Value.CreateProfile)
            {
                CreateProfileFrom(e.Value);
            }

            // todo: validate in debugger why 100% mark never hit there
            _view.UpdateProgressBar(100, "Sitecore installation complete");
        }

        private void CreateProfileFrom(dynamic value)
        {
            var profileProvider = Create.New<IProfilesProvider>();
            var profile = profileProvider.CreateProfile((string)value.Prefix);

            profile.RemotingEnabled = value.RemotingEnabled;
            profile.RemoteHost = value.RemotingHost;
            profile.RemoteUsername = value.RemotingUsername;
            profile.RemotePassword = value.RemotingPassword;
            profile.RemoteFolder = value.RemotingPassword;

            profile.AdminPassword = value.SitecoreAdminPassword;
            profile.AdminUsername = "admin";

            profile.IsXM = value.IsXM;
            profile.Prefix = value.Prefix;
            profile.Website = value.SitecoreSiteName;
            profile.Webroot = value.SitePhysicalRoot + "\\" + value.SitecoreSiteName;
            profile.XConnectSiteName = value.XConnectSiteName;
            profile.XConnectSiteRoot = value.SitePhysicalRoot + "\\" + value.XConnectSiteName;
            profile.CDSiteName = value.CDSiteName;
            profile.CDSiteRoot = value.SitePhysicalRoot + "\\" + value.CDSiteName;

            profile.Solr = value.SolrUrl;

            var sqlRecord = profile.AppendSQL(value.SqlServer, value.SqlAdminUser, value.SqlAdminPassword);

            var sqlProvider = Create.New<ISqlServerRecordProvider>();
            sqlProvider.Add(sqlRecord);
            sqlProvider.Save();

            _profilesProvider.Append(profile);
            _profilesProvider.Save();
            _profilesProvider.SelectProfile(profile.ProfileName);

            _view.LoadProfilesSelector(JustReadProfileNames, profile.ProfileName);
        }

        private async void BackupToolStripClicked(object sender, EventArgs<IBackupRemoverViewModel> e)
        {
            var model = e.Value;

            await BackupInfoExtensions.CreateBackupInfo(SelectedProfile.Website, SelectedProfile.Webroot, SelectedProfile, _view);

            if (model.XConnectFolder.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.XConnectFolder, SelectedProfile, _view);
            }

            if (model.IdentityFolder.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.IdentityFolder, SelectedProfile, _view);
            }

            if (model.HorizonFolder.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.HorizonFolder, SelectedProfile, _view);
            }

            if (model.PublishingFolder.NotEmpty())
            {
                await BackupInfoExtensions.CreateBackupInfo(string.Empty, model.PublishingFolder, SelectedProfile, _view);
            }

            if (model.CommerceSites != null && model.CommerceSites.Any())
            {
                foreach (var commerceSite in model.CommerceSites)
                {
                    await BackupInfoExtensions.CreateBackupInfo(string.Empty, commerceSite.Key, SelectedProfile, _view);
                }
            }

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Activity, Messages.Activities.Backup }};
            _profilesProvider.AddScriptProfileParameters(parameters);
            _profilesProvider.AddBackupRemoveParameters(parameters, model);
            _profilesProvider.AddCommerceScriptParameters(parameters, model.CommerceSites);

            await Run(model, parameters);
        }

        private async void RemoveToolStripClicked(object sender, EventArgs<IBackupRemoverViewModel> e)
        {
            var model = e.Value;

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Activity, Messages.Activities.Remove }};
            _profilesProvider.AddScriptProfileParameters(parameters);
            _profilesProvider.AddBackupRemoveParameters(parameters, model);
            _profilesProvider.AddCommerceScriptParameters(parameters, model.CommerceSites);

            await Run(model, parameters);
        }

        private async void RestoreToolStripClicked(object sender, EventArgs<IRestoreViewModel> e)
        {
            var model = e.Value;

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.Activity, Messages.Activities.Restore }};
            _profilesProvider.AddScriptProfileParameters(parameters);
            _profilesProvider.AddBackupRemoveParameters(parameters, model);
            _profilesProvider.AddRestoreParameters(parameters, model);
            _profilesProvider.AddCommerceScriptParameters(parameters, model.CommerceSites);

            await Run(model, parameters);
        }

        private async Task Run(IBackupRemoverViewModel model, Dictionary<string, object> parameters)
        {
            var iScript = Create.WithParam<IScript>(model);
            await PrepareAndStart(await LocalOrRemote(iScript.Script), parameters);
        }

        #endregion

        public IRemoteScriptCopier RemoteScriptCopier => Create.WithCurrentProfile<IRemoteScriptCopier>(_view);

        private async Task ScriptToolStripClicked(object sender, EventArgs<string> e)
        {
            var metacode = Create.WithParam<IMetacodeHelper, string>(e.Value);

            if (metacode.RequiresProfile 
                && _profilesProvider.SelectedProfile.ProfileName == Settings.ProfileNotCreated
                && _profilesProvider.Count == 1)
            {
                _view.NotifyRequiresProfile();
                return;
            }
                
            string script = metacode.ExecuteLocalOnly ? e.Value : await LocalOrRemote(e.Value);
            if (script == null)
            {
                _view.NotifyRemoteNotAccessible();
                return;
            }

            var parameters = new Dictionary<string, dynamic>();
            _profilesProvider.AddScriptProfileParameters(parameters, metacode.ExecuteLocalOnly);
            _settingsProvider.AddScriptSettingsParameters(parameters);
            _containersProvider.AddContainersParameters(parameters);
            await AddParametersFromMetacode(parameters, metacode);
            
            var scriptDependencies = metacode.IdentifyDependencies();
            foreach (string dependency in scriptDependencies)
            {
                string dependencyFile = $"{Path.GetDirectoryName(e.Value)}\\{dependency}";
                if (File.Exists(dependencyFile))
                {
                    await RemoteScriptCopier.CopyIfRemote(dependencyFile);
                }
            }

            await PrepareAndStart(script, parameters, metacode.ExecuteLocalOnly);

            _view.PluginsToolStripEnabled();
        }

        private async Task AddParametersFromMetacode(Dictionary<string, object> parameters, IMetacodeHelper metacode)
        {
            var metacodeResultsDictionary = metacode.ExecuteMetacode(parameters, WinformsAssemblyLocation);

            foreach (var metadataPair in metacodeResultsDictionary)
            {
                // if we used external control to ask for file, add it then with a provided param
                if (metadataPair.Value is string && ((string)metadataPair.Value).IsValidFilePath())
                {
                    string localFile = (string)metadataPair.Value;

                    var resultedPath = await RemoteScriptCopier.CopyIfRemote(localFile);

                    parameters.Add(metadataPair.Key.Trim('$'), resultedPath);
                }
                else
                {
                    parameters.Add(metadataPair.Key.Trim('$'), metadataPair.Value);
                }
            }
        }

        public bool IsLocal => !SelectedProfile.RemotingEnabled;

        private void SelectedProfileChanged(object sender, EventArgs<string> e)
        {
            _profilesProvider.SelectProfile(e.Value);

            UpdatePluginsMenu(IsLocal);

            _view.SetCaption(_profilesProvider.SelectedProfile.WindowCaptionSuffix);

            _view.ToolStripsEnabled(ToolStripsEnabled(JustReadProfileNames));
        }

        private void ProfilesToolStripClicked(object sender, EventArgs e)
        {
            UpdatePluginsMenu(IsLocal);

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

        private void SettingsChanged(object sender, EventArgs e)
        {
            UpdatePluginsMenu(IsLocal);
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

            var localFilesystem = Create.Filesystem.Local();

            var menuItem = new PluginMenuItem
            {
                DirectoryName = di.Name,
                DirectoryFullPath = di.FullName,
                Scripts = localFilesystem.GetFiles(di.FullName, ".ps1"),
                Plugins = localFilesystem.GetFiles(di.FullName, ".dll")
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
