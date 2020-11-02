using System;
using System.ComponentModel;
using Sifon.Abstractions.Forms;
using Sifon.Code.Events;

namespace Sifon.Forms.Prerequsites
{
    public interface IPrerequisitesView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs<IPrerequisites>> InstallClicked;

        void UpdateProgressBar(int percentComplete, string statusLabelText);
        void UpdateView(Tuple<bool, bool, bool, bool> firstOrDefault);
        void Success(Tuple<bool, bool, bool, bool> firstOrDefault);
        void Error(Exception firstOrDefault);
    }
}