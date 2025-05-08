using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberEducationalDetailsAppService.Dto
{
    public class MemberEducationalDetailsCreateDto : IValidatableDto
    {
        public string EducationType { get; set; }

        public string Education { get; set; }
    }

    public class MemberEducationalDetailsUpdateDto : IEntityUpdateDto
    {
        public string EducationType { get; set; }

        public string Education { get; set; }
    }
}
