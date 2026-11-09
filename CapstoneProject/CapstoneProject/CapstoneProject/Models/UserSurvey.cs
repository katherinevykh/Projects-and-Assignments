using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class UserSurvey
    {
        [Key]
        [DisplayName("Survey ID")]
        public required int SurveyID { get; set; } //Identity

        [Required]
        [DisplayName("Campus Status")]
        public required string CampusStatus { get; set; }

        [Required]
        [DisplayName("Service Use Frequency")]
        public required string FreqServices { get; set; }

        [Required]
        [DisplayName("Used Other Pantries")]
        public bool UsedOtherPantries { get; set; }

        [Required]
        [DisplayName("Not Enough Food")]
        public bool NotEnoughFood { get; set; }

        [Required]
        [DisplayName("Inadequate Food Frequency")]
        public bool FreqFoodInadequate { get; set; }

        [Required]
        [DisplayName("Pantry Preference")]
        public required string PantryPreference { get; set; }

        [Required]
        [DisplayName("Need Opinion")]
        public required string NeedOpinion { get; set; }

        [Required]
        [DisplayName("Class Year")]
        public required string UserClassYear { get; set; }

        [Required]
        [DisplayName("Turned Away-Student")]
        public bool TurnedAwayStudent { get; set; }

        [Required]
        [DisplayName("Turned Away-Money")]
        public bool TurnedAwayMoney { get; set; }

        [Required]
        [DisplayName("Turned Away-Other")]
        public bool TurnedAwayOther { get; set; }

        [Required]
        [DisplayName("Turned Away-No")]
        public bool TurnedAwayNo { get; set; }

        [Required]
        [DisplayName("Meal Otherwise Skipped")]
        public required string SkipMeal { get; set; }

        [Required]
        [DisplayName("Recieved Protein")]
        public bool RecievedProtein { get; set; }

        [Required]
        [DisplayName("Recieved Vegetables")]
        public bool RecievedVegetables { get; set; }

        [Required]
        [DisplayName("Recieved Fruit")]
        public bool RecievedFruit { get; set; }

        [Required]
        [DisplayName("Recieved Dairy")]
        public bool RecievedDairy { get; set; }

        [Required]
        [DisplayName("Recieved Grains")]
        public bool RecievedGrains { get; set; }

        [Required]
        [DisplayName("Recieved Personal Care")]
        public bool RecievedPersonalCare { get; set; }

        [Required]
        [DisplayName("Recieved Other")]
        public bool RecievedOther { get; set; }

        [Required]
        [DisplayName("Assistance Info Provided")]
        public required string AssistanceReference { get; set; }

        [Required]
        [DisplayName("Helped Allocate Funds")]
        public required string AllocateFunds { get; set; }

        [Required]
        [DisplayName("Helped Class Activities")]
        public required string ClassActivities { get; set; }

        [Required]
        [DisplayName("Helped Class Attendance")]
        public required string ClassAttendance { get; set; }

        [Required]
        [DisplayName("Helped Grades")]
        public required string UserGrades { get; set; }

        [Required]
        [DisplayName("Helped Stay Enrolled")]
        public required string UserEnrolled { get; set; }

        [Required]
        [DisplayName("Helped Job Performance")]
        public required string UserJobPerformance { get; set; }

        [Required]
        [DisplayName("Helped Stay Employed")]
        public required string UserJobEmployed { get; set; }

        [Required]
        [DisplayName("Treated with Diginity")]
        public required string UserCustService { get; set; }

        [Required]
        [DisplayName("Hours Convenience")]
        public required string UserHours { get; set; }

        [Required]
        [DisplayName("Opinions-Products")]
        public required string UserOpinionProducts { get; set; }

        [Required]
        [DisplayName("Opinions-Services")]
        public required string UserOpinionServices { get; set; }

        [Required]
        [DisplayName("Opinions-Improvements")]
        public required string UserOpinionImprove { get; set; }

        [Required]
        [DisplayName("Opinions-Comments")]
        public required string UserOpinionComments { get; set; }

    }
}
