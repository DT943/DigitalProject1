using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.POSAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.POSAppService
{
    public interface IPOSAppService : IBaseAppService<POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>
    {
        Task<string> GetPosCode(int id);
    }
}
