using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatbotAPI.Model
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string DataBaseName { get; set; }
    }
}
