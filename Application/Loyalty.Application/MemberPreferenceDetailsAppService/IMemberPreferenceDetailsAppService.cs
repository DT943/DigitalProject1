using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberPreferenceDetailsAppService
{
    public interface IMemberPreferenceDetailsAppService : IBaseAppService<MemberPreferenceDetailsGetAllDto, MemberPreferenceDetailsGetDto, MemberPreferenceDetailsCreateDto, MemberPreferenceDetailsUpdateDto, SieveModel>
    {
    }
}
