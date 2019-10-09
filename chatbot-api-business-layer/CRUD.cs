using ChatbotApiDataLayer;
using ChatbotAPI;
using ChatbotAPI.Model;

namespace ChatbotApiBusinessLayer
{
    public class CRUD
    {
        CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
        public string CreateUser(User user)
        {
            if (IsUserExists(user))
                return "User Already Exists";
       
            return cRUDDataLayer.CreateUser(user);
           
        }
        public bool IsUserExists(User user)
        {
            return cRUDDataLayer.IsUserExists(user);
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
                return cRUDDataLayer.CreateDataBase(database);
            }
            return false;
        }

        public bool IsDatabaseExists(string database)
        {
            return cRUDDataLayer.IsDataBaseExists(database);
        }
    }
}
