using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace B2B.Application.TravelAgentApplicationAppService
{
    public interface ITravelAgentApplicationAppService : IBaseAppService<TravelAgentApplicationGetAllDto, TravelAgentApplicationGetDto, TravelAgentApplicationCreateDto, TravelAgentApplicationUpdateDto, SieveModel>
    {
        Task<TravelAgentApplicationGetDto> GetByCode(string code);

         Task<EmployeeApplicationGetDto> GetEmployeeById(int id);
    }
}
