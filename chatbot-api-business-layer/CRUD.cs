using ChatbotApiDataLayer;
using ChatbotAPI;
using ChatbotAPI.Model;
using System;

namespace ChatbotApiBusinessLayer
{
    public class CRUD
    {
        CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
        public string CreateUser(User user)
        {
            string response = string.Empty;
            if (!IsUserTableExists(user))
                response = cRUDDataLayer.CreateUserTable(user);

            if(string.IsNullOrEmpty(response))
            {
                if (IsUserExists(user))
                    response = "User Already Exists";
                else
                    response = cRUDDataLayer.CreateUser(user);
            }

            return string.IsNullOrEmpty(response) ? "User Created" : string.Empty;
            
        }

        private bool IsUserExists(User user)
        {
            return cRUDDataLayer.IsUserExists(user);
        }

        public bool IsUserTableExists(User user)
        {
            return cRUDDataLayer.IsUserTableExists(user);
        }
        public string CreateProduct(Product product)
        {
            CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
            return cRUDDataLayer.CreateProduct(product);
        }

        public string CreateDatabase(string database)
        {
            if (IsDatabaseExists(database))
                return "DataBase already Exists";

            return cRUDDataLayer.CreateDataBase(database);
        }

        public bool IsDatabaseExists(string database)
        {
            return cRUDDataLayer.IsDataBaseExists(database);
        }
    }
}
