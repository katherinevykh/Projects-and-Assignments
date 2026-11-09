namespace CapstoneProject.Models
{
    public class CategoryDTO
    {
        public ItemCategory category { get; set; }
        public List<ItemSubcategory> subcategories { get; set; }
    }
}