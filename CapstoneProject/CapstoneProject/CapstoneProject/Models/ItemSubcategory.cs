using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject.Models
{
    public class ItemSubcategory
    {
        [Key]
        public int SubcategoryID { get; set; } //Identity
        [Required]
        [ForeignKey("Category")]
        public required int CategoryID { get; set; }
        public required string Name { get; set; }

        public ItemCategory? Category { get; set; }
    }
}
