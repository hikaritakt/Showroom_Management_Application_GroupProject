namespace ShowroomApp.Models
{
    internal class CarModel
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public int BrandId { get; set; }

        public Brand? Brand { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}