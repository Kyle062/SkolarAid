using System;

namespace SkolarAid.Models
{
    public class ScholarshipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StipendAmount { get; set; }
        public string PaymentFrequency { get; set; } // Monthly, Quarterly, Semi-Annual, Annual
        public string Requirements { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}