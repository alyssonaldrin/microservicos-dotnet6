using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.Model;

namespace MyEcommerce.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Create(Product product);
        Task<ProductDTO> Update(Product product);
        Task<bool> Delete(long id);
    }
}
