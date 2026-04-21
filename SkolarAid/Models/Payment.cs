using System;

namespace SkolarAid.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ScholarId { get; set; }
        public string PaymentPeriod { get; set; }
        public decimal Amount { get; set; }
        public DateTime ComputationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Status { get; set; } // Pending, Processed, Released, Failed
        public string PaymentMethod { get; set; } // Bank Transfer, Cash, Mobile Wallet
        public string ReferenceNumber { get; set; }
        public int? ProcessedBy { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Scholar Scholar { get; set; }
        public User Processor { get; set; }
    }
}