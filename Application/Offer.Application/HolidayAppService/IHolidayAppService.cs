using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Sieve.Models;

namespace Offer.Application.HolidayAppService
{
    public interface IHolidayAppService : IBaseAppService<HolidayGetDto, HolidayGetDto, HolidayCreateDto, HolidayUpdateDto, SieveModel>
    {
    }
}
