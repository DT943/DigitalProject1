using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Sieve.Models;

namespace Loyalty.Application.MemberAccrualTransactions
{
    public interface IMemberAccrualTransactionsAppService : IBaseAppService<MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>
    {
    }
}
