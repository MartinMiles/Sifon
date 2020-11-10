using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Filesystem;
using Sifon.Abstractions.Formatters;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Forms.MainForm;
using Sifon.Code.Factories;
using Sifon.Code.Formatters.Output;
using Sifon.Code.Formatters.Text;
using Sifon.Code.Model;
using Sifon.Code.Statics;

namespace Sifon.Forms.Base
{
    internal abstract class ScriptablePresenter
    {
        protected readonly IProfilesProvider _profilesProvider;
        protected readonly ISettingsProvider _settingsProvider;
        protected readonly IContainersProvider _containersProvider;

        private IScriptWrapper<PSObject> _scriptWrapper;
        protected readonly IMainView _view;
        private IFilesystem _filesystem;
        protected IBackupRemoverViewModel _model;

        private readonly IFormatter<PSObject> _outputFormatter;
        private readonly GenericTextFormatter _genericTextFormatter;
        private readonly IFormatter<ProgressRecord> _progressFormatter;
        private readonly IFormatter<string> _errorFormatter;

        protected IProfile SelectedProfile => _profilesProvider.SelectedProfile;

        internal ScriptablePresenter(IMainView view)
        {
            // TODO: Review below
            _view = view;
            _profilesProvider = Create.New<IProfilesProvider>();
            _settingsProvider = Create.New<ISettingsProvider>();
            _containersProvider = Create.New<IContainersProvider>();

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
        }

        public async Task PrepareAndStart(string script, Dictionary<string, dynamic> parameters)
        {
            _scriptWrapper = Create.WithParam(_view, d => d);

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
                _scriptWrapper.Complete -= Complete;
                _scriptWrapper.ObjectReady -= ObjectReady;
                _scriptWrapper.ProgressReady -= ProgressReady;
                _scriptWrapper.InformationReady -= InformationReady;
                _scriptWrapper.WarningReady -= WarningReady;
                _scriptWrapper.ErrorReady -= ErrorReady;

                _scriptWrapper = null;
            }
        }

        private void ScriptRunnerComplete(object sender, EventArgs<string> e)
        {
            var scriptFileToDelete = e.Value;

            if (SelectedProfile.RemotingEnabled || scriptFileToDelete.StartsWith(Folders.Cache))
            {
                // this cannot be used at constructor as SelectedProfile will be null when no profiles yet are created
                _filesystem = Create.WithProfile<IFilesystem>(SelectedProfile, _view);
                _filesystem.DeleteFile(scriptFileToDelete);
            }
        }

        #region New handlers

        private void Complete(IScriptRunner sender)
        {
            ScriptRunnerComplete(this, new EventArgs<string>(sender.ScriptFile));

            _view.FinishUI();

            bool isLocal = !_profilesProvider.SelectedProfile.RemotingEnabled;
            _view.PopulateToolStripMenuItemWithPluginsAndScripts(GetPluginsAndScripts(Folders.Plugins), isLocal);
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
