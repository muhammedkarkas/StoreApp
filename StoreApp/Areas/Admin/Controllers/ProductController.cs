﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }

        //İkinci attribute formun doğrulanması için girildi.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Product product)
        {
            //Eğer model geçerli ise
            if(ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View();  
        }

        public IActionResult Update(int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if(ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
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