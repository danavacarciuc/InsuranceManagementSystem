
using InsuranceManagementSystem.Data;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace InsuranceManagementSystem.Forms
{
    public partial class InsuranceForm : Form
    {
        private DataTable policiesTable = new DataTable();
        private string lastSortedColumn = "";
        private bool sortAscending = true;

        public InsuranceForm()
        {
            InitializeComponent();

            dgvPolicies.AllowDrop = true;
            dgvPolicies.MouseDown += dgvPolicies_MouseDown;
            dgvPolicies.DragOver += dgvPolicies_DragOver;
            dgvPolicies.DragDrop += dgvPolicies_DragDrop;


            cmbFilterType.Items.Clear();
            cmbFilterType.Items.AddRange(new object[]
            {
                "All Types", "Life", "Property", "Health", "Auto"
            });
            cmbFilterType.SelectedIndex = 0;

            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.AddRange(new object[]
            {
                "All Statuses", "Active", "Cancelled", "Expired"
            });
            cmbFilterStatus.SelectedIndex = 0;

            txtSearchPolicy.TextChanged += FilterPolicies;
            cmbFilterType.SelectedIndexChanged += FilterPolicies;
            cmbFilterStatus.SelectedIndexChanged += FilterPolicies;


            AddPoliciesContextMenu();
            dgvPolicies.ColumnHeaderMouseClick += dgvPolicies_ColumnHeaderMouseClick;
            dgvPolicies.CellFormatting += dgvPolicies_CellFormatting;
            ConfigurePoliciesGrid();
            LoadPolicies();
        }



        private void ConfigurePoliciesGrid()
        {
            dgvPolicies.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPolicies.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvPolicies.RowTemplate.Height = 28;
            dgvPolicies.AllowUserToResizeRows = false;

            dgvPolicies.ColumnHeadersHeight = 35;
            dgvPolicies.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvPolicies.EnableHeadersVisualStyles = false;

            dgvPolicies.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 55, 90);

            dgvPolicies.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvPolicies.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvPolicies.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);

            dgvPolicies.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 225, 245);

            dgvPolicies.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 55, 90);

            dgvPolicies.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);

            dgvPolicies.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
        }

        private void ConfigurePolicyColumnWidths()
        {
            if (dgvPolicies.Columns.Count == 0)
                return;

            dgvPolicies.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvPolicies.Columns.Contains("PolicyNumber"))
            {
                dgvPolicies.Columns["PolicyNumber"].MinimumWidth = 150;
                dgvPolicies.Columns["PolicyNumber"].FillWeight = 120;
            }

            if (dgvPolicies.Columns.Contains("Id"))
                dgvPolicies.Columns["Id"].FillWeight = 45;

            if (dgvPolicies.Columns.Contains("ClientId"))
                dgvPolicies.Columns["ClientId"].FillWeight = 55;

            if (dgvPolicies.Columns.Contains("InsuranceType"))
                dgvPolicies.Columns["InsuranceType"].FillWeight = 85;

            if (dgvPolicies.Columns.Contains("StartDate"))
                dgvPolicies.Columns["StartDate"].FillWeight = 85;

            if (dgvPolicies.Columns.Contains("EndDate"))
                dgvPolicies.Columns["EndDate"].FillWeight = 85;

            if (dgvPolicies.Columns.Contains("Premium"))
                dgvPolicies.Columns["Premium"].FillWeight = 60;

            if (dgvPolicies.Columns.Contains("Status"))
                dgvPolicies.Columns["Status"].FillWeight = 75;
        }


        private void dgvPolicies_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvPolicies.Columns[e.ColumnIndex].Name != "Status" &&
                dgvPolicies.Columns[e.ColumnIndex].DataPropertyName != "Status")
                return;

            if (e.Value == null || e.Value == DBNull.Value)
                return;

            string status = e.Value.ToString().Trim();

            if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.DarkGreen;
                e.CellStyle.BackColor = Color.FromArgb(225, 245, 230);
                e.CellStyle.SelectionForeColor = Color.DarkGreen;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 235, 210);
                e.CellStyle.Font = new Font(
                    dgvPolicies.Font,
                    FontStyle.Bold);
            }
            else if (status.Equals("Expired", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.DarkRed;
                e.CellStyle.BackColor = Color.FromArgb(255, 230, 230);
                e.CellStyle.SelectionForeColor = Color.DarkRed;
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 210);
            }
            else if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.DarkOrange;
                e.CellStyle.BackColor = Color.FromArgb(255, 245, 220);
                e.CellStyle.SelectionForeColor = Color.DarkOrange;
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 230, 180);
            }
        }


        private void LoadPolicies()
        {
            dgvPolicies.AutoGenerateColumns = true;

            policiesTable = DatabaseHelper.GetPolicies();

            dgvPolicies.DataSource = null;
            dgvPolicies.DataSource = policiesTable;

            dgvPolicies.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);

            if (dgvPolicies.Columns.Contains("PolicyNumber"))
            {
                dgvPolicies.Columns["PolicyNumber"].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;

                dgvPolicies.Columns["PolicyNumber"].MinimumWidth = 150;
            }

            FilterPolicies(this, EventArgs.Empty);
        }


        private void FilterPolicies(object? sender, EventArgs e)
        {
            if (policiesTable.Columns.Count == 0)
                return;

            string searchText = txtSearchPolicy.Text.Trim()
                .Replace("'", "''");

            string filter = "";

            if (!string.IsNullOrEmpty(searchText))
            {
                filter = "[PolicyNumber] LIKE '%" + searchText + "%'";
            }

            if (cmbFilterType.SelectedIndex > 0)
            {
                string type = cmbFilterType.Text.Replace("'", "''");
                if (filter.Length > 0)
                    filter += " AND ";

                filter += "[InsuranceType] = '" + type + "'";
            }

            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string status = cmbFilterStatus.Text.Replace("'", "''");
                if (filter.Length > 0)
                    filter += " AND ";

                filter += "[Status] = '" + status + "'";
            }

            DataView view = new DataView(policiesTable);
            view.RowFilter = filter;
            dgvPolicies.DataSource = view;
        }




        private void dgvPolicies_ColumnHeaderMouseClick(
            object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 ||
                e.ColumnIndex >= dgvPolicies.Columns.Count)
                return;

            string columnName =
                dgvPolicies.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrEmpty(columnName))
                columnName = dgvPolicies.Columns[e.ColumnIndex].Name;

            string[] allowedColumns =
            {
        "Id", "ClientId", "PolicyNumber", "InsuranceType",
        "StartDate", "EndDate", "Premium", "Status"
    };

            if (!allowedColumns.Contains(columnName))
                return;

            if (lastSortedColumn == columnName)
                sortAscending = !sortAscending;
            else
            {
                lastSortedColumn = columnName;
                sortAscending = true;
            }

            if (dgvPolicies.DataSource is DataView view)
            {
                view.Sort = "[" + columnName + "] " +
                    (sortAscending ? "ASC" : "DESC");
            }
        }




        private void btnAddPolicy_Click(object sender, EventArgs e)
        {
            using (PolicyEditorForm editor = new PolicyEditorForm())
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPolicies();
                }
            }
        }

        private void btnEditPolicy_Click(object sender, EventArgs e)
        {
            if (dgvPolicies.CurrentRow == null ||
                dgvPolicies.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a policy.");
                return;
            }

            DataGridViewRow row = dgvPolicies.CurrentRow;

            using (PolicyEditorForm editor = new PolicyEditorForm(
                Convert.ToInt32(row.Cells["Id"].Value),
                Convert.ToInt32(row.Cells["ClientId"].Value),
                row.Cells["PolicyNumber"].Value?.ToString() ?? "",
                row.Cells["InsuranceType"].Value?.ToString() ?? "",
                Convert.ToDateTime(row.Cells["StartDate"].Value),
                Convert.ToDateTime(row.Cells["EndDate"].Value),
                Convert.ToDecimal(row.Cells["Premium"].Value),
                row.Cells["Status"].Value?.ToString() ?? ""
            ))
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPolicies();
                }
            }
        }

        private void btnDeletePolicy_Click(object sender, EventArgs e)
        {
            if (dgvPolicies.CurrentRow == null ||
                dgvPolicies.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a policy.");
                return;
            }

            int policyId = Convert.ToInt32(
                dgvPolicies.CurrentRow.Cells["Id"].Value
            );

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this policy?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {

                DatabaseHelper.DeletePolicy(policyId);
                LoadPolicies();
                MessageBox.Show("Policy deleted successfully!");
            }
        }


        private void ExportPoliciesToCsv()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Export Insurance Policies";
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FileName = "InsurancePolicies.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                DataTable policies = DatabaseHelper.GetPolicies();

                using (System.IO.StreamWriter writer =
                       new System.IO.StreamWriter(
                           dialog.FileName,
                           false,
                           System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(
                        "\"ID\",\"Client ID\",\"Policy Number\",\"Insurance Type\",\"Start Date\",\"End Date\",\"Premium\",\"Status\"");

                    foreach (DataRow row in policies.Rows)
                    {
                        string[] columns =
                        {
                    "Id",
                    "ClientId",
                    "PolicyNumber",
                    "InsuranceType",
                    "StartDate",
                    "EndDate",
                    "Premium",
                    "Status"
                };

                        string[] values = new string[columns.Length];

                        for (int i = 0; i < columns.Length; i++)
                        {
                            string value = policies.Columns.Contains(columns[i])
                                ? Convert.ToString(row[columns[i]]) ?? ""
                                : "";

                            values[i] = "\"" +
                                value.Replace("\"", "\"\"") + "\"";
                        }

                        writer.WriteLine(string.Join(",", values));
                    }
                }

                MessageBox.Show(
                    "Policies exported successfully!",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        private int printRowIndex = 0;

        private void PrintPolicies()
        {
            if (dgvPolicies.Rows.Count == 0)
            {
                MessageBox.Show("There are no policies to print.");
                return;
            }

            using (PrintDocument document = new PrintDocument())
            {
                document.DocumentName = "Insurance Policies";
                document.DefaultPageSettings.Landscape = true;

                document.PrintPage += (sender, e) =>
                {
                    if (e.Graphics == null)
                        return;

                    Graphics g = e.Graphics;

                    using Font titleFont =
                        new Font("Segoe UI", 16, FontStyle.Bold);
                    using Font headerFont =
                        new Font("Segoe UI", 9, FontStyle.Bold);
                    using Font bodyFont =
                        new Font("Segoe UI", 9);
                    using Pen linePen = new Pen(Color.LightGray);

                    int left = e.MarginBounds.Left;
                    int y = e.MarginBounds.Top;
                    int rowHeight = 28;

                    g.DrawString(
                        "INSURANCE CRM - POLICIES LIST",
                        titleFont,
                        Brushes.Black,
                        left,
                        y);

                    y += 40;

                    int visibleColumns = dgvPolicies.Columns
                        .Cast<DataGridViewColumn>()
                        .Count(c => c.Visible);

                    if (visibleColumns == 0)
                    {
                        e.HasMorePages = false;
                        return;
                    }

                    int columnWidth =
                        e.MarginBounds.Width / visibleColumns;

                    foreach (DataGridViewColumn column in dgvPolicies.Columns)
                    {
                        if (!column.Visible)
                            continue;

                        g.DrawString(
                            column.HeaderText,
                            headerFont,
                            Brushes.Black,
                            new RectangleF(left, y, columnWidth, rowHeight));

                        left += columnWidth;
                    }

                    y += rowHeight;
                    g.DrawLine(linePen, e.MarginBounds.Left, y,
                        e.MarginBounds.Right, y);
                    y += 5;

                    while (printRowIndex < dgvPolicies.Rows.Count)
                    {
                        DataGridViewRow row =
                            dgvPolicies.Rows[printRowIndex];

                        if (row.IsNewRow)
                        {
                            printRowIndex++;
                            continue;
                        }

                        if (y + rowHeight > e.MarginBounds.Bottom)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                        left = e.MarginBounds.Left;

                        foreach (DataGridViewColumn column in dgvPolicies.Columns)
                        {
                            if (!column.Visible)
                                continue;

                            string value =
                                Convert.ToString(row.Cells[column.Index].Value)
                                ?? "";

                            g.DrawString(
                                value,
                                bodyFont,
                                Brushes.Black,
                                new RectangleF(left, y, columnWidth, rowHeight));

                            left += columnWidth;
                        }

                        y += rowHeight;
                        g.DrawLine(linePen, e.MarginBounds.Left, y,
                            e.MarginBounds.Right, y);

                        printRowIndex++;
                    }

                    printRowIndex = 0;
                    e.HasMorePages = false;
                };

                using PrintDialog dialog = new PrintDialog();
                dialog.Document = document;
                dialog.UseEXDialog = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printRowIndex = 0;
                    document.Print();
                    printRowIndex = 0;
                }
            }
        }

        private void btnPrintPolicies_Click(object sender, EventArgs e)
        {
            PrintPolicies();
        }


        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportPoliciesToCsv();
        }


        private void AddPoliciesContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem =
                new ToolStripMenuItem("Edit Policy");

            ToolStripMenuItem deleteItem =
                new ToolStripMenuItem("Delete Policy");

            ToolStripMenuItem refreshItem =
                new ToolStripMenuItem("Refresh");

            editItem.Click += (s, e) => btnEditPolicy_Click(s, e);
            deleteItem.Click += (s, e) => btnDeletePolicy_Click(s, e);
            refreshItem.Click += (s, e) => LoadPolicies();

            contextMenu.Items.Add(editItem);
            contextMenu.Items.Add(deleteItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(refreshItem);

            dgvPolicies.ContextMenuStrip = contextMenu;
        }


        private void dgvPolicies_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            DataGridView.HitTestInfo hit = dgvPolicies.HitTest(e.X, e.Y);

            if (hit.RowIndex >= 0)
            {
                dgvPolicies.ClearSelection();
                dgvPolicies.Rows[hit.RowIndex].Selected = true;

                dgvPolicies.DoDragDrop(
                    dgvPolicies.Rows[hit.RowIndex],
                    DragDropEffects.Move
                );
            }
        }

        private void dgvPolicies_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data != null &&
                       e.Data.GetDataPresent(typeof(DataGridViewRow))
                ? DragDropEffects.Move
                : DragDropEffects.None;
        }

        private void dgvPolicies_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null ||
                !e.Data.GetDataPresent(typeof(DataGridViewRow)))
                return;

            DataGridViewRow draggedRow =
                (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));

            if (draggedRow.Index >= 0 &&
                draggedRow.Index < dgvPolicies.Rows.Count)
            {
                dgvPolicies.ClearSelection();
                dgvPolicies.Rows[draggedRow.Index].Selected = true;
                dgvPolicies.CurrentCell =
                    dgvPolicies.Rows[draggedRow.Index].Cells[0];
            }
        }


    }
}
