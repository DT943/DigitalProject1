using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class Candidate : BasicEntityWithAuditAndFakeDelete
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string CVUrlName { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        public string Summary { get; set; }

        public List<string>? Skills { get; set; } = new();

        public ICollection<ExperienceItem>? Experience { get; set; } = new List<ExperienceItem> ();

        public ICollection<EducationItem>? Education { get; set; } = new List<EducationItem>();

        public List<string>? Certifications { get; set; } = new();

        public List<string>? Languages { get; set; } = new ();

        public ICollection<ProjectItem>? Projects { get; set; } = new List<ProjectItem>();

        public ICollection<Application>? Applications { get; set; } = new List<Application>();


        [Url]
        public string? LinkedIn { get; set; }

        [Url]
        public string? GitHub { get; set; }

        [MaxLength(100)]
        public string CurrentLocation { get; set; }

        [Url]
        public string? PortfolioUrl { get; set; }

        public string JobAppliedFor { get; set; }

        public string? CurrentJobTitle { get; set; }

        public string? YearsOfExperience { get; set; }

        public string Motivation { get; set; }

        public DateTime? EarliestStartDate { get; set; }

        public string? SalaryExpectation { get; set; }
    }



}
