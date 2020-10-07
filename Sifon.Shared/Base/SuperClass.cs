using System;
using System.Windows.Forms;
using Sifon.Abstractions.Base;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Forms.FolderBrowserDialog;
using Sifon.Code.Statics;

namespace Sifon.Code.Base
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
            return $"{profile.ProfileName} - {(profile.RemotingEnabled ? $"REMOTE [{profile.RemoteHost}]" : "(local instance)")}";
        }
    }
}
