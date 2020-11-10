using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Filesystem;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;
using Sifon.Code.Statics;
using Sifon.Shared.Forms.FolderBrowserDialog;

namespace Sifon.Forms.Base
{
    internal class BaseBackupRestorePresenter
    {
        protected readonly IProfilesProvider _profileProvider;
        protected readonly IRemoteScriptCopier _remoteScriptCopier;
        protected readonly ISiteProvider _siteProvider;
        protected readonly IScriptWrapper<string> _scriptWrapper;
        private readonly IBaseBackupRestoreView _view;

        internal BaseBackupRestorePresenter(IBaseBackupRestoreView view)
        {
            _profileProvider = Create.New<IProfilesProvider>();
            var profile = _profileProvider.SelectedProfile;

            _view = view;
            
            _view.FolderBrowserClicked += (sender, e) => e.Value1.Text = ShowFolderSelector(profile, e.Value2);
            _view.AppendEnvironmentToCaption(profile.WindowCaptionSuffix);

            _scriptWrapper = Create.WithParam(_view, d => d.ToString());
            _remoteScriptCopier = Create.WithCurrentProfile<IRemoteScriptCopier>(_view);
            _siteProvider = Create.WithCurrentProfile<ISiteProvider>(_view);
        }

        private string ShowFolderSelector(IProfile profile, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
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

            var filesystemWrapper = Create.WithCurrentProfile<IFilesystem>();

            if (! await filesystemWrapper.DirectoryExists(destinationFolder))
            {
                _validationMessages.Add(Validation.Backup.DestinationFolderDoesNotExist);
            }

            return _validationMessages;
        }

        #endregion

        protected void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper?.Finish();
        }
    }
}