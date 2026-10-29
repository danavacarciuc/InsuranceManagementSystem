
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace InsuranceManagementSystem.Forms
{
    public partial class ClientsForm : Form
    {
        private static BindingList<Client> clients =
            new BindingList<Client>();

        private DataGridView dgvClients;
        private TextBox txtSearch;
        private string lastSortedColumn = "";
        private bool sortAscending = true;

        public ClientsForm()
        {
            InitializeComponent();
            BuildInterface();
            AddClientsContextMenu();
            LoadClients();
        }

        private void BuildInterface()
        {
            BackColor = Color.FromArgb(245, 247, 250);

            Controls.Clear();

            Label title = new Label
            {
                Text = "Clients Management",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(30, 25),
                AutoSize = true
            };

            Controls.Add(title);

            Label subtitle = new Label
            {
                Text = "Manage your insurance clients",
                ForeColor = Color.Gray,
                Location = new Point(32, 75),
                AutoSize = true
            };

            Controls.Add(subtitle);

            FlowLayoutPanel toolbar = new FlowLayoutPanel
            {
                Height = 55,
                Padding = new Padding(10, 5, 0, 0),
                Location = new Point(25, 120),
                Width = 1000,
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Left |
                         AnchorStyles.Right,
                WrapContents = false
            };


            Button btnAdd = CreateButton("Add Client");
            Button btnEdit = CreateButton("Edit Client");
            Button btnDelete = CreateButton("Delete Client");

            btnDelete.BackColor = Color.FromArgb(200, 50, 60);

            txtSearch = new TextBox
            {
                Width = 180,
                Height = 32,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(25, 10, 5, 0),
                ForeColor = Color.Gray,
                Text = "Search clients..."
            };

            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Search clients...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search clients...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            Button btnSearch = CreateButton("Search");
            Button btnPrint = CreateButton("Print Clients");
            Button btnExport = CreateButton("Export CSV");

            btnPrint.BackColor = Color.FromArgb(0, 140, 60);
            btnExport.BackColor = Color.FromArgb(0, 140, 60);

            btnExport.Click += (s, e) => ExportClientsToCsv();

            toolbar.Controls.Add(btnAdd);
            toolbar.Controls.Add(btnEdit);
            toolbar.Controls.Add(btnDelete);
            toolbar.Controls.Add(txtSearch);
            toolbar.Controls.Add(btnSearch);
            toolbar.Controls.Add(btnPrint);
            toolbar.Controls.Add(btnExport);

            Controls.Add(toolbar);

            dgvClients = new DataGridView
            {
                Location = new Point(30, 200),
                Size = new Size(950, 400),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Bottom |
                         AnchorStyles.Left |
                         AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.DisplayedCells,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false
            };

            Controls.Add(dgvClients);

            dgvClients.ColumnHeaderMouseClick += (s, e) =>
            {
                string columnName = dgvClients.Columns[e.ColumnIndex].DataPropertyName;

                if (string.IsNullOrEmpty(columnName))
                    columnName = dgvClients.Columns[e.ColumnIndex].Name;

                if (lastSortedColumn == columnName)
                    sortAscending = !sortAscending;
                else
                {
                    lastSortedColumn = columnName;
                    sortAscending = true;
                }

                SortClients(columnName);

                if (!sortAscending)
                {
                    switch (columnName)
                    {
                        case "Id":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.Id).ToList();
                            break;
                        case "FirstName":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.FirstName).ToList();
                            break;
                        case "LastName":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.LastName).ToList();
                            break;
                        case "Email":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.Email).ToList();
                            break;
                        case "Phone":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.Phone).ToList();
                            break;
                        case "RegistrationDate":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.RegistrationDate).ToList();
                            break;
                        case "FullName":
                            dgvClients.DataSource = clients.OrderByDescending(c => c.FullName).ToList();
                            break;
                    }
                }
            };


            dgvClients.SortCompare += (s, e) =>
            {
                if (e.Column.Name == "Id")
                {
                    int value1 = Convert.ToInt32(e.CellValue1);
                    int value2 = Convert.ToInt32(e.CellValue2);
                    e.SortResult = value1.CompareTo(value2);
                    e.Handled = true;
                }
            };

            foreach (DataGridViewColumn column in dgvClients.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            btnAdd.Click += (s, e) => AddClient();
            btnEdit.Click += (s, e) => EditClient();
            btnDelete.Click += (s, e) => DeleteClient();
            btnSearch.Click += (s, e) => LoadClients();
            btnPrint.Click += (s, e) => PrintClients();

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LoadClients();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void AddClientsContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem =
                new ToolStripMenuItem("Edit Client");

            ToolStripMenuItem deleteItem =
                new ToolStripMenuItem("Delete Client");

            ToolStripMenuItem refreshItem =
                new ToolStripMenuItem("Refresh");

            editItem.Click += (s, e) => EditClient();
            deleteItem.Click += (s, e) => DeleteClient();
            refreshItem.Click += (s, e) => LoadClients();

            contextMenu.Items.Add(editItem);
            contextMenu.Items.Add(deleteItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(refreshItem);

            dgvClients.ContextMenuStrip = contextMenu;
        }


        private Button CreateButton(string text)
        {
            return new Button
            {
                Text = text,
                Size = new Size(120, 38),
                BackColor = Color.FromArgb(30, 64, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Margin = new Padding(4, 5, 4, 5),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
        }


        private void LoadClients()
        {
            DataTable table = DatabaseHelper.GetClients();

            clients.Clear();

            foreach (DataRow row in table.Rows)
            {
                clients.Add(new Client
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = row["FirstName"].ToString() ?? "",
                    LastName = row["LastName"].ToString() ?? "",
                    Email = row["Email"].ToString() ?? "",
                    Phone = row["Phone"].ToString() ?? "",
                    RegistrationDate =
                        Convert.ToDateTime(row["RegistrationDate"])
                });
            }

            string search = txtSearch.Text == "Search clients..."
                ? ""
                : txtSearch.Text.Trim();

            var filtered = clients.Where(c =>
                c.FullName.IndexOf(
                    search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (c.Email ?? "").IndexOf(
                    search, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            dgvClients.DataSource = null;
            dgvClients.DataSource = filtered;
            foreach (DataGridViewColumn column in dgvClients.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (dgvClients.Columns["Id"] != null)
                dgvClients.Columns["Id"].Width = 55;

            if (dgvClients.Columns["FirstName"] != null)
                dgvClients.Columns["FirstName"].Width = 130;

            if (dgvClients.Columns["LastName"] != null)
                dgvClients.Columns["LastName"].Width = 130;

            if (dgvClients.Columns["Email"] != null)
                dgvClients.Columns["Email"].Width = 220;

            if (dgvClients.Columns["Phone"] != null)
                dgvClients.Columns["Phone"].Width = 120;

            if (dgvClients.Columns["RegistrationDate"] != null)
                dgvClients.Columns["RegistrationDate"].Width = 150;

            if (dgvClients.Columns["FullName"] != null)
                dgvClients.Columns["FullName"].Width = 180;

            if (dgvClients.Columns["Insurances"] != null)
                dgvClients.Columns["Insurances"].Visible = false;

            if (dgvClients.Columns["FullName"] != null)
                dgvClients.Columns["FullName"].HeaderText = "Full Name";
        }

        private Client GetSelectedClient()
        {
            if (dgvClients.CurrentRow == null)
                return null;

            return dgvClients.CurrentRow.DataBoundItem as Client;
        }

        private void AddClient()
        {
            using (ClientEditorForm form = new ClientEditorForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Client client = form.ClientData;

                    DatabaseHelper.AddClient(
                        client.FirstName,
                        client.LastName,
                        client.Email,
                        client.Phone
                    );

                    LoadClients();
                }
            }
        }

        private void EditClient()
        {
            Client selected = GetSelectedClient();

            if (selected == null)
            {
                MessageBox.Show("Please select a client.");
                return;
            }

            using (ClientEditorForm form =
                   new ClientEditorForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DatabaseHelper.UpdateClient(
                        selected.Id,
                        form.ClientData.FirstName,
                        form.ClientData.LastName,
                        form.ClientData.Email,
                        form.ClientData.Phone
                    );

                    LoadClients();
                }
            }
        }

        private void DeleteClient()
        {
            Client selected = GetSelectedClient();

            if (selected == null)
            {
                MessageBox.Show("Please select a client.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete selected client?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DatabaseHelper.DeleteClient(selected.Id);
                LoadClients();
            }
        }

        private void PrintClients()
        {
            using (PrintDocument printDocument = new PrintDocument())
            {
                int currentRow = 0;

                printDocument.DocumentName = "Clients List";

                printDocument.PrintPage += (sender, e) =>
                {
                    using (Font titleFont =
                           new Font("Arial", 16, FontStyle.Bold))
                    using (Font headerFont =
                           new Font("Arial", 10, FontStyle.Bold))
                    using (Font bodyFont = new Font("Arial", 9))
                    {
                        float y = 50;
                        float left = 50;

                        e.Graphics.DrawString(
                            "INSURANCE CRM - CLIENTS LIST",
                            titleFont,
                            Brushes.Black,
                            left,
                            y
                        );

                        y += 45;

                        string[] columns =
                        {
                            "Id", "FullName", "Email", "Phone"
                        };

                        string[] headers =
                        {
                            "ID", "Name", "Email", "Phone"
                        };

                        float[] widths = { 50, 180, 220, 130 };
                        float x = left;

                        for (int i = 0; i < columns.Length; i++)
                        {
                            e.Graphics.DrawString(
                                headers[i],
                                headerFont,
                                Brushes.Black,
                                x,
                                y
                            );

                            x += widths[i];
                        }

                        y += 25;

                        while (currentRow < dgvClients.Rows.Count)
                        {
                            DataGridViewRow row =
                                dgvClients.Rows[currentRow];

                            if (row.IsNewRow)
                            {
                                currentRow++;
                                continue;
                            }

                            if (y > e.MarginBounds.Bottom - 30)
                            {
                                e.HasMorePages = true;
                                return;
                            }

                            x = left;

                            for (int i = 0; i < columns.Length; i++)
                            {
                                string columnName = columns[i];

                                string value =
                                    dgvClients.Columns.Contains(columnName)
                                    ? Convert.ToString(
                                        row.Cells[columnName].Value) ?? ""
                                    : "";

                                e.Graphics.DrawString(
                                    value,
                                    bodyFont,
                                    Brushes.Black,
                                    new RectangleF(
                                        x, y, widths[i] - 5, 35)
                                );

                                x += widths[i];
                            }

                            y += 30;
                            currentRow++;
                        }

                        currentRow = 0;
                        e.HasMorePages = false;
                        y += 10;

                        e.Graphics.DrawString(
                            "Total clients: " + dgvClients.Rows.Count,
                            headerFont,
                            Brushes.Black,
                            left,
                            y
                        );
                    }
                };

                using (PrintDialog dialog = new PrintDialog())
                {
                    dialog.Document = printDocument;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
            }
        }

        private void ExportClientsToCsv()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Export Clients";
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FileName = "InsuranceClients.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                using (System.IO.StreamWriter writer =
                       new System.IO.StreamWriter(dialog.FileName, false,
                           System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("ID,Name,Email,Phone,Registration Date");

                    foreach (DataGridViewRow row in dgvClients.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string id = GetCellValue(row, "Id");
                        string name = GetCellValue(row, "FullName");
                        string email = GetCellValue(row, "Email");
                        string phone = GetCellValue(row, "Phone");
                        string date = GetCellValue(row, "RegistrationDate");

                        writer.WriteLine(
                            $"{CsvEscape(id)},{CsvEscape(name)},{CsvEscape(email)},{CsvEscape(phone)},{CsvEscape(date)}"
                        );
                    }
                }

                MessageBox.Show(
                    "Clients exported successfully!",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            if (!dgvClients.Columns.Contains(columnName))
                return "";

            return Convert.ToString(row.Cells[columnName].Value) ?? "";
        }

        private string CsvEscape(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }



        private void SortClients(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return;

            string search = txtSearch.Text.Trim();

            if (search == "Search clients...")
                search = "";

            var filtered = clients.Where(c =>
                c.FullName.IndexOf(
                    search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (c.Email ?? "").IndexOf(
                    search, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            switch (columnName)
            {
                case "Id":
                    filtered = filtered.OrderBy(c => c.Id).ToList();
                    break;
                case "FirstName":
                    filtered = filtered.OrderBy(c => c.FirstName).ToList();
                    break;
                case "LastName":
                    filtered = filtered.OrderBy(c => c.LastName).ToList();
                    break;
                case "Email":
                    filtered = filtered.OrderBy(c => c.Email).ToList();
                    break;
                case "Phone":
                    filtered = filtered.OrderBy(c => c.Phone).ToList();
                    break;
                case "RegistrationDate":
                    filtered = filtered.OrderBy(c => c.RegistrationDate).ToList();
                    break;
                case "FullName":
                    filtered = filtered.OrderBy(c => c.FullName).ToList();
                    break;
            }

            dgvClients.DataSource = null;
            dgvClients.DataSource = filtered;

            if (dgvClients.Columns["Insurances"] != null)
                dgvClients.Columns["Insurances"].Visible = false;

            if (dgvClients.Columns["FullName"] != null)
                dgvClients.Columns["FullName"].HeaderText = "Full Name";
        }

    }

    public class ClientEditorForm : Form
    {
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;

        public Client ClientData { get; private set; }

        public ClientEditorForm(Client existing = null)
        {
            ClientData = new Client();

            Text = existing == null ? "Add Client" : "Edit Client";
            Size = new Size(440, 400);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 10);

            txtFirstName = AddField("First Name", 25);
            txtLastName = AddField("Last Name", 95);
            txtEmail = AddField("Email", 165);
            txtPhone = AddField("Phone", 235);

            Button btnSave = new Button
            {
                Text = "Save",
                Location = new Point(285, 310),
                Size = new Size(110, 35),
                BackColor = Color.FromArgb(30, 64, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += SaveClient;
            Controls.Add(btnSave);
            AcceptButton = btnSave;

            if (existing != null)
            {
                txtFirstName.Text = existing.FirstName;
                txtLastName.Text = existing.LastName;
                txtEmail.Text = existing.Email;
                txtPhone.Text = existing.Phone;
            }
        }

        private TextBox AddField(string label, int y)
        {
            Label lbl = new Label
            {
                Text = label,
                Location = new Point(25, y),
                AutoSize = true
            };

            TextBox txt = new TextBox
            {
                Location = new Point(25, y + 25),
                Width = 370
            };

            Controls.Add(lbl);
            Controls.Add(txt);

            return txt;
        }


        private void SaveClient(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show(
                    "First name and last name are required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validate email
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Email is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtEmail.Focus();
                return;
            }

            try
            {
                MailAddress address = new MailAddress(email);

                if (address.Address != email)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            // Validate phone number
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show(
                    "Phone number is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPhone.Focus();
                return;
            }

            string normalizedPhone = phone
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                normalizedPhone, @"^\+?\d{7,15}$"))
            {
                MessageBox.Show(
                    "Enter a valid phone number with 7-15 digits. " +
                    "You may use + at the beginning, spaces, hyphens, or parentheses.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPhone.Focus();
                txtPhone.SelectAll();
                return;
            }

            ClientData.FirstName = txtFirstName.Text.Trim();
            ClientData.LastName = txtLastName.Text.Trim();
            ClientData.Email = email;
            ClientData.Phone = phone;

            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
