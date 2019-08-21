using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Shared.Events;
using Sifon.Shared.Model;

namespace Sifon.Forms.MainForm
{
    public interface IMainView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs> ScriptFinishRequested;
        event EventHandler<EventArgs<string>> SelectedProfileChanged;
        event EventHandler<EventArgs> ProfilesToolStripClicked;
        event EventHandler<EventArgs<IBackupRestoreModel>> BackupToolStripClicked;
        event EventHandler<EventArgs<IBackupRestoreModel>> RestoreToolStripClicked;
        event EventHandler<EventArgs<IBackupRestoreModel>> RemoveToolStripClicked;
        event EventHandler<EventArgs<string>> ScriptToolStripClicked;

        void LoadProfilesSelector(IEnumerable<string> profiles, string selectedProfileName);
        void ToolStripsEnabled(bool enabled);
        void PopulateToolStripMenuItemWithPluginsAndScripts(PluginMenuItem pluginMenuItem);
        void SetCaption(string captionSuffix);
        bool listBoxChangedFlag { get; set; }
        void BeginUI();
        void FinishUI();
        void AppendLine(string line, Color? color = null);
        void UpdateProgressBar(int percentComplete, string statusLabelText);
    }
}
