using CRUD_App.Models;
using System;
using System.Linq;

namespace CRUD_App.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //Look for any customers
            if (context.Customer.Any())
                {
                    Console.WriteLine("Return statement");
                    return;   // DB has been seeded
                }

            var Countries = new Country[]
            {
                new Country{Name="Latvia"},
                new Country{Name="Lithuania"},
                new Country{Name="Estonia"},
            };
            foreach (Country s in Countries)
            {
                context.Countrie.Add(s);
            }

            context.SaveChanges();

            var Customers = new Customer[]
            {
                new Customer{FullName="Carson Alexander",Email="example1@google.com",BirthDate=DateTime.Parse("2005-09-01")},
                new Customer{FullName="Meredith Alonso",Email="example2@google.com",BirthDate=DateTime.Parse("2003-09-01")},
                new Customer{FullName="Arturo Anand",Email="example3@google.com",BirthDate=DateTime.Parse("2002-09-01")},
            };
            foreach (Customer s in Customers)
            {
                context.Customer.Add(s);
            }

            context.SaveChanges();

            var Adresses = new Adress[]
            {
                new Adress{CustomerID=3, StreetAdress="Atbrīvošanas aleja 155-1", City="Rēzekne", Zip="LV-4000", CountryID=1, Type=Adress.AdressType.Billing},
                new Adress{CustomerID=3, StreetAdress="Atbrīvošanas aleja 155-4", City="Rēzekne", Zip="LV-4000", CountryID=1, Type=Adress.AdressType.Delivery},
                new Adress{CustomerID=1, StreetAdress="Example of street adress in Lithuania 1 (Billing)", City="CityInLithuania", Zip="LT-4000", CountryID=1, Type=Adress.AdressType.Billing},
                new Adress{CustomerID=1, StreetAdress="Example of street adress in Lithuania 1 (Delivery)", City="CityInLithuania", Zip="LT-4000", CountryID=1, Type=Adress.AdressType.Delivery},
                new Adress{CustomerID=2, StreetAdress="Example of street adress in Estonia 1 (Billing)", City="CityInEstonia", Zip="EE-4000", CountryID=1, Type=Adress.AdressType.Billing},
                new Adress{CustomerID=2, StreetAdress="Example of street adress in Estonia 1 (Delivery)", City="CityInEstonia", Zip="EE-4000", CountryID=1, Type=Adress.AdressType.Delivery},
            };
            foreach (Adress s in Adresses)
            {
                context.Adress.Add(s);
            }

            context.SaveChanges();
        }
    }
}

