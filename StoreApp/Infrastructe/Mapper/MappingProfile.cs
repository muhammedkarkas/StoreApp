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
            CreateMap<ProductsDtoForInsertion, Product>();
        }
    }
}
