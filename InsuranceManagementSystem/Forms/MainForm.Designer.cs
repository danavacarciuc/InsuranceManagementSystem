namespace InsuranceManagementSystem.Forms
{
    partial class MainForm
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
            panelSidebar = new Panel();
            btnExit = new Button();
            btnStatistics = new Button();
            btnPolicies = new Button();
            btnClients = new Button();
            lblLogo = new Label();
            panelContent = new Panel();
            btnDashboard = new Button();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(25, 39, 65);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(btnExit);
            panelSidebar.Controls.Add(btnStatistics);
            panelSidebar.Controls.Add(btnPolicies);
            panelSidebar.Controls.Add(btnClients);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.ImeMode = ImeMode.Off;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(228, 594);
            panelSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(10, 330);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(240, 45);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStatistics.ForeColor = Color.White;
            btnStatistics.Location = new Point(10, 275);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(240, 45);
            btnStatistics.TabIndex = 3;
            btnStatistics.Text = "Statistics";
            btnStatistics.TextAlign = ContentAlignment.MiddleLeft;
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnPolicies
            // 
            btnPolicies.FlatAppearance.BorderSize = 0;
            btnPolicies.FlatStyle = FlatStyle.Flat;
            btnPolicies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPolicies.ForeColor = Color.White;
            btnPolicies.Location = new Point(10, 220);
            btnPolicies.Name = "btnPolicies";
            btnPolicies.Size = new Size(240, 45);
            btnPolicies.TabIndex = 2;
            btnPolicies.Text = "Insurance Policies";
            btnPolicies.TextAlign = ContentAlignment.MiddleLeft;
            btnPolicies.UseVisualStyleBackColor = true;
            btnPolicies.Click += btnPolicies_Click;
            // 
            // btnClients
            // 
            btnClients.FlatAppearance.BorderSize = 0;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClients.ForeColor = Color.White;
            btnClients.Location = new Point(10, 165);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(240, 45);
            btnClients.TabIndex = 1;
            btnClients.Text = "Clients";
            btnClients.TextAlign = ContentAlignment.MiddleLeft;
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // lblLogo
            // 
            lblLogo.Enabled = false;
            lblLogo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(15, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(200, 80);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "INSURANCE CRM";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Click += lblLogo_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 247, 250);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(228, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(750, 594);
            panelContent.TabIndex = 1;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(10, 110);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(240, 45);
            btnDashboard.TabIndex = 5;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 594);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insurance Management System";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Label lblLogo;
        private Panel panelContent;
        private Button btnExit;
        private Button btnStatistics;
        private Button btnPolicies;
        private Button btnClients;
        private Button btnDashboard;
    }
}