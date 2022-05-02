using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class Country
    {
        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
