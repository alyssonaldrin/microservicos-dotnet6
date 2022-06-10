using MyEcommerce.ProductAPI.DTOs.Requests;
using MyEcommerce.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEcommerce.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        public Product(string name, decimal price, string description, string categoryName, string imageURL)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            CategoryName = categoryName;
            ImageURL = imageURL;
            IsDeleted = false;
        }

        [Column("name")]
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

        [Column("descrition")]
        public string Description { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("image_url")]
        public string ImageURL { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public void EditProduct(EditProductRequest editProductRequest)
        {
            Name = editProductRequest.Name;
            Price = editProductRequest.Price;
            Description = editProductRequest.Description;
            CategoryName = editProductRequest.CategoryName;
            ImageURL = editProductRequest.ImageURL;
        }

        public void DeleteProduct()
        {
            IsDeleted = true;
        }
    }
}
