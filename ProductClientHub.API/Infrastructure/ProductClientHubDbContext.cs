using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Products> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conectionString = "Server=localhost;Port=3306;Database=teste;Uid=root;Pwd=NovaSenha";
            if (!optionsBuilder.IsConfigured)
                // Use MySQL database
            optionsBuilder.UseMySQL(conectionString);
        }
    }
}
