using Microsoft.EntityFrameworkCore;
using La_Mia_Pizzeria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace La_Mia_Pizzeria.Database
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PizzaModel> Pizze { get; set; }

        public DbSet<CathegoryModel> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFPizzeria;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
