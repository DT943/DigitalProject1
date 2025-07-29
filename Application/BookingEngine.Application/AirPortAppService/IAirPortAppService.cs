using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using Infrastructure.Application;
using Infrastructure.Application.BasicDto;
using Sieve.Models;

namespace BookingEngine.Application.AirPortAppService
{

    public interface IAirPortAppService: IBaseAppService<AirPortGetDto, AirPortGetDto, AirPortCreateDto, AirPortUpdateDto, SieveModel>
    {
        Task<PaginatedResult<AirPortGetDto>> GetSpecific(SieveModel input, string from);

        string GetByIataCode(string iataCode);

    }
}
