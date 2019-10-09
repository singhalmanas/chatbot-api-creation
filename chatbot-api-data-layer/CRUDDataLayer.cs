using ChatbotAPI.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ChatbotApiDataLayer
{
    public class CRUDDataLayer
    {

        public string CreateUser(User user)
        {
            return string.Empty;
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
                myConn.Open();
                myCommand.ExecuteNonQuery();
          
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return true;
        }
        public bool IsDataBaseExists(string database)
        {
            return true;
        }

    }
}
