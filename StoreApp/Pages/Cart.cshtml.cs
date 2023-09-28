using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        
        public Cart Cart { get; set; } // IoC kayd� yap�lacak

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        
        public string ReturnUrl { get; set; } = "/";

        //OnGet ile sayfa sunucudan talep edildi�i zaman kullan�c�ya ne d�n�lecekse burada tan�mlan�r
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            // Veritaban� ile ilgili i�lemler i�in servicemanager kullan�lmaktad�r.
            Product? product = _manager.ProductService.GetOneProduct(productId,false);

            if(product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page(); //returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.ProductId == id).Product);
            return Page();
        }

    }
}
