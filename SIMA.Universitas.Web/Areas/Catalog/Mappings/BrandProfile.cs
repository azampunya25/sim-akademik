using AutoMapper;
using SIMA.Universitas.Application.Features.Brands.Commands.Create;
using SIMA.Universitas.Application.Features.Brands.Commands.Update;
using SIMA.Universitas.Application.Features.Brands.Queries.GetAllCached;
using SIMA.Universitas.Application.Features.Brands.Queries.GetById;
using SIMA.Universitas.Web.Areas.Catalog.Models;

namespace SIMA.Universitas.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}