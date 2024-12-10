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
using ITS245Project;
using FinalProjectV2.Tools;
using FinalProjectV2;

namespace HealthcareForms
{
    public partial class Medication : Form
    {
        MySqlConnection conn;
        DataTable dt;
        string name;
        int medicationID;
        int pid;
        private int ScreenMode = 0; // 1 = Modify, 2 = Add
        int age;
        public Medication(int PatientID, string fullName, int age)
        {
            InitializeComponent();
            pid = PatientID;
            name = fullName;
            this.age = age;
            this.Load += Medication_Load;
        }

        private void Medication_Load(object sender, EventArgs e)
        {
            LoadGridView();
            LockScreen();
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

        private void LoadGridView()
        {
            try
            {
                using (var connection = DatabaseTools.MakeConnection())
                {
                    // Retrieve medication data from the database
                    DataTable dt = Data.MedicationTools.ShowMedications(connection, pid);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No medication records found.");
                        return;
                    }

                    // Bind to DataGridView
                    dataGridViewMedication.DataSource = dt;

                    // Hide unnecessary columns
                    if (dataGridViewMedication.Columns.Contains("PatientID"))
                    {
                        dataGridViewMedication.Columns["PatientID"].Visible = false;
                    }
                    if (dataGridViewMedication.Columns.Contains("deleted"))
                    {
                        dataGridViewMedication.Columns["deleted"].Visible = false;
                    }
                    if (dataGridViewMedication.Columns.Contains("MedicationID"))
                    {
                        dataGridViewMedication.Columns["MedicationID"].Visible = false;
                    }

                    // Ensure DataGridView is read-only
                    //dataGridViewMedication.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error binding DataGridView: " + ex.Message);
            }
        }


        

       

        

        private void btnUndo_Click(object sender, EventArgs e)
        {
            using (conn = DatabaseTools.MakeConnection())
            {
                try
                {
                    // Undo changes in the database
                    DatabaseTools.Undo(conn);
                    MessageBox.Show("Changes undone successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error undoing changes: " + ex.Message);
                }

                // Reload to show the current state
                LoadGridView();
            }
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            DemographicsForm demo = new DemographicsForm(pid, name, age);
            demo.Show();
            this.Close();
        }

        private void btnGeneralMedHistory_Click(object sender, EventArgs e)
        {
           
        }

        private void btnViewAllergies_Click(object sender, EventArgs e)
        {
            Allergies allergyInfo = new Allergies(pid, name, age);
            allergyInfo.Show();
            this.Close();
        }

        private void btnViewFamily_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected in the DataGridView
                if (dataGridViewMedication.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.");
                    return;
                }

                // Get the FamilyID from the selected row
                int rowIndex = dataGridViewMedication.CurrentCell.RowIndex;
                int medicationID = Convert.ToInt32(dataGridViewMedication.Rows[rowIndex].Cells["MedicationID"].Value);

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
                        Data.MedicationTools.DeleteMedication(connection, medicationID);
                    }

                    MessageBox.Show("Record marked as deleted successfully.");
                    LoadGridView(); // Refresh the data grid view
                    LockScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting the record: " + ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ScreenMode = 2;
            UnlockScreen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ScreenMode = 1; // Set screen mode to Add
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

        private void dataGridViewMedication_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = dataGridViewMedication.CurrentCell.RowIndex;
            medicationID = Convert.ToInt32(dataGridViewMedication[0, rowIndex].Value);
            MessageBox.Show("You selected Medication ID: " + medicationID);

            txtMedication.Text = Convert.ToString(dataGridViewMedication[2, rowIndex].Value);
            txtAmount.Text = Convert.ToString(dataGridViewMedication[3, rowIndex].Value);
            txtUnit.Text = Convert.ToString(dataGridViewMedication[4, rowIndex].Value);
            txtInstructions.Text = Convert.ToString(dataGridViewMedication[5, rowIndex].Value);
            txtStartDate.Text = Convert.ToString(dataGridViewMedication[6, rowIndex].Value);
            txtEndDate.Text = Convert.ToString(dataGridViewMedication[7, rowIndex].Value);
            txtHCP.Text = Convert.ToString(dataGridViewMedication[8, rowIndex].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (conn = DatabaseTools.MakeConnection())
            {
                try
                {
                    if (ScreenMode == 1)
                    {
                        Data.MedicationTools.InsertMedication(conn, pid, txtMedication.Text, txtAmount.Text, txtUnit.Text, txtInstructions.Text, txtStartDate.Text, txtEndDate.Text, txtHCP.Text);
                        MessageBox.Show("Medication inserted");
                    }
                    else if (ScreenMode == 2)
                    {
                        Data.MedicationTools.UpdateMedication(conn, medicationID, pid, txtMedication.Text, txtAmount.Text, txtUnit.Text, txtInstructions.Text, txtStartDate.Text, txtEndDate.Text, txtHCP.Text);
                        MessageBox.Show("Allergy history updated");
                    }

                    else
                    {
                        MessageBox.Show("Invalid mode");
                    }

                    DatabaseTools.Save(conn); // Commit to the database
                    LockScreen(); // Switch back to default view mode
                    LoadGridView(); // Reload to show the new info
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUndo_Click_1(object sender, EventArgs e)
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

        private void btnView_Click_1(object sender, EventArgs e)
        {
            DemographicsForm demographicsForm = new DemographicsForm(pid, Name, age);
            demographicsForm.Show();
            this.Hide();
        }

        private void btnGeneralMedHistory_Click_1(object sender, EventArgs e)
        {
            GeneralHistoryForm generalHistoryForm = new GeneralHistoryForm(pid, Name, age);
            generalHistoryForm.Show();
            this.Hide();
        }

        private void btnPatientSelectForm_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }

        private void btnViewAllergies_Click_1(object sender, EventArgs e)
        {
            Allergies allergies = new Allergies(pid, Name, age);
            allergies.Show();
            this.Hide();
        }

        private void btnViewFamily_Click_1(object sender, EventArgs e)
        {
            FamilyHistoryForm familyHistoryForm = new FamilyHistoryForm(pid, Name, age);
            familyHistoryForm.Show();
            this.Hide();
        }
    }
}
