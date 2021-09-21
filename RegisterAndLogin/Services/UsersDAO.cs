using RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLogin.Services
{
    public class UsersDAO
    {                                              //Lokal database               //Navn på database     //Anvender sikkerhed       
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = TestDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
        public bool AddUser(UserModel user)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO dbo.Users (username, password) VALUES (@username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    int reader = command.ExecuteNonQuery();

                    if (reader > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}
