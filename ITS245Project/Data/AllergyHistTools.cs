using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareForms.Data
{
    internal class AllergyHistoryTools
    {
        public static DataTable ShowAllergyHistory(MySqlConnection conn, int pid)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn == null)
                {
                    throw new ArgumentNullException(nameof(conn), "Connection object is null.");
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();  // Open the connection
                }

                string query = @"
                    SELECT *
                    FROM AllergyHistory
                    WHERE PatientID = @PID AND Deleted = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PID", pid);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);  // Fill the DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving allergy history! Error = " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();  // Ensure the connection is closed
                }
            }

            return dt;
        }




        public static void InsertAllergy(MySqlConnection conn, int allergyID, int pid, string allergen, string startDate,
            string endDate, string description)
        {
            MySqlCommand cmd = new MySqlCommand("InsertAllergy", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_AllergyID", allergyID);
            cmd.Parameters.AddWithValue("@p_PatientID", pid);
            cmd.Parameters.AddWithValue("@p_Allergen", allergen);
            cmd.Parameters.AddWithValue("@p_AllergyStartDate", startDate);
            cmd.Parameters.AddWithValue("@p_AllergyEndDate", endDate);
            cmd.Parameters.AddWithValue("@p_AllergyDescription", description);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateAllergy(MySqlConnection conn, int allergyID, int pid, string allergen, string startDate,
            string endDate, string description)
        {
            MySqlCommand cmd = new MySqlCommand("UpdateAllergy", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_AllergyID", allergyID);
            cmd.Parameters.AddWithValue("@p_PatientID", pid);
            cmd.Parameters.AddWithValue("@p_Allergen", allergen);
            cmd.Parameters.AddWithValue("@p_AllergyStartDate", startDate);
            cmd.Parameters.AddWithValue("@p_AllergyEndDate", endDate);
            cmd.Parameters.AddWithValue("@p_AllergyDescription", description);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAllergy(MySqlConnection conn, int allergyID)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE AllergyHistory SET Deleted = 1 WHERE AllergyID = @allergyID";
                cmd.Parameters.AddWithValue("@allergyID", allergyID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing delete!" + ex.Message);
            }
        }
    }
}
