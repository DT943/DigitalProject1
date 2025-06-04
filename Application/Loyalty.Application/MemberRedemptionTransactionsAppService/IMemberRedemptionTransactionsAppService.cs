using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberRedemptionTransactions.Dto;
using Sieve.Models;

namespace Loyalty.Application.MemberRedemptionTransactions
{
    public interface IMemberRedemptionTransactionsAppService : IBaseAppService<MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsCreateDto, MemberRedemptionTransactionsUpdateDto, SieveModel>
    {
    }
}
