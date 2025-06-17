using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace HR.Application.JobPostAppService.Dtos
{
    public class JobPostCreateDto : IValidatableDto
    {
        [Required]
        [MaxLength(150)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string JobType { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }

        [MaxLength(4000)]
        public string Requirements { get; set; }

        [MaxLength(4000)]
        public string Responsibilities { get; set; }

        [MaxLength(100)]
        public string EmploymentLevel { get; set; }

        public List<string> SkillsRequired { get; set; }

        public string SalaryRange { get; set; }

        public string WorkingHours { get; set; }

        [EmailAddress]
        public string HRContactEmail { get; set; }


    }

    public class JobPostUpdateDto : IEntityUpdateDto
    {

        [Required]
        [MaxLength(150)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string JobType { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }

        [MaxLength(4000)]
        public string Requirements { get; set; }

        [MaxLength(4000)]
        public string Responsibilities { get; set; }

        [MaxLength(100)]
        public string EmploymentLevel { get; set; }

        public List<string> SkillsRequired { get; set; }

        public string SalaryRange { get; set; }

        public string WorkingHours { get; set; }

        [EmailAddress]
        public string HRContactEmail { get; set; }
    }
}




