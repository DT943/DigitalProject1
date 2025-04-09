using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.CandidateAppService.Dtos
{
    public class CandidateGetDto
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


    public class CandidateGetAllDto
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
