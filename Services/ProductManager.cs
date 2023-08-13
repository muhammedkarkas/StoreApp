using AutoMapper;
using Entities.Dtos;
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
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            //Manager üzerinden producta gidildi ve ilgili product nesnesi verildi daha sonra save methodu ile değişiklikler kaydedildi.


            //Product product = new Product()
            //{
            //    ProductName = productDto.ProductName,
            //    Price = productDto.Price,
            //    CategoryId = productDto.CategoryId,
            //};

            //Product dönecek ve producta kaynaklık eden ise productdto olacaktır.
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var product = _manager.Product.GetOneProduct(id, false);

            if(product != null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);

            if(product is null)  // Null Kontrolü
            {
                throw new Exception("Product Not Found");
            }

            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            //İlgili product nesnesi elde edilecek ve productdtoforupdate türünden bir nesne istenecek.İstenilen nesneye product nesnesi kaynaklık edecek. Map bize istediğimiz türdeki nesneyi verecek.Elde edilen nesne return edilecek.
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        } 

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //Varlık veritabanından getirilmektedir ve varlık true değeri verilerek izlenmektedir.
            //var entity = _manager.Product.GetOneProduct(productDto.ProductId,true);
            //Varlığın category, name ve price değerleri değiştirilmektedir.

            /*
            entity.ProductName = productDto.ProductName;
            entity.Price = productDto.Price;
            entity.CategoryId = productDto.CategoryId;
            */

            //Mapleme işlemi yapılabilir. Örneğin map ile product verip productdto kaynak olarak gösterilirse eğer bu durumda varlık yeni bir referans alacağı için EfCore bu varlığı izlemez ve doğal olarak repo üzerinde bir update methodu çağırmamız gerekir.Manager üzerinde bir update işlemine ihtiyacımız olur.
            var entity = _mapper.Map<Product>(productDto); //Yeni referans geleceği için izleme olmaz.
            _manager.Product.UpdateOneProduct(entity);

            //varlığın izlenmesine bağlı olarak değişiklikler manager nesnesi üzerinden veritabanına kayıt edilmektedir.
            _manager.Save();
        }
    }
}
