using Asit4U_API.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Asit4U_API.DataAccess
{
    public class DataHandler
    {
        private string connectionStringPrime;
        private SqlConnection connection;
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;

        public DataHandler(string connectionStrinP = "default")
        {
            connectionStringPrime = ConfigurationManager.ConnectionStrings[connectionStrinP].ConnectionString;
        }

        public User SelecUser(string username)
        {
            dataTable = new DataTable();
            User user = new User();
            try
            {
                connection = new SqlConnection(connectionStringPrime);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT User_ID, Username, Password FROM tblUsers WHERE Username = @Username";
        
                command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@Username", username));
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    user = new User
                    {
                        UserID = Convert.ToInt32(item["User_ID"]),
                        Username = item["Username"].ToString(),
                        Password = item["Password"].ToString()
                    };
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return user;
        }

        public List<User> SelecAllUser()
        {
            List<User> users = new List<User>();
            dataTable = new DataTable();

            try
            {
                connection = new SqlConnection(connectionStringPrime);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT User_ID, Username, Password FROM tblUsers ";

                command = new SqlCommand(query, connection);
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    User user = new User
                    {
                        UserID = Convert.ToInt32(item["User_ID"]),
                        Username = item["Username"].ToString(),
                        Password = item["Password"].ToString()
                    };
                    

                    users.Add(user);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return users;
        }

        public void InsertUser(User u)
        {
            try
            {
                connection = new SqlConnection(connectionStringPrime);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string sql = "INSERT INTO tblUsers(Username, Password) VALUES(@Username, @Password)";

                command = new SqlCommand(sql, connection);
           
                command.Parameters.Add(new SqlParameter("@Username", u.Username));
                command.Parameters.Add(new SqlParameter("@Password", u.Password));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}