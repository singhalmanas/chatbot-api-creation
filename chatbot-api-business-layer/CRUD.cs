﻿using ChatbotApiDataLayer;
using ChatbotAPI;
using ChatbotAPI.Model;

namespace ChatbotApiBusinessLayer
{
    public class CRUD
    {
        CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
        public string CreateUser(User user)
        {
            return cRUDDataLayer.CreateUser(user);
        }

        public string CreateProduct(Product product)
        {
            CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
            return cRUDDataLayer.CreateProduct(product);
        }

        public bool CreateDatabase(string database)
        {
            if (!IsDatabaseExists(database))
            {
                CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
                return cRUDDataLayer.CreateDataBase(database);
            }
            return false;

        }

        public bool IsDatabaseExists(string database)
        {
            return false;
        }
    }
}
