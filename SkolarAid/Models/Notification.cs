using System;

namespace SkolarAid.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int? SenderId { get; set; } // NULL = system-generated
        public int RecipientId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; } // Reminder, Alert, Update, Announcement
        public DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }

        // Navigation properties
        public User Sender { get; set; }
        public Scholar Recipient { get; set; }
    }
}