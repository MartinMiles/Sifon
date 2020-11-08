using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Events;
using Sifon.Code.Factories;
using Sifon.Code.Filesystem;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers;
using Sifon.Code.Statics;
using Sifon.Shared.Forms.FolderBrowserDialog;

namespace Sifon.Forms.Base
{
    internal class BaseBackupRestorePresenter
    {
        protected readonly IProfilesProvider _profileProvider;
        protected readonly RemoteScriptCopier _remoteScriptCopier;
        protected readonly FilesystemFactory _filesystemFactory;
        protected readonly ISiteProvider _siteProvider;

        private readonly IBaseBackupRestoreView _view;

        internal BaseBackupRestorePresenter(IBaseBackupRestoreView view)
        {
            _profileProvider = Create.New<IProfilesProvider>();
            var profile = _profileProvider.SelectedProfile;

            _view = view;
            _view.FormLoaded += Loaded;
            _view.FolderBrowserClicked += (sender, e) => e.Value1.Text = ShowFolderSelector(profile, e.Value2);
            _view.AppendEnvironmentToCaption(profile.WindowCaptionSuffix);

            _filesystemFactory = new FilesystemFactory(profile, _view);
            _remoteScriptCopier = new RemoteScriptCopier(profile, _view);
            _siteProvider = new PowerShellSiteProvider(profile, _view);
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        private void Loaded(object sender, EventArgs e)
        {
        }

        #region Validation used on both Backup and Restore presenters

        private List<string> _validationMessages;

        protected async Task ValidateBeforeClose(object sender, EventArgs<string> e)
        {
            _view.ValidateAndRun(await ValidateForm(e.Value));
        }

        private async Task<IEnumerable<string>> ValidateForm(string destinationFolder)
        {
            _validationMessages = new List<string>();

            var filesystemWrapper = _filesystemFactory.Create();

            if (! await filesystemWrapper.DirectoryExists(destinationFolder))
            {
                _validationMessages.Add(Validation.Backup.DestinationFolderDoesNotExist);
            }

            return _validationMessages;
        }

        #endregion
    }
}