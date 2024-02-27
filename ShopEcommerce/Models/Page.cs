using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }

        [Required]
        [StringLength(2000)]
        public string TitlePage { get; set; }
        [Required]
        public string ContentPage { get; set; }
        [ForeignKey(nameof(Menu)) ]
        public int? IdMenu { get; set; }
        [ValidateNever]
        public  Menu? Menu { get; set; }
    }
}
