using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class StaffRegister
    {
        [Key]
        [DisplayName("User ID")]

        [Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "ID must have 7 digits")]
        public string UserID { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    
    }
}
