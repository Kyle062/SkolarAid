using System;

namespace SkolarAid.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // ADMIN or SCHOLAR
        public string Name { get; set; }
        public string AccountStatus { get; set; } // Active, Inactive, Locked
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}