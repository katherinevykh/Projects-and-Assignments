using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Identity.Client;

namespace CapstoneProject.Models
{
    public class ResourceRequest
    {
        [Key]
        [DisplayName("Request ID")]
        public required int RequestID { get; set; }

        [Required]
        public required string UserID { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [DisplayName("Household Adults")]
        public byte HouseholdAdults { get; set; }

        [Required]
        [DisplayName("Household Underage")]
        public byte HouseholdUnderage { get; set; }

        
        [DisplayName("Stove")]
        public bool Stove { get; set; }

        
        [DisplayName("Oven")]
        public bool Oven { get; set; }

        
        [DisplayName("Microwave")]
        public bool Microwave { get; set; }

        
        [DisplayName("Can Opener")]
        public bool CanOpener { get; set; }

        
        [DisplayName("Running Water")]
        public bool RunningWater { get; set; }


        [Required]
        [DisplayName("Dietary Restrictions")]
        public required string DietaryRestrictions { get; set; }

        [Required]
        public required string Allergies { get; set; }

        
        [DisplayName("Chili")]
        public bool SoupChili { get; set; }

        
        [DisplayName("Chicken")]
        public bool SoupChicken { get; set; }

        
        [DisplayName("Tomato")]
        public bool SoupTomato { get; set; }

        
        [DisplayName("Cream")]
        public bool SoupCream { get; set; }

        
        [DisplayName("Vegetable")]
        public bool SoupVegetable { get; set; }

        
        [DisplayName("Soup-Other")]
        public bool SoupOther { get; set; }

        
        [DisplayName("Vegetable")]
        public bool RamenVegetable { get; set; }

        
        [DisplayName("Chicken")]
        public bool RamenChicken { get; set; }

        
        [DisplayName("Shrimp")]
        public bool RamenShrimp { get; set; }

        
        [DisplayName("Beef")]
        public bool RamenBeef { get; set; }

        
        [DisplayName("Pork")]
        public bool RamenPork { get; set; }

        
        [DisplayName("Other")]
        public bool RamenOther { get; set; }

        
        [DisplayName("Tuna")]
        public bool CanMeatTuna { get; set; }
        

        [DisplayName("Other")]
        public bool CanMeatOther { get; set; }

        
        [DisplayName("Vegetable Mix")]
        public bool CanVegetableMix { get; set; }

        
        [DisplayName("Peas")]
        public bool CanVegetablePeas { get; set; }

        
        [DisplayName("Green Beans")]
        public bool CanVegetableGreenBean { get; set; }

        
        [DisplayName("Corn")]
        public bool CanVegetableCorn { get; set; }

        
        [DisplayName("Tomatoes")]
        public bool CanVegetableTomato { get; set; }

        
        [DisplayName("Carrots")]
        public bool CanVegetableCarrot { get; set; }

        
        [DisplayName("Vegetables-Other")]
        public bool CanVegetableOther { get; set; }

        
        [DisplayName("Canned")]
        public bool BeanCanned { get; set; }

        
        [DisplayName("Dry")]
        public bool BeanDry { get; set; }

        
        [DisplayName("Beef")]
        public bool BoxMealBeef { get; set; }

        
        [DisplayName("Chicken")]
        public bool BoxMealChicken { get; set; }

        
        [DisplayName("Vegetarian")]
        public bool BoxMealVegetarian { get; set; }

        
        [DisplayName("Other")]
        public bool BoxMealOther { get; set; }

        
        [DisplayName("Granola Bar")]
        public bool SnackGranolaBar { get; set; }

        
        [DisplayName("Crackers")]
        public bool SnackCrackers { get; set; }

        
        [DisplayName("Chips")]
        public bool SnackChips { get; set; }

        
        [DisplayName("Other")]
        public bool SnackOther { get; set; }

        
        [DisplayName("Kids")]
        public bool CerealKids { get; set; }

        
        [DisplayName("Oatmeal")]
        public bool CerealOatmeal { get; set; }

        
        [DisplayName("Breakfast Bar")]
        public bool CerealBreakfastBar { get; set; }

        
        [DisplayName("Canned Fruit")]
        public bool OtherCannedFruit { get; set; }

        
        [DisplayName("Peanut Butter")]
        public bool OtherPeanutButter { get; set; }

        
        [DisplayName("Jelly")]
        public bool OtherJelly { get; set; }

        
        [DisplayName("Mac N' Cheese")]
        public bool OtherMacNCheese { get; set; }

        
        [DisplayName("Mashed Potatoes")]
        public bool OtherMashedPotatoe { get; set; }

        
        [DisplayName("Rice")]
        public bool OtherRice { get; set; }

        
        [DisplayName("Pasta and Sauce")]
        public bool OtherPastaAndSauce { get; set; }

        [DisplayName("Special Requests")]
        public string? SpecialRequests { get; set; }
    }
}
