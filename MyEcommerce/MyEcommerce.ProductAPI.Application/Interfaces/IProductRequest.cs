namespace MyEcommerce.ProductAPI.Application.Interfaces
{
    internal interface IProductRequest
    {
        string Name { get; }
        decimal Price { get; }
        string Description { get; }
        string CategoryName { get; }
        string ImageURL { get; }
    }
}
