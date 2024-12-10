using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS245Project.Data
{
    internal class DemographicsData
    {
        internal class DemographicTools
        {
            public static DataTable ShowAllDemographics(MySqlConnection conn, int pid)
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                try
                {
                    MySqlCommand cmd = new MySqlCommand("ShowPatientDemographicsUsingPID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    cmd.Parameters.AddWithValue("@PID", pid);
                    da.Fill(dt);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Retrieving Patient Demographics Using Stored Proc!" +
                        "Error = " + ex.Message);
                }
                return dt;
            }
            public static void UpdateDemographics(MySqlConnection conn, int pid, string mrNum, string lastname, string prevlastname, string firstname,
                string initial, string suffix, string address, string city, string state, string zip, string country, string citizenship, string phone,
                string emergencyphone, string email, string ssn, DateTime dob, string gender, string ethnicity, string religion, string married,
                string employed, DateTime dateofexpire, string referral, string hcp, string comments, DateTime dateentered, string nextofkin,
                string relationship)
            {
                MySqlCommand cmd = new MySqlCommand("Demographics", conn); //CHANGE THIS BACK IF IT BREAKS
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@MRnumber", mrNum);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@previouslastname", prevlastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@initial", initial);
                cmd.Parameters.AddWithValue("@in_suffix", suffix);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@zip", zip);
                cmd.Parameters.AddWithValue("@in_country", country);
                cmd.Parameters.AddWithValue("@in_citizenship", citizenship);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@emergencyphone", emergencyphone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@in_ssn", ssn);
                cmd.Parameters.AddWithValue("@in_dob", dob);
                cmd.Parameters.AddWithValue("@in_gender", gender);
                cmd.Parameters.AddWithValue("@ethnicity", ethnicity);
                cmd.Parameters.AddWithValue("@in_religion", religion);
                cmd.Parameters.AddWithValue("@married", married);
                cmd.Parameters.AddWithValue("@employed", employed);
                cmd.Parameters.AddWithValue("@in_dateofexpire", dateofexpire);
                cmd.Parameters.AddWithValue("@in_referral", referral);
                cmd.Parameters.AddWithValue("@hcp", hcp);
                cmd.Parameters.AddWithValue("@in_comments", comments);
                cmd.Parameters.AddWithValue("@in_dateentered", dateentered);
                cmd.Parameters.AddWithValue("@nextofkin", nextofkin);
                cmd.Parameters.AddWithValue("@nextofkinrelationship", relationship);
                cmd.ExecuteNonQuery();
            }

            public static void DeleteDemographics(MySqlConnection conn, int pid)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    //conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE patientdemographics SET Deleted = 1 WHERE patientID = @patientID";
                    cmd.Parameters.AddWithValue("@patientID", pid);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error performing delete!" + ex.Message);
                }
            }
        }
    }
}
