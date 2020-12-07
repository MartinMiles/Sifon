using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Model;
using Sifon.Code.Extensions;
using Sifon.Code.Model;
using Sifon.Statics;
using Sifon.UserControls;

namespace Sifon.Forms.Solr
{
    internal class SolrHelper
    {
        private readonly DataGridView _dataGrid;
        private readonly Label _labelSolrGrid;
        private readonly LoadingCircle _loading;
        private readonly Action<string> _raiseUninstall;

        private const string UninstallWarning =
            "Uninstall guarantees processing only instances created with this tool.\n\nUnintalling other falls at your own risk. Do you want to continue?";

        internal SolrHelper(DataGridView dataGrid, Label labelSolrGrid, LoadingCircle loading, Action<string> raiseUninstall) 
        {
            _dataGrid = dataGrid;
            _labelSolrGrid = labelSolrGrid;
            _loading = loading;
            _raiseUninstall = raiseUninstall;
        }

        internal void SetSolrGrid(IEnumerable<ISolrInfo> solrs, bool isRemote)
        {
            if (solrs == null) return;

            _dataGrid.Columns.Clear();
            _dataGrid.Rows.Clear();
            _dataGrid.Refresh();
            _dataGrid.AutoGenerateColumns = false;

            if (solrs.Any())
            {
                var source = new BindingSource {DataSource = solrs};

                var version = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Version",
                    DataPropertyName = "Version",
                    ReadOnly = true,
                    Name = "Version",
                    Width = 50,
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
                    DefaultCellStyle = {SelectionBackColor = Control.DefaultBackColor}
                };

                var buttons = new DataGridViewDisableButtonColumn
                {
                    HeaderText = "Action",
                    DataPropertyName = "Directory",
                    Text = "Uninstall",
                    Name = "Action",
                    Width = 55,
                    UseColumnTextForButtonValue = true
                };
                buttons.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                _dataGrid.BackgroundColor = Color.White;
                _dataGrid.RowHeadersVisible = false;
                _dataGrid.DataSource = source;

                _dataGrid.Columns.Add(version);
                _dataGrid.Columns.Add(links);
                _dataGrid.Columns.Add(buttons);

                _dataGrid.DataBindingComplete += (sender, args) => { ((DataGridView) sender).ClearSelection(); };
                _dataGrid.CellClick -= CellClick;
                _dataGrid.CellClick += CellClick;
                _dataGrid.CellToolTipTextNeeded += CellToolTipTextNeeded;

                _dataGrid.Visible = true;
            }

            _labelSolrGrid.Text = solrs.Any() ? Messages.Profiles.Connectivity.InstancesFound : Messages.Profiles.Connectivity.Errors.InstancesNotFound;
        }

        private void CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                var item = ((BindingSource)_dataGrid.DataSource)[e.RowIndex] as SolrInfo;

                if (item != null && e.ColumnIndex == 2)
                {
                    e.ToolTipText = item.Directory.Replace("\\server\\solr", String.Empty);
                }
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = ((BindingSource)_dataGrid.DataSource).Current as SolrInfo;

            if (item != null && e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                var cell = _dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDisableButtonCell;
                if (cell != null && cell.Enabled && ((string)cell.Value).NotEmpty())
                {
                    if (e.ColumnIndex == 2)
                    {

                        if(MessageBox.Show(UninstallWarning, "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Uninstall(item.Directory);
                        }
                    }
                    else
                    {
                        Process.Start(item.Url);
                    }
                }
            }
        }

        private void Uninstall(string itemDirectory)
        {
            _raiseUninstall(itemDirectory);
        }

        public void UpdateProgress(int value)
        {
            _labelSolrGrid.Text = $"{Messages.Profiles.Connectivity.SolrDetectionInProgress} {value}%";
        }

        public void NotifyRemoteNotInitialized()
        {
            _dataGrid.Visible = false;
            _loading.Visible = false;
            _labelSolrGrid.Text = Messages.Profiles.Connectivity.InitializationRequired;
        }
    }
}
