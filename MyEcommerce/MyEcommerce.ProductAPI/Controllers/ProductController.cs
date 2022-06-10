using Microsoft.AspNetCore.Mvc;
using MyEcommerce.ProductAPI.DTOs.Requests;
using MyEcommerce.ProductAPI.DTOs.Responses;
using MyEcommerce.ProductAPI.Exceptions;
using MyEcommerce.ProductAPI.Services;
using System.Net;

namespace MyEcommerce.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListAllProductsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListAllProducts()
        {
            var product = await _productService.ListAllProducts();

            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            try
            {
                var product = await _productService.GetProductById(id);

                return Ok(product);
            }
            catch (ProductNotFoundException)
            {
                return BadRequest("There is no product for this id.");
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductRequest registerProductRequest)
        {
            await _productService.RegisterProduct(registerProductRequest);

            return Ok("Product successfully registered!");
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EditProduct([FromBody] EditProductRequest editProductRequest)
        {
            try
            {
                await _productService.EditProduct(editProductRequest);

                return Ok("Product successfully edited!");
            }
            catch (ProductNotFoundException)
            {
                return BadRequest("There is no product for this id.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                await _productService.DeleteProduct(id);

                return Ok("Product successfully deleted!");
            }
            catch (ProductNotFoundException)
            {
                return BadRequest("There is no product for this id.");
            }
        }
    }
}
