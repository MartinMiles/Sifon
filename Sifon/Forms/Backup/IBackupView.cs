using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Forms.Base;
using Sifon.Shared.Events;

namespace Sifon.Forms.Backup
{
    public interface IBackupView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event BaseForm.AsyncEventHandler<EventArgs<string>> InstanceChanged;
        event EventHandler<EventArgs<string>> ValidateBeforeClose;

        void ToggleControls(bool enabled);
        void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances);
        void PopulateHostnamesListboxForSite(IEnumerable<KeyValuePair<string, string>> hostnames);
        void PopulateDatabasesListboxForSite(IEnumerable<string> databaseNames, IEnumerable<string> errors);
        void EnableDisableMainButton(bool? b);

        
        void SetFieldsandCheckboxes(BackupViewModel model);


        //void SetCheckboxes(BackupViewModel model);
        //void SetCheckboxes(bool site, bool xconnect, bool ids,bool horizon, bool publishing, bool commerceSites);
        //void SetXConnctAndIdentity(string xconnectFolder, string idsFolder, IEnumerable<KeyValuePair<string, string>> commerceSites);
    }
}
