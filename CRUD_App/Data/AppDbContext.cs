using CRUD_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Country> Countrie { get; set; }
    }
}
