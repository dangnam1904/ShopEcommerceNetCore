using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class ProductModel
    {
        [Required]
        [Key]
        public int IdProductModel { get; set; }
        
        [Required]
        [ForeignKey(nameof(GroupOption))]
        public int IdGroupOtion { get; set; }
        public virtual GroupOption GroupOption { get; set; }

    }
}
