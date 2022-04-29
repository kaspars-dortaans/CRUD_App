namespace CRUD_App.Models
{
    public class Adress
    {
        public enum AdressType { Billing, Delivery }

        public int AdressID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public AdressType Type { get; set; }
    }
}
