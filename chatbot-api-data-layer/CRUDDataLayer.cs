using ChatbotAPI.Model;
using System;
using System.Data.SqlClient;

namespace chatbot_api_data_layer
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
            return true;
        }
        public bool IsDataBaseExists(string database)
        {
            return true;
        }

    }
}
