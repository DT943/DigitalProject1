using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService
{
    public interface IMemberTravelAgentDetailsAppService : IBaseAppService<MemberTravelAgentDetailsGetAllDto, MemberTravelAgentDetailsGetDto, MemberTravelAgentDetailsCreateDto, MemberTravelAgentDetailsUpdateDto, SieveModel>
    {
    }
}