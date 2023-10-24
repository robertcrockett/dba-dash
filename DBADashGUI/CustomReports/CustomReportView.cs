﻿using DBADashGUI.Performance;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DBADashGUI.CustomReports
{
    public partial class CustomReportView : UserControl, ISetContext, IRefreshData
    {
        public event EventHandler ReportNameChanged;

        private ContextMenuStrip columnContextMenu;
        private readonly ToolStripMenuItem convertLocalMenuItem = new ToolStripMenuItem("Convert to local timezone") { Checked = true, CheckOnClick = true };
        private int clickedColumnIndex = -1;
        private DataSet reportDS;
        private int selectedTableIndex = 0;
        private bool doAutoSize = true;
        private bool suppressCboResultsIndexChanged;

        public CustomReportView()
        {
            InitializeComponent();
            ShowParamPrompt(false);
            InitializeContextMenu();
        }

        private void InitializeContextMenu()
        {
            // Create ContextMenuStrip and add a "Rename Column" item
            columnContextMenu = new ContextMenuStrip();
            var renameColumnMenuItem = new ToolStripMenuItem("Rename Column");
            var setFormatStringMenuItem = new ToolStripMenuItem("Set Format String");
            renameColumnMenuItem.Click += RenameColumnMenuItem_Click;
            convertLocalMenuItem.Click += ConvertLocalMenuItem_Click;
            setFormatStringMenuItem.Click += SetFormatStringMenuItem_Click;
            columnContextMenu.Items.Add(renameColumnMenuItem);
            columnContextMenu.Items.Add(convertLocalMenuItem);
            columnContextMenu.Items.Add(setFormatStringMenuItem);
            dgv.MouseUp += Dgv_MouseUp;
        }

        private void SetFormatStringMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedColumnIndex < 0) return;
            var formatString = dgv.Columns[clickedColumnIndex].DefaultCellStyle.Format;
            var key = dgv.Columns[clickedColumnIndex].Name;
            if (CommonShared.ShowInputDialog(ref formatString, "Enter format string (e.g. N1, P1, yyyy-MM-dd)") !=
                DialogResult.OK) return;
            dgv.Columns[clickedColumnIndex].DefaultCellStyle.Format = formatString;
            if (report.CustomReportResults[selectedTableIndex].CellFormatString.ContainsKey(key))
            {
                report.CustomReportResults[selectedTableIndex].CellFormatString.Remove(key);
            }

            if (!string.IsNullOrEmpty(formatString))
            {
                report.CustomReportResults[selectedTableIndex].CellFormatString.Add(key, formatString);
            }

            report.Update();
        }

        private void ConvertLocalMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedColumnIndex < 0) return;
            var name = dgv.Columns[clickedColumnIndex].DataPropertyName;
            switch (convertLocalMenuItem.Checked)
            {
                case true when report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Contains(name):
                    report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Remove(name);
                    break;

                case false when !report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Contains(name):
                    report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Add(name);
                    break;
            }

            try
            {
                report.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving time zone preference: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            RefreshData();
        }

        /// <summary>
        /// Used to display context menu when user right-clicks column headers.  Selected column index is stored in clickedColumnIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_MouseUp(object sender, MouseEventArgs e)
        {
            if (!report.CanEditReport || e.Button != MouseButtons.Right) return;
            // Perform a hit test to determine where the click occurred
            var hitTestInfo = dgv.HitTest(e.X, e.Y);

            // If the click occurred on a column header
            if (hitTestInfo.Type != DataGridViewHitTestType.ColumnHeader) return;
            clickedColumnIndex = hitTestInfo.ColumnIndex;
            if (dgv.Columns[clickedColumnIndex].ValueType == typeof(DateTime)) // Show option for timezone conversion if column is DateTime
            {
                convertLocalMenuItem.Checked =
                    !report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Contains(dgv.Columns[clickedColumnIndex].DataPropertyName);
                convertLocalMenuItem.Visible = true;
            }
            else
            {
                convertLocalMenuItem.Visible = false;
            }
            // Show the context menu at the mouse position
            columnContextMenu.Show(dgv, e.Location);
        }

        private void RenameColumnMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedColumnIndex < 0) return;
            // Show a dialog for renaming
            var newName = dgv.Columns[clickedColumnIndex].HeaderText;
            if (CommonShared.ShowInputDialog(ref newName, "Enter new column name:") != DialogResult.OK) return;
            if (string.IsNullOrEmpty(newName))
            {
                newName = dgv.Columns[clickedColumnIndex].DataPropertyName;
            }
            dgv.Columns[clickedColumnIndex].HeaderText = newName;
            try
            {
                report.CustomReportResults[selectedTableIndex].ColumnAlias = GetColumnMapping();
                report.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving alias: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, string> GetColumnMapping() => dgv.Columns.Cast<DataGridViewColumn>()
                .Where(column => column.DataPropertyName != column.HeaderText)
                .ToDictionary(column => column.DataPropertyName, column => column.HeaderText);

        /// <summary>
        /// Param prompt is shown instead of grid if we have a 201 error indicating that parameter values are required.
        /// </summary>
        /// <param name="show">True = parameter prompt is visible.  False = Grid is visible</param>
        private void ShowParamPrompt(bool show)
        {
            splitContainer1.Panel2Collapsed = !show;
            splitContainer1.Panel1Collapsed = show;
        }

        /// <summary>
        /// Convert DateTime columns to local timezone unless user has specified that conversion should be excluded for the column
        /// </summary>
        /// <param name="dt"></param>
        private void ConvertDateTimeColsToLocalTimeZone(DataTable dt)
        {
            var convertCols = dt.Columns.Cast<DataColumn>()
                .Where(column => column.DataType == typeof(DateTime) && !report.CustomReportResults[selectedTableIndex].DoNotConvertToLocalTimeZone.Contains(column.ColumnName))
                .Select(column => column.ColumnName).ToList();
            if (convertCols.Any())
            {
                DateHelper.ConvertUTCToAppTimeZone(ref dt, convertCols);
            }
        }

        private void ApplyCellFormats()
        {
            foreach (var f in report.CustomReportResults[selectedTableIndex].CellFormatString)
            {
                dgv.Columns[f.Key]!.DefaultCellStyle.Format = f.Value;
            }
        }

        /// <summary>
        /// Rename columns if user has supplied aliases
        /// </summary>
        private void RenameColumns()
        {
            if (!(report.CustomReportResults[selectedTableIndex].ColumnAlias?.Count > 0)) return;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (report.CustomReportResults[selectedTableIndex].ColumnAlias.TryGetValue(column.DataPropertyName, out var newHeaderText))
                {
                    column.HeaderText = newHeaderText;
                }
            }
        }

        private void LoadResultsCombo()
        {
            suppressCboResultsIndexChanged = true;
            for (var i = 0; i < reportDS.Tables.Count; i++)
            {
                if (report.CustomReportResults.ContainsKey(i))
                {
                    report.CustomReportResults[i].ResultName ??= "Result" + i; // ensure we have a name
                }
                else
                {
                    report.CustomReportResults.Add(i, new CustomReportResult() { ResultName = "Result" + i });
                }
            }

            cboResults.Items.Clear();
            for (var i = 0; i < reportDS.Tables.Count; i++)
            {
                cboResults.Items.Add(report.CustomReportResults[i].ResultName);
            }
            renameResultsetToolStripMenuItem.Visible = cboResults.Items.Count > 1;
            cboResults.Visible = cboResults.Items.Count > 1;
            lblSelectResults.Visible = cboResults.Items.Count > 1;
            cboResults.SelectedIndex = selectedTableIndex < cboResults.Items.Count ? selectedTableIndex : 0;
            suppressCboResultsIndexChanged = false;
        }

        public void RefreshData()
        {
            try
            {
                ShowParamPrompt(false); // Show grid
                reportDS = GetReportData();
                LoadResultsCombo();
                if (reportDS.Tables.Count > 0)
                {
                    ShowTable();
                }
                else
                {
                    MessageBox.Show("Report didn't return a result set", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex) when (ex.Number == 201) // Parameter required
            {
                ShowParamPrompt(true); // Show parameter prompt instead of grid as we have required parameters that were not supplied
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running report:" + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ShowTable()
        {
            if (reportDS.Tables.Count == 0) return;
            if (selectedTableIndex >= reportDS.Tables.Count)
            {
                suppressCboResultsIndexChanged = true;
                selectedTableIndex = 0;
                cboResults.SelectedIndex = 0;
                dgv.Columns.Clear();
                suppressCboResultsIndexChanged = false;
            }
            var dt = reportDS.Tables[selectedTableIndex];
            ConvertDateTimeColsToLocalTimeZone(dt);
            dgv.DataSource = dt;
            RenameColumns();
            ApplyCellFormats();
            if (report.CustomReportResults[selectedTableIndex].ColumnLayout.Count > 0) dgv.LoadColumnLayout(report.CustomReportResults[selectedTableIndex].ColumnLayout);
            else if (doAutoSize) dgv.AutoResizeColumns();
            doAutoSize = false;
        }

        /// <summary>
        /// Run the query to get the data for the user custom report
        /// </summary>
        /// <returns></returns>
        private DataSet GetReportData()
        {
            using var cn = new SqlConnection(Common.ConnectionString);
            using var cmd = new SqlCommand(report.QualifiedProcedureName, cn) { CommandType = CommandType.StoredProcedure, CommandTimeout = Config.DefaultCommandTimeout };
            using var da = new SqlDataAdapter(cmd);
            // Add context parameters
            if (report.Params.ParamList.Any(p => p.ParamName.Equals("@InstanceIDs", StringComparison.InvariantCultureIgnoreCase)))
            {
                cmd.Parameters.AddWithValue("InstanceIDs", context.InstanceIDs.AsDataTable());
            }
            if (report.Params.ParamList.Any(p => p.ParamName.Equals("@InstanceID", StringComparison.InvariantCultureIgnoreCase)) && context.InstanceID > 0)
            {
                cmd.Parameters.AddWithValue("InstanceID", context.InstanceID);
            }
            if (report.Params.ParamList.Any(p => p.ParamName.Equals("@DatabaseID", StringComparison.CurrentCultureIgnoreCase)) && context.DatabaseID > 0)
            {
                cmd.Parameters.AddWithValue("DatabaseID", context.DatabaseID);
            }
            if (report.Params.ParamList.Any(p => p.ParamName.Equals("@FromDate", StringComparison.CurrentCultureIgnoreCase)))
            {
                cmd.Parameters.AddWithValue("FromDate", DateRange.FromUTC);
            }
            if (report.Params.ParamList.Any(p => p.ParamName.Equals("@ToDate", StringComparison.CurrentCultureIgnoreCase)))
            {
                cmd.Parameters.AddWithValue("ToDate", DateRange.ToUTC);
            }
            // Add user supplied parameters
            foreach (var p in customParams.Where(p => !p.UseDefaultValue))
            {
                cmd.Parameters.Add(p.Param.Clone());
            }

            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        private DBADashContext context;
        private CustomReport report;
        private List<CustomSqlParameter> customParams = new();

        public void SetContext(DBADashContext context)
        {
            doAutoSize = true;
            selectedTableIndex = 0;
            dgv.Columns.Clear();
            this.context = context;
            report = context.Report;
            customParams = report.GetCustomSqlParameters();
            tsParameters.Enabled = customParams.Count > 0;
            tsConfigure.Visible = report.CanEditReport;
            lblDescription.Text = report.Description;
            statusStrip1.Visible = !string.IsNullOrEmpty(report.Description);
            lblDescription.Visible = !string.IsNullOrEmpty(report.Description);
            if (report.DeserializationException != null)
            {
                MessageBox.Show(
                    "An error occurred deserializing the report. Preferences have been reset.\n" +
                    report.DeserializationException.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                report.DeserializationException = null;// Display the message once
            }
            RefreshData();
        }

        private void TsRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void TsCopy_Click(object sender, EventArgs e)
        {
            Common.CopyDataGridViewToClipboard(dgv);
        }

        private void TsExcel_Click(object sender, EventArgs e)
        {
            Common.PromptSaveDataGridView(dgv);
        }

        private void SetTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var title = report.ReportName;
            if (CommonShared.ShowInputDialog(ref title, "Update Title") != DialogResult.OK) return;
            try
            {
                report.ReportName = title;
                report.Update();
                OnReportNameChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving title: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected virtual void OnReportNameChanged(EventArgs e)
        {
            ReportNameChanged?.Invoke(this, e);
        }

        private void TsParameters_Click(object sender, EventArgs e)
        {
            PromptParams();
        }

        private void LnkParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PromptParams();
        }

        private void PromptParams()
        {
            var frm = new ReportParams() { Params = customParams };
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                customParams = frm.Params;
            }
            RefreshData();
        }

        private void TsCols_Click(object sender, EventArgs e)
        {
            dgv.PromptColumnSelection();
        }

        private void SaveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report.CustomReportResults[selectedTableIndex].ColumnLayout = dgv.GetColumnLayout();
            report.Update();
        }

        private void ResetLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report.CustomReportResults[selectedTableIndex].ColumnLayout = new();
            report.Update();
        }

        private void CboResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressCboResultsIndexChanged) return;
            selectedTableIndex = cboResults.SelectedIndex;
            dgv.Columns.Clear();
            ShowTable();
        }

        private void RenameResultsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = cboResults.SelectedItem.ToString();
            if (CommonShared.ShowInputDialog(ref name, "Enter name") == DialogResult.OK)
            {
                report.CustomReportResults[cboResults.SelectedIndex].ResultName = name;
                suppressCboResultsIndexChanged = true;
                cboResults.Items[selectedTableIndex] = name;
                suppressCboResultsIndexChanged = false;
                report.Update();
            }
        }

        private void SetDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var description = report.Description;
            if (CommonShared.ShowInputDialog(ref description, "Enter description") != DialogResult.OK) return;
            report.Description = description;
            report.Update();
            lblDescription.Text = report.Description;
            statusStrip1.Visible = !string.IsNullOrEmpty(report.Description);
            lblDescription.Visible = !string.IsNullOrEmpty(report.Description);
        }
    }
}