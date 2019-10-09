using ChatbotApiDataLayer;
using ChatbotAPI;
using ChatbotAPI.Model;
using System;
using System.Collections.Generic;

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

        public List<object> GetProduct(string id)
        {
            return cRUDDataLayer.GetProduct(id);
        }

        private bool IsUserExistsForStore(string username,string storename,string storetype)
        {
            return cRUDDataLayer.IsUserExistsForStore(username,storename,storetype);
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

        public string CheckAndCreateUserAndStore(string username,string storename,string storetype)
        {
            if (IsUserExistsForStore(username, storename, storetype))
                return "User already Exists for this Store";
            else if (IsDatabaseExists(storename))
                return "Store already Exists with this name";
            int storetypeId = cRUDDataLayer.GetStoreId(storetype);
            string message = cRUDDataLayer.EnterUserNameforDatabase(username, storetypeId, storename);
            message += cRUDDataLayer.CreateDataBase(storename);
            return message;
        }

        public bool IsDatabaseExists(string database)
        {
            return cRUDDataLayer.IsDataBaseExists(database);
        }
    }
}
