using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberPreferenceDetailsAppService.Dto
{
    public class MemberPreferenceDetailsCreateDto : IValidatableDto
    {
        public string Level { get; set; }
    }

    public class MemberPreferenceDetailsUpdateDto : IEntityUpdateDto
    {
        public string Level { get; set; }
    }
}
