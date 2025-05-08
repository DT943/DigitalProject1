using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberTravelAgentDetails : BasicEntity
    {
        public string AgentCode { get; set; }

        public DateTime BeginDate { get; set; }
    }
}
