using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.B2BAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace B2B.Application.B2BAppService
{
    public interface ITravelAgentOfficeAppService : IBaseAppService<TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>
    {
    }
}
