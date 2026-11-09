using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class TransactionDTO
    {

        [Key]
        public required int TransactionID { get; set; } //Identity

        [ForeignKey("UserApplication")]
        public required string UserID { get; set; }

        public DateOnly Date { get; set; }
    }
}
