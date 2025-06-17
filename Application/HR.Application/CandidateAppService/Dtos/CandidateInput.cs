using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace HR.Application.CandidateAppService.Dtos
{
    public class CandidateCreateDto : IValidatableDto
    {
        public string CVUrlName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string Summary { get; set; }

        public List<string> Skills { get; set; } = new();
        public List<ExperienceItemDto> Experience { get; set; } = new();
        public List<EducationItemDto> Education { get; set; } = new();
        public List<string> Certifications { get; set; } = new();
        public List<string> Languages { get; set; } = new();
        public List<ProjectItemDto> Projects { get; set; } = new();

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string GitHub { get; set; }

        public string CurrentLocation { get; set; }

        [Url]
        public string PortfolioUrl { get; set; }

        public string JobAppliedFor { get; set; }
        public string CurrentJobTitle { get; set; }
        public string YearsOfExperience { get; set; }
        public string Motivation { get; set; }
        public DateTime? EarliestStartDate { get; set; }
        public string SalaryExpectation { get; set; }


    }
    public class CandidateUpdateDto : IEntityUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string Summary { get; set; }

        public List<string> Skills { get; set; } = new();
        public List<ExperienceItemDto> Experience { get; set; } = new();
        public List<EducationItemDto> Education { get; set; } = new();
        public List<string> Certifications { get; set; } = new();
        public List<string> Languages { get; set; } = new();
        public List<ProjectItemDto> Projects { get; set; } = new();

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string GitHub { get; set; }

        public string CurrentLocation { get; set; }

        [Url]
        public string PortfolioUrl { get; set; }

        public string JobAppliedFor { get; set; }
        public string CurrentJobTitle { get; set; }
        public string YearsOfExperience { get; set; }
        public string Motivation { get; set; }
        public DateTime? EarliestStartDate { get; set; }
        public string SalaryExpectation { get; set; }

    }
    public class ExperienceItemDto: IValidatableDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }

    public class EducationItemDto: IValidatableDto
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ProjectItemDto: IValidatableDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Url]
        public string Url { get; set; }
    }







    public class ExperienceItemUpdateDto: IEntityUpdateDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }

    public class EducationItemUpdateDto: IEntityUpdateDto
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ProjectItemUpdateDto: IEntityUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Url]
        public string Url { get; set; }
    }









}
