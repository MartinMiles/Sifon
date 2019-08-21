using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Forms.Base;
using Sifon.Shared.BackupInfo;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Filesystem;
using Sifon.Shared.Statics;

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
                var archives = _filesystem.GetFiles(selectedFolder, ".bak");
                _view.LoadFolder(archives.Select(f => f.Value));

                var files = _filesystem.GetFiles(selectedFolder, ".zip");
                var list = await GetInputForGrid(files);
                _view.ShowDatagrid(list);
                _view.SetXConnctAndIdentity(list);
            }
            else
            {
                _view.LoadFolder(new string[]{});
            }

            _view.SetRestoreButtonTitle(Settings.Buttons.Restore);
            _view.SetRestoreButton(null);
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
