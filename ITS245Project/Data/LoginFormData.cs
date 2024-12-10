using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS245Project.Data
{
    public static class LoginFormData
    {
        private static string connectionString = "server=127.0.0.1;uid=root;pwd=password;database=patientdb;";

        public static bool AuthenticateUser(string userName, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if user exists with Active = 1
                    string checkActiveQuery = @"
                        SELECT Active 
                        FROM Login 
                        WHERE UserName = @username 
                          AND Password = @password 
                          AND deleted = 0";

                    using (MySqlCommand command = new MySqlCommand(checkActiveQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", userName);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) == 1)
                        {
                            // User is already active; authentication successful
                            return true;
                        }
                    }

                    // If user is not active, activate and authenticate
                    string activateUserQuery = @"
                        UPDATE Login 
                        SET Active = 1 
                        WHERE UserName = @username 
                          AND Password = @password 
                          AND deleted = 0";

                    using (MySqlCommand command = new MySqlCommand(activateUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", userName);
                        command.Parameters.AddWithValue("@password", password);

                        int rowsAffected = command.ExecuteNonQuery();

                        // If the update was successful, authenticate the user
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error during user authentication.", ex);
            }
        }

        public static void LogoutUser(string userName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        UPDATE Login 
                        SET Active = 0 
                        WHERE UserName = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", userName);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error during logout.", ex);
            }
        }
    }
}
