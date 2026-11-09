using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Models
{
    [PrimaryKey(nameof(TransactionID), nameof(ItemID))]
    public class TransactionLineItem
    {
        [Key]
        [DisplayName("Transaction ID")]
        [ForeignKey("Transaction")]
        public required int TransactionID { get; set; }
        [Key]
        [DisplayName("Item ID")]
        [ForeignKey("Item")]
        public required int ItemID { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Donated By RG")]
        public bool IsRG { get; set; }

        [Required]
        [DisplayName("Donated By PAL")]
        public bool IsPAL { get; set; }

        //public Transaction Transaction { get; set; }

        public Item Item { get; set; }
    }
}
