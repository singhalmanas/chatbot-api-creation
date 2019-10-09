using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotApiDataLayer
{
    public class MasterDataLayer
    {
        string connectionString = "Data Source=chatbot-data.database.windows.net;User ID = chatbot-user; Password=Noida@144;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=chatbot-master";
        public async Task<string[]> GetStoreType()
        {
            try
            {
                List<string> storetypes = new List<string>(2);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    var commandStr = "select distinct storename from StoreType";
                    using (SqlCommand cmd = new SqlCommand(commandStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.HasRows)
                            {
                                storetypes.Add(reader["storename"].ToString());
                            }
                        }
                    }
                    con.Close();
                }
                return storetypes.ToArray();
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }
    }
}
