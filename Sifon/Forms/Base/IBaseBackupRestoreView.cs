using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Sifon.Shared.Events;

namespace Sifon.Forms.Base
{
    public interface IBaseBackupRestoreView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs<TextBox, bool>> FolderBrowserClicked;
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs> BeforeFormClosing;

        //TextBox TargetTextBox { get; set; }

        void AppendEnvironmentToCaption(string suffix);
        void ValidateAndRun(IEnumerable<string> validationMessages);
    }
}
