using System.Drawing;
using System.Windows.Forms;

namespace Sifon.Shared.UserControls.ThreadSafeFilePicker
{
    public class ThreadSafeBasePicker
    {
        #region Attributes
        /// <summary>
        /// Gets or sets the file path of the file to open.
        /// </summary>
        /// <value>The file path of the file to open.</value>
        public string FilePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the flag wheter the operation was successful or not.
        /// </summary>
        /// <value>The flag wheter the operation was successful or not.</value>
        public bool DialogSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the filter string for this dialog.
        /// </summary>
        /// <value>The filter string for this dialog.</value>
        public string Filter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the default extension of the dialog.
        /// </summary>
        /// <value>The default extension of the dialog.</value>
        public string DefaultExt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title of the dialog.
        /// </summary>
        /// <value>The title of the dialog.</value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// The initial directory for the form
        /// </summary>
        public string InitialDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the startup position.
        /// </summary>
        /// <value>The startup position.</value>
        public Point StartupLocation
        {
            get;
            set;
        }
        #endregion

        #region VirtualMethods
        /// <summary>
        /// virtual base method which must be implemented
        /// </summary>
        /// <returns></returns>
        public virtual DialogResult ShowDialog()
        {
            return (DialogResult.Cancel);
        }
        #endregion
    }
}
