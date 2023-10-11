using AutoMapper;
using FlavorWorld.Application.Features.Commands.Products.CreateProduct;
using FlavorWorld.Application.Features.Commands.Products.DeleteProduct;
using FlavorWorld.Application.Features.Commands.Products.UpdateProduct;
using FlavorWorld.Application.Features.Query.Products.CreateProduct;
using FlavorWorld.Application.Features.Query.Products.GetProduct;
using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;

namespace FlavorWorld.Application.Common.Mappings;

public class ProductMappingConfig : Profile
{
    public ProductMappingConfig()
    {
        CreateMap<Product, CreateProductCommand>()
            .ForMember(dest => dest.ProductReviewsCommand, opt => opt.MapFrom(src => src.ProductReview));
        CreateMap<ProductReview, ProductReviewCommand>().ReverseMap();

        CreateMap<CreateProductCommandDto, CreateProductCommand>().ReverseMap();
        CreateMap<ProductReviewCommandDto, ProductReviewCommand>().ReverseMap();

        CreateMap<DeleteProductCommandDto, DeleteProductCommand>().ReverseMap();

        CreateMap<UpdateProductCommandDto, UpdateProductCommand>().ReverseMap();

        CreateMap<GetProductQueryDto, GetProductQuery>().ReverseMap();

        CreateMap<GetProductQueryDto, GetProductWithReviewsQuery>().ReverseMap();
    }
}