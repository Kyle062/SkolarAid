using System;

namespace SkolarAid.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string ActionType { get; set; } // LOGIN, CREATE, UPDATE, DELETE, VIEW, EXPORT
        public string TableAffected { get; set; }
        public int? RecordId { get; set; }
        public string Details { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}