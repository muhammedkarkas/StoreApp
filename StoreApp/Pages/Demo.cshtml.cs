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
        
        //HttpContext.Session dediðimizde burda tanýmlanan metotlarda kullanýlabilir olacaktýr.
        //Metotlarýn kullanýmý için ilgili yapý içerisine extensionun using ifadesi olarak eklenmesi gerekmektedir.    
    }
}
