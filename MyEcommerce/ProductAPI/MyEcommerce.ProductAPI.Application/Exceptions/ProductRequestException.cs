namespace MyEcommerce.ProductAPI.Application.Exceptions
{
    public class ProductRequestException : Exception
    {
        public ProductRequestException(string message) : base(message) { }
    }
}
