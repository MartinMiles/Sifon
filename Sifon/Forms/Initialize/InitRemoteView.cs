using System;
using System.ComponentModel;

namespace Sifon.Forms.Initialize
{
    internal interface InitRemoteView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;

        void UpdateProgressBar(int percentComplete, string statusLabelText);
        void ScriptComplete(string scriptsFolder, string moduleFolder, string errorMessage);
    }
}
