
using System;
using System.Drawing;
using System.Windows.Forms;
using InsuranceManagementSystem.Data;

namespace InsuranceManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private FlowLayoutPanel cards;

        private Label lblTotalClients;
        private Label lblLifeInsurance;
        private Label lblPropertyInsurance;
        private Label lblTotalPolicies;
        private Label lblActivePolicies;
        private Label lblTotalPremium;

        private int lifePoliciesCount;
        private int propertyPoliciesCount;
        private int healthPoliciesCount;
        private int autoPoliciesCount;
        private Panel insuranceChartPanel;

        public DashboardForm()
        {
            InitializeComponent();
            BuildDashboard();
            Resize += (s, e) => ResizeCards();
            LoadDashboardData();
        }

        private void BuildDashboard()
        {
            BackColor = Color.FromArgb(245, 247, 250);

            Label title = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(30, 25),
                AutoSize = true
            };
            Controls.Add(title);

            Label subtitle = new Label
            {
                Text = "Insurance Management Overview",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Gray,
                Location = new Point(32, 80),
                AutoSize = true
            };
            Controls.Add(subtitle);

            Button btnRefresh = new Button
            {
                Name = "btnRefreshDashboard",
                Text = "Refresh",
                Location = new Point(32, 130),
                Size = new Size(110, 32),
                BackColor = Color.FromArgb(0, 140, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadDashboardData();
            Controls.Add(btnRefresh);

            cards = new FlowLayoutPanel
            {
                Name = "flpDashboardCards",
                Location = new Point(25, 195),
                Size = new Size(ClientSize.Width - 50,
                                ClientSize.Height - 215),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Bottom |
                         AnchorStyles.Left |
                         AnchorStyles.Right,
                AutoScroll = true,
                WrapContents = true,
                BackColor = Color.Transparent,
                Padding = new Padding(0)
            };
            Controls.Add(cards);

            lblTotalClients = CreateCard("Total Clients");
            lblLifeInsurance = CreateCard("Life Insurance");
            lblPropertyInsurance = CreateCard("Property Insurance");
            lblTotalPolicies = CreateCard("Total Policies");
            lblActivePolicies = CreateCard("Active Policies");
            lblTotalPremium = CreateCard("Total Premium");

            ResizeCards();
            CreateInsuranceChart();

        }

        private Label CreateCard(string title)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 135),
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 11),
                Location = new Point(20, 18),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            Label lblValue = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 64, 120),
                Location = new Point(20, 55),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            cards.Controls.Add(card);

            card.Tag = title;
            lblTitle.Tag = title;
            lblValue.Tag = title;

            card.Click += Navigate;
            lblTitle.Click += Navigate;
            lblValue.Click += Navigate;

            return lblValue;
        }


        private void Navigate(object sender, EventArgs e)
        {
            if (sender is not Control control)
                return;

            string cardTitle = Convert.ToString(control.Tag) ?? "";

            Form parent = this.ParentForm;

            if (parent is not MainForm mainForm)
            {
                MessageBox.Show("MainForm was not found.");
                return;
            }

            if (cardTitle == "Total Clients")
            {
                mainForm.NavigateToClients();
            }
            else
            {
                mainForm.NavigateToPolicies();
            }
        }



        private void CreateInsuranceChart()
        {
            insuranceChartPanel = new Panel
            {
                Name = "pnlInsuranceChart",
                BackColor = Color.White,
                Location = new Point(25, 570),
                Size = new Size(ClientSize.Width - 50, 230),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Left |
                         AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle
            };

            insuranceChartPanel.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using Font titleFont =
                    new Font("Segoe UI", 13, FontStyle.Bold);
                using Font labelFont =
                    new Font("Segoe UI", 10);
                using Pen axisPen = new Pen(Color.LightGray, 1);
                using SolidBrush barBrush =
                    new SolidBrush(Color.FromArgb(30, 100, 180));

                g.DrawString(
                    "Insurance Policies by Type",
                    titleFont,
                    Brushes.Black,
                    20,
                    15);

                int[] values =
                {
            lifePoliciesCount,
            propertyPoliciesCount,
            healthPoliciesCount,
            autoPoliciesCount
        };

                string[] names =
                {
            "Life",
            "Property",
            "Health",
            "Auto"
        };

                int maxValue = Math.Max(1, values.Max());
                int chartLeft = 120;
                int chartTop = 60;
                int maxBarWidth =
                    Math.Max(100, insuranceChartPanel.ClientSize.Width - 230);
                int barHeight = 16;
                int gap = 25;

                g.DrawLine(
                    axisPen,
                    chartLeft,
                    chartTop - 5,
                    chartLeft,
                    chartTop + 4 * gap - 5);


                for (int i = 0; i < values.Length; i++)
                {
                    int y = chartTop + i * gap;
                    int barWidth = (int)(
                        (double)values[i] / maxValue * maxBarWidth);

                    SizeF labelSize = g.MeasureString(names[i], labelFont);
                    SizeF valueSize = g.MeasureString(
                        values[i].ToString(), labelFont);

                    float labelY = y + (barHeight - labelSize.Height) / 2f;
                    float valueY = y + (barHeight - valueSize.Height) / 2f;

                    g.DrawString(
                        names[i],
                        labelFont,
                        Brushes.DimGray,
                        20,
                        labelY);

                    if (values[i] > 0)
                    {
                        g.FillRectangle(
                            barBrush,
                            chartLeft,
                            y,
                            Math.Max(2, barWidth),
                            barHeight);
                    }

                    g.DrawString(
                        values[i].ToString(),
                        labelFont,
                        Brushes.Black,
                        chartLeft + barWidth + 8,
                        valueY);
                }

            };

            Controls.Add(insuranceChartPanel);
            insuranceChartPanel.BringToFront();
        }



        private void LoadDashboardData()
        {
            try
            {
                System.Data.DataTable data =
                    DatabaseHelper.GetDashboardStatistics();

                if (data.Rows.Count == 0)
                    return;

                System.Data.DataRow row = data.Rows[0];

                lblTotalClients.Text =
                    Convert.ToInt32(row["TotalClients"]).ToString();

                lblLifeInsurance.Text =
                    Convert.ToInt32(row["LifePolicies"]).ToString();

                lblPropertyInsurance.Text =
                    Convert.ToInt32(row["PropertyPolicies"]).ToString();

                lblTotalPolicies.Text =
                    Convert.ToInt32(row["TotalPolicies"]).ToString();

                lblActivePolicies.Text =
                    Convert.ToInt32(row["ActivePolicies"]).ToString();

                object premium = row["TotalPremium"];

                lblTotalPremium.Text =
                    premium == DBNull.Value
                        ? "0.00"
                        : Convert.ToDecimal(premium).ToString("N2");
                lifePoliciesCount = DatabaseHelper.GetPoliciesByType("Life");
                propertyPoliciesCount = DatabaseHelper.GetPoliciesByType("Property");
                healthPoliciesCount = DatabaseHelper.GetPoliciesByType("Health");
                autoPoliciesCount = DatabaseHelper.GetPoliciesByType("Auto");

                insuranceChartPanel?.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load dashboard statistics: " + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void ResizeCards()
        {
            if (cards == null || cards.IsDisposed)
                return;

            cards.Width = Math.Max(300, ClientSize.Width - 50);
            cards.Height = Math.Max(200, ClientSize.Height - 215);

            int availableWidth = cards.ClientSize.Width - 30;

            int columns = Math.Max(1, availableWidth / 300);

            int cardWidth = Math.Max(
                220,
                Math.Min(320,
                    (availableWidth - (columns * 16)) / columns));

            foreach (Control control in cards.Controls)
            {
                control.Width = cardWidth;
            }
        }
    }
}
