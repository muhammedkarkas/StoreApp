﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Index()
        {
            //var context = new RepositoryContext(
            //    new DbContextOptionsBuilder<RepositoryContext>()
            //    .UseSqlite("Data Source = C:\\MVC\\ProductDb.db")
            //    .Options
            //    );
            return _context.Products;
        }
    }
}
