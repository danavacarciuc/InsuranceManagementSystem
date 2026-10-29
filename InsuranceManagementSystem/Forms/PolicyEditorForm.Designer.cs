namespace InsuranceManagementSystem.Forms
{
    partial class PolicyEditorForm
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
            lblClient = new Label();
            lblPolicyNumber = new Label();
            lblInsuranceType = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            lblPremium = new Label();
            lblStatus = new Label();
            cmbClient = new ComboBox();
            txtPolicyNumber = new TextBox();
            cmbInsuranceType = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            numPremium = new NumericUpDown();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPremium).BeginInit();
            SuspendLayout();
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClient.Location = new Point(30, 30);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(67, 28);
            lblClient.TabIndex = 0;
            lblClient.Text = "Client";
            // 
            // lblPolicyNumber
            // 
            lblPolicyNumber.AutoSize = true;
            lblPolicyNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPolicyNumber.Location = new Point(30, 100);
            lblPolicyNumber.Name = "lblPolicyNumber";
            lblPolicyNumber.Size = new Size(151, 28);
            lblPolicyNumber.TabIndex = 1;
            lblPolicyNumber.Text = "Policy Number";
            // 
            // lblInsuranceType
            // 
            lblInsuranceType.AutoSize = true;
            lblInsuranceType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInsuranceType.Location = new Point(30, 170);
            lblInsuranceType.Name = "lblInsuranceType";
            lblInsuranceType.Size = new Size(154, 28);
            lblInsuranceType.TabIndex = 2;
            lblInsuranceType.Text = "Insurance Type";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStartDate.Location = new Point(30, 240);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(110, 28);
            lblStartDate.TabIndex = 3;
            lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEndDate.Location = new Point(30, 310);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(98, 28);
            lblEndDate.TabIndex = 4;
            lblEndDate.Text = "End Date";
            // 
            // lblPremium
            // 
            lblPremium.AutoSize = true;
            lblPremium.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPremium.Location = new Point(30, 380);
            lblPremium.Name = "lblPremium";
            lblPremium.Size = new Size(97, 28);
            lblPremium.TabIndex = 5;
            lblPremium.Text = "Premium";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(30, 450);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(71, 28);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // cmbClient
            // 
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.Font = new Font("Segoe UI", 9F);
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(30, 64);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(470, 33);
            cmbClient.TabIndex = 7;
            // 
            // txtPolicyNumber
            // 
            txtPolicyNumber.Location = new Point(30, 133);
            txtPolicyNumber.Name = "txtPolicyNumber";
            txtPolicyNumber.Size = new Size(470, 34);
            txtPolicyNumber.TabIndex = 8;
            // 
            // cmbInsuranceType
            // 
            cmbInsuranceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInsuranceType.Font = new Font("Segoe UI", 9F);
            cmbInsuranceType.FormattingEnabled = true;
            cmbInsuranceType.Location = new Point(30, 204);
            cmbInsuranceType.Name = "cmbInsuranceType";
            cmbInsuranceType.Size = new Size(470, 33);
            cmbInsuranceType.TabIndex = 9;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(30, 273);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(470, 34);
            dtpStartDate.TabIndex = 10;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(30, 341);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(470, 34);
            dtpEndDate.TabIndex = 11;
            // 
            // numPremium
            // 
            numPremium.DecimalPlaces = 2;
            numPremium.Location = new Point(30, 411);
            numPremium.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPremium.Name = "numPremium";
            numPremium.Size = new Size(470, 34);
            numPremium.TabIndex = 12;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(30, 481);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(470, 33);
            cmbStatus.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 85, 150);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(118, 552);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(110, 120, 135);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(284, 552);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 40);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // PolicyEditorForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(581, 632);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbStatus);
            Controls.Add(numPremium);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cmbInsuranceType);
            Controls.Add(txtPolicyNumber);
            Controls.Add(cmbClient);
            Controls.Add(lblStatus);
            Controls.Add(lblPremium);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblInsuranceType);
            Controls.Add(lblPolicyNumber);
            Controls.Add(lblClient);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PolicyEditorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Insurance Policy";
            ((System.ComponentModel.ISupportInitialize)numPremium).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClient;
        private Label lblPolicyNumber;
        private Label lblInsuranceType;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblPremium;
        private Label lblStatus;
        private ComboBox cmbClient;
        private TextBox txtPolicyNumber;
        private ComboBox cmbInsuranceType;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private NumericUpDown numPremium;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button button2;
        private Button btnCancel;
    }
}