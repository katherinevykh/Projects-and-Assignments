using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneProject.Models
{
    public class CartItemInfo
    {
        public int QuantityReq { get; set; }
        public bool IsRG { get; set; }
        public bool IsPal { get; set; }
    }
}
