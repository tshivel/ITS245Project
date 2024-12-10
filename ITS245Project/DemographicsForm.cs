using FinalProjectV2;
using Google.Protobuf.WellKnownTypes;
using ITS245Project;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HealthcareForms
{
    public partial class DemographicsForm : Form
    {
        private int ScreenMode = 0; // 1 = Modify, 2 = Add
        MySqlConnection conn;
        DataTable dt;
        int pid;
        string name;
        int age;


        public DemographicsForm(int patientID, string fullName, int age)
        {
            InitializeComponent();
            pid = patientID;
            name = fullName;
            this.age = age;
            this.Load += DemographicsForm_Load;
        }

        private void DemographicsForm_Load(object sender, EventArgs e)
        {
            LoadData();
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
                else if (control is DateTimePicker dtp)
                {
                    dtp.Enabled = false;  // Disable the DateTimePicker
                    dtp.CalendarMonthBackground = Color.LightGray;  // Set background color to light gray
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
                else if (control is DateTimePicker dtp)
                {
                    dtp.Enabled = true;  // Enable the DateTimePicker
                    dtp.CalendarMonthBackground = Color.White;  // Set background color to white
                }
            }

            // Enable Save, Undo, and Delete buttons
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            btnDelete.Enabled = true;
        }


        private void LoadData()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) // Ensure a fresh connection
                {
                    // Ensure the stored procedure or query uses 'pid' correctly
                    dt = Data.DemographicTools.ShowAllDemographics(connection, pid);  // Passing the correct connection here

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the provided patient ID.");
                        return;
                    }

                 

                    // Populate textboxes with the data from the first row (if applicable)
                    DataRow row = dt.Rows[0]; // Assuming you want to show the first row's data

                    // Ensure each textbox is populated with data from the row, checking for DBNull
                    txtComments.Text = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : string.Empty;
                    txtNextOfKin.Text = row["NextOfKinID"] != DBNull.Value ? row["NextOfKinID"].ToString() : string.Empty;
                    txtRelationship.Text = row["NextOfKinRelationshipToPatient"] != DBNull.Value ? row["NextOfKinRelationshipToPatient"].ToString() : string.Empty;
                    txtReferral.Text = row["Referral"] != DBNull.Value ? row["Referral"].ToString() : string.Empty;
                    txtHCP.Text = row["CurrentPrimaryHCPId"] != DBNull.Value ? row["CurrentPrimaryHCPId"].ToString() : string.Empty;
                    txtReligion.Text = row["Religion"] != DBNull.Value ? row["Religion"].ToString() : string.Empty;
                    txtCity.Text = row["HomeCity"] != DBNull.Value ? row["HomeCity"].ToString() : string.Empty;
                    txtGender.Text = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : string.Empty;
                    txtEthnicity.Text = row["EthnicAssociation"] != DBNull.Value ? row["EthnicAssociation"].ToString() : string.Empty;
                    txtCitizenship.Text = row["Citizenship"] != DBNull.Value ? row["Citizenship"].ToString() : string.Empty;
                    txtPhone.Text = row["PtHomePhone"] != DBNull.Value ? row["PtHomePhone"].ToString() : string.Empty;
                    txtEmergencyPhone.Text = row["EmergencyPhoneNumber"] != DBNull.Value ? row["EmergencyPhoneNumber"].ToString() : string.Empty;
                    txtEmail.Text = row["EmailAddress"] != DBNull.Value ? row["EmailAddress"].ToString() : string.Empty;
                    txtEmployment.Text = row["EmploymentStatus"] != DBNull.Value ? row["EmploymentStatus"].ToString() : string.Empty;
                    txtMaritalStatus.Text = row["MaritalStatus"] != DBNull.Value ? row["MaritalStatus"].ToString() : string.Empty;
                    txtSSN.Text = row["SSN"] != DBNull.Value ? row["SSN"].ToString() : string.Empty;
                    txtMiddleInitial.Text = row["PtMiddleInitial"] != DBNull.Value ? row["PtMiddleInitial"].ToString() : string.Empty;
                    txtSuffix.Text = row["Suffix"] != DBNull.Value ? row["Suffix"].ToString() : string.Empty;
                    txtAddress.Text = row["HomeAddress"] != DBNull.Value ? row["HomeAddress"].ToString() : string.Empty;
                    txtState.Text = row["HomeState"] != DBNull.Value ? row["HomeState"].ToString() : string.Empty;
                    txtZip.Text = row["HomeZip"] != DBNull.Value ? row["HomeZip"].ToString() : string.Empty;
                    txtCountry.Text = row["Country"] != DBNull.Value ? row["Country"].ToString() : string.Empty;
                    txtFirstname.Text = row["PtFirstName"] != DBNull.Value ? row["PtFirstName"].ToString() : string.Empty;
                    txtPreviousLastname.Text = row["PtLastName"] != DBNull.Value ? row["PtPreviousLastName"].ToString() : string.Empty;
                    txtLastname.Text = row["PtLastName"] != DBNull.Value ? row["PtLastName"].ToString() : string.Empty;
                    txtMRNumber.Text = row["HospitalMR"] != DBNull.Value ? row["HospitalMR"].ToString() : string.Empty;

                    // DatePickers - Ensure DBNull handling for dates
                    if (row["DOB"] != DBNull.Value)
                        dateTimePicker1.Value = Convert.ToDateTime(row["DOB"]);
                    if (row["DateofExpire"] != DBNull.Value)
                        dateTimePicker2.Value = Convert.ToDateTime(row["DateofExpire"]);
                    if (row["DateEntered"] != DBNull.Value)
                        dateTimePicker3.Value = Convert.ToDateTime(row["DateEntered"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void SaveNewRecord()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) 
                {
                    string query = "INSERT INTO patientdemographics " +
                                   "(HospitalMR, PtLastName, PtPreviousLastName, PtFirstName, PtMiddleInitial, Suffix, " +
                                   "HomeAddress, HomeCity, HomeState, HomeZip, Country, Citizenship, PtHomePhone, EmergencyPhoneNumber, " +
                                   "EmailAddress, SSN, DOB, Gender, EthnicAssociation, Religion, MaritalStatus, EmploymentStatus, " +
                                   "DateofExpire, Referral, CurrentPrimaryHCPId, Comments, DateEntered, NextOfKinID, " +
                                   "NextOfKinRelationshipToPatient, deleted) " +
                                   "VALUES " +
                                   "(@HospitalMR, @PtLastName, @PtPreviousLastName, @PtFirstName, @PtMiddleInitial, @Suffix, " +
                                   "@HomeAddress, @HomeCity, @HomeState, @HomeZip, @Country, @Citizenship, @PtHomePhone, @EmergencyPhoneNumber, " +
                                   "@EmailAddress, @SSN, @DOB, @Gender, @EthnicAssociation, @Religion, @MaritalStatus, @EmploymentStatus, " +
                                   "@DateofExpire, @Referral, @CurrentPrimaryHCPId, @Comments, @DateEntered, @NextOfKinID, " +
                                   "@NextOfKinRelationshipToPatient, @deleted)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters for all fields from the form controls
                        cmd.Parameters.AddWithValue("@HospitalMR", txtMRNumber.Text);
                        cmd.Parameters.AddWithValue("@PtLastName", txtLastname.Text);
                        cmd.Parameters.AddWithValue("@PtPreviousLastName", txtPreviousLastname.Text);
                        cmd.Parameters.AddWithValue("@PtFirstName", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@PtMiddleInitial", txtMiddleInitial.Text);
                        cmd.Parameters.AddWithValue("@Suffix", txtSuffix.Text);
                        cmd.Parameters.AddWithValue("@HomeAddress", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@HomeCity", txtCity.Text);
                        cmd.Parameters.AddWithValue("@HomeState", txtState.Text);
                        cmd.Parameters.AddWithValue("@HomeZip", txtZip.Text);
                        cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                        cmd.Parameters.AddWithValue("@Citizenship", txtCitizenship.Text);
                        cmd.Parameters.AddWithValue("@PtHomePhone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@EmergencyPhoneNumber", txtEmergencyPhone.Text);
                        cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);

                        // Set DateTime fields from DateTimePickers
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value); // Assuming this is the Date of Birth
                        cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                        cmd.Parameters.AddWithValue("@EthnicAssociation", txtEthnicity.Text);
                        cmd.Parameters.AddWithValue("@Religion", txtReligion.Text);
                        cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                        cmd.Parameters.AddWithValue("@EmploymentStatus", txtEmployment.Text);

                        // Set Expiry Date from DateTimePicker (if applicable)
                        cmd.Parameters.AddWithValue("@DateofExpire", dateTimePicker2.Value); // Assuming this is the Date of Expiry (e.g., Date of Admission)

                        // Other fields
                        cmd.Parameters.AddWithValue("@Referral", txtReferral.Text);
                        cmd.Parameters.AddWithValue("@CurrentPrimaryHCPId", txtHCP.Text);
                        cmd.Parameters.AddWithValue("@Comments", txtComments.Text);
                        cmd.Parameters.AddWithValue("@DateEntered", DateTime.Now); // Automatically set current date and time
                        cmd.Parameters.AddWithValue("@NextOfKinID", txtNextOfKin.Text);
                        cmd.Parameters.AddWithValue("@NextOfKinRelationshipToPatient", txtRelationship.Text);

                        // Assuming 'deleted' field is a boolean (defaulting to 0, meaning not deleted)
                        cmd.Parameters.AddWithValue("@deleted", 0);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New record inserted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting record: {ex.Message}");
            }
        }

        private void UpdateExistingRecord()
        {
            try
            {
                using (var connection = dbUtil.MakeConnection()) // Ensure a fresh connection
                {
                    string query = "UPDATE patientdemographics SET " +
                                   "HospitalMR = @HospitalMR, " +
                                   "PtLastName = @PtLastName, " +
                                   "PtPreviousLastName = @PtPreviousLastName, " +
                                   "PtFirstName = @PtFirstName, " +
                                   "PtMiddleInitial = @PtMiddleInitial, " +
                                   "Suffix = @Suffix, " +
                                   "HomeAddress = @HomeAddress, " +
                                   "HomeCity = @HomeCity, " +
                                   "HomeState = @HomeState, " +
                                   "HomeZip = @HomeZip, " +
                                   "Country = @Country, " +
                                   "Citizenship = @Citizenship, " +
                                   "PtHomePhone = @PtHomePhone, " +
                                   "EmergencyPhoneNumber = @EmergencyPhoneNumber, " +
                                   "EmailAddress = @EmailAddress, " +
                                   "SSN = @SSN, " +
                                   "DOB = @DOB, " +
                                   "Gender = @Gender, " +
                                   "EthnicAssociation = @EthnicAssociation, " +
                                   "Religion = @Religion, " +
                                   "MaritalStatus = @MaritalStatus, " +
                                   "EmploymentStatus = @EmploymentStatus, " +
                                   "DateofExpire = @DateofExpire, " +
                                   "Referral = @Referral, " +
                                   "CurrentPrimaryHCPId = @CurrentPrimaryHCPId, " +
                                   "Comments = @Comments, " +
                                   "DateEntered = @DateEntered, " +
                                   "NextOfKinID = @NextOfKinID, " +
                                   "NextOfKinRelationshipToPatient = @NextOfKinRelationshipToPatient, " +
                                   "deleted = @deleted " +
                                   "WHERE PatientID = @PatientID";  // Update condition based on PatientID

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters for all fields from the form controls
                        cmd.Parameters.AddWithValue("@HospitalMR", txtMRNumber.Text);
                        cmd.Parameters.AddWithValue("@PtLastName", txtLastname.Text);
                        cmd.Parameters.AddWithValue("@PtPreviousLastName", txtPreviousLastname.Text);
                        cmd.Parameters.AddWithValue("@PtFirstName", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@PtMiddleInitial", txtMiddleInitial.Text);
                        cmd.Parameters.AddWithValue("@Suffix", txtSuffix.Text);
                        cmd.Parameters.AddWithValue("@HomeAddress", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@HomeCity", txtCity.Text);
                        cmd.Parameters.AddWithValue("@HomeState", txtState.Text);
                        cmd.Parameters.AddWithValue("@HomeZip", txtZip.Text);
                        cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                        cmd.Parameters.AddWithValue("@Citizenship", txtCitizenship.Text);
                        cmd.Parameters.AddWithValue("@PtHomePhone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@EmergencyPhoneNumber", txtEmergencyPhone.Text);
                        cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);

                        // Set DateTime fields from DateTimePickers
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value); // Assuming this is the Date of Birth
                        cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                        cmd.Parameters.AddWithValue("@EthnicAssociation", txtEthnicity.Text);
                        cmd.Parameters.AddWithValue("@Religion", txtReligion.Text);
                        cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                        cmd.Parameters.AddWithValue("@EmploymentStatus", txtEmployment.Text);

                        // Set Expiry Date from DateTimePicker (if applicable)
                        cmd.Parameters.AddWithValue("@DateofExpire", dateTimePicker2.Value); // Assuming this is the Date of Expiry (e.g., Date of Admission)

                        // Other fields
                        cmd.Parameters.AddWithValue("@Referral", txtReferral.Text);
                        cmd.Parameters.AddWithValue("@CurrentPrimaryHCPId", txtHCP.Text);
                        cmd.Parameters.AddWithValue("@Comments", txtComments.Text);
                        cmd.Parameters.AddWithValue("@DateEntered", DateTime.Now); // Automatically set current date and time
                        cmd.Parameters.AddWithValue("@NextOfKinID", txtNextOfKin.Text);
                        cmd.Parameters.AddWithValue("@NextOfKinRelationshipToPatient", txtRelationship.Text);

                        // Assuming 'deleted' field is a boolean (defaulting to 0, meaning not deleted)
                        cmd.Parameters.AddWithValue("@deleted", 0);

                        // Add the PatientID (you must already have the PatientID for the update operation)
                        cmd.Parameters.AddWithValue("@PatientID", pid);

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


        public static void DeletePatient(MySqlConnection conn, int patientID)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open(); // Open the connection if it's not already open
                }

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandText = "UPDATE patientdemographics SET deleted = 1 WHERE PatientID = @patientID"
                };
                cmd.Parameters.AddWithValue("@patientID", patientID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing delete! " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close(); // Close the connection to ensure cleanup
                }
            }
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

        private void btnModify_Click(object sender, EventArgs e)
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

            LoadData();
            LockScreen();
        }

        private void btnPatientSelect_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            LockScreen(); // Lock the screen
            ScreenMode = 0; // Reset to View mode
            LoadData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbUtil.MakeConnection())
                    {
                        DeletePatient(conn, pid); 
                        MessageBox.Show("Record marked as deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Allergies allergies = new Allergies(pid, Name, age);
            allergies.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GeneralHistoryForm generalHistoryForm = new GeneralHistoryForm(pid, Name, age);
            generalHistoryForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FamilyHistoryForm familyHistoryForm = new FamilyHistoryForm(pid, Name, age);
            familyHistoryForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Medication medication = new Medication(pid, Name, age);
            medication.Show();
            this.Hide();
        }

        private void btnSelectionForm_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            selectionForm.Show();
            this.Hide();
        }
    }
}
