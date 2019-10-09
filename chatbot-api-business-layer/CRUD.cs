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
        private bool IsUserExists(User user)
        {
            return cRUDDataLayer.IsUserExists(user);
        }

        private bool IsUserExistsForStore(string username,string storename,string storetype)
        {
            return cRUDDataLayer.IsUserExistsForStore(username,storename,storetype);
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
