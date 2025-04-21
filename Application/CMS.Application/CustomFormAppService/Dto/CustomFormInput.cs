using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.CustomFormAppService.Dto
{ 
    public class CustomFormCreateDto : IValidatableDto
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Services { get; set; }
        public double Score { get; set; }

        public bool IsValid { get; set; }
    }

    public class CustomFormUpdateDto : IEntityUpdateDto
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Services { get; set; }
        public double Score { get; set; }

        public bool IsValid { get; set; }
    }
}
