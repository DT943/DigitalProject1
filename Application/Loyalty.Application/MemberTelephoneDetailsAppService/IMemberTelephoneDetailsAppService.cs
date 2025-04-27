using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberTelephoneDetailsAppService
{
    public interface IMemberTelephoneDetailsAppService : IBaseAppService<MemberTelephoneDetailsGetAllDto, MemberTelephoneDetailsGetDto, MemberTelephoneDetailsCreateDto, MemberTelephoneDetailsUpdateDto, SieveModel>
    {
    }
}