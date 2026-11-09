using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class Donation
    {
        [Key]
        [DisplayName("Donation ID")]
        public required int DonationID { get; set; } //Identity

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [DisplayName("First Name")]
        public required string FirstName { get; set; }

        [Required]
        [DisplayName("Middle Name")]
        public required string MidName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public required string LastName { get; set; }

        [Required]
        [Range(0, ((double)decimal.MaxValue), ErrorMessage = "Please enter a valid donation value")]
        public decimal Value { get; set; }

        [Required]
        public required string Company { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        [Range(0, (int.MaxValue), ErrorMessage = "Please enter a valid donation quantity")]
        public int Quantity { get; set; }

        [Required]
        public required string Notes { get; set; }
    }
}
