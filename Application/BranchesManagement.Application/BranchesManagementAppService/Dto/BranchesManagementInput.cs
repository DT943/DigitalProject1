using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BranchesManagement.Application.BranchesManagementAppService.Dto
{
    public class BranchesManagementCreateDto : IValidatableDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string OfficeHours { get; set; }
    }


    public class BranchesManagementUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string OfficeHours { get; set; }
    }
}
