using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        
        public Cart Cart { get; set; } // IoC kaydý yapýlacak

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        
        public string ReturnUrl { get; set; } = "/";

        //OnGet ile sayfa sunucudan talep edildiði zaman kullanýcýya ne dönülecekse burada tanýmlanýr
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            // Veritabaný ile ilgili iþlemler için servicemanager kullanýlmaktadýr.
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
