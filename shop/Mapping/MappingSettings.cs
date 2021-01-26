using AutoMapper;

using shop.DAL.Models;
using shop.Web.Resources;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Mapping
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            CreateMap<Product, ProductResources>();
            CreateMap<Color, ColorResources>();
            CreateMap<Category, CategoryResources>();
            CreateMap<Product, DiscountResources>();

            CreateMap<ProductResources, Product>();
            CreateMap<ColorResources, Color>();
            CreateMap<CategoryResources, Category>();
            CreateMap<DiscountResources, Product>();
        }
    }
}
