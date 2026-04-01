namespace ShowroomApp.Models
{
    internal class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int? ModelId { get; set; }
        public CarModel? CarModel { get; set; }

        public int? ColorId { get; set; }
        public Color? Color { get; set; }

        public int? StatusId { get; set; }
        public CarStatus? Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<CarInventoryTransaction> CarInventoryTransactions { get; set; } = new List<CarInventoryTransaction>();
        public ICollection<CarAccessory> CarAccessories { get; set; } = new List<CarAccessory>();
    }
}