using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService.Dto
{
    public class MemberTravelAgentDetailsGetDto  
    {
        public int Id { get; set; }
        public string AgentCode { get; set; }

        public DateTime BeginDate { get; set; }
    }


    public class MemberTravelAgentDetailsGetAllDto
    {
        public int Id { get; set; }

        public string AgentCode { get; set; }

        public DateTime BeginDate { get; set; }
    }
}
