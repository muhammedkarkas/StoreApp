using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? "NoName";

        public void OnGet()
        {

        }

        public void OnPost([FromForm] string name) 
        {
            HttpContext.Session.SetString("names",name);
        }
        
        //HttpContext.Session dedi�imizde burda tan�mlanan metotlarda kullan�labilir olacakt�r.
        //Metotlar�n kullan�m� i�in ilgili yap� i�erisine extensionun using ifadesi olarak eklenmesi gerekmektedir.    
    }
}
