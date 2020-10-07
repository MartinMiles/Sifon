using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Automation;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.MainForm;
using Sifon.Code.Events;
using Sifon.Code.Filesystem;
using Sifon.Code.Formatters.Output;
using Sifon.Code.Formatters.Text;
using Sifon.Code.Model;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Forms.Base
{
    internal abstract class ScriptablePresenter
    {
        protected readonly ProfilesProvider _profilesService;
        protected readonly SettingsProvider _settingsProvider;
        protected readonly ContainersProvider _containersProvider;

        private ScriptWrapper<PSObject> _scriptWrapper;
        protected readonly IMainView _view;
        private readonly ConsoleOutputFormatter _outputFormatter;
        private IFilesystem _filesystem;
        protected IBackupRemoverViewModel model;

        private readonly GenericTextFormatter _genericTextFormatter;
        private readonly ProgressFormatter _progressFormatter;
        private readonly ErrorFormatter _errorFormatter;

        protected IProfile SelectedProfile => _profilesService.SelectedProfile;

        internal ScriptablePresenter(IMainView view)
        {
            _view = view;
            _profilesService = new ProfilesProvider();
            _settingsProvider = new SettingsProvider();
            _containersProvider = new ContainersProvider();
            _view.ScriptFinishRequested += ScriptFinishRequested;
            _outputFormatter = new ConsoleOutputFormatter();

            _genericTextFormatter = new GenericTextFormatter();
            _progressFormatter = new ProgressFormatter();
            _errorFormatter = new ErrorFormatter();
        }

        protected abstract PluginMenuItem GetPluginsAndScripts(string baseDirectory);

        private void ScriptFinishRequested(object sender, EventArgs e)
        {
            RemoveHandlers();
            _scriptWrapper?.Finish();
            _view.FinishUI();
            _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Settings.Folders.Plugins));
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
            _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Settings.Folders.Plugins));
        }

        private void ObjectReady(PSObject data)
        {
            string line = _outputFormatter.Format(data);
            line = _genericTextFormatter.FormatOutput(line);
            _view.AppendLine(line);
        }

        private void InformationReady(string line)
        {
            line = _genericTextFormatter.FormatOutput(line);
            _view.AppendLine(line);
        }

        private void WarningReady(string line)
        {
            line = _genericTextFormatter.FormatWarning(line);
            _view.AppendLine(line, Color.Yellow);
        }

        private void ErrorReady(Exception exception)
        {
            string line = _errorFormatter.Format(exception.Message);
            line = _genericTextFormatter.FormatOutput(line);
            _view.AppendLine(line, Color.Red);
        }

        private void ProgressReady(ProgressRecord data)
        {
            if (data.PercentComplete >= 0 && !_genericTextFormatter.ProgressMuted)
            {
                string progressMessage = _progressFormatter.Format(data);
                _view.UpdateProgressBar(data.PercentComplete, progressMessage);
            }
        }

        #endregion
    }
}
