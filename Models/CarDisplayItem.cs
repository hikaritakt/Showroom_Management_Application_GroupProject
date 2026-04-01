namespace ShowroomApp.Models
{
    internal class CarDisplayItem
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}