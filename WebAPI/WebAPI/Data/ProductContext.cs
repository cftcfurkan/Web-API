using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id = 1,Name = "Bilgisayar",CreatedDate = DateTime.Now.AddDays(-1),Price = 1000,Stock = 500},
                new(){Id = 2,Name = "Telefon",CreatedDate = DateTime.Now.AddDays(-2),Price = 1800,Stock = 700},
                new(){Id = 3,Name = "Klavye",CreatedDate = DateTime.Now.AddDays(-4),Price = 200,Stock = 300}
            });
        }

        public  DbSet<Product> Products { get; set; }
    }
}
