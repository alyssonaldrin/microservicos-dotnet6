using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.Model;

namespace MyEcommerce.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task RegisterProduct(Product product);
        Task EditProduct(Product product);
    }
}
