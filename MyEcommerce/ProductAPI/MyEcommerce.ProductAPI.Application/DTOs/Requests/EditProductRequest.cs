using MyEcommerce.ProductAPI.Application.Interfaces;

namespace MyEcommerce.ProductAPI.Application.DTOs.Requests
{
    public class EditProductRequest : IProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
