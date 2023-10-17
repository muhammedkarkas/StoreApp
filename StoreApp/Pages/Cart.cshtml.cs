using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        
        public Cart Cart { get; set; } // IoC kaydý yapýlacak

        public CartModel(IServiceManager manager)
        {
            _manager = manager;
        } 
        
        public string ReturnUrl { get; set; } = "/";

        //OnGet ile sayfa sunucudan talep edildiði zaman kullanýcýya ne dönülecekse burada tanýmlanýr
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Session içerisinde cart nesnesi varsa onu alacak yoksa eðer yeni bir nesne üretecektir.
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            // Veritabaný ile ilgili iþlemler için servicemanager kullanýlmaktadýr.
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);

            if(product is not null)
            {
                //Cart nesnesi okundu.GetJson deserialize etti ve class verdi.Classa yeni nesne ekleniyor.SetJson ile de serialize edilerek session içerisine yazýlýyor.
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return Page(); //returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.ProductId.Equals(id)).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }

    }
}
