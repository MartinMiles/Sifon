using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using Sifon.Code.Logger;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon
{
    internal class OnStart
    {
        internal bool IsValid {
            get
            {
                EnsureFoldersExist(new[] { Settings.Folders.Cache, Settings.Folders.Profiles, Settings.Folders.Plugins });

                return ValidateFilesPresent(new[]
                {
                    Settings.Scripts.InitializeRemote,
                    Settings.Scripts.CopyToRemote,

                    Settings.Scripts.GetBackupInfo,
                    Settings.Scripts.GetSitecoreSites,
                    Settings.Scripts.RestoreInstance,
                    Settings.Scripts.RetrieveDatabases,
                    Settings.Scripts.RetrieveSolr,
                    Settings.Scripts.SaveBackupInfo,
                    Settings.Scripts.TestSolr,
                    Settings.Scripts.TestSqlServerConnection,
                    Settings.Scripts.TestPortalCredentials,
                    Settings.Scripts.GetHorizonFolder,
                    Settings.Scripts.GetPublishingServiceFolder,
                    Settings.Scripts.GetCommerceSites,
                    Settings.Scripts.GetCommerceDatabases,

                    Settings.Scripts.Filesystem.RenameDirectory,
                    Settings.Scripts.Filesystem.CreateDirectory,
                    Settings.Scripts.Filesystem.DeleteDirectory,
                    Settings.Scripts.Filesystem.DeleteFile,
                    Settings.Scripts.Filesystem.GetDirectory,
                    Settings.Scripts.Filesystem.GetDrives,
                    Settings.Scripts.Filesystem.GetFiles,
                    Settings.Scripts.Filesystem.GetHashMD5,
                    Settings.Scripts.Filesystem.VerifyDirectory
                });
            }
        }

        private void EnsureFoldersExist(string[] folders)
        {
            foreach (string folder in folders)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
        }

        private bool ValidateFilesPresent(string[] files)
        {
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    MessageBox.Show($"Requred file is missed by an expected path{Environment.NewLine}{file}",
                        "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        public bool EnsureAdminRights()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                if (MessageBox.Show(Messages.Startup.PermissionRequest.Message, Messages.Startup.PermissionRequest.Caption, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    ProcessStartInfo proc = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };

                    try
                    {
                        Process.Start(proc);
                    }
                    catch
                    {
                        // The user elevation refused.
                    }

                    Application.Exit();
                }

                return false;
            }

            return true;
        }

        public void EnableLogger()
        {
            SimpleLog.SetLogFile(".\\Logs", "SifonLog_");
        }
    }
}
