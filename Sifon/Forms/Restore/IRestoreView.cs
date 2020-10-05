﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Base;
using Sifon.Shared.Events;

namespace Sifon.Forms.Restore
{
    public interface IRestoreView : IBaseBackupRestoreView, ISynchronizeInvoke
    {
        event EventHandler<EventArgs<string>> FolderSelected;
        event EventHandler<EventArgs<string>> ValidateBeforeClose;

        void DisplayDatabases(IEnumerable<string> files);
        void SetRestoreButton(bool? enabled);
        void SetRestoreButtonTitle(string loading);
        void ShowDatagrid(IEnumerable<KeyValuePair<string, string>> list, string[] columns);
        void SetOtherSites(IRestoreViewModel model);
    }
}
