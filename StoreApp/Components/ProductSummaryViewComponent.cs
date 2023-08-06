using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        //Service katmanına kadar gitmeden direkt olarak repositorycontext üzerinden veritabanına erişim sağlandı.
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        //Service üzerinden giderken direkt olarak en sağlıklı veriye ulaşılır.En güncel olan veri elimizde olur.

        //DI çerçevesinin uygulanması


        public string Invoke()
        {
            //Veritabanı içerisindeki product sayısı elde edildi.
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
