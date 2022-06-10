using AutoMapper;
using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.DTOs.Requests;
using MyEcommerce.ProductAPI.DTOs.Responses;
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
                config.CreateMap<Product, GetProductByIdResponse>();
                config.CreateMap<RegisterProductRequest, Product>();
                config.CreateMap<EditProductRequest, Product>();
            });

            return mappingconfig;
        }
    }
}
