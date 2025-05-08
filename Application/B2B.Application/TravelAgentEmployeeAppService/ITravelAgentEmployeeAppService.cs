using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentOffice.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace B2B.Application.TravelAgentEmployeeAppService
{
    public interface ITravelAgentEmployeeAppService : IBaseAppService<TravelAgentEmployeeGetAllDto, TravelAgentEmployeeGetDto, TravelAgentEmployeeCreateDto, TravelAgentEmployeeUpdateDto, SieveModel>
    { 
    }
}
