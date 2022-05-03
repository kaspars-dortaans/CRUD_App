using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class Adress
    {
        public enum AdressType { Billing, Delivery }

        public int AdressID { get; set; }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Street Adress")]
        [Required]
        [StringLength(100)]
        public string StreetAdress { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[A-Z0-9]*-?[A-Z0-9]*$", ErrorMessage = "Invalid zip code")]
        [StringLength(20)]
        [Display(Name = "Zip code")]
        public string Zip { get; set; }

        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public Country Country { get; set; }

        [Required]
        [Display(Name = "Adress type")]
        public AdressType Type { get; set; }
    }
}
