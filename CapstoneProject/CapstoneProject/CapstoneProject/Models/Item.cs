using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; } //Identity
        [Required]
        public required int SubcategoryID { get; set; }
        [Required]
        [DisplayName("UPC")]
        public required string UUID { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required int Quantity { get; set; }


        [ForeignKey("SubcategoryID")]
        public ItemSubcategory? ItemSubcategory { get; set; }

        [Required]

        public required int PointCost { get; set; }
    }
}
