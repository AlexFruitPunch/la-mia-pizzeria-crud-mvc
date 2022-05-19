using MammaMiaPizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace MammaMiaPizzaria.DataBase
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Mamma_Mia_Pizzaria;Integrated Security=True");
        }

    }
}
