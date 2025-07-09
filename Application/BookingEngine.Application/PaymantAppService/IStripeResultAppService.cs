using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PaymantAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.PaymantAppService
{
    public interface IStripeResultAppService : IBaseAppService<StripeResultGetDto, StripeResultGetDto, StripeResultCreateDto, StripeResultUpdateDto, SieveModel>
    {
    }

}
