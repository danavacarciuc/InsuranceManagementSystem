namespace InsuranceManagementSystem.Forms
{
    partial class InsuranceForm
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
            btnAddPolicy = new Button();
            btnEditPolicy = new Button();
            btnDeletePolicy = new Button();
            dgvPolicies = new DataGridView();
            lblInsuranceFormtTtitle = new Label();
            lblSearchPolicy = new Label();
            txtSearchPolicy = new TextBox();
            cmbFilterType = new ComboBox();
            cmbFilterStatus = new ComboBox();
            btnExportCsv = new Button();
            btnPrintPolicies = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPolicies).BeginInit();
            SuspendLayout();
            // 
            // btnAddPolicy
            // 
            btnAddPolicy.BackColor = Color.FromArgb(40, 85, 150);
            btnAddPolicy.FlatAppearance.BorderSize = 0;
            btnAddPolicy.FlatStyle = FlatStyle.Flat;
            btnAddPolicy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddPolicy.ForeColor = Color.White;
            btnAddPolicy.Location = new Point(25, 80);
            btnAddPolicy.Name = "btnAddPolicy";
            btnAddPolicy.Size = new Size(140, 40);
            btnAddPolicy.TabIndex = 0;
            btnAddPolicy.Text = "Add Policy";
            btnAddPolicy.UseVisualStyleBackColor = false;
            btnAddPolicy.Click += btnAddPolicy_Click;
            // 
            // btnEditPolicy
            // 
            btnEditPolicy.BackColor = Color.FromArgb(40, 85, 150);
            btnEditPolicy.FlatAppearance.BorderSize = 0;
            btnEditPolicy.FlatStyle = FlatStyle.Flat;
            btnEditPolicy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditPolicy.ForeColor = Color.White;
            btnEditPolicy.Location = new Point(180, 80);
            btnEditPolicy.Name = "btnEditPolicy";
            btnEditPolicy.Size = new Size(140, 40);
            btnEditPolicy.TabIndex = 1;
            btnEditPolicy.Text = "Edit Policy";
            btnEditPolicy.UseVisualStyleBackColor = false;
            btnEditPolicy.Click += btnEditPolicy_Click;
            // 
            // btnDeletePolicy
            // 
            btnDeletePolicy.BackColor = Color.FromArgb(190, 60, 70);
            btnDeletePolicy.FlatAppearance.BorderSize = 0;
            btnDeletePolicy.FlatStyle = FlatStyle.Flat;
            btnDeletePolicy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeletePolicy.ForeColor = Color.White;
            btnDeletePolicy.Location = new Point(335, 80);
            btnDeletePolicy.Name = "btnDeletePolicy";
            btnDeletePolicy.Size = new Size(140, 40);
            btnDeletePolicy.TabIndex = 2;
            btnDeletePolicy.Text = "Delete Policy";
            btnDeletePolicy.UseVisualStyleBackColor = false;
            btnDeletePolicy.Click += btnDeletePolicy_Click;
            // 
            // dgvPolicies
            // 
            dgvPolicies.AllowUserToAddRows = false;
            dgvPolicies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPolicies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPolicies.BackgroundColor = Color.White;
            dgvPolicies.BorderStyle = BorderStyle.None;
            dgvPolicies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPolicies.Location = new Point(27, 196);
            dgvPolicies.MultiSelect = false;
            dgvPolicies.Name = "dgvPolicies";
            dgvPolicies.ReadOnly = true;
            dgvPolicies.RowHeadersVisible = false;
            dgvPolicies.RowHeadersWidth = 62;
            dgvPolicies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPolicies.Size = new Size(850, 500);
            dgvPolicies.TabIndex = 3;
            // 
            // lblInsuranceFormtTtitle
            // 
            lblInsuranceFormtTtitle.AutoSize = true;
            lblInsuranceFormtTtitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblInsuranceFormtTtitle.Location = new Point(25, 20);
            lblInsuranceFormtTtitle.Name = "lblInsuranceFormtTtitle";
            lblInsuranceFormtTtitle.Size = new Size(293, 48);
            lblInsuranceFormtTtitle.TabIndex = 4;
            lblInsuranceFormtTtitle.Text = "Insurance Editor";
            // 
            // lblSearchPolicy
            // 
            lblSearchPolicy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearchPolicy.Location = new Point(27, 145);
            lblSearchPolicy.Name = "lblSearchPolicy";
            lblSearchPolicy.Size = new Size(75, 25);
            lblSearchPolicy.TabIndex = 5;
            lblSearchPolicy.Text = "Search:";
            // 
            // txtSearchPolicy
            // 
            txtSearchPolicy.Location = new Point(100, 141);
            txtSearchPolicy.Name = "txtSearchPolicy";
            txtSearchPolicy.PlaceholderText = "Policy number...";
            txtSearchPolicy.Size = new Size(230, 34);
            txtSearchPolicy.TabIndex = 6;
            // 
            // cmbFilterType
            // 
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.FormattingEnabled = true;
            cmbFilterType.Location = new Point(350, 141);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(190, 36);
            cmbFilterType.TabIndex = 7;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(560, 141);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(190, 36);
            cmbFilterStatus.TabIndex = 8;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.Green;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(538, 80);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(140, 40);
            btnExportCsv.TabIndex = 9;
            btnExportCsv.Text = "Export CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // btnPrintPolicies
            // 
            btnPrintPolicies.BackColor = Color.Green;
            btnPrintPolicies.FlatAppearance.BorderSize = 0;
            btnPrintPolicies.FlatStyle = FlatStyle.Flat;
            btnPrintPolicies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrintPolicies.ForeColor = Color.White;
            btnPrintPolicies.Location = new Point(694, 80);
            btnPrintPolicies.Name = "btnPrintPolicies";
            btnPrintPolicies.Size = new Size(172, 40);
            btnPrintPolicies.TabIndex = 10;
            btnPrintPolicies.Text = "Print Policies";
            btnPrintPolicies.UseVisualStyleBackColor = false;
            btnPrintPolicies.Click += btnPrintPolicies_Click;
            // 
            // InsuranceForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1032, 721);
            Controls.Add(btnPrintPolicies);
            Controls.Add(btnExportCsv);
            Controls.Add(cmbFilterStatus);
            Controls.Add(cmbFilterType);
            Controls.Add(txtSearchPolicy);
            Controls.Add(lblSearchPolicy);
            Controls.Add(lblInsuranceFormtTtitle);
            Controls.Add(dgvPolicies);
            Controls.Add(btnDeletePolicy);
            Controls.Add(btnEditPolicy);
            Controls.Add(btnAddPolicy);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1032, 721);
            Name = "InsuranceForm";
            Text = "InsuranceForm";
            ((System.ComponentModel.ISupportInitialize)dgvPolicies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPolicy;
        private Button btnEditPolicy;
        private Button btnDeletePolicy;
        private DataGridView dgvPolicies;
        private Label lblInsuranceFormtTtitle;
        private Label lblSearchPolicy;
        private TextBox txtSearchPolicy;
        private ComboBox cmbFilterType;
        private ComboBox cmbFilterStatus;
        private Button btnExportCsv;
        private Button btnPrintPolicies;
    }
}