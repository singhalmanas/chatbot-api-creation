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
                connectionString = connectionString + ";database=" + user.DataBaseName;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select * from information_schema.tables where table_name =user";

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

        public int GetStoreId(string storetype)
        {
            try
            {
                int storeTypeId = -1;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select StoreId from StoreType where storename='" + storetype + "'";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    storeTypeId= Convert.ToInt32(reader["StoreId"]);
                                }
                            }
                        }
                    }
                    con.Close();
                }
                return storeTypeId;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public string EnterUserNameforDatabase(string username, int storetype, string storename)
        {
            try
            {

                connectionString = connectionString + ";database=chatbot-master";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "INSERT INTO companyinfo (DBName,Uname,StoreTypeId) VALUES ('" + storename + "','" + username + "'," + storetype + ")";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        var result = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return "";
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        public bool IsUserExistsForStore(string username, string storename, string storetype)
        {
            bool isExists = false;
            try
            {
                connectionString = connectionString + ";database=chatbot-master";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var commandStr = "select * from companyinfo cf join storetype st on cf.storetypeid=st.storetypeid where dbname='" + storename + "' and username='" + username + "' and storetype='" + storetype + "'";
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
                        cmd.ExecuteNonQuery();
                        result = "DataBase Created";
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
                    var commandStr = "SELECT * FROM companyInfo WHERE DBName ='" + database + "'";
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
