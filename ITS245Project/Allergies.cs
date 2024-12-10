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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using FinalProjectV2.Tools;
using HealthcareForms.Data;
using ITS245Project;
using FinalProjectV2;

namespace HealthcareForms
{
    public partial class Allergies : Form
    {
        MySqlConnection conn;
        DataTable dt;
        string name;
        int age;
        int pid;
        int allergyID;
        int deleted;
        private int ScreenMode = 0; // 1 = Modify, 2 = Add


        public Allergies(int PatientID, string fullName, int age)
        {
            InitializeComponent();
            pid = PatientID;
            name = fullName;
            this.age = age;
            this.Load += Allergies_Load;
        }

        public Allergies()
        {

        }
        private void Allergies_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridView();
                LockScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during form load: " + ex.Message);
            }

        }
        private void LoadGridView()
        {
            try
            {
                using (var connection = DatabaseTools.MakeConnection())
                {
                    DataTable dt = AllergyHistoryTools.ShowAllergyHistory(connection, pid);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No records found.");
                        return;
                    }

                    // Bind to DataGridView
                    dataGridViewAllergyHistory.DataSource = dt;

                    // Hide unnecessary columns
                    if (dataGridViewAllergyHistory.Columns.Contains("PatientID"))
                    {
                        dataGridViewAllergyHistory.Columns["PatientID"].Visible = false;
                    }
                    if (dataGridViewAllergyHistory.Columns.Contains("AllergyID"))
                    {
                        dataGridViewAllergyHistory.Columns["AllergyID"].Visible = false;
                    }
                    if (dataGridViewAllergyHistory.Columns.Contains("deleted"))
                    {
                        dataGridViewAllergyHistory.Columns["deleted"].Visible = false;
                    }
                    // Ensure DataGridView is read-only
                    //dataGridView1.ReadOnly = true;
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

     

      

        private void btnViewMedications_Click(object sender, EventArgs e)
        {

        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            UnlockScreen();
            ScreenMode = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected in the DataGridView
                if (dataGridViewAllergyHistory.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.");
                    return;
                }

                // Get the FamilyID from the selected row
                int rowIndex = dataGridViewAllergyHistory.CurrentCell.RowIndex;
                int allergyID = Convert.ToInt32(dataGridViewAllergyHistory.Rows[rowIndex].Cells["AllergyID"].Value);

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
                        Data.AllergyHistoryTools.DeleteAllergy(connection, allergyID);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (conn = DatabaseTools.MakeConnection())
            {
                try
                {
                    if (ScreenMode == 1)
                    {
                        Data.AllergyHistoryTools.InsertAllergy(conn, allergyID, pid, txtAllergen.Text,
                            txtStartDate.Text, txtEndDate.Text, txtDescription.Text);
                        MessageBox.Show("Allergy history inserted");
                    }
                    else if (ScreenMode == 2)
                    {
                        Data.AllergyHistoryTools.UpdateAllergy(conn, allergyID, pid, txtAllergen.Text,
                            txtStartDate.Text, txtEndDate.Text, txtDescription.Text);
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

        private void dataGridViewAllergyHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Retrieve the selected row's data
                    DataGridViewRow selectedRow = dataGridViewAllergyHistory.Rows[e.RowIndex];

                    // Assign the AllergyID to the class-level variable
                    allergyID = Convert.ToInt32(selectedRow.Cells["AllergyID"].Value);

                    // Populate the form controls with the selected row's data
                  
                    txtAllergen.Text = selectedRow.Cells["Allergen"]?.Value?.ToString();
                    txtStartDate.Text = selectedRow.Cells["AllergyStartDate"]?.Value?.ToString();
                    txtEndDate.Text = selectedRow.Cells["AllergyEndDate"]?.Value?.ToString();
                    txtDescription.Text = selectedRow.Cells["AllergyDescription"]?.Value?.ToString();

                    // Optional: handle the 'Deleted' column if needed
                    // deleted = Convert.ToInt32(selectedRow.Cells["Deleted"].Value);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting row: " + ex.Message);
                }
            }
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

        private void btnViewFamily_Click_1(object sender, EventArgs e)
        {
            FamilyHistoryForm familyHistoryForm = new FamilyHistoryForm(pid, Name, age);
            familyHistoryForm.Show();
            this.Hide();
        }

        private void btnSelectionForm_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }

        private void btnAllergiesForm_Click(object sender, EventArgs e)
        {
            Allergies allergies = new Allergies(pid, Name, age);
            allergies.Show();
            this.Hide();
        }

        private void btnViewMedications_Click_1(object sender, EventArgs e)
        {
            Medication medication = new Medication(pid, Name, age);
            medication.Show();
            this.Hide();
        }
    }
}
