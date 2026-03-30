using System;

namespace ShowroomApp.Shared
{
    // Session class to hold the currently logged in user info
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; } // "Admin" or "Staff"
    }
}
