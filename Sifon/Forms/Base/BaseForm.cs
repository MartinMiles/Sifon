using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Shared.Events;

namespace Sifon.Forms.Base
{
    public class BaseForm : AbstractForm
    {
        public delegate Task AsyncEventHandler<T>(object sender, EventArgs e);

        public event EventHandler<EventArgs<TextBox, bool>> FolderBrowserClicked = delegate { };
        public event EventHandler<EventArgs> FormLoaded = delegate { };
        public event EventHandler<EventArgs> BeforeFormClosing = delegate { };

        public void Raise_FormLoaded()
        {
            FormLoaded.Invoke(this, new EventArgs());
        }

        public void Raise_FormClosing()
        {
            BeforeFormClosing.Invoke(this, new EventArgs());
        }
        
        protected internal void Raise_FolderBrowserClicked(TextBox textBox, bool allowCreatingNewFolders)
        {
            FolderBrowserClicked(this, new EventArgs<TextBox, bool>(textBox, allowCreatingNewFolders));
        }

        public void AppendEnvironmentToCaption(string suffix)
        {
            Text += $" - {suffix}";
        }
    }
}
