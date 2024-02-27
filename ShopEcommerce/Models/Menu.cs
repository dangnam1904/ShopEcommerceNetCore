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
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
        public int MenuOrder { get; set; }
        public int Level { get; set; }
        public Page? Page { get; set; }
    }
}
