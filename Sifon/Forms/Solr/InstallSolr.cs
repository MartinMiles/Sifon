using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifon.Forms.Solr
{
    internal  partial class InstallSolr : BaseForm, IInstallSolr, ISolrInstall
    {
        public event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;

        public event EventHandler<EventArgs> ClosingForm = delegate { };
        public event EventHandler<EventArgs<ISolrInstall>> InstallClicked = delegate { };
        public event BaseForm.AsyncEventHandler<EventArgs<string>> UninstallClicked;

        internal readonly SolrHelper _solrHelper;

        internal InstallSolr()
        {
            InitializeComponent();

            _solrHelper = new SolrHelper(dataGrid, labelSolrGrid, loadingCircleGrid, RaiseUninstall);

            new InstallSolrPresenter(this, _solrHelper);
        }

        private async void InstallSolr_Load(object sender, EventArgs e)
        {
            textFolder.Text = "c:\\Solr";

            if(comboVersion.Items.Count > 0)
            {
                comboVersion.SelectedIndex = comboVersion.Items.Count - 1;
            }

            buttonInstall.Select();

            await OnLoad();
        }

        public async Task OnLoad()
        {
            if (LoadedAsync != null)
            {
                await LoadedAsync(this, new EventArgs());
            }
        }

        public void RaiseUninstall(string path)
        {
            ToggleControls(false);
            ToggleSpinner(false);

            UninstallClicked?.Invoke(this, new EventArgs<string>(path));
        }

        public void SetCaption(string suffix)
        {
            Text = Text += suffix; // 
        }

        private void comboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string port = comboVersion.SelectedItem as string;
            textPort.Text = SolrHelper.SuggestValidPort(port);
            textFolderSuffix.Text = $"/solr-{port}";
            ActiveControl = buttonInstall;
        }

        private void install_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            ToggleControls(false);
            ToggleSpinner(false);

            InstallClicked(this, new EventArgs<ISolrInstall>(this));

            textFolderSuffix.SelectionLength = 0;
        }

        public void UpdateView(bool result)
        {
            ToggleControls(true);
            ToggleSpinner(true);

            if (result)
            {
                if (!ShowYesNo("Success", "Solr instance has been successfully installed\n\nWould you like to install/remove one more instance?"))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                ShowError("Something went wrong", "Solr instance has NOT been installed");
            }
        }

        public void ToggleControls(bool enabled)
        {
            textFolder.Enabled = enabled;
            buttonLocation.Enabled = enabled;
            textPort.Enabled = enabled;
            comboVersion.Enabled = enabled;
            buttonInstall.Enabled = enabled;
            dataGrid.Enabled = enabled;
        }
        
        private void ToggleSpinner(bool enabled)
        {
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
            get => comboVersion.SelectedItem.ToString().Trim();
            set => throw new NotImplementedException();
        }
        public string Hostname
        {
            get => "localhost";
            set => throw new NotImplementedException();
        }
        public string Port
        {
            get => textPort.Text.Trim();
            set => throw new NotImplementedException();
        }

        #endregion

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textFolder, true);
        }


        public void ShowSpinnerHideGrid(bool visible)
        {
            loadingCircleGrid.Visible = visible;
            loadingCircleGrid.Active = visible;
            dataGrid.Visible = !visible;
        }
    }
}
