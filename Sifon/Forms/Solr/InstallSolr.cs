using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;
using System;

namespace Sifon.Forms.Solr
{
    internal  partial class InstallSolr : BaseForm, IInstallSolr, ISolrInstall
    {
        public event EventHandler<EventArgs> FormLoad = delegate { };
        public event EventHandler<EventArgs> ClosingForm = delegate { };
        public event EventHandler<EventArgs<ISolrInstall>> InstallClicked = delegate { };

        internal InstallSolr()
        {
            InitializeComponent();
            new InstallSolrPresenter(this);
        }

        private void InstallSolr_Load(object sender, EventArgs e)
        {
            textFolder.Text = "c:\\Solr";

            if(comboVersion.Items.Count > 0)
            {
                comboVersion.SelectedIndex = comboVersion.Items.Count - 1;
            }

            buttonInstall.Select();

            FormLoad(this, e);
        }

        public void SetCaption(string suffix)
        {
            Text = Text += suffix; // 
        }

        private void comboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string port = comboVersion.SelectedItem as string;
            textPort.Text = $"8{port.Replace(".", "")}";
            textFolderSuffix.Text = $"/solr-{port}";
            ActiveControl = buttonInstall;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO:
            //if (!ValidateForm()) return;

            ToggleControls(false);

            InstallClicked(this, new EventArgs<ISolrInstall>(this));

            textFolderSuffix.SelectionLength = 0;
        }

        public void UpdateView(bool result)
        {
            if (result)
            {
                ShowInfo("Success", "Solr has been successfully installed");
            }
            else
            {
                ShowError("Something went wrong", "Solr has not been installled");
            }

            ToggleControls(true);
        }

        private void ToggleControls(bool enabled)
        {
            textFolder.Enabled = enabled;
            buttonBackupLocation.Enabled = enabled;
            textPort.Enabled = enabled;
            comboVersion.Enabled = enabled;
            buttonInstall.Enabled = enabled;

            loadingCircle.Visible = !enabled;
            loadingCircle.Active = !enabled;
        }

        #region ISolrInstall

        public string Folder
        {
            get => textFolder.Text;
            set => textFolder.Text = value;
        }

        public string Version
        {
            get => "8.1.1";
            set => throw new NotImplementedException();
        }
        public string Hostname
        {
            get => "localhost";
            set => throw new NotImplementedException();
        }
        public string Port
        {
            get => textPort.Text;
            set => throw new NotImplementedException();
        }

        #endregion

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textFolder, true);
        }
    }
}
