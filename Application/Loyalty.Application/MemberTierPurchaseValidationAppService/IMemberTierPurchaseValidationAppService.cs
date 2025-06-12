using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Loyalty.Application.MemberTierPurchaseValidationAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberTierPurchaseValidationAppService
{
    public interface IMemberTierPurchaseValidationAppService : IBaseAppService<MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationCreateDto, MemberTierPurchaseValidationUpdateDto, SieveModel>
    {
    }
}