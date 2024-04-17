using AutoMapper;
using SIMA.Universitas.Application.Features.Products.Commands.Create;
using SIMA.Universitas.Application.Features.Products.Queries.GetAllCached;
using SIMA.Universitas.Application.Features.Products.Queries.GetAllPaged;
using SIMA.Universitas.Application.Features.Products.Queries.GetById;
using SIMA.Universitas.Domain.Entities.Catalog;

namespace SIMA.Universitas.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}