namespace ShowroomApp.Models
{
    internal class AccessoryInventoryTransaction
    {
        public int AccessoryTransactionId { get; set; }
        public int AccessoryId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; }

        public Accessory? Accessory { get; set; }
    }
}