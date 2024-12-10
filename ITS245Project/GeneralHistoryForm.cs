using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectV2;
using HealthcareForms;
using MySql.Data.MySqlClient;

namespace ITS245Project
{
    public partial class GeneralHistoryForm : Form
    {
        
        private int ScreenMode = 0; // 1 = Modify, 2 = Add
        DataTable dt;
        int pid;
        string name;
        int age;

        public GeneralHistoryForm(int PatientID, string fullName, int age)
        {
            InitializeComponent();
            pid = PatientID;
            name = fullName;
            this.age = age;
            this.Load += GeneralHistoryForm_Load;
        }

        private void GeneralHistoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LockScreen();
        }



        private void LoadData()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) // Use a fresh connection
                {
                    dt = dbUtil.GetMedHistoryByIDsp(connection, pid);  // Make sure the stored procedure uses 'pid'

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the provided patient ID.");
                        return;
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        txtPatientID.Text = row["PatientID"].ToString();
                        txtMaritalStatus.Text = row["MaritalStatus"].ToString();
                        txtEducation.Text = row["Education"].ToString();
                        txtBehavioralHistory.Text = row["BehavioralHistory"].ToString();
                        txtTobacco.Text = row["Tobacco"].ToString();
                        txtTobaccoQuantity.Text = row["TobaccoQuantity"].ToString();
                        txtTobaccoDuration.Text = row["TobaccoDuration"].ToString();
                        txtAlcohol.Text = row["Alcohol"].ToString();
                        txtNumberOfChildren.Text = row["NumberOfChildren"].ToString();
                        txtAlcoholDuration.Text = row["AlcoholDuration"].ToString();
                        txtAlcoholQuantity.Text = row["AlcoholQuantity"].ToString();
                        txtDrug.Text = row["Drug"].ToString();
                        txtDrugType.Text = row["DrugType"].ToString();
                        txtDrugDuration.Text = row["DrugDuration"].ToString();
                        txtDietary.Text = row["Dietary"].ToString();
                        txtBloodType.Text = row["BloodType"].ToString();
                        txtMedNotes.Text = row["MedicalHistoryNotes"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        public void LockScreen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.ReadOnly = true; 
                    txtBox.BackColor = Color.LightGray; 
                }
                else if (control is RichTextBox rtb)
                {
                    rtb.ReadOnly = true; 
                    rtb.BackColor = Color.LightGray; 
                }
            }
            btnSave.Enabled = false; 
            btnUndo.Enabled = false; 
            btnDelete.Enabled = false;
        }

        public void UnlockScreen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.ReadOnly = false; // Unlock the textbox
                    txtBox.BackColor = Color.White; // Set background to white
                }
                else if (control is RichTextBox rtb)
                {
                    rtb.ReadOnly = false; // Unlock the rich text box
                    rtb.BackColor = Color.White; // Set background to white
                }
            }
            btnSave.Enabled = true; // Enable Save button
            btnModify.Enabled = true; // Enable Modify button
            btnUndo.Enabled= true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ScreenMode = 2; // Set to Add mode
            UnlockScreen(); // Unlock the screen for editing

            // Clear all textboxes
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtBox)
                {
                    txtBox.Text = string.Empty;
                }
            }
        }
        private void btnModify_Click_1(object sender, EventArgs e)
        {
            ScreenMode = 1; // Set to Modify mode
            UnlockScreen(); // Unlock the screen for editing
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ScreenMode == 2)
            {
                SaveNewRecord(); // Save new record
            }
            else if (ScreenMode == 1)
            {
                UpdateExistingRecord(); // Update existing record
            }

            LockScreen(); // Lock the screen after saving
            ScreenMode = 0; // Reset to View mode
        }
        private void btnUndo_Click_1(object sender, EventArgs e)
        {
            LockScreen(); // Lock the screen
            ScreenMode = 0; // Reset to View mode
            LoadData(); // Reload data to undo changes
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteRecord();
                LockScreen(); // Lock the screen after deletion
                ScreenMode = 0; // Reset to View mode
            }
        }


        private void SaveNewRecord()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) // Ensure a fresh connection
                {
                    string query = "INSERT INTO generalmedicalhistory (PatientID,MaritalStatus, Education, BehavioralHistory, TobaccoQuantity, TobaccoDuration, Alcohol, NumberOfChildren, AlcoholDuration, AlcoholQuantity, Drug, DrugType, DrugDuration, Dietary, BloodType, MedicalHistoryNotes) " +
                                   "VALUES (@PatientID, @MaritalStatus, @Education, @BehavioralHistory, @TobaccoQuantity, @TobaccoDuration, @Alcohol, @NumberOfChildren, @AlcoholDuration, @AlcoholQuantity, @Drug, @DrugType, @DrugDuration, @Dietary, @BloodType, @MedicalHistoryNotes)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text);
                        cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                        cmd.Parameters.AddWithValue("@Education", txtEducation.Text);
                        cmd.Parameters.AddWithValue("@BehavioralHistory", txtBehavioralHistory.Text);
                        cmd.Parameters.AddWithValue("@TobaccoQuantity", txtTobaccoQuantity.Text);
                        cmd.Parameters.AddWithValue("@TobaccoDuration", txtTobaccoDuration.Text);
                        cmd.Parameters.AddWithValue("@Alcohol", txtAlcohol.Text);
                        cmd.Parameters.AddWithValue("@NumberOfChildren", txtNumberOfChildren.Text);
                        cmd.Parameters.AddWithValue("@AlcoholDuration", txtAlcoholDuration.Text);
                        cmd.Parameters.AddWithValue("@AlcoholQuantity", txtAlcoholQuantity.Text);
                        cmd.Parameters.AddWithValue("@Drug", txtDrug.Text);
                        cmd.Parameters.AddWithValue("@DrugType", txtDrugType.Text);
                        cmd.Parameters.AddWithValue("@DrugDuration", txtDrugDuration.Text);
                        cmd.Parameters.AddWithValue("@Dietary", txtDietary.Text);
                        cmd.Parameters.AddWithValue("@BloodType", txtBloodType.Text);
                        cmd.Parameters.AddWithValue("@MedicalHistoryNotes", txtMedNotes.Text);


                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record added successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding record: {ex.Message}");
            }
        }
        private void UpdateExistingRecord()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) // Ensure a fresh connection for each operation
                {
                    string query = "UPDATE generalmedicalhistory SET " +
                                   "MaritalStatus = @MaritalStatus, " +
                                   "Education = @Education, " +
                                   "BehavioralHistory = @BehavioralHistory, " +
                                   "TobaccoQuantity = @TobaccoQuantity, " +
                                   "TobaccoDuration = @TobaccoDuration, " +
                                   "Alcohol = @Alcohol, " +
                                   "NumberOfChildren = @NumberOfChildren, " +
                                   "AlcoholDuration = @AlcoholDuration, " +
                                   "AlcoholQuantity = @AlcoholQuantity, " +
                                   "Drug = @Drug, " +
                                   "DrugType = @DrugType, " +
                                   "DrugDuration = @DrugDuration, " +
                                   "Dietary = @Dietary, " +
                                   "BloodType = @BloodType " +
                                   "WHERE PatientID = @PatientID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters for the query
                        cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                        cmd.Parameters.AddWithValue("@Education", txtEducation.Text);
                        cmd.Parameters.AddWithValue("@BehavioralHistory", txtBehavioralHistory.Text);
                        cmd.Parameters.AddWithValue("@TobaccoQuantity", txtTobaccoQuantity.Text);
                        cmd.Parameters.AddWithValue("@TobaccoDuration", txtTobaccoDuration.Text);
                        cmd.Parameters.AddWithValue("@Alcohol", txtAlcohol.Text);
                        cmd.Parameters.AddWithValue("@NumberOfChildren", txtNumberOfChildren.Text);
                        cmd.Parameters.AddWithValue("@AlcoholDuration", txtAlcoholDuration.Text);
                        cmd.Parameters.AddWithValue("@AlcoholQuantity", txtAlcoholQuantity.Text);
                        cmd.Parameters.AddWithValue("@Drug", txtDrug.Text);
                        cmd.Parameters.AddWithValue("@DrugType", txtDrugType.Text);
                        cmd.Parameters.AddWithValue("@DrugDuration", txtDrugDuration.Text);
                        cmd.Parameters.AddWithValue("@Dietary", txtDietary.Text);
                        cmd.Parameters.AddWithValue("@BloodType", txtBloodType.Text);
                        cmd.Parameters.AddWithValue("@PatientID", pid); // Use the current PatientID

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}");
            }
        }
        private void DeleteRecord()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) 
                {
                    string query = "UPDATE generalmedicalhistory SET Deleted = 1 WHERE PatientID = @PatientID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", pid); 
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record marked as deleted successfully.");
                    }
                }

                
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking record as deleted: {ex.Message}");
            }
        }

        private void btnFamilyHistory_Click(object sender, EventArgs e)
        {
            FamilyHistoryForm familyHistoryForm = new FamilyHistoryForm(pid, Name, age);
            familyHistoryForm.Show();
            this.Hide();
            // familyHistoryForm.PatientID = this.pid;
            
        }

        private void btnDemographicsForm_Click(object sender, EventArgs e)
        {
            DemographicsForm demographicsForm = new DemographicsForm(pid, Name, age);
            demographicsForm.Show();
            this.Hide();
        }

        private void btnPatientSelectForm_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }

        private void btnAllergyHistory_Click(object sender, EventArgs e)
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