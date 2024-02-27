using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required]
        [StringLength(50)]
        public string NameCategoty { get; set; }

        [ValidateNever]
        public virtual List<Product> Products { get; set; }

    }
}
