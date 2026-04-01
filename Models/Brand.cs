namespace ShowroomApp.Models
{
    internal class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}