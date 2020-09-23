using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Model;
using Sifon.Shared.Statics;
using Sifon.Shared.UserControls;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    public partial class Connectivity : BaseUserControl, IConnectivityView
    {
        public event EventHandler<EventArgs> SqlServersUpdated = delegate { };
        public event EventHandler<EventArgs<string>> TestSolr = delegate { };

        #region Expose fields properties

        internal string Solr => textSolr.Text.Trim().TrimEnd("/");

        internal string Sql => comboSqlServers.SelectedItem.ToString();

        #endregion

        public Connectivity()
        {
            InitializeComponent();
            new ConnectivityPresenter(this);
            labelSolrGrid.Text = Messages.Profiles.Connectivity.SolrDetectionInProgress;
        }

        public void LoadSolrDropdown()
        {
            comboSolrInstances.Items.Clear();
            comboSolrInstances.Items.Add(Settings.ManualEntry);
            comboSolrInstances.SelectedIndex = 0;
        }

        public void SetSolrValue(string selectedProfileSolr)
        {
            textSolr.Text = selectedProfileSolr ?? String.Empty;
        }

        public void LoadDatabaseServersDropdown(IEnumerable<string> sqlServers, string selectedSqlServerName = null)
        {
            comboSqlServers.Items.Clear();
            comboSqlServers.Items.Add(Settings.Dropdowns.NotSet);

            foreach (var sqlServerName in sqlServers)
            {
                comboSqlServers.Items.Add(sqlServerName);
            }

            if (comboSqlServers.Items.Count > 0)
            {
                comboSqlServers.SelectedIndex = selectedSqlServerName.NotEmpty() ? comboSqlServers.Items.IndexOf(selectedSqlServerName) : 0;
            }
        }
        public void ToggleControls(bool value)
        {
            comboSqlServers.Enabled = value;
            buttonSqlConnection.Enabled = value;
            comboSolrInstances.Enabled = value;
            buttonTest.Enabled = value;
            dataGrid.Enabled = value;
        }

        public void SetSolrGrid(IEnumerable<SolrInfo> solrs, bool isRemote)
        {
            foreach (var solrUrl in solrs.Select(s => s.Url))
            {
                comboSolrInstances.Items.Add(solrUrl);
            }

            var source = new BindingSource {DataSource = solrs};
            dataGrid.Columns.Clear();
            dataGrid.Rows.Clear();
            dataGrid.Refresh();
            dataGrid.AutoGenerateColumns = false;

            var version = new DataGridViewTextBoxColumn
            {
                HeaderText = "Version", DataPropertyName = "Version", ReadOnly = true, Name = "Version", Width = 50,
            };
            version.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            version.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var links = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = false,
                Name = "Url",
                HeaderText = "URL",
                ReadOnly = true,
                DataPropertyName = "Url",
                ActiveLinkColor = Color.White,
                LinkBehavior = LinkBehavior.SystemDefault,
                LinkColor = Color.Blue,
                TrackVisitedState = true,
                VisitedLinkColor = Color.Blue,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = {SelectionBackColor = BackColor}
            };

            var buttons = new DataGridViewDisableButtonColumn
            {
                HeaderText = "Directory", DataPropertyName = "Directory", Text = "Open", Name = "Directory", Width = 55, 
                UseColumnTextForButtonValue = true
            };
            buttons.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGrid.BackgroundColor = Color.White;
            dataGrid.RowHeadersVisible = false;
            dataGrid.DataSource = source;

            dataGrid.Columns.Add(version);
            dataGrid.Columns.Add(links);
            dataGrid.Columns.Add(buttons);

            dataGrid.DataBindingComplete += (sender, args) => { ((DataGridView)sender).ClearSelection(); };
            dataGrid.CellClick += CellClick;
            dataGrid.CellToolTipTextNeeded += CellToolTipTextNeeded;

            dataGrid.Visible = true;

            labelSolrGrid.Text = solrs.Any() ? Messages.Profiles.Connectivity.InstancesFound : Messages.Profiles.Connectivity.Errors.InstancesNotFound;

            dataGrid.SetButtonColumnEnable(2, !isRemote);
        }

        private void CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                var item = ((BindingSource)dataGrid.DataSource).Current as SolrInfo;

                if (item != null && e.ColumnIndex == 2)
                {
                    e.ToolTipText = item.Directory;
                }
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = ((BindingSource)dataGrid.DataSource).Current as SolrInfo;

            if (item != null && e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                var cell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var path = cell.Value as string;
                if (path.NotEmpty())
                {
                    Process.Start(e.ColumnIndex == 2 ? item.Directory : item.Url);
                }
            }
        }

        public void SetSolrDropdownByProfile(string solrUrl)
        {
            comboSolrInstances.SelectedIndex = 0;

            if (solrUrl.NotEmpty() && comboSolrInstances.Items.IndexOf(solrUrl) >= 0)
            {
                comboSolrInstances.SelectedIndex = comboSolrInstances.Items.IndexOf(solrUrl);
            }
        }

        private void buttonSqlConnection_Click(object sender, EventArgs e)
        {
            var testSqlForm = new SqlSettings.SqlSettings
            {
                StartPosition = FormStartPosition.CenterParent
            };

            testSqlForm.ShowDialog();
            testSqlForm.Dispose();

            SqlServersUpdated(this, e);
        }

        private void test_Click(object sender, EventArgs e)
        {
            TestSolr(this, new EventArgs<string>(Solr));
        }

        public void ShowSpinnerHideGrid(bool visible)
        {
            loadingCircle.Visible = visible;
            loadingCircle.Active = visible;
            dataGrid.Visible = !visible;
        }

        private void comboSolr_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            textSolr.Text = comboBox.SelectedIndex > 0 ? comboBox.SelectedItem.ToString() : String.Empty;
        }

        public void UpdateProgress(int value)
        {
            labelSolrGrid.Text = $"{Messages.Profiles.Connectivity.SolrDetectionInProgress} {value}%";
        }

        public void NotifyRemoteNotInitialized()
        {
            dataGrid.Visible = false;
            loadingCircle.Visible = false;
            labelSolrGrid.Text = Messages.Profiles.Connectivity.InitializationRequired;
        }
    }
}
