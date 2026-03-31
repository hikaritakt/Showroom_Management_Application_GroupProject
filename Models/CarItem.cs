namespace ShowroomApp.Models
{
    internal class CarItem
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int? ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public int? ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public int? StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}