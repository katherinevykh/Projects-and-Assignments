using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class CartList
    {
        public List<CartItemDTO> cartList { get; set; }
        public string UserID { get; set; }

        public string SpecialRequests { get; set; }
    }
}
