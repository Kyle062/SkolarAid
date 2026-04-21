using System;

namespace SkolarAid.Models
{
    public class Scholar
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string StudentId { get; set; }
        public string ScholarNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Program { get; set; }
        public string HEI { get; set; }
        public string DegreeProgram { get; set; }
        public int? ScholarshipTypeId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? ExpectedGraduation { get; set; }
        public string Status { get; set; } // Active, Inactive, Graduated, Terminated
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ScholarshipType ScholarshipType { get; set; }

        // Computed property
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ").Trim();
    }
}