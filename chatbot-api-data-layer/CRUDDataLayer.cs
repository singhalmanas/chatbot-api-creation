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
        public bool IsUserExists(User user)
        {
            bool isExists = false;
            try
            {               
                connectionString =  connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select 1 from User";
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

        public string CreateUser(User user)
        {
            string result = "Unable to create user";
            try
            {
                connectionString = connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "CREATE TABLE User(FirstName varchar(Max),SecondName varchar(Max),LastName varchar(Max),Address varchar(Max),EmailAddress varchar(Max),DataBase varchar(Max)";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            result = reader.HasRows? "User Created": result;
                        }
                    }
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
        public string CreateProduct(Product product)
        {
            return string.Empty;
        }
        public bool CreateDataBase(string database)
        {

            String str;
            SqlConnection myConn = new SqlConnection("Server=sql-elastic-pool.database.windows.net;User Id=manas1991;Password =String@201301;");

            str = "CREATE DATABASE " + database;
            //    " ON PRIMARY " +
            //"(NAME = " + database + "_Data, " +
            //"FILENAME = 'C:\\" + database + ".mdf', " +
            //"SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            //"LOG ON (NAME = " + database + "_Log, " +
            //"FILENAME = 'C:\\" + database + "Log.ldf', " +
            //"SIZE = 1MB, " +
            //"MAXSIZE = 5MB, " +
            //"FILEGROWTH = 10%)"
          

            SqlCommand myCommand = new SqlCommand(str, myConn);
            myCommand.CommandTimeout = 200;
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
