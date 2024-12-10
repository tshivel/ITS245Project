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
    internal class MedicationTools
    {
        public static DataTable ShowMedications(MySqlConnection conn, int pid)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand("ShowMedications", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@PID", pid);
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Retrieving Medications Using Stored Proc Within Tools!" +
                    "Error = " + ex.Message);
            }
            return dt;
        }

        public static void InsertMedication(MySqlConnection conn, int pid, string medication, string amount,
            string unit, string instructions, string startDate, string endDate, string HCP)
        {
            MySqlCommand cmd = new MySqlCommand("InsertMedication", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("p_Medication", medication);
            cmd.Parameters.AddWithValue("@p_MedicationAmt", amount);
            cmd.Parameters.AddWithValue("@p_MedicationUnit", unit);
            cmd.Parameters.AddWithValue("@p_Instructions", instructions);
            cmd.Parameters.AddWithValue("@p_MedicationStartDate", startDate);
            cmd.Parameters.AddWithValue("@p_MedicationEndDate", endDate);
            cmd.Parameters.AddWithValue("@p_PrescriptionHCP", HCP);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateMedication(MySqlConnection conn, int medicationID, int pid, string medication, string amount,
            string unit, string instructions, string startDate, string endDate, string HCP)
        {
            MySqlCommand cmd = new MySqlCommand("UpdateMedication", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@medicationID", medicationID);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@p_Medication", medication);
            cmd.Parameters.AddWithValue("@p_MedicationAmt", amount);
            cmd.Parameters.AddWithValue("@p_MedicationUnit", unit);
            cmd.Parameters.AddWithValue("@p_Instructions", instructions);
            cmd.Parameters.AddWithValue("@p_MedicationStartDate", startDate);
            cmd.Parameters.AddWithValue("@p_MedicationEndDate", endDate);
            cmd.Parameters.AddWithValue("@p_PrescriptionHCP", HCP);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteMedication(MySqlConnection conn, int medicationID)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE patientmedications SET Deleted = 1 WHERE MedicationID = @medicationID";
                cmd.Parameters.AddWithValue("@medicationID", medicationID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing delete!" + ex.Message);
            }
        }
    }
}
