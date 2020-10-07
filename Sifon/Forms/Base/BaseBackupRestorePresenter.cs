using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Base;
using Sifon.Code.Events;
using Sifon.Code.Filesystem;
using Sifon.Code.Helpers;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Forms.Base
{
    internal class BaseBackupRestorePresenter
    {
        protected readonly ProfilesProvider _profileService;
        protected readonly RemoteScriptCopier _remoteScriptCopier;
        protected readonly FilesystemFactory _filesystemFactory;
        protected readonly ISiteProvider _siteProvider;

        private readonly IBaseBackupRestoreView _view;
        private readonly ISuperClass _superClass;

        protected IProfile SelectedProfile => _profileService.SelectedProfile;

        internal BaseBackupRestorePresenter(IBaseBackupRestoreView view)
        {
            _superClass = new SuperClass();

            _view = view;
            _view.FormLoaded += Loaded;
            _view.FolderBrowserClicked += (sender, e) => e.Value1.Text = _superClass.ShowFolderBrowser(SelectedProfile, e.Value2);

            _profileService = new ProfilesProvider();
            _filesystemFactory = new FilesystemFactory(SelectedProfile, _view);
            _remoteScriptCopier = new RemoteScriptCopier(_profileService.SelectedProfile, _view);

            _siteProvider = new PowerShellSiteProvider(SelectedProfile, _view);
        }

        private void Loaded(object sender, EventArgs e)
        {
            string suffix = _superClass.AppendEnvironmentToCaption(_profileService.SelectedProfile);
            _view.AppendEnvironmentToCaption(suffix);
        }

        #region Validation used on both Backup and Restore presenters

        private List<string> _validationMessages;

        protected async void ValidateBeforeClose(object sender, EventArgs<string> e)
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