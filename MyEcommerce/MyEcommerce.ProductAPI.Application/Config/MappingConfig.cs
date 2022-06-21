using AutoMapper;
using MyEcommerce.ProductAPI.Application.DTOs;
using MyEcommerce.ProductAPI.Application.DTOs.Requests;
using MyEcommerce.ProductAPI.Application.DTOs.Responses;
using MyEcommerce.ProductAPI.Application.Models;

namespace MyEcommerce.ProductAPI.Application.Config
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
