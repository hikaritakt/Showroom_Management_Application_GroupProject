namespace ShowroomApp.Models
{
    internal class InventoryDisplayItem
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
    }
}