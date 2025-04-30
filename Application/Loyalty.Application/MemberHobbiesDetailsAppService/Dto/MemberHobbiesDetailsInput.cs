using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberHobbiesDetailsAppService.Dto
{
    public class MemberHobbiesDetailsCreateDto : IValidatableDto
    {
        public string HobbyName { get; set; }
    }

    public class MemberHobbiesDetailsUpdateDto : IEntityUpdateDto
    {
        public string HobbyName { get; set; }
    }
}
