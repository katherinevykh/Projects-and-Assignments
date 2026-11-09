using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryID { get; set; } //Identity
        [Required]
        public required string Name { get; set; }
    }
}