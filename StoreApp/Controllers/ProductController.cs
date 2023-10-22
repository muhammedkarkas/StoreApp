using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //private readonly RepositoryContext _context;
        //IOC tarafından manager çözümlenecek ve manager içerisinde context,productrepository gibi tüm parametreler yer almaktadır.
        //private readonly IRepositoryManager _manager;
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        //public ProductController(RepositoryContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Index(ProductRequestParameters p)
        {
            //var context = new RepositoryContext(
            //    new DbContextOptionsBuilder<RepositoryContext>()
            //    .UseSqlite("Data Source = C:\\MVC\\ProductDb.db")
            //    .Options
            //    );

            //Kayıtların elde edilmesi
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }

        //FromRoute routedan geleceğinin ve parametrenin adının bilgisini verir. Endpointlerde karşılık yaşanma ihtimali yüksektir.
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            //Product product = _context.Products.First(x => x.ProductId.Equals(id));
            //return View(product);
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}
