using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        //Tanımlamalar, Kullanıcı yetkilendirme gibi işlemler manager içerisinde yapılabilir.
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        IAuthService AuthService { get; }
    }
}
