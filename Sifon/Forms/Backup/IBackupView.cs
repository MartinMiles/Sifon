using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Base;

namespace Sifon.Forms.Backup
{
    internal interface IBackupView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;
        event BaseForm.AsyncEventHandler<EventArgs<string>> InstanceChanged;
        event BaseForm.AsyncEventHandler<EventArgs<string>> ValidateBeforeClose;

        void ToggleControls(bool enabled);
        void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances);
        void PopulateHostnamesListboxForSite(IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames);
        void PopulateDatabasesListboxForSite(IDatabase viewModel);
        void DisplayErrors(IEnumerable<string> errors);
        void EnableDisableMainButton(bool? b);
        
        void SetFieldsAndCheckboxes(IBackupRestoreFolders model);
    }
}
