using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatbotAPI.Model
{
    public class Database
    {
        [Key]
        public int DataBaseId { get; set; }
        public string DataBaseName { get; set; }
    }
}
