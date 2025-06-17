using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.JobPostAppService.Dtos
{
    public class JobPostGetDto
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string Status { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }

        public string EmploymentLevel { get; set; }
        public List<string> SkillsRequired { get; set; }
        public string SalaryRange { get; set; }
        public string WorkingHours { get; set; }
        public string HRContactEmail { get; set; }

        public string? AwaitingApprovalUserCode { get; set; }

        public string? ApprovedUserCode { get; set; }

        public string ApprovalStatus { get; set; } 

        public bool IsDeleted { get; set; } 

    }

    public class JobPostGetAllDto
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string Status { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }

        public string EmploymentLevel { get; set; }
        public List<string> SkillsRequired { get; set; }
        public string SalaryRange { get; set; }
        public string WorkingHours { get; set; }
        public string HRContactEmail { get; set; }
        public string? AwaitingApprovalUserCode { get; set; }

        public string? ApprovedUserCode { get; set; }

        public string ApprovalStatus { get; set; } 

        public bool IsDeleted { get; set; }

    }

}
