using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Infrastructure.Application.BasicDto;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Loyalty.Application.MemberAccrualTransactions
{
    public interface IMemberAccrualTransactionsAppService : IBaseAppService<MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>
    {
        Task<PaginatedResult<MemberAccrualTransactionsGetDto>> MemberAccrualTransactionsDetails(SieveModel _sieveModel);


        Task<MemberAccrualTransactionsGetDto> CreateFlightTransactionDetails(MemberAccrualTransactionsCreateDto create);

        Task<MemberAccrualTransactionsGetDto> CreatePaymentTransactionDetails(PaymentDetails create);
    }
}
