using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        // İlgili Concreate ifadeyi uygulayacak ifade edecek yapı manager classıdır.
        //Repolarda tanımlı olan özellikler kullanılmak istenecek. Bunu yaparken bir manager nesnesinden yararlanacağız.
        private readonly IRepositoryManager _repositoryManager;

        public ProductManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);

            if(product is null)  // Null Kontrolü
            {
                throw new Exception("Product Not Found");
            }

            return product;
        }
    }
}
