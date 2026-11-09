using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace CapstoneProject.Models
{
    public class UserApplication
    {
        [Key]
        [DisplayName("User ID")]
        public required string UserID { get; set; }

        // I have added 2 new Properties
        // Current Point Property
        [Required]
        [DisplayName("Current Points")]
        public int Points { get; set; }

        // 2nd
        // The Max Points can be changed to a certain number or unlimited
        public int MaxPoints { get; set; } = 1000;

        [Required]
        [DisplayName("First Name")]
        public required string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public required string LastName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public required string DOB { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public required string PhoneNum { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [DisplayName("Is African American")]
        public bool EthAfricanAmerican { get; set; }

        [Required]
        [DisplayName("Is Asian")]
        public bool EthAsian { get; set; }

        [Required]
        [DisplayName("Is Caucasion")]
        public bool EthCaucasian { get; set; }

        [Required]
        [DisplayName("Is Latino")]
        public bool EthLatino { get; set; }

        [Required]
        [DisplayName("Is Middle Eastern")]
        public bool EthMiddleEastern { get; set; }

        [Required]
        [DisplayName("Is Native American")]
        public bool EthNativeAmerican { get; set; }

        [Required]
        [DisplayName("Is Pacific Islander")]
        public bool EthPacificIslander { get; set; }

        [Required]
        [DisplayName("Is Other Ethnicity")]
        public bool EthOther { get; set; }

        [Required]
        public required string Gender { get; set; }

        [Required]
        [DisplayName("Student Status")]
        public required string StudentStatus { get; set; }

        [Required]
        [DisplayName("Attends Spartanburg(Giles)")]
        public bool AttendsSpartanburg { get; set; }

        [Required]
        [DisplayName("Attends Downtown(Evans)")]
        public bool AttendsDowntown { get; set; }

        [Required]
        [DisplayName("Attends Cherokee")]
        public bool AttendsCherokee { get; set; }

        [Required]
        [DisplayName("Attends Tyger River")]
        public bool AttendsTygerRiver { get; set; }

        [Required]
        [DisplayName("Attends Union")]
        public bool AttendsUnion { get; set; }

        [Required]
        [DisplayName("Household Number-Toddlers")]
        public byte HouseholdBabiesToddlers { get; set; }

        [Required]
        [DisplayName("Household Number-Children")]
        public byte HouseholdBabiesChildren { get; set; }

        [Required]
        [DisplayName("Household Number-Teens")]
        public byte HouseholdTeens { get; set; }

        [Required]
        [DisplayName("Household Number-Adults")]
        public byte HouseholdAdults { get; set; }

        [Required]
        public bool Transportation { get; set; }


        [Required]
        public required string Employed { get; set; }

        [Required]
        [DisplayName("Employed Household Members")]
        public byte EmployedHouseMembers { get; set; }

        [Required]
        [DisplayName("Has SNAP")]
        public bool HasSNAP { get; set; }

        [Required]
        [DisplayName("Has WIC")]
        public bool HasWIC { get; set; }

        [Required]
        [DisplayName("Has TANF")]
        public bool HasTANF { get; set; }

        [Required]
        [DisplayName("Interested-SNAP")]
        public bool InterestedSNAP { get; set; }

        [Required]
        [DisplayName("Interested-WIC")]
        public bool InterestedWIC { get; set; }

        [Required]
        [DisplayName("Interested-TANF")]
        public bool InterestedTANF { get; set; }
    }
}
