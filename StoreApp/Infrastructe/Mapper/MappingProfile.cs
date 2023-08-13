using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Kaynak ifade ile nihai olarak product elde ediyoruz.
            CreateMap<ProductDtoForInsertion, Product>();

            //Update işleminde her iki tür mapleme işlemine de gerek olmaktadır.
            CreateMap<ProductDtoForUpdate, Product>();

            //Update işleminde üründen de nesneye gitmemiz gerekmektedir.
            CreateMap<Product, ProductDtoForUpdate>();

        }
    }
}
