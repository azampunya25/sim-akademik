using AutoMapper;
using SIMA.Universitas.Application.Features.Products.Commands.Create;
using SIMA.Universitas.Application.Features.Products.Commands.Update;
using SIMA.Universitas.Application.Features.Products.Queries.GetAllCached;
using SIMA.Universitas.Application.Features.Products.Queries.GetById;
using SIMA.Universitas.Web.Areas.Catalog.Models;

namespace SIMA.Universitas.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}