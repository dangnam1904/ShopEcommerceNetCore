using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class Post
    {
        [Key] public int IdPost { get; set; }
        [Required]
        [StringLength(3000)]
        public string TitlePost { get; set; }
        [Required]
        public string DescriptionPost { get; set; }

        public string AvatarPost { get; set; }
        [NotMapped] public IFormFile fileAvatar { get; set;}
    }
}
