using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.infraestruture
{
    public class ProductClientHubDbContext : DbContext
    {
        //atributo com nome da tabela
        public DbSet<cliente> Clients { get; set; } = default!;
        public DbSet<produto> Products { get; set; } = default!; //define q não será nulo

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\pietr\\Downloads\\Product-client-hub.octet-stream");
        }
    }
}
