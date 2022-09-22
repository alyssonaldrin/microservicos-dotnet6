using MyEcommerce.ProductAPI.Application.DTOs.Requests;
using MyEcommerce.ProductAPI.Application.DTOs.Responses;

namespace MyEcommerce.ProductAPI.Application.ServicesAbstractions
{
    public interface IProductService
    {
        Task<ListAllProductsResponse> ListAllProducts();
        Task<GetProductByIdResponse> GetProductById(Guid id);
        Task RegisterProduct(RegisterProductRequest registerProductRequest);
        Task EditProduct(EditProductRequest editProductRequest);
        Task DeleteProduct(Guid id);
    }
}
