using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ITS245Project
{
    public static class dbUtil
    {
      
        public static MySqlConnection MakeConnection()
        {
            string connStr = "server=127.0.0.1; uid=root; pwd=password; database=patientdb";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn; // Return the connection without opening it
        }

        public static DataTable GetMedHistoryByIDsp(MySqlConnection conn, int pid)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cmd = new MySqlCommand("GetMedHistoryByIDsp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid", pid);
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Retrieve All Patients Error: " +
                    ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return dt;
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
    }
}