using System;
using System.Windows.Forms;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Base
{
    public class SuperClass : ISuperClass
    {
        public string ShowFolderSelector(IProfile profile, string caption, bool allowNewFolders)
        {
            var browser = new FolderBrowser(profile, allowNewFolders) { StartPosition = FormStartPosition.CenterParent, Text = caption };
            return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }

        public string ShowFolderBrowser(IProfile profile, bool allowNewFolders)
        {
            string caption = Controls.FolderBrowser.Caption + AppendEnvironmentToCaption(profile);
            return ShowFolderSelector(profile, caption, allowNewFolders);
        }

        public string AppendEnvironmentToCaption(IProfile profile)
        { 
            return $" - {profile.Name} - {(profile.RemotingEnabled ? $"REMOTE [{profile.RemoteExecutionHost}]" : "(local instance)")}";
        }
    }
}
