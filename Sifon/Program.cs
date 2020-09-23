using System;
using System.Windows.Forms;
using Sifon.Forms.MainForm;
using Sifon.Shared.Exceptions;
using Sifon.Shared.Logger;

namespace Sifon
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var onStart = new OnStart();
            if (onStart.EnsureAdminRights() && onStart.IsValid)
            {
                try
                {
                    onStart.EnableLogger();
                    SimpleLog.Info("Sifon started.");

                    Application.Run(new Main());
                }
                catch (Exception e)
                {
                    if (e.InnerException is RemoteNotInitializedException)
                    {
                        MessageBox.Show("Remote profile folder is not initialized.\nPlease reinitialize from Profile menu", "Remote Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    SimpleLog.Log(e);
                }
            }
        }
    }
}