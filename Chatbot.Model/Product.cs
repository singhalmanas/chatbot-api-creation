using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatbotAPI.Model
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
    }
}
