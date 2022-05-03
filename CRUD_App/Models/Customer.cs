using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class Customer
    {
        public enum GenderEnum { Male, Female }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        [Required]
        [RegularExpression("^([A-Z][a-z]*)([\\s-][A-Z][a-z]*)*", ErrorMessage = "Enter only names with leading capital letter and one whitespace in between them")]
        [Display(Name = "Full name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        
        [Required]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [Remote(action: "VarifyBirthDate", controller: "Customers", ErrorMessage = "Birth date is not valid")]
        public DateTime BirthDate { get; set; }
        public ICollection<Adress> Adresses { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }
    }
}