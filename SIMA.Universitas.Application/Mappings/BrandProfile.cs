using AutoMapper;
using SIMA.Universitas.Application.Features.Brands.Commands.Create;
using SIMA.Universitas.Application.Features.Brands.Queries.GetAllCached;
using SIMA.Universitas.Application.Features.Brands.Queries.GetById;
using SIMA.Universitas.Domain.Entities.Catalog;

namespace SIMA.Universitas.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}