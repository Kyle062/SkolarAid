using System;

namespace SkolarAid.Models
{
    public class ComplianceRecord
    {
        public int Id { get; set; }
        public int ScholarId { get; set; }
        public string RequirementType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string Status { get; set; } // Pending, Submitted, Approved, Rejected, Overdue
        public string Remarks { get; set; }
        public int? CheckedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Scholar Scholar { get; set; }
        public User Checker { get; set; }
    }
}