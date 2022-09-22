using MyEcommerce.ProductAPI.Application.Models;

namespace MyEcommerce.ProductAPI.Application.RepositoryAbstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task RegisterProduct(Product product);
        Task EditProduct(Product product);
    }
}
