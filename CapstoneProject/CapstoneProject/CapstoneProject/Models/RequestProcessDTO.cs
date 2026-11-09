namespace CapstoneProject.Models
{
    public class RequestProcessDTO
    {
        public int TransactionID { get; set; }

        //<itemId, quantity>
        public Dictionary<int, int> Items { get; set; }

        public int AdditionalPoints { get; set; } = 0;
    }
}
