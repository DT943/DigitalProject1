using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberEducationalDetailsAppService.Dto;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberEducationalDetailsAppService
{
    public interface IMemberEducationalDetailsAppService : IBaseAppService<MemberEducationalDetailsGetAllDto, MemberEducationalDetailsGetDto, MemberEducationalDetailsCreateDto, MemberEducationalDetailsUpdateDto, SieveModel>
    { 
    }
}
