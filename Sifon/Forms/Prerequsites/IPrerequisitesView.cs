using System;
using System.ComponentModel;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;

namespace Sifon.Forms.Prerequsites
{
    internal interface IPrerequisitesView : ISynchronizeInvoke
    {
        event EventHandler<EventArgs> FormLoaded;
        event EventHandler<EventArgs<IPrerequisites>> InstallClicked;

        void UpdateProgressBar(int percentComplete, string statusLabelText);
        void UpdateView(bool[] firstOrDefault);
        void Success(bool[] firstOrDefault);
        void Error(Exception firstOrDefault);
    }
}