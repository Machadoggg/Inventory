using AutoMapper;
using Inventory.Domain.Entities;
using Inventory.Application.DTOs;

namespace Inventory.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
