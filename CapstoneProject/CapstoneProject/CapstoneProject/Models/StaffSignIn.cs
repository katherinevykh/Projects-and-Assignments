using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class StaffSignIn
    {
        [Key]
        [DisplayName("User ID")]
        public string UserID { get; set; }

        public string Password { get; set; }
        

    }
}
