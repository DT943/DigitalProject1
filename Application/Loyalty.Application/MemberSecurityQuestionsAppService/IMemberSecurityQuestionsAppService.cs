using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberSecurityQuestionsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberSecurityQuestionsAppService
{
    public interface IMemberSecurityQuestionsAppService : IBaseAppService<MemberSecurityQuestionsGetAllDto, MemberSecurityQuestionsGetDto, MemberSecurityQuestionsCreateDto, MemberSecurityQuestionsUpdateDto, SieveModel>
    {
    }
}
