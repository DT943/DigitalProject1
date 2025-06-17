using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class JobPost : ApproveEntityWithAuditWithFakeDelete
    {
        [Required]
        [MaxLength(150)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string JobType { get; set; } // Full-time, Part-time, etc.

        [MaxLength(50)]
        public string Status { get; set; } // Open, Closed, etc.

        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }

        [MaxLength(4000)]
        public string Requirements { get; set; }

        [MaxLength(4000)]
        public string Responsibilities { get; set; }

        [MaxLength(100)]
        public string EmploymentLevel { get; set; } // Entry, Mid, Senior

        public List<string> SkillsRequired { get; set; } = new();

        public string SalaryRange { get; set; }

        public string WorkingHours { get; set; }

        [EmailAddress]
        public string HRContactEmail { get; set; }
        public ICollection<Application>? Applications { get; set; } = new List<Application>();

    }
}

