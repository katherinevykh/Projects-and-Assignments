namespace CapstoneProject.Models
{
    public class TransactionLineItemDTO
    {
        public int transactionID { get; set; }

        public int itemID { get; set; }

        public int quantity { get; set; }

        public bool isRG { get; set; }

        public bool isPAL { get; set; }
    }
}
