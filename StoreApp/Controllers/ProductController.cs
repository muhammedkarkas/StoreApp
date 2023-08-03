using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            //var context = new RepositoryContext(
            //    new DbContextOptionsBuilder<RepositoryContext>()
            //    .UseSqlite("Data Source = C:\\MVC\\ProductDb.db")
            //    .Options
            //    );

            var model = _context.Products.ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        {
            Product product = _context.Products.First(x => x.ProductId.Equals(id));
            return View(product);
        }
    }
}
