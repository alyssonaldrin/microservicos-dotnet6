using MyEcommerce.ProductAPI.Application.DTOs;
using MyEcommerce.ProductAPI.Application.DTOs.Responses;

namespace MyEcommerce.ProductAPI.Application.Mappers
{
    public static class ListAllProductsResponseMapper
    {
        public static ListAllProductsResponse Map(this IEnumerable<ProductDTO> products)
        {
            return new ListAllProductsResponse
            {
                Products = products
            };
        }
    }
}
