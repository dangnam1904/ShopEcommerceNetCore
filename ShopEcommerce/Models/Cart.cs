using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEcommerce.Models
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        [Required]
       
        [ForeignKey(nameof(Product))]
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

    }
}
