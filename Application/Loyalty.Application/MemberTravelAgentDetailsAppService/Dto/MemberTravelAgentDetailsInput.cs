using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService.Dto
{
    public class MemberTravelAgentDetailsCreateDto : IValidatableDto
    {
        public string AgentCode { get; set; }

        public DateTime BeginDate { get; set; }
    }

    public class MemberTravelAgentDetailsUpdateDto : IEntityUpdateDto
    {
        public string AgentCode { get; set; }

        public DateTime BeginDate { get; set; }
    }
}
