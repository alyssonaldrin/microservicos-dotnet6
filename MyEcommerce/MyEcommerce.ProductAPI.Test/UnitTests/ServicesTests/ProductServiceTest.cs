using AutoMapper;
using Moq;
using MyEcommerce.ProductAPI.Application.Config;
using MyEcommerce.ProductAPI.Application.DTOs;
using MyEcommerce.ProductAPI.Application.DTOs.Requests;
using MyEcommerce.ProductAPI.Application.DTOs.Responses;
using MyEcommerce.ProductAPI.Application.Exceptions;
using MyEcommerce.ProductAPI.Application.Models;
using MyEcommerce.ProductAPI.Application.RepositoryAbstractions;
using MyEcommerce.ProductAPI.Application.Services;
using MyEcommerce.ProductAPI.Application.ServicesAbstractions;
using Newtonsoft.Json;

namespace MyEcommerce.ProductAPI.Test.UnitTests.ServicesTests
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _mapper = MappingConfig.RegisterMaps().CreateMapper();
            _productService = new ProductService(_productRepository.Object, _mapper);
        }

        [Fact]
        public async Task GivenIdToGetProduct_WhenProductExistsInDatabase_ThenReturnProduct()
        {
            //Arrange
            var product = new Product
            (
                "Camiseta No Internet",
                new decimal(69.9),
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                "T-shirt",
                "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            );

            var expectedResponse = new GetProductByIdResponse
            {
                Id = product.Id,
                Name = "Camiseta No Internet",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync(product);
            var getProductByIdResponse = await _productService.GetProductById(product.Id);

            //Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(getProductByIdResponse));
        }

        [Fact]
        public async Task GivenIdToGetProduct_WhenProductNotExistsInDatabase_ThenThrowsProductNotFoundException()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync((Product)null);

            //Assert
            await Assert.ThrowsAsync<ProductNotFoundException>(() => _productService.GetProductById(id));
        }

        [Fact]
        public async Task GivenIdToDeleteProduct_WhenProductExistsInDatabase_ThenReturnsVoid()
        {
            //Arrange
            var product = new Product
            (
                "Camiseta No Internet",
                new decimal(69.9),
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                "T-shirt",
                "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            );

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync(product);
            await _productService.DeleteProduct(product.Id);

            //Assert
            Assert.True(product.IsDeleted);
        }

        [Fact]
        public async Task GivenIdToDeleteProduct_WhenProductNotExistsInDatabase_ThenThrowsProductNotFoundException()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync((Product)null);

            //Assert
            await Assert.ThrowsAsync<ProductNotFoundException>(() => _productService.DeleteProduct(id));
        }

        [Fact]
        public async Task GivenVoid_WhenProductsExistInDatabase_ThenReturnProducts()
        {
            //Arrange
            var products = new List<Product>()
            {
                new Product("Camiseta No Internet",
                            new decimal(69.9),
                            "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                            "T-shirt",
                            "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true")
            };

            var expectedResponse = new ListAllProductsResponse
            {
                Products = new List<ProductDTO>
                {
                    new ProductDTO
                    {
                        Id = products[0].Id,
                        Name = "Camiseta No Internet",
                        Price = new decimal(69.9),
                        Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                        CategoryName = "T-shirt",
                        ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
                    }
                }
            };

            //Act
            _productRepository.Setup(x => x.ListAllProducts()).ReturnsAsync(products);
            var listAllProductsResponse = await _productService.ListAllProducts();

            //Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(listAllProductsResponse));
        }

        [Fact]
        public async Task GivenVoid_WhenProductsNotExistInDatabase_ThenReturnEmpty()
        {
            //Arrange
            var expectedResponse = new ListAllProductsResponse
            {
                Products = new List<ProductDTO>()
            };

            //Act
            _productRepository.Setup(x => x.ListAllProducts()).ReturnsAsync(new List<Product>());
            var listAllProductsResponse = await _productService.ListAllProducts();

            //Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(listAllProductsResponse));
        }

        [Fact]
        public async Task GivenProductToRegister_WhenValid_ThenReturnsVoid()
        {
            //Arrange
            var registerProductRequest = new RegisterProductRequest
            {
                Name = "Camiseta No Internet",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            //Act
            _productRepository.Setup(x => x.RegisterProduct(It.IsAny<Product>())).Verifiable();
            var ex = await Record.ExceptionAsync(() => _productService.RegisterProduct(registerProductRequest));

            //Assert
            Assert.Null(ex);
        }

        [Fact]
        public async Task GivenProductToRegister_WhenNotValid_ThenThrowsProductRequestException()
        {
            //Arrange
            var registerProductRequest = new RegisterProductRequest
            {
                Name = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            //Act
            var ex = await Record.ExceptionAsync(() => _productService.RegisterProduct(registerProductRequest));

            //Assert
            Assert.Equal("Name can only have 256 characters.", ex.Message);
        }

        [Fact]
        public async Task GivenProductToEdit_WhenValid_ThenReturnsVoid()
        {
            //Arrange
            var editProductRequest = new EditProductRequest
            {
                Id = Guid.NewGuid(),
                Name = "Camiseta No Internet!",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            var product = new Product("Camiseta No Internet!",
                new decimal(69.9),
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                "T-shirt",
                "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            );

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync(product);
            _productRepository.Setup(x => x.EditProduct(It.IsAny<Product>())).Verifiable();
            var ex = await Record.ExceptionAsync(() => _productService.EditProduct(editProductRequest));

            //Assert
            Assert.Null(ex);
        }

        [Fact]
        public async Task GivenProductToEdit_WhenNotValid_ThenThrowsProductRequestException()
        {
            //Arrange
            var editProductRequest = new EditProductRequest
            {
                Id = Guid.NewGuid(),
                Name = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            //Act
            var ex = await Record.ExceptionAsync(() => _productService.EditProduct(editProductRequest));

            //Assert
            Assert.Equal("Name can only have 256 characters.", ex.Message);
        }

        [Fact]
        public async Task GivenProductToEdit_WhenProductNotExistsInDatabase_ThenThrowsProductNotFoundException()
        {
            //Arrange
            var editProductRequest = new EditProductRequest
            {
                Id = Guid.NewGuid(),
                Name = "Camiseta No Internet!",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryName = "T-shirt",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
            };

            //Act
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>())).ReturnsAsync((Product)null);

            //Assert
            await Assert.ThrowsAsync<ProductNotFoundException>(() => _productService.EditProduct(editProductRequest));
        }
    }
}