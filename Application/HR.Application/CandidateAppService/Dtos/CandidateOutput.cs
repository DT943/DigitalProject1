using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.CandidateAppService.Dtos
{
    public class CandidateGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Summary { get; set; }
        public bool IsDeleted { get; set; } 

        public List<string> Skills { get; set; }
        public List<ExperienceItemDto> Experience { get; set; }
        public List<EducationItemDto> Education { get; set; }
        public List<string> Certifications { get; set; }
        public List<string> Languages { get; set; }
        public List<ProjectItemDto> Projects { get; set; }

        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string CurrentLocation { get; set; }
        public string PortfolioUrl { get; set; }
        public string JobAppliedFor { get; set; }
        public string CurrentJobTitle { get; set; }
        public string YearsOfExperience { get; set; }
        public string Motivation { get; set; }
        public DateTime? EarliestStartDate { get; set; }
        public string SalaryExpectation { get; set; }
    }

    
    public class CandidateGetAllDto
    {
        public int Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobAppliedFor { get; set; }
        public string CurrentLocation { get; set; }
        public string CurrentJobTitle { get; set; }
        public string YearsOfExperience { get; set; }
        public bool IsDeleted { get; set; }


    }

}
