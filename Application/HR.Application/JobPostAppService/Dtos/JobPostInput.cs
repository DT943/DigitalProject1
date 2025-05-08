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
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string Status { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
    }

    public class JobPostUpdateDto : IEntityUpdateDto
    {
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string Status { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
    }
}
