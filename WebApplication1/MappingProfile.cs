using AutoMapper;
using Entities;
using Shared.Dtos;

namespace WebApplication1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForCtorParam("FullAddress",
                opt => opt.MapFrom(s => string.Join(' ', s.Address, s.Country)));
        }
    }
}
