using ChatbotAPI.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ChatbotApiDataLayer
{
    public class CRUDDataLayer
    {
        string connectionString = "Data Source=chatbot-data.database.windows.net;User ID = chatbot-user; Password=Noida@144;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
         
        //string conStr = @"Server=sql-elastic-pool.database.windows.net;Integrated security=SSPI;database=";
        SqlConnection myConn = new SqlConnection();
        public bool IsUserTableExists(User user)
        {
            bool isExists = false;
            try
            {               
                connectionString =  connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select * from information_schema.tables where table_name =user"; 

                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            isExists= reader.HasRows;
                        }
                    }
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                return isExists;
            }
            return isExists;
        }

        public string CreateUserTable(User user)
        {
            string errorMessage = string.Empty;
            try
            {
                connectionString = connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "CREATE TABLE [User] (FirstName varchar(Max),SecondName varchar(Max),LastName varchar(Max),Address varchar(Max),EmailAddress varchar(Max),[DataBase] varchar(Max))";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            errorMessage = !reader.HasRows? "Unable to create table": errorMessage;
                        }
                    }
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return errorMessage;
        }

        public bool IsUserExists(User user)
        {
            bool isExists = false;
            try
            {
                connectionString = connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select * from users where userName ="+ user.UserName;

                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            isExists = reader.HasRows;
                        }
                    }
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                return isExists;
            }
            return isExists;
        }

        public string CreateUser(User user)
        {
            string errorMessage = string.Empty;
            try
            {
                connectionString = connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = string.Format("INSERT TABLE [User] (UserName,FirstName,SecondName,LastName,Address,EmailAddress,[DataBase]) Values ({0},{1},{2},{3},{4},{5},{6})", user.UserName, user.FirstName, user.SecondName, user.LastName, user.Address, user.EmailAddress, user.DataBaseName);
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            errorMessage = !reader.HasRows ? "Unable to insert data" : errorMessage;
                        }
                    }
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return errorMessage;
        }

        public string CreateProduct(Product product)
        {
            return string.Empty;
        }
        public string CreateDataBase(string database)
        {
            string result = "Unable to create Database";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "CREATE DATABASE " + database;
                    
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        cmd.CommandTimeout = 300;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            result = reader.HasRows? "DataBase Created": result;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public bool IsDataBaseExists(string database)
        {
            bool isExists = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "SELECT * FROM master.dbo.sysdatabases WHERE name ='" + database + "'";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            isExists = reader.HasRows;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return isExists;
            }
            return isExists;
        }

    }
}
