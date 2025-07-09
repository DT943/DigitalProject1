using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.ReservationInfo.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.Reservation
{
    public interface IReservationAppService : IBaseAppService<ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>
    {
    }


}
