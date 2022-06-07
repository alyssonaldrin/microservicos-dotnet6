using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.ProductAPI.DTOs;
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
        public async Task<ProductDTO> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if(product == null)
                {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            IEnumerable<Product> products = await _context.Products.Take(10).ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
