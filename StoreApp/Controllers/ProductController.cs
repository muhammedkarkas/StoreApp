using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //private readonly RepositoryContext _context;
        //IOC tarafından manager çözümlenecek ve manager içerisinde context,productrepository gibi tüm parametreler yer almaktadır.
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        //public ProductController(RepositoryContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Index()
        {
            //var context = new RepositoryContext(
            //    new DbContextOptionsBuilder<RepositoryContext>()
            //    .UseSqlite("Data Source = C:\\MVC\\ProductDb.db")
            //    .Options
            //    );

            //Kayıtların elde edilmesi
            var model = _manager.Product.GetAllProducts(false); 
            return View(model);
        }

        public IActionResult Get(int id)
        {
            //Product product = _context.Products.First(x => x.ProductId.Equals(id));
            //return View(product);
            var model = _manager.Product.GetOneProduct(id,false);
            return View(model);
        }
    }
}
