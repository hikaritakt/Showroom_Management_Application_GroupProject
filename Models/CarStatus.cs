namespace ShowroomApp.Models
{
    internal class CarStatus
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}