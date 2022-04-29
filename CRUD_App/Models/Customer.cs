using System;
using System.Collections.Generic;

namespace CRUD_App.Models
{
    public class Customer
    {
        public enum Gender { Male, Female }

        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Adress> Adresses { get; set; }
    }
}