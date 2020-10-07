using System;
using System.Threading;
using System.Windows.Forms;

namespace Sifon.Shared.UserControls.ThreadSafeFilePicker
{
    public class ThreadSafeSavePicker : ThreadSafeBasePicker
    {
        /// <summary>
        /// Uses the open file dialog in an STA thread in order to get rid of the STA/MTA issue with the open file dialog
        /// </summary>
        public override DialogResult ShowDialog()
        {
            var dlgRes = DialogResult.Cancel;

            var theThread = new Thread((ThreadStart)delegate
            {
                var saveFileDialog = new SaveFileDialog { RestoreDirectory = true };

                if (!string.IsNullOrEmpty(FilePath))
                {
                    saveFileDialog.FileName = FilePath;
                }

                if (!string.IsNullOrEmpty(Filter))
                {
                    saveFileDialog.Filter = Filter;
                }

                if (!string.IsNullOrEmpty(DefaultExt))
                {
                    saveFileDialog.DefaultExt = DefaultExt;
                }

                if (!string.IsNullOrEmpty(Title))
                {
                    saveFileDialog.Title = Title;
                }

                if (!string.IsNullOrEmpty(InitialDirectory))
                {
                    saveFileDialog.InitialDirectory = InitialDirectory;
                }

                //Create a layout dialog instance on the current thread to align the file dialog
                var frmLayout = new Form();

                if (StartupLocation != null)
                {
                    //set the hidden layout form to manual form start position
                    frmLayout.StartPosition = FormStartPosition.Manual;

                    //set the location of the form
                    frmLayout.Location = StartupLocation;
                    frmLayout.DesktopLocation = StartupLocation;
                }

                //the layout form is not visible
                frmLayout.Width = 0;
                frmLayout.Height = 0;

                //show the dialog 
                dlgRes = saveFileDialog.ShowDialog(frmLayout);

                if (dlgRes == DialogResult.OK)
                {
                    FilePath = saveFileDialog.FileName;
                }
            });

            try
            {
                //set STA as the Save file dialog needs it to work
                theThread.TrySetApartmentState(ApartmentState.STA);
                theThread.Start();

                // Wait for thread to get started
                while (!theThread.IsAlive)
                {
                    Thread.Sleep(1);
                }

                // Wait a tick more
                Thread.Sleep(1);

                //wait for the dialog thread to finish
                theThread.Join();

                DialogSuccess = true;
            }
            catch (Exception e)
            {
                DialogSuccess = false;
            }

            return dlgRes;
        }
    }
}
