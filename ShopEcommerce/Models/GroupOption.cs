using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class GroupOption
    {
        [Key] public int IdGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string NameGroup { get; set; }
        [ForeignKey(nameof(OptionProduct))]
        public int IdOption { get; set; }
        public virtual List<OptionProduct> OptionProducts { get; set; }

        [ForeignKey(nameof(Product))]
        public int IdProduct{ get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
