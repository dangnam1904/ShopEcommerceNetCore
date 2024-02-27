using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Models
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string SloganTitle { get; set; }

        [Required]
        [StringLength(500)]
        [ValidateNever]
        public string NameImg { get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile ImageFile { get; set; }
    }
}
