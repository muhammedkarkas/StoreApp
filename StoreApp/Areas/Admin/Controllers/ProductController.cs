using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        //DI Mekanizması
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            //Manager üzerinden tüm product verisi getirilmektedir.
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        //Categories nesnelerini her yerde tek tek metot içerisinde tanımlamak yerine direkt olarak bir metot içerisinde tanımlayıp ilgili yerler içerisinde metodu kullanmak sistemin daha yalın ve sürdürülebilir olmasına katkı sağlamaktadır.
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]     //İkinci attribute formun doğrulanması için girildi. Asenkron metot
        public async Task<IActionResult> Create([FromForm]ProductDtoForInsertion productDto, IFormFile file)  
        {
            //Eğer model geçerli ise
            if(ModelState.IsValid)
            {
                //File Operation
                //Fiziksel olarak çalışılan path tanımının yapılması gerekmektedir. Path dosyanın fiziksel olarak yolunu göstermektedir.
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                //süslü parantezden çıkınca işlemler sistem tarafından otomatik olarak kaldırılmaktadır.Sistem kaynakları serbest bırakılır.
                using (var stream = new FileStream(path, FileMode.Create)) //namespace hemen üzerinde ilgili paketler dahil edilmek için kullanılır
                {
                    //asenkron olarak bu işlem gerçekleşecek ve dosya sunucuya yüklenecek.
                    await file.CopyToAsync(stream);
                }
                //ProductDto içerisinde ImageUrl alanı set edilmektedir.
                productDto.ImageUrl = String.Concat("/images/", file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }

            return View();  
        }

        public IActionResult Update(int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductDtoForUpdate productDto, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                //File Operation
                //Fiziksel olarak çalışılan path tanımının yapılması gerekmektedir. Path dosyanın fiziksel olarak yolunu göstermektedir.
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                //süslü parantezden çıkınca işlemler sistem tarafından otomatik olarak kaldırılmaktadır.Sistem kaynakları serbest bırakılır.
                using (var stream = new FileStream(path, FileMode.Create)) //namespace hemen üzerinde ilgili paketler dahil edilmek için kullanılır
                {
                    //asenkron olarak bu işlem gerçekleşecek ve dosya sunucuya yüklenecek.
                    await file.CopyToAsync(stream);
                }
                //ProductDto içerisinde ImageUrl alanı set edilmektedir.
                productDto.ImageUrl = String.Concat("/images/", file.FileName);

                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Delete(int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
