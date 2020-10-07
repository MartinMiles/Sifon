using System;
using System.Threading;
using System.Windows.Forms;

namespace Sifon.Shared.UserControls.ThreadSafeFilePicker
{
    public class ThreadSafeOpenPicker : ThreadSafeBasePicker
    {
        /// <summary>
        /// uses the open file dialog in an STA thread in order to get rid of the STA/MTA issue with the open file dialog
        /// </summary>
        public override DialogResult ShowDialog()
        {
            DialogResult dlgRes = DialogResult.Cancel;

            Thread theThread = new Thread((ThreadStart)delegate
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Multiselect = false,
                    RestoreDirectory = true
                };

                if (!string.IsNullOrEmpty(FilePath))
                    ofd.FileName = FilePath;
                if (!string.IsNullOrEmpty(Filter))
                    ofd.Filter = Filter;
                if (!string.IsNullOrEmpty(DefaultExt))
                    ofd.DefaultExt = DefaultExt;
                if (!string.IsNullOrEmpty(Title))
                    ofd.Title = Title;
                if (!string.IsNullOrEmpty(InitialDirectory))
                    ofd.InitialDirectory = InitialDirectory;

                //Create a layout dialog instance on the current thread to align the file dialog
                Form frmLayout = new Form();

                if (StartupLocation != null)
                {
                    //set the hidden layout form to manual form start position
                    frmLayout.StartPosition = FormStartPosition.CenterParent;

                    //set the location of the form
                    frmLayout.Location = StartupLocation;
                    frmLayout.DesktopLocation = StartupLocation;
                }

                //the layout form is not visible
                frmLayout.Width = 0;
                frmLayout.Height = 0;

                dlgRes = ofd.ShowDialog(frmLayout);

                if (dlgRes == DialogResult.OK)
                {
                    FilePath = ofd.FileName;
                }
            });

            try
            {
                //set STA as the Open file dialog needs it to work
                theThread.TrySetApartmentState(ApartmentState.STA);

                //start the thread
                theThread.Start();

                // Wait for thread to get started
                while (!theThread.IsAlive) { Thread.Sleep(1); }

                // Wait a tick more (@see: http://scn.sap.com/thread/45710)
                Thread.Sleep(1);

                //wait for the dialog thread to finish
                theThread.Join();

                DialogSuccess = true;
            }
            catch (Exception err)
            {
                DialogSuccess = false;
            }

            return (dlgRes);
        }
    }
}
