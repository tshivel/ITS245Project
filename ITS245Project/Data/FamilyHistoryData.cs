using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS245Project.Data
{
    public static class FamilyHistoryData
    {
      
        public static DataTable GetFamilyHistory(MySqlConnection conn, int pid)
        {
            
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand("GetFamilyHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@PID", pid);
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Retrieving Family History Using Stored Proc Within Data" +
                    "Error = " + ex.Message);
            }
            return dt;
        }
        public static void DeleteFamily(MySqlConnection conn, int familyID)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE FamilyHistory SET Deleted = 1 WHERE FamilyID = @familyID";
                cmd.Parameters.AddWithValue("@familyID", familyID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing delete!" + ex.Message);
            }
        }
        public static void InsertFamilyHistory(MySqlConnection conn, int pid, string fullName, string relation,
            int alive, int livesWithPatient, string majorDisorder)
        {
           
            MySqlCommand cmd = new MySqlCommand("InsertFamilyHistory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@fullName", fullName);
            cmd.Parameters.AddWithValue("@relation", relation);
            cmd.Parameters.AddWithValue("@alive", alive);
            cmd.Parameters.AddWithValue("@livesWithPatient", livesWithPatient);
            cmd.Parameters.AddWithValue("@majorDisorder", majorDisorder);
            cmd.ExecuteNonQuery();
        }
        public static void UpdateFamilyHistory(MySqlConnection connection, int familyID, string name, string relation, int alive, int livesWithPatient, string majorDisorder)
        {
            string query = "UPDATE FamilyHistory SET FullName = @FullName, Relation = @Relation, Alive = @Alive, LivesWithPatient = @LivesWithPatient, MajorDisorder = @MajorDisorder WHERE FamilyID = @FamilyID";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Relation", relation);
                cmd.Parameters.AddWithValue("@Alive", alive);
                cmd.Parameters.AddWithValue("@LivesWithPatient", livesWithPatient);
                cmd.Parameters.AddWithValue("@MajorDisorder", majorDisorder);
                cmd.Parameters.AddWithValue("@FamilyID", familyID);

                cmd.ExecuteNonQuery();
            }
        }
        internal static DataTable GetFamilyHistory(object conn, int pid)
        {
            throw new NotImplementedException();
        }
    }
}
