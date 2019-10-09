using chatbot_api_data_layer;
using ChatbotAPI;
using ChatbotAPI.Model;
using System;

namespace chatbot_api_business_layer
{
    public class CRUD
    {   
        public string CreateUser(User user)
        {
            CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
            return cRUDDataLayer.CreateUser(user);
        }

        public string CreateProduct(Product product)
        {
            CRUDDataLayer cRUDDataLayer = new CRUDDataLayer();
            return cRUDDataLayer.CreateProduct(product);
        }
    }
}
