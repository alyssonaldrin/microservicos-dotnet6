﻿namespace MyEcommerce.ProductAPI.Application.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        private new const string Message = "Product not found!";
        public ProductNotFoundException() : base(Message) { }
    }
}
