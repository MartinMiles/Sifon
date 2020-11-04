using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Code.Events;
using Sifon.Code.Model;

namespace Sifon.Forms.MainForm
{
    internal interface IMainView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs> ScriptFinishRequested;
        event EventHandler<EventArgs<string>> SelectedProfileChanged;
        event EventHandler<EventArgs> ProfilesToolStripClicked;
        event EventHandler<EventArgs<IBackupRemoverViewModel>> BackupToolStripClicked;
        event EventHandler<EventArgs<IBackupRemoverViewModel>> RemoveToolStripClicked;
        event EventHandler<EventArgs<IRestoreViewModel>> RestoreToolStripClicked;
        event EventHandler<EventArgs<string>> ScriptToolStripClicked;

        void LoadProfilesSelector(IEnumerable<string> profiles, string selectedProfileName);
        void ToolStripsEnabled(bool enabled);
        void PopulateToolStripMenuItemWithPluginsAndScripts(PluginMenuItem pluginMenuItem, bool isLocal);
        void SetCaption(string captionSuffix);
        bool listBoxChangedFlag { get; set; }
        void BeginUI();
        void FinishUI();
        void AppendLine(string line, Color? color = null);
        void UpdateProgressBar(int percentComplete, string statusLabelText);
        void ForceProfileDialogOnFirstRun();
        bool ShowFirstRunDialog();
        void TerminateAsEmptyProfile();
        void PluginsToolStripEnabled();
    }
}
