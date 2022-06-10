using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.ProductAPI.Model;
using MyEcommerce.ProductAPI.Model.Context;

namespace MyEcommerce.ProductAPI.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task RegisterProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            IEnumerable<Product> products = await _context.Products.Where(p => !p.IsDeleted).ToListAsync();

            return products;
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            Product? product = await _context.Products.Where(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync();

            return product;
        }

        public async Task EditProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
