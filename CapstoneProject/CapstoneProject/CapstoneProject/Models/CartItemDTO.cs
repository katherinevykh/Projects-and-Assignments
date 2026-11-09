using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class CartItemDTO
    {
        public Item Item { get; set; }
        public CartItemInfo Info { get; set; }

    }
}
