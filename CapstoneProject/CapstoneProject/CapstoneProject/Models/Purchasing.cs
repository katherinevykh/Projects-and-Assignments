using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class Purchasing
    {
        [Key]
        [DisplayName("Purchase ID")]
        public required int PurchaseID { get; set; } //Identity

        [Required]
        [DisplayName("Shop Transaction ID")]
        public required string ShopTransactionID { get; set; }

        [Required]
        [DisplayName("Store Name")]
        public required string StoreName { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public required string PaymentMethod { get; set; }

        [Required]
        [DisplayName("Total Spent")]
        public decimal TotalSpent { get; set; }
    }
}
