using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Sifon.Abstractions.Events;

namespace Sifon.Forms.Base
{
    internal interface IBaseBackupRestoreView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs<TextBox, bool>> FolderBrowserClicked;
        //event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs> BeforeFormClosing;

        void AppendEnvironmentToCaption(string suffix);
        void ValidateAndRun(IEnumerable<string> validationMessages);
    }
}
