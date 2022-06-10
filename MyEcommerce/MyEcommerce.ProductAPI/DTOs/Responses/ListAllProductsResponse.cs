namespace MyEcommerce.ProductAPI.DTOs.Responses
{
    public class ListAllProductsResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
