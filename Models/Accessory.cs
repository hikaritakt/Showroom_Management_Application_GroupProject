namespace ShowroomApp.Models
{
    internal class Accessory
    {
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }

        public ICollection<AccessoryInventoryTransaction> AccessoryInventoryTransactions { get; set; } = new List<AccessoryInventoryTransaction>();
        public ICollection<CarAccessory> CarAccessories { get; set; } = new List<CarAccessory>();
    }
}