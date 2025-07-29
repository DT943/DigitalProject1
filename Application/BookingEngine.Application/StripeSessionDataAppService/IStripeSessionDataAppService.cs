using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.StripeSessionDataAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.StripeSessionDataAppService
{
    public interface IStripeSessionDataAppService : IBaseAppService<StripeSessionDataGetDto, StripeSessionDataGetDto, StripeSessionDataCreateDto, StripeSessionDataUpdateDto, SieveModel>
    {
    }

}
