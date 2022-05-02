﻿using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class Adress
    {
        public enum AdressType { Billing, Delivery }

        public int AdressID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Street Adress")]
        public string StreetAdress { get; set; }
        public string City { get; set; }

        [Display(Name = "Zip code")]
        public string Zip { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }

        [Display(Name = "Adress type")]
        public AdressType Type { get; set; }
    }
}
