using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InsuranceManagementSystem.Data;

namespace InsuranceManagementSystem.Forms
{
    public partial class PolicyEditorForm : Form
    {
        private int? editingPolicyId = null;
        public PolicyEditorForm()
        {
            InitializeComponent();
            btnCancel.Click += btnCancel_Click;
            cmbInsuranceType.Items.AddRange(new string[] { "Life", "Property", "Health", "Auto" });
            cmbStatus.Items.AddRange(new string[] { "Active", "Cancelled", "Expired" });

            cmbInsuranceType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            DataTable client = DatabaseHelper.GetClients();
            client.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
            cmbClient.DataSource = client;

            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";
        }
        public PolicyEditorForm(
           int id,
           int clientId,
           string policyNumber,
           string insuranceType,
           DateTime startDate,
           DateTime endDate,
           decimal premium,
           string status) : this()
        {
            editingPolicyId = id;
            Text = "Edit Insurance Policy";
            cmbClient.SelectedValue = clientId;
            txtPolicyNumber.Text = policyNumber;
            cmbInsuranceType.SelectedItem = insuranceType;
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;
            numPremium.Value = premium;
            cmbStatus.SelectedItem = status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Please select a client.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPolicyNumber.Text))
            {
                MessageBox.Show("Please enter a policy number.");
                return;
            }

            if (DatabaseHelper.PolicyNumberExists(
                txtPolicyNumber.Text.Trim(),
                editingPolicyId))
            {
                MessageBox.Show(
                    "This policy number already exists. Please enter a unique policy number.",
                    "Duplicate Policy Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPolicyNumber.Focus();
                txtPolicyNumber.SelectAll();
                return;
            }

            if (dtpEndDate.Value.Date <= dtpStartDate.Value.Date)
            {
                MessageBox.Show(
                    "End Date must be after Start Date.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpEndDate.Focus();
                return;
            }

            if (numPremium.Value <= 0)
            {
                MessageBox.Show(
                    "Premium must be greater than 0.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                numPremium.Focus();
                return;
            }
            if (editingPolicyId.HasValue)
            {
                DatabaseHelper.UpdatePolicy(
                    editingPolicyId.Value,
                    Convert.ToInt32(cmbClient.SelectedValue),
                    txtPolicyNumber.Text.Trim(),
                    cmbInsuranceType.Text,
                    dtpStartDate.Value.Date,
                    dtpEndDate.Value.Date,
                    numPremium.Value,
                    cmbStatus.Text
                );
            }
            else
            {
                DatabaseHelper.AddPolicy(
                    Convert.ToInt32(cmbClient.SelectedValue),
                    txtPolicyNumber.Text.Trim(),
                    cmbInsuranceType.Text,
                    dtpStartDate.Value.Date,
                    dtpEndDate.Value.Date,
                    numPremium.Value,
                    cmbStatus.Text
                );
            }
            MessageBox.Show("Policy saved successfully!");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
