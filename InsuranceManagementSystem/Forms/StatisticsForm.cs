
using InsuranceManagementSystem.Data;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace InsuranceManagementSystem.Forms
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            AddInsuranceChart();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                lblTotalClientsValue.Text =
                    DatabaseHelper.GetTotalClients().ToString();

                lblTotalPoliciesValue.Text =
                    DatabaseHelper.GetTotalPolicies().ToString();

                lblActivePoliciesValue.Text =
                    DatabaseHelper.GetActivePolicies().ToString();

                lblTotalPremiumValue.Text =
                    DatabaseHelper.GetTotalPremium().ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load statistics: " + ex.Message,
                    "Statistics Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void AddInsuranceChart()
        {
            Panel chartPanel = new Panel
            {
                Name = "pnlInsuranceChart",
                BackColor = Color.White,
                Padding = new Padding(15),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Bottom |
                         AnchorStyles.Left |
                         AnchorStyles.Right
            };

            chartPanel.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using Font titleFont =
                    new Font("Segoe UI", 14, FontStyle.Bold);
                using Font labelFont =
                    new Font("Segoe UI", 10);
                using Font valueFont =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                using SolidBrush barBrush =
                    new SolidBrush(Color.FromArgb(52, 152, 219));

                g.DrawString(
                    "Policies by Insurance Type",
                    titleFont,
                    Brushes.DarkSlateGray,
                    15,
                    12);

                string[] types = { "Life", "Property", "Health", "Auto" };
                int[] values = new int[types.Length];

                DataTable policies = DatabaseHelper.GetPolicies();

                foreach (DataRow row in policies.Rows)
                {
                    string type =
                        Convert.ToString(row["InsuranceType"]) ?? "";

                    for (int i = 0; i < types.Length; i++)
                    {
                        if (type.Equals(
                            types[i],
                            StringComparison.OrdinalIgnoreCase))
                        {
                            values[i]++;
                            break;
                        }
                    }
                }

                int maxValue = Math.Max(values.Max(), 1);
                int labelX = 15;
                int barX = 100;
                int barHeight = 22;
                int spacing = 42;

                int availableWidth = Math.Max(
                    100,
                    chartPanel.ClientSize.Width - barX - 65);

                for (int i = 0; i < types.Length; i++)
                {
                    int y = 55 + i * spacing;

                    g.DrawString(
                        types[i],
                        labelFont,
                        Brushes.DimGray,
                        labelX,
                        y + 2);

                    int barWidth = values[i] == 0
                        ? 0
                        : Math.Max(
                            4,
                            (int)((double)values[i] /
                            maxValue * availableWidth));

                    if (barWidth > 0)
                    {
                        g.FillRectangle(
                            barBrush,
                            barX,
                            y,
                            barWidth,
                            barHeight);
                    }

                    g.DrawString(
                        values[i].ToString(),
                        valueFont,
                        Brushes.DarkSlateGray,
                        barX + barWidth + 8,
                        y + 2);
                }
            };
            chartPanel.BringToFront();
            Controls.Add(chartPanel);

            void PositionChart()
            {
                int chartTop = 490;

                chartPanel.Location = new Point(15, chartTop);
                chartPanel.Size = new Size(
                    Math.Max(300, ClientSize.Width - 30),
                    Math.Max(150, ClientSize.Height - chartTop - 15));

                chartPanel.Invalidate();
            }
            PositionChart();

            Resize += (sender, e) => PositionChart();
        }


        private void ExportStatisticsToCsv()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Export Statistics";
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FileName = "InsuranceStatistics.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                using (System.IO.StreamWriter writer =
                       new System.IO.StreamWriter(
                           dialog.FileName,
                           false,
                           System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("\"Statistic\",\"Value\"");

                    writer.WriteLine(
                        "\"Total Clients\"," +
                        "\"" + DatabaseHelper.GetTotalClients() + "\"");

                    writer.WriteLine(
                        "\"Total Policies\"," +
                        "\"" + DatabaseHelper.GetTotalPolicies() + "\"");

                    writer.WriteLine(
                        "\"Active Policies\"," +
                        "\"" + DatabaseHelper.GetActivePolicies() + "\"");

                    writer.WriteLine(
                        "\"Total Premium\"," +
                        "\"" + DatabaseHelper.GetTotalPremium() + "\"");
                }

                MessageBox.Show(
                    "Statistics exported successfully!",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnExportStatistics_Click(object sender, EventArgs e)
        {
            ExportStatisticsToCsv();
        }
    }
}
