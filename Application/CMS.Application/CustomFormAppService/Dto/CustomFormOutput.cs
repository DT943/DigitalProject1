using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.CustomFormAppService.Dto
{
    public class CustomFormGetDto
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Services { get; set; }

        public DateTime LastSubmissionDate { get; set; }

    }

    public class EmailValidationResult
    {
        public double QualityScore { get; set; }
        public string Deliverability { get; set; }
    }

}
