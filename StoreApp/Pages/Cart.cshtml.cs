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
        
        public Cart Cart { get; set; } // IoC kayd� yap�lacak

        public CartModel(IServiceManager manager)
        {
            _manager = manager;
        } 
        
        public string ReturnUrl { get; set; } = "/";

        //OnGet ile sayfa sunucudan talep edildi�i zaman kullan�c�ya ne d�n�lecekse burada tan�mlan�r
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Session i�erisinde cart nesnesi varsa onu alacak yoksa e�er yeni bir nesne �retecektir.
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            // Veritaban� ile ilgili i�lemler i�in servicemanager kullan�lmaktad�r.
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);

            if(product is not null)
            {
                //Cart nesnesi okundu.GetJson deserialize etti ve class verdi.Classa yeni nesne ekleniyor.SetJson ile de serialize edilerek session i�erisine yaz�l�yor.
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
