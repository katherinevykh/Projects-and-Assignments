using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject.Models
{
    public class TransactionForReport
    {
        [DisplayName("Transaction ID")]
        public int TransactionID { get; set; }
        [DisplayName("User ID")]
        public string UserID { get; set; }
        public DateOnly Date { get; set; }
        [DisplayName("Item Type")]
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        [DisplayName("Donated By RG")]
        public bool IsRG { get; set; }
        [DisplayName("Donated By PAL")]
        public bool IsPAL { get; set; }
    }
}
