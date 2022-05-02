using CRUD_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_App.ViewModels.Customer
{
    public class CustomerIndexViewModel
    {
        public enum GenderEnum { Male, Female }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public string Email { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Adress> Adresses { get; set; }
        public GenderEnum Gender { get; set; }
        [Display(Name = "Delivery adresses")]
        public int DeliveryAdressesCount { get; set; }
    }
}
