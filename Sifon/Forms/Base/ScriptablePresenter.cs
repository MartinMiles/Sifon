using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Automation;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.MainForm;
using Sifon.Shared.Events;
using Sifon.Shared.Filesystem;
using Sifon.Shared.Formatters.Error;
using Sifon.Shared.Formatters.Output;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Base
{
    internal class ScriptablePresenter
    {
        protected readonly ProfilesProvider _profilesService;
        private ScriptWrapper<PSObject> _scriptWrapper;
        protected readonly IMainView _view;
        private readonly ConsoleOutputFormatter _outputFormatter;
        private IFilesystem _filesystem;
        protected IBackupRestoreModel model;

        protected IProfile SelectedProfile => _profilesService.SelectedProfile;

        internal ScriptablePresenter(IMainView view)
        {
            _view = view;
            _profilesService = new ProfilesProvider();
            _view.ScriptFinishRequested += ScriptFinishRequested;
            _outputFormatter = new ConsoleOutputFormatter();
        }

        private void ScriptFinishRequested(object sender, EventArgs e)
        {
            RemoveHandlers();
            _scriptWrapper?.Finish();
            _view.FinishUI();
        }

        public async void PrepareAndStart(string script, Dictionary<string, dynamic> parameters)
        {
            _scriptWrapper = new ScriptWrapper<PSObject>(SelectedProfile, _view, d => d);

            AddHandlers();

            _view.BeginUI();

            await _scriptWrapper.Run(script, parameters);

            RemoveHandlers();
            _view.FinishUI();
        }   

        private void AddHandlers()
        {
            _scriptWrapper.Complete += Complete;
            _scriptWrapper.ObjectReady += ObjectReady;
            _scriptWrapper.ProgressReady += ProgressReady;
            _scriptWrapper.InformationReady += InformationReady;
            _scriptWrapper.WarningReady += WarningReady;
            _scriptWrapper.ErrorReady += ErrorReady;
        }

        private void RemoveHandlers()
        {
            if (_scriptWrapper != null)
            {
                _scriptWrapper.Complete += Complete;
                _scriptWrapper.ObjectReady += ObjectReady;
                _scriptWrapper.ProgressReady += ProgressReady;
                _scriptWrapper.InformationReady += InformationReady;
                _scriptWrapper.WarningReady += WarningReady;
                _scriptWrapper.ErrorReady += ErrorReady;
            }
        }

        private void ScriptRunnerComplete(object sender, EventArgs<string> e)
        {
            var scriptFileToDelete = e.Value;

            if (SelectedProfile.RemotingEnabled || scriptFileToDelete.StartsWith(Settings.Folders.Cache))
            {
                // this cannot be used at constructor as SelectedProfile will be null when no profiles yet are created
                _filesystem = new FilesystemFactory(SelectedProfile, _view).Create();
                _filesystem.DeleteFile(scriptFileToDelete);
            }
        }

        #region New handlers

        private void Complete(IScriptRunner sender)
        {
            ScriptRunnerComplete(this, new EventArgs<string>(sender.ScriptFile));

            _view.FinishUI();
        }

        private void ObjectReady(PSObject data)
        {
            _view.AppendLine(_outputFormatter.Format(data));
            _view.listBoxChangedFlag = true;
        }

        private void InformationReady(string message)
        {
            _view.AppendLine(message);
        }

        private void WarningReady(string message)
        {
            _view.AppendLine(message, Color.Yellow);
        }

        private void ErrorReady(Exception exception)
        {
            _view.AppendLine(new ErrorFormatter().Format(exception.Message), Color.Red);
        }

        private void ProgressReady(ProgressRecord data)
        {
            if (data.PercentComplete >= 0)
            {
                var currentOperation = data.CurrentOperation != null
                    ? $" - {data.CurrentOperation.Replace("  ", " ")}"
                    : String.Empty;

                _view.UpdateProgressBar(data.PercentComplete, $"{data.Activity}{currentOperation}");
            }
        }

        #endregion
    }
}
