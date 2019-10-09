using ChatbotApiDataLayer;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotApiBusinessLayer
{
    public class AzureTableBusinessLayer
    {
        AzureTableDataAccess tableAccess;
        public AzureTableBusinessLayer()
        {
            tableAccess = new AzureTableDataAccess();
        }
        public async Task RunSamples(List<ProductEntity> productEntity,string database)
        {
            string tableName = database+ ".product";
            
            // Create or reference an existing table
            CloudTable table = await AzureTableDataAccess.CreateTableAsync(tableName);

            try
            {
                // Demonstrate basic CRUD functionality 
                await BasicDataOperationsAsync(table,productEntity);
            }
            finally
            {
                // Delete the table
                // await table.DeleteIfExistsAsync();
            }
        }

        private static async Task BasicDataOperationsAsync(CloudTable table, List<ProductEntity> productEntity)
        {
            // Create an instance of a customer entity. See the Model\CustomerEntity.cs for a description of the entity.

            AzureTableDataAccess.InsertOrMergeEntityAsync(table, productEntity);

    
    
        }
    }
}
