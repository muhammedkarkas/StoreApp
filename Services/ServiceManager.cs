using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;


        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, IAuthService authService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
        }

        // Constructor'dan çıkıldığı anda productservice ve categoryservice'in newlenmiş halleri elimizde olacak. Hangi nesne istenirse isteğe göre aşağıdaki gibi dönüş yapılacaktır.

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}
