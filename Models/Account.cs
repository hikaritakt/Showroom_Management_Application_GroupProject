using System;

namespace ShowroomApp.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; }
        public Employee Employee { get; set; }
    }
}
