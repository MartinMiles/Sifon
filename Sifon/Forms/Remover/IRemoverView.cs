using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Base;

namespace Sifon.Forms.Remover
{
    internal interface IRemoverView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;
        event BaseForm.AsyncEventHandler<EventArgs<string>> InstanceChanged;
        //event EventHandler<EventArgs<string>> InstanceChanged;
        //event EventHandler<EventArgs<string>> DatabaseFilterChanged;
        event BaseForm.AsyncEventHandler<EventArgs<string>> DatabaseFilterChanged;

        void FinishUI();
        void ToggleControls(bool enabled);
        void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances);
        void PopulateDatabasesListboxForSite(IEnumerable<string> databaseNames, IEnumerable<string> errors);

        void SetWebfoldersAndCheckboxes(IBackupRestoreFolders model);
    }
}
