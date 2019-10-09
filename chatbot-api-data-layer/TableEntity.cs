using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatbotApiDataLayer
{
    public class ProductEntity : TableEntity
    {
        public ProductEntity()
        {
        }

        public ProductEntity(string columnName, string columnValue)
        {
            ColumnName = columnName;
            ColumnValue = columnValue;
        }

        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}
