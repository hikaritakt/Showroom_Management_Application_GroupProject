namespace ShowroomApp.Models
{
    internal class CarInventoryTransaction
    {
        public int TransactionId { get; set; }
        public int CarId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; }

        public Car? Car { get; set; }
    }
}