namespace MyEcommerce.ProductAPI.Application.DTOs.Responses
{
    public class ListAllProductsResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
