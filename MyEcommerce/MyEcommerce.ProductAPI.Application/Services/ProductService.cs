using AutoMapper;
using MyEcommerce.ProductAPI.Application.DTOs;
using MyEcommerce.ProductAPI.Application.DTOs.Requests;
using MyEcommerce.ProductAPI.Application.DTOs.Responses;
using MyEcommerce.ProductAPI.Application.Exceptions;
using MyEcommerce.ProductAPI.Application.Interfaces;
using MyEcommerce.ProductAPI.Application.Mappers;
using MyEcommerce.ProductAPI.Application.Models;
using MyEcommerce.ProductAPI.Application.RepositoryAbstractions;
using MyEcommerce.ProductAPI.Application.ServicesAbstractions;

namespace MyEcommerce.ProductAPI.Application.Services
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
            ValidateProductRequest(registerProductRequest);

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
            ValidateProductRequest(editProductRequest);

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

        private void ValidateProductRequest(IProductRequest productRequest)
        {
            if (productRequest.Name.Length >= 256)
            {
                throw new ProductRequestException("Name can only have 256 characters.");
            }
        }
    }
}
