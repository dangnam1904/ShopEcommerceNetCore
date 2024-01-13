using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ShopEcommerce.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
       
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
       
        [Required]
        [StringLength(50)]
        public string FullName {  get; set; }

        [StringLength(150)]
        
        public string? Email { get; set; }
        [Required]
        [StringLength(150)]
        public string Password { get; set; }
        [StringLength(50)]
        public string? NumberPhone { get; set; }
        public string? Address { get; set; }

        [ForeignKey(nameof(Role))]
        public int IdRole { get; set; }
        public virtual Role Role { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
