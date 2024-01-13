using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Models
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }
        [Required]
        [StringLength(50)]

        public string NameMenu { get; set; }
        [Required]
        [StringLength(50)]
        public string LinkMenu{ get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
        public int IsChildren { get; set; }

    }
}
