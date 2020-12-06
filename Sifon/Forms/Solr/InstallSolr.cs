using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;
using System;
using System.Windows.Forms;

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


        //public void SetSolrGrid(IEnumerable<ISolrInfo> solrs, bool isRemote)
        //{
        //    if (solrs == null) return;

        //    LoadSolrDropdown();

        //    foreach (var solrUrl in solrs.Select(s => s.Url))
        //    {
        //        comboSolrInstances.Items.Add(solrUrl);
        //    }

        //    comboSolrInstances.Enabled = true;

        //    var source = new BindingSource { DataSource = solrs };
        //    dataGrid.Columns.Clear();
        //    dataGrid.Rows.Clear();
        //    dataGrid.Refresh();
        //    dataGrid.AutoGenerateColumns = false;

        //    var version = new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Version",
        //        DataPropertyName = "Version",
        //        ReadOnly = true,
        //        Name = "Version",
        //        Width = 50,
        //    };
        //    version.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    version.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    var links = new DataGridViewLinkColumn
        //    {
        //        UseColumnTextForLinkValue = false,
        //        Name = "Url",
        //        HeaderText = "URL",
        //        ReadOnly = true,
        //        DataPropertyName = "Url",
        //        ActiveLinkColor = Color.White,
        //        LinkBehavior = LinkBehavior.SystemDefault,
        //        LinkColor = Color.Blue,
        //        TrackVisitedState = true,
        //        VisitedLinkColor = Color.Blue,
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        //        DefaultCellStyle = { SelectionBackColor = BackColor }
        //    };

        //    var buttons = new DataGridViewDisableButtonColumn
        //    {
        //        HeaderText = "Directory",
        //        DataPropertyName = "Directory",
        //        Text = "Open",
        //        Name = "Directory",
        //        Width = 55,
        //        UseColumnTextForButtonValue = true
        //    };
        //    buttons.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        //    dataGrid.BackgroundColor = Color.White;
        //    dataGrid.RowHeadersVisible = false;
        //    dataGrid.DataSource = source;

        //    dataGrid.Columns.Add(version);
        //    dataGrid.Columns.Add(links);
        //    dataGrid.Columns.Add(buttons);

        //    dataGrid.DataBindingComplete += (sender, args) => { ((DataGridView)sender).ClearSelection(); };
        //    dataGrid.CellClick += CellClick;
        //    dataGrid.CellToolTipTextNeeded += CellToolTipTextNeeded;

        //    dataGrid.Visible = true;

        //    labelSolrGrid.Text = solrs.Any() ? Messages.Profiles.Connectivity.InstancesFound : Messages.Profiles.Connectivity.Errors.InstancesNotFound;

        //    dataGrid.SetButtonColumnEnable(2, !isRemote);
        //}

        //private void CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0) return;

        //    var item = ((BindingSource)dataGrid.DataSource).Current as SolrInfo;

        //    if (item != null && e.ColumnIndex == 1 || e.ColumnIndex == 2)
        //    {
        //        var cell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDisableButtonCell;
        //        if (cell != null && cell.Enabled && ((string)cell.Value).NotEmpty())
        //        {
        //            Process.Start(e.ColumnIndex == 2 ? item.Directory : item.Url);
        //        }
        //    }
        //}
    }
}
