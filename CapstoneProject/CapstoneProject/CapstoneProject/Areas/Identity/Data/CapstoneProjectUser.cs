using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CapstoneProjectUser class
public class CapstoneProjectUser : IdentityUser
{

    //essential for all users
    [Required]
    public string StudentId { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    [Required]
    [DisplayName("First Name")]
    public required string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public required string LastName { get; set; }

    [Required]
    public required string Email { get; set; }


    //Essential for students
    [DisplayName("Date of Birth")]
    public string DOB { get; set; } = "";

    [DisplayName("Phone Number")]
    public string PhoneNum { get; set; } = "";

    [DisplayName("Is African American")]
    public bool EthAfricanAmerican { get; set; } = false;

    [DisplayName("Is Asian")]
    public bool EthAsian { get; set; } = false;

    [DisplayName("Is Caucasion")]
    public bool EthCaucasian { get; set; } = false;

    [DisplayName("Is Latino")]
    public bool EthLatino { get; set; } = false;

    [DisplayName("Is Middle Eastern")]
    public bool EthMiddleEastern { get; set; } = false;

    [DisplayName("Is Native American")]
    public bool EthNativeAmerican { get; set; } = false;

    [DisplayName("Is Pacific Islander")]
    public bool EthPacificIslander { get; set; } = false;

    [DisplayName("Is Other Ethnicity")]
    public bool EthOther { get; set; } = false;

    public string Gender { get; set; } = "";

    [DisplayName("Student Status")]
    public string StudentStatus { get; set; } = "";

    [DisplayName("Attends Spartanburg(Giles)")]
    public bool AttendsSpartanburg { get; set; } = false;

    [DisplayName("Attends Downtown(Evans)")]
    public bool AttendsDowntown { get; set; } = false;

    [DisplayName("Attends Cherokee")]
    public bool AttendsCherokee { get; set; } = false;

    [DisplayName("Attends Tyger River")]
    public bool AttendsTygerRiver { get; set; } = false;

    [DisplayName("Attends Union")]
    public bool AttendsUnion { get; set; } = false;

    [DisplayName("Household Number-Toddlers")]
    public byte HouseholdBabiesToddlers { get; set; }

    [DisplayName("Household Number-Children")]
    public byte HouseholdBabiesChildren { get; set; }

    [DisplayName("Household Number-Teens")]
    public byte HouseholdTeens { get; set; }

    [DisplayName("Household Number-Adults")]
    public byte HouseholdAdults { get; set; }

    public bool? HasTransportation { get; set; }

    public string Employed { get; set; } = "";

    [DisplayName("Employed Household Members")]
    public byte EmployedHouseMembers { get; set; }

    [DisplayName("Has SNAP")]
    public bool HasSNAP { get; set; } = false;

    [DisplayName("Has WIC")]
    public bool HasWIC { get; set; } = false;

    [DisplayName("Has TANF")]
    public bool HasTANF { get; set; } = false;

    [DisplayName("Interested-SNAP")]
    public bool IsInterestedInSNAP { get; set; } = false;

    [DisplayName("Interested-WIC")]
    public bool IsInterestedInWIC { get; set; } = false;

    [DisplayName("Interested-TANF")]
    public bool IsInterestedInTANF { get; set; } = false;

    [DisplayName("Current Points")]
    public int Points { get; set; } = 0;

    public int MaxPoints { get; set; } = 0;

    
    public bool IsRegistrationComplete { get; set; } = false;


}

