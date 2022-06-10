using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.DTOs.Requests;
using MyEcommerce.ProductAPI.DTOs.Responses;

namespace MyEcommerce.ProductAPI.Services
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
