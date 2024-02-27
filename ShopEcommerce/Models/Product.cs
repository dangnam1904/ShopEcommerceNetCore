using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [Required]
        [StringLength(600)]
        public string NameProduct { get; set; }
        [Required]
        public string? DescriptionProduct { get; set; }
        [Required]
        [StringLength (600)]
        public string? TitleProduct { get; set; }
        [Required]
        [StringLength (200)]
        public string AvatarImg { get; set; }

        [StringLength (2000)]
        public string ImageProduct {  get; set; }

        [NotMapped]
        public IFormFile fileAvatar {  get; set; }
        [NotMapped]
        public List<IFormFile> fileImageProduct { get; set; }

        [ForeignKey(nameof(Category))]
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public bool IsNew { get; set; }
        public bool IsHot { get; set; }
    }
}
