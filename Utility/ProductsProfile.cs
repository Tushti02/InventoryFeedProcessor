using AutoMapper;
using InventoryFeedProcessor.Models;
using InventoryFeedProcessor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFeedProcessor
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, SoftwareAdviceProduct>();
            CreateMap<SoftwareAdviceProduct, Product>();

            CreateMap<SoftwareAdviceProducts, List<Product>>().ConvertUsing<SoftwareAdviceProductsMapper>();

            CreateMap<Product, CapterraProduct>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Twitter, act => act.MapFrom(src => src.TwitterHandle))
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => String.Join(" ", src.Categories.ToArray())));

            CreateMap<CapterraProduct, Product>()
                 .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Name))
                 .ForMember(dest => dest.TwitterHandle, act => act.MapFrom(src => src.Twitter))
                .ForMember(dest => dest.Categories, act => act.MapFrom(src => src.Tags.SplitBySring(",").ToList()));

        }


    }
    public class SoftwareAdviceProductsMapper : ITypeConverter<SoftwareAdviceProducts, List<Product>>
    {
        public List<Product> Convert(SoftwareAdviceProducts source, List<Product> destination, ResolutionContext context)
        {
            return context.Mapper.Map<List<Product>>(source.Products);
        }
    }

}