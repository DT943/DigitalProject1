using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberSecurityQuestionsAppService.Dto
{
    public class MemberSecurityQuestionsCreateDto : IValidatableDto
    {
        public string Question { get; set; }

        public string Answer { get; set; }
    }

    public class MemberSecurityQuestionsUpdateDto : IEntityUpdateDto
    {
        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
