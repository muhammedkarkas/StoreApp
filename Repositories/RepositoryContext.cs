using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());

            //Çalışan assembly içerisindeki tip configleri otomatik olarak alınacak.Yeni bir tip kaydı yapıldığında ilgili ifade dinamik olarak çözülecektir.Ekstradan tanımlama yapmamıza gerek kalmamaktadır.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}

//Config dosyası içerisine taşındı
//modelBuilder.Entity<Product>()
//    .HasData(
//        new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 27000 },
//        new Product() { ProductId = 2, CategoryId = 2, ProductName = "Notebook", Price = 32000 },
//        new Product() { ProductId = 3, CategoryId = 2, ProductName = "Phone", Price = 11500 },
//        new Product() { ProductId = 4, CategoryId = 2, ProductName = "Tablet", Price = 21000 },
//        new Product() { ProductId = 5, CategoryId = 2, ProductName = "İpad", Price = 12000 },
//        new Product() { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 1700 },
//        new Product() { ProductId = 7, CategoryId = 1, ProductName = "Hamlet", Price = 2400 }

//    );

//modelBuilder.Entity<Category>()
//    .HasData(
//    new Category() { CategoryId = 1, CategoryName = "Book" },
//    new Category() { CategoryId = 2, CategoryName = "Electronic" });