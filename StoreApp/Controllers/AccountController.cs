using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);

                if(user is not null)
                {
                    //Oturum açma işlemleri
                    await _signInManager.SignOutAsync(); //açık oturum varsa sonlandırıldı

                    if((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password.");
            }
            return View();
        }
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            //Kullanıcı kaydı
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            //kullanıcı bilgilerinin database'e aktarılması
            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                //Kullanıcı role tanımı
                var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (roleResult.Succeeded)
                    return RedirectToAction("Login", new { ReturnUrl = "/"});
            }
            else
            {   
                //User eklenemezse eğer hatalara bakılacaktır. Modelstate içerisine eklenecektir.
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View();
        }
    }
}
