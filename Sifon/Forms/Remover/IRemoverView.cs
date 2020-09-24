using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Forms.Backup;
using Sifon.Forms.Base;
using Sifon.Shared.Events;

namespace Sifon.Forms.Remover
{
    public interface IRemoverView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs<string>> InstanceChanged;
        event EventHandler<EventArgs<string>> DatabaseFilterChanged;

        void FinishUI();
        void ToggleControls(bool enabled);
        void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances);
        void PopulateDatabasesListboxForSite(IEnumerable<string> databaseNames, IEnumerable<string> errors);

        void SetWebfoldersAndCheckboxes(BackupViewModel model);
        //void SetWebfoldersAndCheckboxes(string name, string xconnectFolder, string idsFolder, IEnumerable<KeyValuePair<string, string>> commerceSites);
    }
}
