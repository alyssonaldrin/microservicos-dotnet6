using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.DTOs.Responses;

namespace MyEcommerce.ProductAPI.Mappers
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
