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
                    new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/images/1.jpeg", ProductName = "Computer", Price = 27000 },
                    new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/2.jpeg", ProductName = "Notebook", Price = 32000 },
                    new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/3.jpeg", ProductName = "Phone", Price = 11500 },
                    new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/4.jpeg", ProductName = "Tablet", Price = 21000 },
                    new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/images/5.jpeg", ProductName = "İpad", Price = 12000 },
                    new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/6.jpeg", ProductName = "History", Price = 1700 },
                    new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/images/7.jpeg", ProductName = "Hamlet", Price = 2400 }
                    );
        }
    }
}
