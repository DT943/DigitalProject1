using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.ReservationAppService.Dto;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace B2B.Application.ReservationAppService
{
    public interface IReservationAppService : IBaseAppService<ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>
    {

    }
}
