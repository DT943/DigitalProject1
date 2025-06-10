using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberTierDetailsAppService
{
    public interface IMemberTierDetailsAppService : IBaseAppService<MemberTierDetailsGetDto, MemberTierDetailsGetDto, MemberTierDetailsCreateDto, MemberTierDetailsUpdateDto, SieveModel>
    {
    }
}