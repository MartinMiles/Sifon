using System;
using System.Collections.Generic;
using Sifon.Forms.Profiles.UserControls.Base;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    internal interface IParametersView : IBaseView
    {
        event EventHandler<EventArgs> DownloadSampleScriptClicked;
        void SetValues(Dictionary<string, string> parameters);
        bool ValidateValues();
        void SaveSampleScript(string script);
    }
}
