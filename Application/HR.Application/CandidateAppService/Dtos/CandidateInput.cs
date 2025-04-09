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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string CurrentCompany { get; set; }
        public string Skills { get; set; }
        public string CvCode { get; set; }
        public string CvUrl { get; set; }
    }

    public class CandidateUpdateDto : IEntityUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string CurrentCompany { get; set; }
        public string Skills { get; set; }
        public string CvCode { get; set; }
        public string CvUrl { get; set; }
    }

}
