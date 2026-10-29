namespace InsuranceManagementSystem.Forms
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatisticsTitle = new Label();
            pnlTotalClients = new Panel();
            lblTotalClientsValue = new Label();
            lblTotalClientsText = new Label();
            pnlActivePolicies = new Panel();
            lblActivePoliciesValue = new Label();
            lblActivePoliciesText = new Label();
            pnlTotalPolicies = new Panel();
            lblTotalPoliciesValue = new Label();
            lblTotalPoliciesText = new Label();
            pnlTotalPremium = new Panel();
            lblTotalPremiumValue = new Label();
            lblTotalPremiumText = new Label();
            btnExportStatistics = new Button();
            pnlTotalClients.SuspendLayout();
            pnlActivePolicies.SuspendLayout();
            pnlTotalPolicies.SuspendLayout();
            pnlTotalPremium.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatisticsTitle
            // 
            lblStatisticsTitle.AutoSize = true;
            lblStatisticsTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatisticsTitle.Location = new Point(25, 20);
            lblStatisticsTitle.Name = "lblStatisticsTitle";
            lblStatisticsTitle.Size = new Size(341, 48);
            lblStatisticsTitle.TabIndex = 0;
            lblStatisticsTitle.Text = "Insurance Statistics";
            // 
            // pnlTotalClients
            // 
            pnlTotalClients.BackColor = Color.White;
            pnlTotalClients.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalClients.Controls.Add(lblTotalClientsValue);
            pnlTotalClients.Controls.Add(lblTotalClientsText);
            pnlTotalClients.Location = new Point(25, 151);
            pnlTotalClients.Name = "pnlTotalClients";
            pnlTotalClients.Size = new Size(420, 150);
            pnlTotalClients.TabIndex = 1;
            // 
            // lblTotalClientsValue
            // 
            lblTotalClientsValue.AutoSize = true;
            lblTotalClientsValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTotalClientsValue.ForeColor = Color.FromArgb(40, 85, 150);
            lblTotalClientsValue.Location = new Point(20, 65);
            lblTotalClientsValue.Name = "lblTotalClientsValue";
            lblTotalClientsValue.Size = new Size(60, 70);
            lblTotalClientsValue.TabIndex = 1;
            lblTotalClientsValue.Text = "0";
            // 
            // lblTotalClientsText
            // 
            lblTotalClientsText.AutoSize = true;
            lblTotalClientsText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalClientsText.ForeColor = Color.FromArgb(80, 90, 110);
            lblTotalClientsText.Location = new Point(20, 20);
            lblTotalClientsText.Name = "lblTotalClientsText";
            lblTotalClientsText.Size = new Size(154, 32);
            lblTotalClientsText.TabIndex = 0;
            lblTotalClientsText.Text = "Total Clients";
            // 
            // pnlActivePolicies
            // 
            pnlActivePolicies.BackColor = Color.White;
            pnlActivePolicies.BackgroundImageLayout = ImageLayout.Center;
            pnlActivePolicies.BorderStyle = BorderStyle.FixedSingle;
            pnlActivePolicies.Controls.Add(lblActivePoliciesValue);
            pnlActivePolicies.Controls.Add(lblActivePoliciesText);
            pnlActivePolicies.Location = new Point(25, 321);
            pnlActivePolicies.Name = "pnlActivePolicies";
            pnlActivePolicies.Size = new Size(420, 150);
            pnlActivePolicies.TabIndex = 2;
            // 
            // lblActivePoliciesValue
            // 
            lblActivePoliciesValue.AutoSize = true;
            lblActivePoliciesValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblActivePoliciesValue.ForeColor = Color.FromArgb(40, 85, 150);
            lblActivePoliciesValue.Location = new Point(20, 65);
            lblActivePoliciesValue.Name = "lblActivePoliciesValue";
            lblActivePoliciesValue.Size = new Size(60, 70);
            lblActivePoliciesValue.TabIndex = 2;
            lblActivePoliciesValue.Text = "0";
            // 
            // lblActivePoliciesText
            // 
            lblActivePoliciesText.AutoSize = true;
            lblActivePoliciesText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblActivePoliciesText.ForeColor = Color.FromArgb(80, 90, 110);
            lblActivePoliciesText.Location = new Point(20, 20);
            lblActivePoliciesText.Name = "lblActivePoliciesText";
            lblActivePoliciesText.Size = new Size(178, 32);
            lblActivePoliciesText.TabIndex = 1;
            lblActivePoliciesText.Text = "Active Policies";
            // 
            // pnlTotalPolicies
            // 
            pnlTotalPolicies.BackColor = Color.White;
            pnlTotalPolicies.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalPolicies.Controls.Add(lblTotalPoliciesValue);
            pnlTotalPolicies.Controls.Add(lblTotalPoliciesText);
            pnlTotalPolicies.Location = new Point(465, 151);
            pnlTotalPolicies.Name = "pnlTotalPolicies";
            pnlTotalPolicies.Size = new Size(420, 150);
            pnlTotalPolicies.TabIndex = 3;
            // 
            // lblTotalPoliciesValue
            // 
            lblTotalPoliciesValue.AutoSize = true;
            lblTotalPoliciesValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTotalPoliciesValue.ForeColor = Color.FromArgb(40, 85, 150);
            lblTotalPoliciesValue.Location = new Point(20, 65);
            lblTotalPoliciesValue.Name = "lblTotalPoliciesValue";
            lblTotalPoliciesValue.Size = new Size(60, 70);
            lblTotalPoliciesValue.TabIndex = 2;
            lblTotalPoliciesValue.Text = "0";
            // 
            // lblTotalPoliciesText
            // 
            lblTotalPoliciesText.AutoSize = true;
            lblTotalPoliciesText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPoliciesText.ForeColor = Color.FromArgb(80, 90, 110);
            lblTotalPoliciesText.Location = new Point(20, 20);
            lblTotalPoliciesText.Name = "lblTotalPoliciesText";
            lblTotalPoliciesText.Size = new Size(163, 32);
            lblTotalPoliciesText.TabIndex = 1;
            lblTotalPoliciesText.Text = "Total Policies";
            // 
            // pnlTotalPremium
            // 
            pnlTotalPremium.BackColor = Color.White;
            pnlTotalPremium.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalPremium.Controls.Add(lblTotalPremiumValue);
            pnlTotalPremium.Controls.Add(lblTotalPremiumText);
            pnlTotalPremium.Location = new Point(465, 321);
            pnlTotalPremium.Name = "pnlTotalPremium";
            pnlTotalPremium.Size = new Size(420, 150);
            pnlTotalPremium.TabIndex = 4;
            // 
            // lblTotalPremiumValue
            // 
            lblTotalPremiumValue.AutoSize = true;
            lblTotalPremiumValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTotalPremiumValue.ForeColor = Color.FromArgb(40, 85, 150);
            lblTotalPremiumValue.Location = new Point(20, 65);
            lblTotalPremiumValue.Name = "lblTotalPremiumValue";
            lblTotalPremiumValue.Size = new Size(60, 70);
            lblTotalPremiumValue.TabIndex = 3;
            lblTotalPremiumValue.Text = "0";
            // 
            // lblTotalPremiumText
            // 
            lblTotalPremiumText.AutoSize = true;
            lblTotalPremiumText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPremiumText.ForeColor = Color.FromArgb(80, 90, 110);
            lblTotalPremiumText.Location = new Point(20, 20);
            lblTotalPremiumText.Name = "lblTotalPremiumText";
            lblTotalPremiumText.Size = new Size(181, 32);
            lblTotalPremiumText.TabIndex = 2;
            lblTotalPremiumText.Text = "Total Premium";
            // 
            // btnExportStatistics
            // 
            btnExportStatistics.BackColor = Color.FromArgb(30, 64, 120);
            btnExportStatistics.Cursor = Cursors.Hand;
            btnExportStatistics.FlatStyle = FlatStyle.Flat;
            btnExportStatistics.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportStatistics.ForeColor = Color.White;
            btnExportStatistics.Location = new Point(25, 86);
            btnExportStatistics.Name = "btnExportStatistics";
            btnExportStatistics.Size = new Size(218, 38);
            btnExportStatistics.TabIndex = 5;
            btnExportStatistics.Text = "Export Statistics";
            btnExportStatistics.UseVisualStyleBackColor = false;
            btnExportStatistics.Click += btnExportStatistics_Click;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1032, 721);
            Controls.Add(btnExportStatistics);
            Controls.Add(pnlTotalPremium);
            Controls.Add(pnlTotalPolicies);
            Controls.Add(pnlActivePolicies);
            Controls.Add(pnlTotalClients);
            Controls.Add(lblStatisticsTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1032, 721);
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            pnlTotalClients.ResumeLayout(false);
            pnlTotalClients.PerformLayout();
            pnlActivePolicies.ResumeLayout(false);
            pnlActivePolicies.PerformLayout();
            pnlTotalPolicies.ResumeLayout(false);
            pnlTotalPolicies.PerformLayout();
            pnlTotalPremium.ResumeLayout(false);
            pnlTotalPremium.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatisticsTitle;
        private Panel pnlTotalClients;
        private Panel pnlTotalPolicies;
        private Panel pnlActivePolicies;
        private Panel pnlTotalPremium;
        private Label lblTotalClientsValue;
        private Label lblTotalClientsText;
        private Label lblTotalPoliciesText;
        private Label lblActivePoliciesValue;
        private Label lblActivePoliciesText;
        private Label label1;
        private Label lblTotalPremiumText;
        private Label lblTotalPremiumValue;
        private Label lblTotalPoliciesValue;
        private Button btnExportStatistics;
    }
}