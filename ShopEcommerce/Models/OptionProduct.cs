using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class OptionProduct
    {
        [Key]
        public int IdOption { get; set; }
        [Required]
        [StringLength(100)]
        public string NameOption { get; set; }

        [ForeignKey(nameof(GroupOption))]
        public int IdGroup { get; set; }
        public virtual GroupOption GroupOption { get; set;}

        public int Quantity { get; set; }
        public double Price { get; set; }
        public double PricePromtion { get; set; }
    }
}
