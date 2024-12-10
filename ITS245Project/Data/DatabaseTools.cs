using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace FinalProjectV2.Tools
{
    public static class DatabaseTools
    {
        public static MySqlConnection MakeConnection()
        {
            string connStr = "server=127.0.0.1; uid=root; pwd=password; database=patientdb";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static DataTable GetAllPatientsUsingSP(MySqlConnection conn)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("GetAllPatientsUsingSP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Retrieving All Patient Recs Using Stored Proc!\nError = {ex.Message}\n{ex.StackTrace}");
            }

            return dt;
        }


        public static void AddNewPatient(MySqlConnection conn, string lastname, string firstname, DateTime dob,
                                   string homeAddress, string homeCity, string homeState, string homeZip,
                                   string country, string ptHomePhone, string emailAddress)
        {
            try
            {
                // Define the query for inserting a new patient
                string query = @"INSERT INTO patientdemographics 
                        (PtLastName, PtFirstName, DOB, HomeAddress, HomeCity, HomeState, HomeZip, Country, PtHomePhone, EmailAddress, deleted) 
                        VALUES 
                        (@lastname, @firstname, @dob, @homeAddress, @homeCity, @homeState, @homeZip, @country, @ptHomePhone, @emailAddress, 0)";

                // Create a MySqlCommand object
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Add parameters to the query to prevent SQL injection
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@homeAddress", homeAddress);
                cmd.Parameters.AddWithValue("@homeCity", homeCity);
                cmd.Parameters.AddWithValue("@homeState", homeState);
                cmd.Parameters.AddWithValue("@homeZip", homeZip);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@ptHomePhone", ptHomePhone);
                cmd.Parameters.AddWithValue("@emailAddress", emailAddress);

                // Execute the query
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Display an error message in case of failure
                MessageBox.Show("Error while adding a new patient: " + ex.Message);
            }
        }

        public static void UpdatePatientDemographics(MySqlConnection connection, int patientID, string lastname, string firstname, DateTime dob,
                                             string homeAddress, string homeCity, string homeState, string homeZip,
                                             string country, string ptHomePhone, string emailAddress)
        {
            string query = @"UPDATE patientdemographics 
                     SET PtLastName = @lastname, 
                         PtFirstName = @firstname, 
                         DOB = @dob, 
                         HomeAddress = @homeAddress, 
                         HomeCity = @homeCity, 
                         HomeState = @homeState, 
                         HomeZip = @homeZip, 
                         Country = @country, 
                         PtHomePhone = @ptHomePhone, 
                         EmailAddress = @emailAddress 
                     WHERE PatientID = @patientID";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                // Add parameters to the query to prevent SQL injection
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@homeAddress", homeAddress);
                cmd.Parameters.AddWithValue("@homeCity", homeCity);
                cmd.Parameters.AddWithValue("@homeState", homeState);
                cmd.Parameters.AddWithValue("@homeZip", homeZip);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@ptHomePhone", ptHomePhone);
                cmd.Parameters.AddWithValue("@emailAddress", emailAddress);


                // Execute the query
                cmd.ExecuteNonQuery();
            }
        }



        public static void AutoCommitOff(MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SET autocommit=0";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting autocommit to 0!" + ex.Message);
            }
        }

        public static void Undo(MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "ROLLBACK";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing rollback!" + ex.Message);
            }
        }

        public static void Save(MySqlConnection conn)
        {
            try
            {
                // Commit the current transaction
                MySqlCommand cmd = new MySqlCommand("COMMIT", conn);
                cmd.ExecuteNonQuery();

                // Start a new transaction if needed
                // cmd.CommandText = "START TRANSACTION";
                // cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing commit: " + ex.Message);
            }
        }

        public static void Delete(MySqlConnection conn, int pid)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE SET deleted = 1 where PatientID = @pid";
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing delete!" + ex.Message);
            }
        }
    }
}

