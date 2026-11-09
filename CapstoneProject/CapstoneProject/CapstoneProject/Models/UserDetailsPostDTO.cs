namespace CapstoneProject.Models
{
    public class UserDetailsPostDTO
    {
        public string UserID { get; set; }
        public int Points { get; set; } 
        public int MaxPoints { get; set; }
        public bool? IsStaff { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
