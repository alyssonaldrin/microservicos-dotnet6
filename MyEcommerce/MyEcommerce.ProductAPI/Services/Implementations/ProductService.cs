using AutoMapper;
using MyEcommerce.ProductAPI.DTOs;
using MyEcommerce.ProductAPI.DTOs.Requests;
using MyEcommerce.ProductAPI.DTOs.Responses;
using MyEcommerce.ProductAPI.Exceptions;
using MyEcommerce.ProductAPI.Mappers;
using MyEcommerce.ProductAPI.Model;
using MyEcommerce.ProductAPI.Repository;

namespace MyEcommerce.ProductAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task RegisterProduct(RegisterProductRequest registerProductRequest)
        {
            var product = _mapper.Map<Product>(registerProductRequest);

            await _productRepository.RegisterProduct(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetProductById(id);

            ValidateProductExistence(product);

            product!.DeleteProduct();

            await _productRepository.EditProduct(product);
        }

        public async Task<ListAllProductsResponse> ListAllProducts()
        {
            var products = await _productRepository.ListAllProducts();

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return productDTOs.Map();
        }

        public async Task<GetProductByIdResponse> GetProductById(Guid id)
        {
            var product = await _productRepository.GetProductById(id);

            ValidateProductExistence(product);

            return _mapper.Map<GetProductByIdResponse>(product);
        }

        public async Task EditProduct(EditProductRequest editProductRequest)
        {
            var product = await _productRepository.GetProductById(editProductRequest.Id);

            ValidateProductExistence(product);

            product!.EditProduct(editProductRequest);

            await _productRepository.EditProduct(product);
        }

        private void ValidateProductExistence(Product? product)
        {
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
