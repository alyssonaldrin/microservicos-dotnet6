using MyEcommerce.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEcommerce.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        public double Price { get; set; }

        [Column("descrition")]
        public string Description { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}
