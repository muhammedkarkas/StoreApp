using Entities.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { ProductId = 1, ProductName = "Computer", Price = 17000 },
                    new Product() { ProductId = 2, ProductName = "Notebook", Price = 17000 },
                    new Product() { ProductId = 3, ProductName = "Phone", Price = 17000 },
                    new Product() { ProductId = 4, ProductName = "Tablet", Price = 17000 },
                    new Product() { ProductId = 5, ProductName = "İpad", Price = 17000 }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                new Category() { CategoryId = 1, CategoryName = "Book" },
                new Category() { CategoryId = 2, CategoryName = "Electronic" });
        }
    }
}