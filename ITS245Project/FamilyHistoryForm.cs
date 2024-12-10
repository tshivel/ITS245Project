using FinalProjectV2;
using HealthcareForms;
using ITS245Project.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ITS245Project
{
    public partial class FamilyHistoryForm : Form
    {
        private int ScreenMode = 0; // 1 = Modify, 2 = Add
        DataTable dt;
        int pid;
        string name;
        int age;
        int familyID;

        public FamilyHistoryForm(int PatientID, string fullName, int age)
        {
            InitializeComponent();
            pid = PatientID;
            name = fullName;
            this.age = age;
            this.Load += FamilyHistoryForm_Load;

        }

      

        private void FamilyHistoryForm_Load(object sender, EventArgs e)
        {
            LockScreen(); // Lock all controls except Add/Modify buttons initially
            LoadGridView();
        }

        private int selectedFamilyID = -1; 

        private void LoadGridView()
        {
            try
            {
                // Open the connection
                using (var connection = dbUtil.MakeConnection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open(); // Ensure the connection is open
                    }

                    // Fetch data from the database (call to stored procedure)
                    dt = Data.FamilyHistoryData.GetFamilyHistory(connection, pid);

                    // Check if the DataTable is null
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No records found or DataTable is null.");
                        return;
                    }

                    // Set DataGridView data source to the populated DataTable
                    dataGridViewFamilyHistory.DataSource = dt;

                    // Hide unnecessary columns
                    dataGridViewFamilyHistory.Columns["PatientID"].Visible = false;
                    dataGridViewFamilyHistory.Columns["FamilyID"].Visible = false;
                    dataGridViewFamilyHistory.Columns["Deleted"].Visible = false;

                    // Set DataGridView as read-only to prevent editing
                    dataGridViewFamilyHistory.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error binding DataGridView: " + ex.Message);
            }
        }

        public void LockScreen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.ReadOnly = true;  // Lock the textbox
                    txtBox.BackColor = Color.LightGray;  // Set background to light gray
                }
                else if (control is RichTextBox rtb)
                {
                    rtb.ReadOnly = true;  // Lock the rich text box
                    rtb.BackColor = Color.LightGray;  // Set background to light gray
                }
                else if (control is CheckBox chkBox)
                {
                    chkBox.Enabled = false;  // Disable checkboxes
                }
                else if (control is DataGridView dataGV)
                {
                    dataGV.Enabled = false;
                    dataGV.DefaultCellStyle.BackColor = Color.LightGray;
                    dataGV.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }

            // Disable Save, Undo, and Delete buttons
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
        }

        public void UnlockScreen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.ReadOnly = false;  // Unlock the textbox
                    txtBox.BackColor = Color.White;  // Set background to white
                }
                else if (control is RichTextBox rtb)
                {
                    rtb.ReadOnly = false;  // Unlock the rich text box
                    rtb.BackColor = Color.White;  // Set background to white
                }
                else if (control is CheckBox chkBox)
                {
                    chkBox.Enabled = true;  // Enable checkboxes
                }
                else if (control is DataGridView dataGV)
                {
                    dataGV.Enabled = true;
                    dataGV.DefaultCellStyle.BackColor = Color.White;
                    dataGV.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Enable Save, Undo, and Delete buttons
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ScreenMode = 2; // Set screen mode to Add
            UnlockScreen(); // Unlock screen for adding data

            // Clear all TextBox controls
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.Clear();  // Clear the text in the TextBox
                }
            }
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            ScreenMode = 1; // Set screen mode to Modify
            UnlockScreen(); // Unlock screen for modifying data
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                LockScreen(); // Lock the screen
                ScreenMode = 0; // Reset to View mode

                // Reload the data grid view to show the latest data
                LoadGridView();

                // Clear all form inputs
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox txtBox)
                    {
                        txtBox.Clear();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during undo: " + ex.Message);
            }
        }

        private void dataGridViewFamilyHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ensure that the clicked row is valid (check for valid row index)
            // Ensure that the clicked row is valid (check for valid row index)
            if (e.RowIndex >= 0)
            {
                // Retrieve the selected row's data
                DataGridViewRow selectedRow = dataGridViewFamilyHistory.Rows[e.RowIndex];

                // Assign the FamilyID to the class-level variable
                selectedFamilyID = Convert.ToInt32(selectedRow.Cells["FamilyID"].Value);

                // Populate the form controls with the selected row's data
                txtFullName.Text = selectedRow.Cells["FullName"].Value?.ToString();
                txtRelation.Text = selectedRow.Cells["Relation"].Value?.ToString();
                cbAlive.Checked = Convert.ToBoolean(selectedRow.Cells["Alive"].Value);
                cbLivesWithPatient.Checked = Convert.ToBoolean(selectedRow.Cells["LivesWithPatient"].Value);
                txtMajorDisorder.Text = selectedRow.Cells["MajorDisorder"].Value?.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from form controls
                string name = txtFullName.Text;
                string relation = txtRelation.Text;
                int alive = cbAlive.Checked ? 1 : 0;
                int livesWithPatient = cbLivesWithPatient.Checked ? 1 : 0;
                string majorDisorder = txtMajorDisorder.Text;

                // Open the connection explicitly inside the button click
                using (var connection = dbUtil.MakeConnection())
                {
                    connection.Open();  
                    if (ScreenMode == 2) 
                    {
                        FamilyHistoryData.InsertFamilyHistory(connection, pid, name, relation, alive, livesWithPatient, majorDisorder);
                    }
                    else if (ScreenMode == 1)
                    {
                        if (selectedFamilyID == -1)
                        {
                            MessageBox.Show("No record selected for modification.");
                            return;
                        }
                        FamilyHistoryData.UpdateFamilyHistory(connection, selectedFamilyID, name, relation, alive, livesWithPatient, majorDisorder);
                    }
                    else
                    {
                        MessageBox.Show("Invalid ScreenMode detected.");
                        return;
                    }
                }

                // Reload the data in the DataGridView
                LoadGridView();

                // Lock the screen and reset mode
                LockScreen();
                ScreenMode = 0;
                selectedFamilyID = -1; // Reset the selectedFamilyID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected in the DataGridView
                if (dataGridViewFamilyHistory.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.");
                    return;
                }

                // Get the FamilyID from the selected row
                int rowIndex = dataGridViewFamilyHistory.CurrentCell.RowIndex;
                int familyID = Convert.ToInt32(dataGridViewFamilyHistory.Rows[rowIndex].Cells["FamilyID"].Value);

                // Confirm the delete action
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to mark this record as deleted?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Perform the delete
                    using (var connection = dbUtil.MakeConnection())
                    {
                        connection.Open();
                        Data.FamilyHistoryData.DeleteFamily(connection, familyID);
                    }

                    MessageBox.Show("Record marked as deleted successfully.");
                    LoadGridView(); // Refresh the data grid view
                    LockScreen() ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting the record: " + ex.Message);
            }
        }

        private void btnGeneralMedicalHistory_Click(object sender, EventArgs e)
        {
            GeneralHistoryForm generalHistoryForm = new GeneralHistoryForm(pid, name, age);
            generalHistoryForm.Show(); // Show the GeneralHistoryForm
            this.Hide(); // Hide the current FamilyHistoryForm
        }

        private void btnPatientSelectForm_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }

        private void btnDemographic_Click(object sender, EventArgs e)
        {
            DemographicsForm demographicsForm = new DemographicsForm(pid, Name, age);
            demographicsForm.Show();
            this.Hide();
        }

        private void btnAllergyForm_Click(object sender, EventArgs e)
        {
            Allergies allergies = new Allergies(pid, Name, age);
            allergies.Show();
            this.Hide();
        }

        private void btnMedicationsForm_Click(object sender, EventArgs e)
        {
            Medication medication = new Medication(pid, Name, age);
            medication.Show();
            this.Hide();
        }
    }
}

