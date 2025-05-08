using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberHobbiesDetailsAppService
{
    public interface IMemberHobbiesDetailsAppService : IBaseAppService<MemberHobbiesDetailsGetAllDto, MemberHobbiesDetailsGetDto, MemberHobbiesDetailsCreateDto, MemberHobbiesDetailsUpdateDto, SieveModel>
    {
    }
}

