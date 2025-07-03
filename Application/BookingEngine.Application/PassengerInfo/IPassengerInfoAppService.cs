using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.PassengerInfo.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.PassengerInfo
{
    public interface IPassengerInfoAppService : IBaseAppService<PassengerInfoGetDto, PassengerInfoGetDto, PassengerInfoCreateDto, PassengerInfoUpdateDto, SieveModel>
    {
    }


}
