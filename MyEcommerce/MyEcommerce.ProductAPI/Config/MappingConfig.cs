using AutoMapper;
using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.Model;

namespace MyEcommerce.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });

            return mappingconfig;
        }
    }
}
