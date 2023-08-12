using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Eğer product için ıd alanı belirtilmemişse tanımlama bu şekilde yapılır.
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();  // Alan zorunludur.
            builder.Property(p => p.Price).IsRequired();  

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 27000 },
                    new Product() { ProductId = 2, CategoryId = 2, ProductName = "Notebook", Price = 32000 },
                    new Product() { ProductId = 3, CategoryId = 2, ProductName = "Phone", Price = 11500 },
                    new Product() { ProductId = 4, CategoryId = 2, ProductName = "Tablet", Price = 21000 },
                    new Product() { ProductId = 5, CategoryId = 2, ProductName = "İpad", Price = 12000 },
                    new Product() { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 1700 },
                    new Product() { ProductId = 7, CategoryId = 1, ProductName = "Hamlet", Price = 2400 }
                    );
        }
    }
}
