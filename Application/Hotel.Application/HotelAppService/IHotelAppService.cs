using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.HotelAppService
{
    public interface IHotelAppService : IBaseAppService<HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        Task<HotelGetDetailsDto> GetWithDetal(int id);
        //Task<IEnumerable<HotelGetDto>> GetAllWithContactInfo(SieveModel input);

    }
}
