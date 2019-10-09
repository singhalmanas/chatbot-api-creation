using ChatbotApiDataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotApiBusinessLayer
{
    public class MasterBusinessLayer
    {
        MasterDataLayer dataLayer;
        public MasterBusinessLayer()
        {
            dataLayer = new MasterDataLayer();
        }
        public async Task<string[]> GetStoreType()
        {
            return await dataLayer.GetStoreType();
        }
    }
}
