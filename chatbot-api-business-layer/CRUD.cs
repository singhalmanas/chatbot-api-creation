using chatbot_api_data_layer;
using ChatbotAPI.Model;

namespace chatbot_api_business_layer
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
            return cRUDDataLayer.IsDataBaseExists(database);
        }
    }
}
