namespace ShowroomApp.Models
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Role { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}