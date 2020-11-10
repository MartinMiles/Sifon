using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Base;

namespace Sifon.Forms.Restore
{
    internal interface IRestoreView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event BaseForm.AsyncEventHandler<EventArgs<string>> FolderSelected;
        event BaseForm.AsyncEventHandler<EventArgs<string>> ValidateBeforeClose;

        void DisplayDatabases(IEnumerable<string> files);
        void SetRestoreButton(bool? enabled);
        void SetRestoreButtonTitle(string loading);
        void ShowDatagrid(IEnumerable<KeyValuePair<string, string>> list, string[] columns);
        void SetSites(IRestoreViewModel model);
    }
}
