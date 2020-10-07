using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Base;
using Sifon.Code.BackupInfo;
using Sifon.Code.Events;
using Sifon.Code.Extensions;
using Sifon.Code.Filesystem;
using Sifon.Code.Statics;
using Sifon.ViewModels;

namespace Sifon.Forms.Restore
{
    internal class RestorePresenter : BaseBackupRestorePresenter
    {
        private readonly IRestoreView _view;
        private readonly IFilesystem _filesystem;
        private readonly IBackupInfoExtractor _backupInfoExtractor;

        internal RestorePresenter(IRestoreView view) : base(view)
        {
            _view = view;
            _view.FolderSelected += FolderSelected;
            _view.ValidateBeforeClose += ValidateBeforeClose;
            _filesystem = _filesystemFactory.Create();

            var backupInfoExtractorFactory = new BackupInfoExtractorFactory(SelectedProfile, _view);
            _backupInfoExtractor = backupInfoExtractorFactory.Create();
        }

        private async void FolderSelected(object sender, EventArgs<string> e)
        {
            var selectedFolder = e.Value;

            var directoryExists = await _filesystem.DirectoryExists(selectedFolder);

            if (selectedFolder.NotEmpty() && directoryExists)
            {
                var iRestoreModel = await BuildViewModel(selectedFolder);
                _view.SetSites(iRestoreModel);
            }
            else
            {
                _view.DisplayDatabases(new string[]{});
            }

            _view.SetRestoreButtonTitle(Settings.Buttons.Restore);
            _view.SetRestoreButton(null);
        }

        private async Task<IRestoreViewModel> BuildViewModel(string selectedFolder)
        {
            var archives = _filesystem.GetFiles(selectedFolder, ".bak");
            var files = _filesystem.GetFiles(selectedFolder, ".zip");
            var list = await GetInputForGrid(files);

            _view.ShowDatagrid(list, new[] { "Backup archive files location", "Destination folder to restore" });

            return new RestoreViewModel
            {
                WebsiteZip = list.FirstOrDefault(i => IsMainSitecoreSite(i.Key)).Key,
                XConnectZip = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.XConnect)).Key,
                IdentityZip = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.IdentityServer)).Key,
                HorizonZip = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.Horizon)).Key,
                PublishingZip = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.PublishingService)).Key,
                
                WebsiteFolder =  list.FirstOrDefault(i => IsMainSitecoreSite(i.Key)).Value,
                XConnectFolder = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.XConnect)).Value,
                IdentityFolder = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.IdentityServer)).Value,
                HorizonFolder = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.Horizon)).Value,
                PublishingFolder = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.PublishingService)).Value,
                CommerceSites = list.Where(i => CheckCommerceSite(i.Key)).ToDictionary(s => s.Key, s => s.Value),

                ProcessDatabases = archives.Any(),
                Databases = archives.Select(f => f.Value).ToArray()
            };
        }

        private bool IsMainSitecoreSite(string key)
        {
            return !CheckCommerceSite(key)
                   && !key.Contains(Settings.Parameters.XConnect)
                   && !key.Contains(Settings.Parameters.IdentityServer)
                   && !key.Contains(Settings.Parameters.Horizon)
                   && !key.Contains(Settings.Parameters.PublishingService);
        }

        private bool CheckCommerceSite(string site)
        {
            string[] commerceSites = { "Authoring", "Ops", "Shops", "Minions", "BizFx" };
            return commerceSites.Any(s => site.Contains(s));
        }

        private async Task<IEnumerable<KeyValuePair<string, string>>> GetInputForGrid(Dictionary<string, string> files)
        {
            var list = new List<KeyValuePair<string, string>>();

            foreach (var file in files.Select(f => f.Key))
            {
                var backupInfo = await _backupInfoExtractor.GetFromArchive(file);
                if (backupInfo != null)
                {
                    list.Add(new KeyValuePair<string, string>(file, backupInfo.Webroot));
                }
            }

            return list;
        }
    }
}
