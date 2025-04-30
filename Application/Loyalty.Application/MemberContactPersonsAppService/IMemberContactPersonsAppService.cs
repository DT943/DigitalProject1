using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;
using Sieve.Models;

namespace Loyalty.Application.MemberContactPersonsAppService
{
    public interface IMemberContactPersonsAppService : IBaseAppService<MemberContactPersonsGetAllDto, MemberContactPersonsGetDto, MemberContactPersonsCreateDto, MemberContactPersonsUpdateDto, SieveModel>
    {
    }
}
