using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class Liability
    {
        [Key]
        [DisplayName("User ID")]
        public required string UserID { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [DisplayName("Renewal Date")]
        public DateOnly RenewalDate { get; set; }

        [Required]
        [DisplayName("First Name")]
        public required string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public required string MidName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public required string LastName { get; set; }
    }
}
