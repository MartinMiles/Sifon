using System;
using System.ComponentModel;

namespace Sifon.Forms.Initialize
{
    public interface  InitRemoteView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;

        void UpdateProgressBar(int percentComplete, string statusLabelText);
        //void InitializeComplete();
        void ScriptComplete(string result, string errorMessage);
    }
}
