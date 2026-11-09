using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CapstoneProject.Models
{
    public class Transaction
    {
        [Key]
        [DisplayName("Transaction ID")]
        public int TransactionID { get; set; } //Identity

        [Required]
        [DisplayName("User ID")]
        [ForeignKey("UserApplication")]
        public required string UserID { get; set; }

        [Required]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public bool IsProcessed { get; set; } = false;

        [Required]
        public string SpecialRequests { get; set; } = "";

        [Required]
        public int AdditionalPointCost { get; set; } = 0;

        public List<TransactionLineItem> LineItems { get; set; } = new();
    }
}
