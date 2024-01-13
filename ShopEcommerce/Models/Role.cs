using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        [Required]
        [StringLength(50)]
        public string NameRole { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
