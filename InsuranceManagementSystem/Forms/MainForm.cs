using System;
using System.Drawing;
using System.Windows.Forms;
using InsuranceManagementSystem.Data;

namespace InsuranceManagementSystem.Forms

{

    public partial class MainForm : Form
    {
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1400, 900);
            this.MinimumSize = new Size(1100, 700);

            try
            {
                using var connection = DatabaseHelper.GetConnection();
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error connecting to database: " + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            ConfigureSidebar();
            ShowPage(new DashboardForm());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D1))
            {
                ShowPage(new DashboardForm());
                return true;
            }

            if (keyData == (Keys.Control | Keys.D2))
            {
                ShowPage(new ClientsForm());
                return true;
            }

            if (keyData == (Keys.Control | Keys.D3))
            {
                ShowPage(new InsuranceForm());
                return true;
            }

            if (keyData == (Keys.Control | Keys.D4))
            {
                ShowPage(new StatisticsForm());
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void ConfigureSidebar()
        {
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Width = 210;

            panelContent.Dock = DockStyle.Fill;

            lblLogo.AutoSize = false;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Height = 75;
            lblLogo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Text = "INSURANCE CRM";

            foreach (Control control in panelSidebar.Controls)
            {
                if (control is Button button)
                {
                    button.Width = panelSidebar.ClientSize.Width - 20;
                    button.Height = 42;
                    button.Anchor = AnchorStyles.Top |
                                    AnchorStyles.Left |
                                    AnchorStyles.Right;
                }
            }
        }



        public void NavigateToClients()
        {
            ShowPage(new ClientsForm());
        }

        public void NavigateToPolicies()
        {
            ShowPage(new InsuranceForm());
        }

        private void ShowPage(Form page)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = page;
            page.TopLevel = false;
            page.FormBorderStyle =
                FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(page);
            page.Show();
            page.BringToFront();
        }

        private void btnClients_Click(
            object sender, EventArgs e)
        {
            ShowPage(new ClientsForm());
        }
        private void btnPolicies_Click(
            object sender, EventArgs e)
        {
            ShowPage(new InsuranceForm());
        }
        private void btnStatistics_Click(
            object sender, EventArgs e)
        {
            ShowPage(new StatisticsForm());
        }
        private void btnExit_Click(
            object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblLogo_Click(
            object sender, EventArgs e)
        {
        }
        private void btnDashboard_Click(
            object sender, EventArgs e)
        {
            ShowPage(new DashboardForm());
        }
    }
}
