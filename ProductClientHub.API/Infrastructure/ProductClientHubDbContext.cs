using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conectionString = "Server=localhost;Port=3306;Database=teste;Uid=root;Pwd=NovaSenha";
            if (!optionsBuilder.IsConfigured)
                // Use MySQL database
            optionsBuilder.UseMySQL(conectionString);
        }
    }
}
